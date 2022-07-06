using ClientServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        private CServer server;
        public Form1()
        {
            server = new CServer();
            InitializeComponent();
            serverStatusPB.BackColor = Color.DarkRed;
            MyServer.ConnectClient += this.MyServer_ConnectClient;
            MyServer.DisconnectClient += this.MyServer_DisconnectClient;
            
        }

        private void MyServer_DisconnectClient(MyClient obj)
        {
            this.activeUsersLB.Items.Remove(obj);   
        }

        private void MyServer_ConnectClient(MyClient obj)
        {
            this.activeUsersLB.Items.Add(obj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (server.IsEnable)
                return;
            server.ServerStart();
            serverStatusPB.BackColor = Color.ForestGreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!server.IsEnable)
                return;
            server.StopServer();
            serverStatusPB.BackColor = Color.DarkRed;
        }

        private void kickBtn_Click(object sender, EventArgs e)
        {
            if(activeUsersLB.SelectedItem != null)
            {
                server.KickUser(activeUsersLB.SelectedItem.ToString());
            }
        }

        private void banBtn_Click(object sender, EventArgs e)
        {
            if (activeUsersLB.SelectedItem != null)
            {
                server.BanUser(activeUsersLB.SelectedItem.ToString());
            }
        }

        private void unBanBtn_Click(object sender, EventArgs e)
        {
            if (nameToUnbanTB.Text.Equals(String.Empty))
                return;
            server.UnbanUser(nameToUnbanTB.Text);
            nameToUnbanTB.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (messageTB.Text.Equals(String.Empty) || activeUsersLB.SelectedItem == null)
                return;
            server.SendMessageToUser(activeUsersLB.SelectedItem.ToString(), $"Server: {messageTB.Text}");
            messageTB.Text = String.Empty;
        }
    }
}
