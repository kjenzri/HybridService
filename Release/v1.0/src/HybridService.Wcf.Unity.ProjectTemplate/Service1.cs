using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class Service1 : IService1
    {
        private readonly IServiceDependency _serviceDependency;

        public Service1(IServiceDependency serviceDependency)
        {
            _serviceDependency = serviceDependency;
        }

        public void Method1()
        {
            throw new NotImplementedException();
        }
    }
}
