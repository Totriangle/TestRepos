using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Unity
{
    public class Demo
    {
        public static void Test()
        {
            /*System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            PintTest("sdfd");
            //ping.SendAsync("baidu.com",null);
            //ping.SendAsync("www.baidu.com",null);
            
            ping.PingCompleted += Ping_PingCompleted;*/
            DirectoryEntry directory = new DirectoryEntry("WinNT:");
            foreach(DirectoryEntry d in directory.Children)
            {
                Console.WriteLine(d.Name);
                foreach(DirectoryEntry d1 in d.Children)
                {
                    Console.WriteLine(d1.Name);
                }
            }
            Console.WriteLine("Finish");
        }
        static void PintTest(string host)
        {
            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                PingReply reply = ping.Send(host);
                if (reply != null)
                {
                    if (reply.Status == IPStatus.Success)
                    {
                        Console.WriteLine("Address: {0}", reply.Address);
                        Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                        Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                        Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                        Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                    }
                    else
                    {
                        Console.WriteLine(reply.Status);
                    }
                }
                else
                {
                    Console.WriteLine("could not find host {0}", host);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private static void Ping_PingCompleted(object sender, System.Net.NetworkInformation.PingCompletedEventArgs e)
        {
            Console.WriteLine("IP:{0},time:{1}ms,TTL:{2}ms",e.Reply.Address,e.Reply.RoundtripTime,e.Reply.Options==null?"NULL":e.Reply.Options.Ttl.ToString());
        }
    }
    public interface ILogger
    {
        void Write(string message);
    }
    public class TextFileLogger:ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine("Writed log to file:\t" + message);
        }
    }
    public class DatabaseLogger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine("Writed Log To Database:\t" + message);
        }
    }
}
