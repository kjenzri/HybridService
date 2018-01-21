using log4net;
using log4net.Config;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridService.Wcf.Unity.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterInstance(LogManager.GetLogger("Application logger"));

            new HybridServiceWcfUnity(new Type[] { typeof(ServiceExample) }, unityContainer).Run(args);
        }
    }
}
