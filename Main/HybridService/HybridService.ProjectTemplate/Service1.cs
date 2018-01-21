using HybridService.Core;
using log4net;
using System;
using System.Collections.Generic;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;
using System.Timers;

namespace $safeprojectname$
{
    public class Service1 : HybridServiceBase
    {
        private static ILog Log = LogManager.GetLogger(typeof(Service1));

        private readonly Timer _timer = new Timer();

        public Service1()
        {
            _timer.Elapsed += (sender, e) => Log.Debug(DateTime.Now.ToString());
            _timer.Interval = 1000 * 3;
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            _timer.Start();
        }
    }
}
