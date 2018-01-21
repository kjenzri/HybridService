using HybridService.Wcf.Example.Contract;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridService.Wcf.Unity.Example
{
    public class ServiceExample : IServiceExample
    {
        private readonly ILog _log;

        public ServiceExample(ILog log)
        {
            if (log == null)
            {
                throw new ArgumentNullException("log");
            }
            _log = log;
        }

        public Guid Ping()
        {
            _log.Debug("Start Ping");
            var result = Guid.NewGuid();
            _log.DebugFormat("Ping result {0}", result);
            return result;
        }
    }
}
