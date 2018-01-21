using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HybridService.Wcf;

namespace $safeprojectname$
{
    class Program
    {
        static void Main(string[] args)
        {
            new HybridServiceWcf(new Type[] { typeof(Service1) }).Run(args);
        }
    }
}
