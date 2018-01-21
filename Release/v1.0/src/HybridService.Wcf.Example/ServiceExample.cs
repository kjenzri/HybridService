using HybridService.Wcf.Example.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridService.Wcf.Example
{
    public class ServiceExample : IServiceExample
    {
        public Guid Ping()
        {
            return Guid.NewGuid();
        }
    }
}
