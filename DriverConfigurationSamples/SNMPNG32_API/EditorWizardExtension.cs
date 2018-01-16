using System;
using Scada.AddIn.Contracts;
using DriverCommon;

namespace SNMPNG32_API
{
    /// <summary>
    /// Description of Editor Wizard Extension.
    /// </summary>
    [AddInExtension("SNMPNG32_API", "Test SNMPNG32 API, Import and Export", "Drivers API/Export/Import")]
    public class EditorWizardExtension : IEditorWizardExtension
    {
        private Log _log;
        private DriverContext _driverContext;

        const string DriverIdent = "SNMPNG32";
        const string DriverName = "SNMP Treiber New Generation";
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
                  ModifyAgents();
                  ModifyMibItems();
                  ModifyTrapService();

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

            _driverContext.SetUnsignedProperty("DrvConfig.Options.Retries", 3, 5);
            _driverContext.SetUnsignedProperty("DrvConfig.Options.RetryTimout", 100, 200);
            _driverContext.SetUnsignedProperty("DrvConfig.Options.ErrorTimout", 500, 800);
            _driverContext.SetUnsignedProperty("DrvConfig.Options.Addressing", 0, 1);

            _log.FunctionExitMessage();
        }

        private void ModifyAgents()
        {
          _log.FunctionEntryMessage("modify agents");

          string[] propItems;
          uint connCount;
          _driverContext.GetNodeInfo("DrvConfig.Agents", out propItems, out connCount);

          for (uint idxI = 0; idxI < connCount; idxI++)
          {
            ModifyAgent(idxI);
          }

          _log.FunctionExitMessage();
        }

        private void ModifyAgent(uint agentIndex)
        {
          string agentNamePrefix;
          agentNamePrefix = "DrvConfig.Agents[" + agentIndex.ToString() + "].";

          agentIndex = agentIndex + 1;

          _log.FunctionEntryMessage($"modify {agentIndex}. agent");


          _driverContext.SetStringProperty(agentNamePrefix + "AgentName", "Agent #" + agentIndex.ToString(), true);
          _driverContext.SetUnsignedProperty(agentNamePrefix + "HwAdress", agentIndex, 0, 65535, true);
          _driverContext.SetUnsignedProperty(agentNamePrefix + "TrapMode", 0, 0, 65535, true);
          _driverContext.SetUnsignedProperty(agentNamePrefix + "TranslationMode", 0, 0, 65535, true);
          _driverContext.SetUnsignedProperty(agentNamePrefix + "ItemCount", agentIndex*10, 0, 65535, true);
          _driverContext.SetStringProperty(agentNamePrefix + "RootOID", ".0.0." + agentIndex.ToString(), true);
          _driverContext.SetStringProperty(agentNamePrefix + "AgentAddress", "255.255.255." + agentIndex.ToString(), true);
          _driverContext.SetUnsignedProperty(agentNamePrefix + "AgentPort", agentIndex, 0, 65535, true);
          _driverContext.SetUnsignedProperty(agentNamePrefix + "SnmpVersion", 0, 0, 65535, true);
          _driverContext.SetStringProperty(agentNamePrefix + "SnmpCommunity", "public", true);
          _driverContext.SetStringProperty(agentNamePrefix + "SnmpUser", "User #" + agentIndex.ToString(), true);
          _driverContext.SetUnsignedProperty(agentNamePrefix + "AuthMethod", 0, 0, 65535, true);
          _driverContext.SetStringProperty(agentNamePrefix + "AuthKey", "Auth Key #" + agentIndex.ToString(), true);
          _driverContext.SetUnsignedProperty(agentNamePrefix + "PrivMethod", 0, 0, 65535, true);
          _driverContext.SetStringProperty(agentNamePrefix + "PrivKey", "Private Key #" + agentIndex.ToString(), true);

          _log.FunctionExitMessage();
        }

    private void ModifyMibItems()
    {
      _log.FunctionEntryMessage("modify mibitems");

      string[] propItems;
      uint itemCount;
      _driverContext.GetNodeInfo("DrvConfig.MibItems", out propItems, out itemCount);

      for (uint idxI = 0; idxI < itemCount; idxI++)
      {
        ModifyMibItem(idxI);
      }

      _log.FunctionExitMessage();
    }

    private void ModifyMibItem(uint itemIndex)
    {
      string mibItemNamePrefix;
      mibItemNamePrefix = "DrvConfig.MibItems[" + itemIndex.ToString() + "].";

      itemIndex = itemIndex + 1;

      _log.FunctionEntryMessage($"modify {itemIndex}. MibItem");

      _driverContext.SetStringProperty(mibItemNamePrefix + "MibItemName", "MibItem #" + itemIndex.ToString(), true);
      _driverContext.SetUnsignedProperty(mibItemNamePrefix + "Datatype", 0, 0, 65535, true);
      _driverContext.SetStringProperty(mibItemNamePrefix + "StringOid", "StringOid #" + itemIndex.ToString(), true);
      _driverContext.SetStringProperty(mibItemNamePrefix + "NumOid", "1.3.6." + itemIndex.ToString(), true);

      _log.FunctionExitMessage();
    }

    private void ModifyTrapService()
    {
      _log.FunctionEntryMessage("modify trap service config");

      _driverContext.SetUnsignedProperty("DrvConfig.TrapService[0].PollingInterval", 3333, 5555);
      _driverContext.SetUnsignedProperty("DrvConfig.TrapService[0].PollingRetries", 7, 8);
      _driverContext.SetUnsignedProperty("DrvConfig.TrapService[0].PollingRetryTimeout", 1111, 2222);

      _log.FunctionExitMessage();
    }
    #endregion
  }

}