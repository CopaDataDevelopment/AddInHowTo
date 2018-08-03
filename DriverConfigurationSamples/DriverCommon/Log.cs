using System;
using AddInSampleLibrary.Logging;
using NLog;
using Scada.AddIn.Contracts;

namespace DriverCommon
{
    public class Log
    {
        private readonly IEditorApplication _editorApplication;
        private readonly string _driverApiName;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Log(IEditorApplication editorApplication, string driverIdent)
        {
            var configurator = new NLogConfigurator();
            configurator.Configure();

            _editorApplication = editorApplication;
            _driverApiName = driverIdent + "API";
        }

        public void Message(string msgText)
        {
        	string text = String.Format(" - [{0}]: {1}",_driverApiName,msgText);
            _editorApplication.DebugPrint(text, DebugPrintStyle.Standard);
            Logger.Info(text);
        }

        public void InvalidPropertyValueMessage(string propName)
        {
        	string text = String.Format(" - [{0}]:     [{1}] is invalid (and remains invalid)",_driverApiName,propName);
            _editorApplication.DebugPrint(text, DebugPrintStyle.Standard);
            Logger.Warn(text);
        }

        public void ExpectionMessage(string msgText, Exception ex)
        {
        	string text = String.Format(" - [{0}]:     [{1}] (Exception: {2})",_driverApiName,msgText,ex.Message);
            _editorApplication.DebugPrint(text, DebugPrintStyle.Standard);
            Logger.Error(ex, text);
        }

        public void FunctionEntryMessage(string msgText)
        {
        	_editorApplication.DebugPrint(String.Format(" - [{0}]:   {1}",_driverApiName,msgText), DebugPrintStyle.Standard);
        }
        public void FunctionExitMessage()
        {
        }
   
        public void PropertyModifiedMessage(string propName, object orgValue, object newValue, string propType)
        {
            _editorApplication.DebugPrint(
        		String.Format(" - [{0}]:    [{1}] from [{2}] to [{3}] (value type: {4})",
        		              _driverApiName,propName,orgValue,newValue,propType), DebugPrintStyle.Standard);
        }
     }
}
