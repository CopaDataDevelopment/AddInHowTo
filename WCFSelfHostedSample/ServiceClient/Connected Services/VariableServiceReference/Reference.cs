﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceClient.VariableServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VariableData", Namespace="http://schemas.datacontract.org/2004/07/AddinWCFService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ServiceClient.VariableServiceReference.VariableData[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(string[]))]
    public partial class VariableData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdentificationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProjectGuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProjectNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short TimestampMillisecondsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimestampSecondsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VariableIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Identification {
            get {
                return this.IdentificationField;
            }
            set {
                if ((object.ReferenceEquals(this.IdentificationField, value) != true)) {
                    this.IdentificationField = value;
                    this.RaisePropertyChanged("Identification");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProjectGuid {
            get {
                return this.ProjectGuidField;
            }
            set {
                if ((object.ReferenceEquals(this.ProjectGuidField, value) != true)) {
                    this.ProjectGuidField = value;
                    this.RaisePropertyChanged("ProjectGuid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProjectName {
            get {
                return this.ProjectNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProjectNameField, value) != true)) {
                    this.ProjectNameField = value;
                    this.RaisePropertyChanged("ProjectName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State {
            get {
                return this.StateField;
            }
            set {
                if ((object.ReferenceEquals(this.StateField, value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short TimestampMilliseconds {
            get {
                return this.TimestampMillisecondsField;
            }
            set {
                if ((this.TimestampMillisecondsField.Equals(value) != true)) {
                    this.TimestampMillisecondsField = value;
                    this.RaisePropertyChanged("TimestampMilliseconds");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TimestampSeconds {
            get {
                return this.TimestampSecondsField;
            }
            set {
                if ((this.TimestampSecondsField.Equals(value) != true)) {
                    this.TimestampSecondsField = value;
                    this.RaisePropertyChanged("TimestampSeconds");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Unit {
            get {
                return this.UnitField;
            }
            set {
                if ((object.ReferenceEquals(this.UnitField, value) != true)) {
                    this.UnitField = value;
                    this.RaisePropertyChanged("Unit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string VariableId {
            get {
                return this.VariableIdField;
            }
            set {
                if ((object.ReferenceEquals(this.VariableIdField, value) != true)) {
                    this.VariableIdField = value;
                    this.RaisePropertyChanged("VariableId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Copadata.AddinSamples.WCFSamples", ConfigurationName="VariableServiceReference.IVariableService")]
    public interface IVariableService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetListOfVariableIds", ReplyAction="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetListOfVariableIdsResp" +
            "onse")]
        string[] GetListOfVariableIds();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetListOfVariableIds", ReplyAction="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetListOfVariableIdsResp" +
            "onse")]
        System.Threading.Tasks.Task<string[]> GetListOfVariableIdsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetVariableData", ReplyAction="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetVariableDataResponse")]
        ServiceClient.VariableServiceReference.VariableData GetVariableData(string variableId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetVariableData", ReplyAction="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetVariableDataResponse")]
        System.Threading.Tasks.Task<ServiceClient.VariableServiceReference.VariableData> GetVariableDataAsync(string variableId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetAllVariables", ReplyAction="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetAllVariablesResponse")]
        ServiceClient.VariableServiceReference.VariableData[] GetAllVariables();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetAllVariables", ReplyAction="http://Copadata.AddinSamples.WCFSamples/IVariableService/GetAllVariablesResponse")]
        System.Threading.Tasks.Task<ServiceClient.VariableServiceReference.VariableData[]> GetAllVariablesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVariableServiceChannel : ServiceClient.VariableServiceReference.IVariableService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VariableServiceClient : System.ServiceModel.ClientBase<ServiceClient.VariableServiceReference.IVariableService>, ServiceClient.VariableServiceReference.IVariableService {
        
        public VariableServiceClient() {
        }
        
        public VariableServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VariableServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VariableServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VariableServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetListOfVariableIds() {
            return base.Channel.GetListOfVariableIds();
        }
        
        public System.Threading.Tasks.Task<string[]> GetListOfVariableIdsAsync() {
            return base.Channel.GetListOfVariableIdsAsync();
        }
        
        public ServiceClient.VariableServiceReference.VariableData GetVariableData(string variableId) {
            return base.Channel.GetVariableData(variableId);
        }
        
        public System.Threading.Tasks.Task<ServiceClient.VariableServiceReference.VariableData> GetVariableDataAsync(string variableId) {
            return base.Channel.GetVariableDataAsync(variableId);
        }
        
        public ServiceClient.VariableServiceReference.VariableData[] GetAllVariables() {
            return base.Channel.GetAllVariables();
        }
        
        public System.Threading.Tasks.Task<ServiceClient.VariableServiceReference.VariableData[]> GetAllVariablesAsync() {
            return base.Channel.GetAllVariablesAsync();
        }
    }
}