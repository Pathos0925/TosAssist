using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TosAssist
{
    class SocketHelper
    {
        public Socket worker;
        private string status;
        private bool isServer;
        private int port;
        private string ip;

        public delegate void OnConnectedDelegate();
        public event OnConnectedDelegate onConnected;
        public delegate void OnBytesReceiveDelegate(byte[] bytes);
        public event OnBytesReceiveDelegate onBytesReceived;

        public string GetStatus()
        {
            return status;
        }

        public SocketHelper(bool IsServer, string Ip, int Port)
        {
            ip = Ip;
            port = Port;
            isServer = IsServer;
            status = "Idle";

            //onConnected += OnConnected;
            //onBytesReceived += OnBytesReceived;
        }

        private void OnBytesReceived(byte[] bytes)
        {

        }

        private void OnConnected()
        {

        }

        public void Start()
        {
            status = "Starting Socket as " + (isServer ? "Server" : "Client");
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            if (isServer)
                StartServer(localEndPoint);
            else
                ConnectClient(localEndPoint);

        }

        private void StartServer(IPEndPoint endpoint)
        {
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {

                listener.Bind(endpoint);
                listener.Listen(2000);

                //listener.ReceiveBufferSize = 10000;
                //listener.SendBufferSize = 10000;

                listener.BeginAccept(
                            new AsyncCallback(AcceptCallback),
                            listener);


                status = "Waiting for connection...";
            }
            catch (Exception e)
            {

            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            status = "Accpeting Connection...";

            if (isServer)
            {
                // Get the socket that handles the client request.
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                worker = handler;

                // Create the state object.
                ReadyReceive(handler);
            }
            else
            {
                Socket client = (Socket)ar.AsyncState;
                worker = client;

                ReadyReceive(worker);

                // Complete the connection.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());
            }
            onConnected();

        }

        public void CloseConnection()
        {
            if (worker != null)
                worker.Close();
        }

        private void ReadCallback(IAsyncResult ar)
        {

            String content = String.Empty;
            status = "Reading data...";
            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            if (handler == null || !handler.Connected)
            {
                status = "Aborted!";
                if (isServer)
                {
                    handler.Close();
                    Start();
                }
                return;
            }
            try
            {
                // Check for more data
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }
            catch (Exception e)
            {
                status = "Aborted!";
                handler.Close();
                Start();
                return;
            }


            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);

            //var receivedBytes = new byte[bytesRead];
            //Buffer.BlockCopy(state.buffer, 0, receivedBytes, 0, bytesRead);
            //onBytesReceived(receivedBytes);
            
            if (bytesRead > 0)
            {
                content = Encoding.UTF8.GetString(state.buffer, 0, bytesRead);

                if (content.IndexOf(Convert.ToChar(0)) > -1)//check for end
                {
                    status = "Found 0 char, Received data of size " + bytesRead;

                    var receivedBytes = new byte[bytesRead];
                    Buffer.BlockCopy(state.buffer, 0, receivedBytes, 0, bytesRead);
                    onBytesReceived(receivedBytes);
                }
                else
                {
                    status = "No 0 char found yet. Size: " + bytesRead;
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
            
        }

        private void ReadyReceive(Socket client)
        {
            try
            {
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ConnectClient(IPEndPoint endPoint)
        {
            // Create a TCP/IP socket.
            Socket client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            client.ReceiveBufferSize = 2000;
            //client.SendBufferSize = 10000;
            // Connect to the remote endpoint.
            client.BeginConnect(endPoint,
                new AsyncCallback(AcceptCallback), client);

            status = "Connecting...";
        }

        public void SendBytes(byte[] data)
        {
            SendBytes(worker, data);
        }

        private void SendBytes(Socket handler, byte[] data)
        {
            try
            {
                status = ("Sending " + data.Length + " bytes.");
                handler.BeginSend(data, 0, data.Length, 0,
                    new AsyncCallback(SendCallback), handler);
            }
            catch (Exception e)
            {
                status = e.ToString();
            }

        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                status = ("Sent " + bytesSent.ToString() + " bytes.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public class StateObject
        {
            // Client  socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
        }

    }
}
