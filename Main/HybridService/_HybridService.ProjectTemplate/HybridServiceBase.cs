using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HybridService.Core
{
    public abstract class HybridServiceBase : ServiceBase
    {
        public void Run(params string[] args)
        {
            if (Environment.UserInteractive)
            {
                OnStart(args);

                Console.Read();

                OnStop();
            }
            else
            {
                Run(this);
            }
        }
    }
}
