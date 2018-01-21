using HybridService.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using System.Diagnostics;

namespace HybridService.Wcf
{
    public class HybridServiceWcf : HybridServiceBase
    {
        private static readonly TraceSource _traceSource = new TraceSource(typeof(HybridServiceWcf).Name);

        private readonly IReadOnlyDictionary<Type, Uri[]> _wcfServiceCollection;

        private IList<ServiceHost> _serviceHostList = new List<ServiceHost>();

        public HybridServiceWcf(Type[] wcfServiceTypeArray)
        {
            if(wcfServiceTypeArray == null || wcfServiceTypeArray.Length == 0)
            {
                throw new ArgumentNullException("wcfService");
            }
            _wcfServiceCollection = new ReadOnlyDictionary<Type, Uri[]>(wcfServiceTypeArray.ToDictionary(type => type, type => new Uri[] { }));    
        }

        public HybridServiceWcf(Dictionary<Type, Uri[]> wcfServiceAndBaseAddresses)
        {
            if (wcfServiceAndBaseAddresses == null || wcfServiceAndBaseAddresses.Count == 0)
            {
                throw new ArgumentNullException("wcfServiceAndBaseAddresses");
            }
            _wcfServiceCollection = new ReadOnlyDictionary<Type, Uri[]>(wcfServiceAndBaseAddresses);
        }

        protected override void DoWork()
        {
            foreach (var currentServiceHostType in _wcfServiceCollection)
            {
                _traceSource.TraceInformation("Start creating Wcf ServiceHost for {0}", currentServiceHostType.Key);

                ServiceHost currentWcfServiceHost = null;

                try
                {
                    currentWcfServiceHost = CreateServiceHost(currentServiceHostType.Key, currentServiceHostType.Value);
                    _serviceHostList.Add(currentWcfServiceHost);

                    _traceSource.TraceInformation("Wcf ServiceHost for {0} created with success", currentServiceHostType.Key);
                }
                catch (Exception e)
                {
                    _traceSource.TraceInformation("Exception occured while creating Wcf ServiceHost for {0}", currentServiceHostType.Key);
                    _traceSource.TraceData(TraceEventType.Error, 0, e);

                    throw;
                }
                
                try
                {
                    _traceSource.TraceInformation("Start opening Wcf ServiceHost of {0}", currentServiceHostType.Key);

                    currentWcfServiceHost.Open();

                    _traceSource.TraceInformation("Wcf ServiceHost of {0} opened with success", currentServiceHostType.Key);
                }
                catch (Exception e)
                {
                    _traceSource.TraceInformation("Exception occured while opening Wcf ServiceHost for {0}", currentServiceHostType.Key);
                    _traceSource.TraceData(TraceEventType.Error, 0, e);

                    throw;
                }
            }
        }

        protected virtual ServiceHost CreateServiceHost(Type serviceType, params Uri[] baseAddresses)
        {
            return new ServiceHost(serviceType, baseAddresses);
        }

        protected override void OnStop()
        {
            base.OnStop();

            foreach (var currentWcfServiceHost in _serviceHostList)
            {
                try
                {
                    _traceSource.TraceInformation("Start closing Wcf ServiceHost of {0}", currentWcfServiceHost.Description.ServiceType);

                    currentWcfServiceHost.Close();

                    _traceSource.TraceInformation("Wcf ServiceHost of {0} closed with success", currentWcfServiceHost.Description.ServiceType);
                }
                catch (Exception e)
                {
                    _traceSource.TraceInformation("Exception occured while closing Wcf ServiceHost for {0}", currentWcfServiceHost.Description.ServiceType);
                    _traceSource.TraceData(TraceEventType.Error, 0, e);

                    throw;
                }
            }
        }
    }
}
