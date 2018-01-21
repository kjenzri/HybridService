using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HybridService.Wcf.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            new HybridServiceWcf(new Type[] { typeof(ServiceExample) }).Run(args);
        }
    }
}
