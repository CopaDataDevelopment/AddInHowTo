using System;
using Scada.AddIn.Contracts;
using AddInSampleLibrary.Subscription;
using System.Collections.Generic;
using Scada.AddIn.Contracts.Variable;
using AddInSampleLibrary.Logging;
using NLog;
using System.Linq;
using System.Windows.Forms;

namespace AddinWCFService
{
    [AddInExtension("Addin Sample - WCF Service", "Addin Sample, which shows the usage of a self hosted WCF Service")]
    public class ProjectServiceExtension : IProjectServiceExtension
    {
        #region IProjectServiceExtension implementation

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private VariableService _variableService;

        private VariableBuffer _variableBuffer;
        private VariableSubscription _variableSubscription;


        public void Start(IProject context, IBehavior behavior)
        {
            var configurator = new NLogConfigurator();
            configurator.Configure();

            _variableBuffer = new VariableBuffer();

            _variableSubscription = new VariableSubscription(VariableChangeReceivedAction);

            try
            {
                List<string> newOnlineVariables = new List<string>();

                // add all variables of the current project, that are set as "extern visible"
                foreach (var item in context.VariableCollection)
                {
                    if ((bool)item.GetDynamicProperty("ExternVisible"))
                    {
                        newOnlineVariables.Add(item.Name);
                        _logger.Debug("Added variable " + item.Name + " to variable subscription");
                    }
                }

                if (newOnlineVariables.Any())
                {
                    _variableSubscription.Start(context, newOnlineVariables);
                }
                else
                {
                    _logger.Info("Didn't find any \"extern visible\" variables in project " + context.Name);
                }

            } catch (Exception ex)
            {
                _logger.Error(ex);
            }

            // create variable service and inject reference to the variableBuffer
            // IMPORTANT: use the following command in a command prompt with elevated rights, to reserve the URI for the WCF service
            // otherwise the zenon runtime must be started with Administrator permissions, to successfully register the service
            // > netsh http add urlacl url=http://+:8080/variable-service user=domain\user
            // further information: https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/configuring-http-and-https
            _variableService = new VariableService(_variableBuffer)
            {
                // set the Uri for the service
                BaseUri = new Uri("http://localhost:8080/variable-service")
            };
            // start WCF service
            var started = _variableService.StartService();
            if (started == false)
            {
                MessageBox.Show("Could not start VariableService. Please see NLog output", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Stop()
        {
            _variableService.StopService();
        }

        private void VariableChangeReceivedAction(IEnumerable<IVariable> variables)
        {
            foreach (var variable in variables)
            {
                _variableBuffer.UpdateVariableData(variable);
            }
        }

        #endregion
    }
}