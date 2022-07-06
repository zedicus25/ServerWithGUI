using ClientServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    internal class CServer
    {
        private MyServer server;
        private Thread serverThread;
        private Thread bannedThread;
        public List<MyClient> Clients => server.GetClients();
        public bool IsEnable { get; private set; }
        public CServer()
        {
            server = new MyServer();
        }

        public void ServerStart()
        {
            try
            {
                serverThread = new Thread(new ThreadStart(server.Listen));
                serverThread.Start();
                serverThread.IsBackground = true;

                bannedThread = new Thread(new ThreadStart(BaningUsers));
                bannedThread.Start();
                bannedThread.IsBackground = true;
                IsEnable = true;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                server.CloseServer();
                serverThread.Abort();
                bannedThread.Abort();
            }
        }

        public void StopServer()
        {
            try
            {
                server.CloseServer();
                serverThread.Abort();
                bannedThread.Abort();
                IsEnable = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                server.CloseServer();
                serverThread.Abort();
                bannedThread.Abort();
            }
        }

        private void BaningUsers()
        {
            while (true)
            {
                server.BanUsers();
                Thread.Sleep(100);
            }
        }

        public void KickUser(string id)
        {
            if(server.GetClients().Count > 0)
            {
                server.SendMessageToClient(id, "Server: You kicked from server");
                server.DeleteConnetion(id);
            }
        }

        public void UnbanUser(string name)
        {
            server.UnBanUser(name);
        }


        public void BanUser(string id)
        {
            server.BanUser(id);
        }

        public void SendMessageToUser(string id, string message)
        {
            server.SendMessageToClient(id, message);
        }
    }
}
