﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiscoveryProxyClient.WillServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WillServiceReference.ITest")]
    public interface ITest {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITest/GetData", ReplyAction="http://tempuri.org/ITest/GetDataResponse")]
        string GetData(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITest/GetData", ReplyAction="http://tempuri.org/ITest/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(string value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITestChannel : DiscoveryProxyClient.WillServiceReference.ITest, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TestClient : System.ServiceModel.ClientBase<DiscoveryProxyClient.WillServiceReference.ITest>, DiscoveryProxyClient.WillServiceReference.ITest {
        
        public TestClient() {
        }
        
        public TestClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TestClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TestClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TestClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(string value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(string value) {
            return base.Channel.GetDataAsync(value);
        }
    }
}
