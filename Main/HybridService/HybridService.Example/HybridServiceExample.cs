using HybridService.Core;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace HybridService.Example
{
    public class HybridServiceExample : HybridServiceBase
    {
        private static ILog Log = LogManager.GetLogger(typeof(HybridServiceExample));

        private readonly Timer _timer = new Timer();

        public HybridServiceExample()
        {
            _timer.Elapsed += (sender, e) => Log.Debug(DateTime.Now.ToString());
            _timer.Interval = 1000 * 3;
        }

        protected override void DoWork()
        {
            _timer.Start();
        }
    }
}
