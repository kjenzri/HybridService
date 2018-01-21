using Microsoft.Practices.Unity;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace HybridService.Wcf.Unity
{
    internal class UnityInstanceProvider : IInstanceProvider
    {
        private readonly IUnityContainer _unityContainer;
        private readonly Type _serviceType;

        public UnityInstanceProvider(IUnityContainer unityContainer, Type serviceType)
        {
            _unityContainer = unityContainer;
            _serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return _unityContainer.Resolve(_serviceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            _unityContainer.Teardown(instance);
        }
    }
}