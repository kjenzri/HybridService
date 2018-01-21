using HybridService.Core;
using System;
using System.Collections.Generic;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;
using System.Timers;

namespace $safeprojectname$
{
    public class Service1 : HybridServiceBase
    {
        protected override void DoWork()
        {
            throw new NotImplementedException();
        }
    }
}
