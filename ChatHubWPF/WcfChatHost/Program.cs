using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WcfChatServiceLibrary.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("Server is started");
                Console.ReadLine();
            }
        }
    }
}
