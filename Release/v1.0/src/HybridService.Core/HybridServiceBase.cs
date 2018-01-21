using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HybridService.Core
{
    public abstract class HybridServiceBase : ServiceBase
    {
        private static readonly TraceSource _traceSource = new TraceSource(typeof(HybridServiceBase).Name);

        public void Run(params string[] args)
        {
            if (Environment.UserInteractive)
            {                
                _traceSource.TraceInformation("Starting as Console Application");

                OnStart(args);

                _traceSource.TraceInformation("Started as Console Application");

                Console.Read();

                _traceSource.TraceInformation("Stopping application");
                
                OnStop();

                _traceSource.TraceInformation("Application stopped");
            }
            else
            {
                _traceSource.TraceInformation("Starting as Windows service");

                Run(this);

                _traceSource.TraceInformation("Started as Windows service");
            }
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            DoWork();
        }

        protected abstract void DoWork();
    }
}
