using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientServer
{
    public class MyServer
    {
        static TcpListener tcpListener;
        private List<MyClient> clients;
        readonly int PORT;
        public static event Action<MyClient> ConnectClient; 
        public static event Action<MyClient> DisconnectClient; 

        public MyServer(int port = 8008)
        {
            clients = new List<MyClient>();
            this.PORT = port;
        }

        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, PORT);
                tcpListener.Start();
                Console.WriteLine("SERVER START");
                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    MyClient myClient = new MyClient(client, this);
               
                    Thread clientThread = new Thread(new ThreadStart(myClient.Work));
                    clientThread.Name = myClient.Name;
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                CloseServer();
            }
        }

        public void BroadcastMsg(string msg, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(msg);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id != id)
                    clients[i].networkStream.Write(data, 0, data.Length);
            }
        }

        public void DeleteConnetion(string id)
        {
            MyClient client = clients.FirstOrDefault(x => x.Id.Equals(id));
            if (client != null)
            {
                clients.Remove(client);
                client.Close();
                DisconnectClient?.Invoke(client);
            }
        }

        public void AddConnection(MyClient myClient)
        {
            if (File.Exists("history.txt"))
            {
                string[] history = File.ReadAllLines("history.txt");
                bool isHas = history.Any(h => h.Equals(myClient.GetLocalIPAddress()));
                if (isHas == false)
                {
                    File.AppendAllText("history.txt", myClient.GetLocalIPAddress());
                }
            }

            clients.Add(myClient);
            ConnectClient?.Invoke(clients.Last());
        }
        public void CloseServer()
        {
            tcpListener.Stop();
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close();
            }

            Console.WriteLine("SERVER STOP");
        }

        public bool BanUsers()
        {
            if (clients.Count > 0 && File.Exists("bannedUser.txt"))
            {
                string[] bannedUsers = File.ReadAllLines("bannedUser.txt");
                List<MyClient> cls = new List<MyClient>();
                foreach (string us in bannedUsers)
                {
                    if (!us.Equals(String.Empty))
                    {
                        MyClient cl = clients.FirstOrDefault(c => c.Name.Equals(us));
                        if(cl!= null)
                            cls.Add(cl);
                    }
                }

                if (cls.Count > 0)
                {
                    for (int i = 0; i < cls.Count; i++)
                    {
                        BroadcastMsg($"{cls[i].Name} banned", cls[i].Id);
                        SendMessageToClient(cls[i].Id, "Server: You banned on server!");
                        DeleteConnetion(cls[i].Id);
                        cls[i].Close();
                        cls[i].CanWrite = false;
                        clients.Remove(cls[i]);
                    }
                    
                    return true;
                }
            }
            return false;
           
        }

        public List<MyClient> GetClients() => clients;

        public void SendMessageToClient(string id, string msg)
        {
            MyClient cl = clients.FirstOrDefault(x => x.Id.Equals(id));
            cl?.networkStream.Write(Encoding.Unicode.GetBytes(msg), 0, Encoding.Unicode.GetBytes(msg).Length);
        }

        public void BanUser(string id)
        {
            if (File.Exists("bannedUser.txt"))
            {
                MyClient cl = clients.FirstOrDefault(x => x.Id.Equals(id));
                if(cl!=null)
                    File.AppendAllText("bannedUser.txt",cl.Name);
            }
        }

        public void UnBanUser(string name)
        {
            if (File.Exists("bannedUser.txt"))
            {
                List<string> names = File.ReadAllLines("bannedUser.txt").ToList();

                if (!names.Remove(name))
                    return;
                File.WriteAllLines("bannedUser.txt", names.ToArray());
            }
        }

        ~MyServer()
        {
            CloseServer();
        }
    }
}
