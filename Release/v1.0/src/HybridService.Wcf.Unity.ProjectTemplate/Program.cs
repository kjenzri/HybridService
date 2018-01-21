using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HybridService.Wcf.Unity;
using Microsoft.Practices.Unity;

namespace $safeprojectname$
{
    class Program
    {
        static void Main(string[] args)
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<IServiceDependency, ServiceDependency>();
            unityContainer.RegisterType<IService1, Service1>();

            new HybridServiceWcfUnity(new Type[] { typeof(Service1) }, unityContainer).Run(args);
        }
    }
}
