using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientServer
{
    public class MyClient
    {
        public string Name { get; set; }

        private MyServer _server;

        public string Id { get; private set; }
        protected TcpClient tcpClient;
        public bool CanWrite { get; set; } = true;
        internal NetworkStream networkStream { get; set; }

        public MyClient(TcpClient tcpClient, MyServer myServer)
        {
            Id = Guid.NewGuid().ToString();
            _server = myServer;
            this.tcpClient = tcpClient;
            _server.AddConnection(this);
        }

        public void Work()
        {
            try
            {
                networkStream = tcpClient.GetStream();
                this.Name = GetMsg();

                string msg = $"{this.Name} in chat!";

                _server.BroadcastMsg(msg, this.Id);
                Console.WriteLine(msg);

                while (CanWrite)
                {
                    try
                    {
                        msg = GetMsg();
                        msg = $"{DateTime.Now.ToShortTimeString()} {Name} : {msg}";
                        _server.BroadcastMsg(msg, this.Id);
                        Console.WriteLine(msg);
                    }
                    catch (Exception ex)
                    {
                        msg = $"{this.Name} OUT OF chat!";
                        _server.BroadcastMsg(msg, this.Id);
                        Console.WriteLine(ex);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _server.DeleteConnetion(this.Id);
                Close();
            }
        }

        public string GetMsg()
        {
            byte[] data = new byte[256];
            StringBuilder  builder =    new StringBuilder();
            int byteCount = 0;
            do
            {
                byteCount = networkStream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, byteCount));
            } while (networkStream.DataAvailable);

            return builder.ToString();
        }

        public void Close()
        {
            tcpClient.Close();
            networkStream.Close();
        }

        public  string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public override string ToString()
        {
            return Id;
        }
        ~MyClient()
        {
            Close();
        }
    }
}
