using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HybridService.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new HybridServiceExample();
            service.Run(args);
        }
    }
}
