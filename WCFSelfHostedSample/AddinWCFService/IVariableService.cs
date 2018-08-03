using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AddinWCFService
{
    [ServiceContract(Namespace="http://Copadata.AddinSamples.WCFSamples")]
    interface IVariableService
    {
        bool StartService();
        void StopService();

        [OperationContract]
        string[] GetListOfVariableIds();

        [OperationContract]
        VariableData GetVariableData(string variableId);

        [OperationContract]
        VariableData[] GetAllVariables();
    }
}
