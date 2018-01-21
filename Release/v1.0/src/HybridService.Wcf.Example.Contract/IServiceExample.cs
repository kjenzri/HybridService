using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HybridService.Wcf.Example.Contract
{
    [ServiceContract]
    public interface IServiceExample
    {
        [OperationContract]
        Guid Ping();
    }
}
