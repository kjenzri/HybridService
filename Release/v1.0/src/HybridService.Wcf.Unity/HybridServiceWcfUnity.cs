using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HybridService.Wcf.Unity
{
    public class HybridServiceWcfUnity : HybridServiceWcf
    {
        private static readonly TraceSource _traceSource = new TraceSource(typeof(HybridServiceWcfUnity).Name);
        private readonly IUnityContainer _unityContainer;

        public HybridServiceWcfUnity(Type[] wcfServiceTypeArray, IUnityContainer unityContainer)
            : base(wcfServiceTypeArray)
        {
            if(unityContainer == null)
            {
                throw new ArgumentNullException("unityContainer");
            }
            _unityContainer = unityContainer;
        }

        public HybridServiceWcfUnity(Dictionary<Type, Uri[]> wcfServiceTypeAndBaseAddresses, IUnityContainer unityContainer)
            : base(wcfServiceTypeAndBaseAddresses)
        {
            if (unityContainer == null)
            {
                throw new ArgumentNullException("unityContainer");
            }
            _unityContainer = unityContainer;
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, params Uri[] baseAddresses)
        {
            var serviceHost = new ServiceHost(serviceType, baseAddresses);

            _traceSource.TraceInformation("Start adding {0} to ServiceHost of {1}", typeof(UnityServiceBehavior), serviceHost.Description.ServiceType);

            serviceHost.Description.Behaviors.Add(new UnityServiceBehavior(_unityContainer));

            _traceSource.TraceInformation("{0} added to ServiceHost of {1} with success", typeof(UnityServiceBehavior), serviceHost.Description.ServiceType);
            
            return serviceHost;
        }
    }
}
