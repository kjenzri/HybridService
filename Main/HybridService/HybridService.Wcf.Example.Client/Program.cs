using HybridService.Wcf.Example.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HybridService.Wcf.Example.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new ChannelFactory<IServiceExample>("ServiceExample").CreateChannel();

            Console.WriteLine(proxy.Ping());

            ((ICommunicationObject)proxy).Close();

            Console.Read();
        }
    }
}
