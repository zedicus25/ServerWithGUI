using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static TcpClient client = new TcpClient();
        static NetworkStream stream = null;
        static bool canWrite = true;

        static void Main(string[] args)
        {
            const int PORT = 8008;
            const string HOST = "127.0.0.1";


            Console.Write("Enter name:\t");
            string userName = Console.ReadLine();

            Console.Title = userName;

            try
            {
                client.Connect(HOST, PORT);
                stream = client.GetStream();

                byte[] buffer = Encoding.Unicode.GetBytes(userName);
                stream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(1000);
                Thread receiveMsgThread = new Thread(ReceiveMsg);
                receiveMsgThread.IsBackground = true;
                receiveMsgThread.Start();
                Console.WriteLine($"Welcome, {userName}");
                SendMsg();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Disconnect();
            }
            Console.ReadKey();
        }

        private static void SendMsg()
        {
            Console.Write("Enter msg:\t");
            while (canWrite)
            {
                string msg = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(msg);
                stream.Write(data, 0, data.Length);
            }
        }

        static void ReceiveMsg()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[256];
                    StringBuilder builder = new StringBuilder();
                    int byteCount = 0;
                    do
                    {
                        byteCount = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, byteCount));
                    } while (stream.DataAvailable);


                    if (builder.ToString().Contains("Server:"))
                        Console.ForegroundColor = ConsoleColor.Green;

                    if (builder.ToString().Equals(String.Empty))
                    {
                        Console.WriteLine("Enter any button to close");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    }
                    Console.WriteLine(builder.ToString());
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Disconnect();
                    Environment.Exit(0);
                }
            }
        }

        static void Disconnect()
        {
            stream.Close();
            client.Close();
        }
    }
}
