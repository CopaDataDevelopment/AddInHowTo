using System;
using Scada.AddIn.Contracts;
using DriverCommon;

namespace STRATONNG_API
{
    /// <summary>
    /// Description of Editor Wizard Extension.
    /// </summary>
    [AddInExtension("STRATONNG_API", "Test STRATONNG API, Import and Export", "Drivers API/Export/Import")]
    public class EditorWizardExtension : IEditorWizardExtension
    {
        private Log _log;
        private DriverContext _driverContext;

        const string DriverFileName = "STRATONNG";
        const string XmlSuffixBefore = "before";
        const string XmlSuffixAfter = "after";

        #region IEditorWizardExtension implementation

        public void Run(IEditorApplication context, IBehavior behavior)
        {
            _log = new Log(context, DriverFileName);

            try
            {
                _driverContext = new DriverContext(context, _log, DriverFileName, false);

                // enter your code which should be executed when starting the SCADA Editor Wizard

                _log.Message("begin test");

                _driverContext.Export(XmlSuffixBefore);

                if (_driverContext.OpenDriver(10))
                {
                    _driverContext.ModifyCommonProperties();
                    _driverContext.ModifyCOMProperties();

                    ModifyOptions();
                    ModifyConnections();
          
                    _driverContext.CloseDriver();

                    _driverContext.Export(XmlSuffixAfter);
                    _driverContext.Import(XmlSuffixBefore);
                }

                _log.Message("end test");
            }
            catch (Exception ex)
            {
            	_log.ExpectionMessage(String.Format("An exception has been thrown: {0}",ex.Message), ex);
                throw;
            }
        }

    private void ModifyOptions()
    {
      _log.FunctionEntryMessage("modify options");

      _driverContext.SetSignedProperty("DrvConfig.Options.SymbolVarName", 7, 0, 999, true);

      _log.FunctionExitMessage();
    }

    private void ModifyConnections()
    {
      _log.FunctionEntryMessage("modify connections");

      string[] propItems;
      uint connCount;
      _driverContext.GetNodeInfo("DrvConfig.Connections", out propItems, out connCount);

      uint idxI;
      for (idxI = 0; idxI < connCount; idxI++)
      {
        ModifyConnection(idxI);
      }

      _log.FunctionExitMessage();
    }

    private void ModifyConnection(uint connIndex)
    {
      string connNamePrefix;
      string connIndexString = connIndex.ToString();
      connNamePrefix = "DrvConfig.Connections[" + connIndexString + "].";

      connIndex = connIndex + 1;

      _log.FunctionEntryMessage(String.Format("modify {0}. connection",connIndex));

      _driverContext.SetStringProperty(connNamePrefix + "ConnectionName", "API_TestName" + connIndexString, true);
      _driverContext.SetStringProperty(connNamePrefix + "PrimaryIPAdr", "API_TestPrimary" + connIndexString, true);
      _driverContext.SetStringProperty(connNamePrefix + "SecondaryIPAdr", "API_TestSecondary" + connIndexString, true);
      _driverContext.SetUnsignedProperty(connNamePrefix + "PrimaryTCPPort", 1, 0, 999, true);
      _driverContext.SetUnsignedProperty(connNamePrefix + "SecondaryTCPPort", 1, 0, 999, true);
      _driverContext.SetUnsignedProperty(connNamePrefix + "Timeout", 5000, 0, 10000, true);
      _driverContext.SetUnsignedProperty(connNamePrefix + "ErrorWaitTime", 1, 0, 999, true);
      _driverContext.SetUnsignedProperty(connNamePrefix + "MultipleConnections", 5, 0, 999, true);
      _driverContext.SetBooleanProperty(connNamePrefix + "EventConnection");
      _driverContext.SetUnsignedProperty(connNamePrefix + "MaxWriteRequestLen", 1024, 0, 1024, true); // 512 or 1024
      _driverContext.SetBooleanProperty(connNamePrefix + "IgnorePLCTimestamps");

      _log.FunctionExitMessage();
    }

    #endregion
  }

}
