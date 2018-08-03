using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace AddinWCFService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class VariableService : IVariableService
    {
        private ServiceHost _serviceHost;
        private VariableBuffer _variableBuffer;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public Uri BaseUri { get; set; }

        public VariableService(VariableBuffer variableBuffer)
        {
            // use default URI
            BaseUri = new Uri("http://localhost:8080/variable-service");
            this._variableBuffer = variableBuffer;
        }

        public bool StartService()
        {
            try
            {
                _serviceHost = new ServiceHost(this, BaseUri);

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                _serviceHost.Description.Behaviors.Add(smb);

                _serviceHost.Open();
                return true;
            }
            catch (Exception e)
            {
                _logger.Error("Exception occured during service startup: {0}", e.ToString());
                return false;
            }
        }

        public void StopService()
        {
            _serviceHost.Close();
        }

        public string[] GetListOfVariableIds()
        {
            return _variableBuffer.ListAllVariableIDs();
        }

        public VariableData GetVariableData(string variableId)
        {
            return _variableBuffer.GetVariableData(variableId);
        }

        public VariableData[] GetAllVariables()
        {
            return _variableBuffer.GetAllVariables().ToArray();
        }
    }
}
