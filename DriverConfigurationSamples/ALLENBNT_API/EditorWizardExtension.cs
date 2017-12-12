using System;
using Scada.AddIn.Contracts;
using DriverCommon;

namespace ALLENBNT_API
{
    /// <summary>
    /// Description of Editor Wizard Extension.
    /// </summary>
    [AddInExtension("ALLENBNT_API", "Test ALLENBNT API, Import and Export", "Drivers API/Export/Import")]
    public class EditorWizardExtension : IEditorWizardExtension
    {
        private Log _log;
        private DriverContext _driverContext;

        const string DriverIdent = "ALLANBNT";
        const string DriverName = "Allen Bradley RS-Linx Treiber";
        const string XmlSuffixBefore = "before";
        const string XmlSuffixAfter = "after";

        #region IEditorWizardExtension implementation

        public void Run(IEditorApplication context, IBehavior behavior)
        {
            _log = new Log(context, DriverIdent);

            try
            {
                _driverContext = new DriverContext(context, _log, DriverName, false);

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
                _log.ExpectionMessage($"An exception has been thrown: {ex.Message}", ex);
                throw;
            }
        }

    private void ModifyOptions()
    {
      _log.FunctionEntryMessage("modify options");

      _driverContext.SetStringProperty("DrvConfig.Options.RSLinxName", "API_String", true);
      _driverContext.IncreaseUnsignedProperty("DrvConfig.Options.PLCType", 0x80, 0xc000);

      _log.FunctionExitMessage();
    }

    private void ModifyConnections()
    {
      _log.FunctionEntryMessage("modify connections");

      string[] propItemsMsg;
      uint connCountMsg;
      _driverContext.GetNodeInfo("DrvConfig.UnsolMessages", out propItemsMsg, out connCountMsg);
      for (uint idxI = 0; idxI < connCountMsg; idxI++)
      {
        ModifyConnectionMsgConfig(idxI);
      }

      string[] propItemsRouting;
      uint connCountRouting;
      _driverContext.GetNodeInfo("DrvConfig.Routing", out propItemsRouting, out connCountRouting);
      for (uint idxI = 0; idxI < connCountRouting; idxI++)
      {
        ModifyConnectionRouting(idxI);
      }

      _log.FunctionExitMessage();
    }

    private void ModifyConnectionMsgConfig(uint connIndex)
    {
      string connNamePrefix;
      string connIndexString = connIndex.ToString();
      connNamePrefix = "DrvConfig.UnsolMessages[" + connIndexString + "].";

      connIndex = connIndex + 1;

      _log.FunctionEntryMessage($"modify {connIndex}. UnsolMessages");

      _driverContext.SetUnsignedProperty(connNamePrefix + "NetAddress", 7, 0, 999, true);
      _driverContext.SetUnsignedProperty(connNamePrefix + "DataTableAddress", 7, 0, 999, true);
      _driverContext.SetUnsignedProperty(connNamePrefix + "DrvObjType", 7, 0, 999, true);
      _driverContext.SetUnsignedProperty(connNamePrefix + "DataNumber", 7, 0, 999, true);
      _driverContext.SetUnsignedProperty(connNamePrefix + "ElementOffset", 7, 0, 999, true);

      _log.FunctionExitMessage();
    }

    private void ModifyConnectionRouting(uint connIndex)
    {
      string connNamePrefix;
      string connIndexString = connIndex.ToString();
      connNamePrefix = "DrvConfig.Routing[" + connIndexString + "].";

      connIndex = connIndex + 1;

      _log.FunctionEntryMessage($"modify {connIndex}. routing");

      // IMPORTANT: VariableAddress NEEDS to be unique value key or entry will be overwritten!!!
      _driverContext.SetUnsignedProperty(connNamePrefix + "VariableAddress", connIndex, 0, 999, true);
      _driverContext.SetUnsignedProperty(connNamePrefix + "IPAddress", 127, 0, 999, true);
      _driverContext.SetSignedProperty(connNamePrefix + "DHRIOSlot", 0, 0, 999, true);
      _driverContext.SetCharacterProperty(connNamePrefix + "Channel", 'B');
      _driverContext.SetSignedProperty(connNamePrefix + "RemoteLinkID", 0, 0, 999, true);
      _driverContext.SetSignedProperty(connNamePrefix + "RemoteStation", 0, 0, 999, true);
      _driverContext.SetSignedProperty(connNamePrefix + "PLCType", 0, 0, 999, true);

      _log.FunctionExitMessage();
    }

    #endregion
  }

}
