﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiscoveryProxyClient.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.myDiscoveryProxy")]
    public interface myDiscoveryProxy {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/myDiscoveryProxy/getString", ReplyAction="http://tempuri.org/myDiscoveryProxy/getStringResponse")]
        string getString(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/myDiscoveryProxy/getString", ReplyAction="http://tempuri.org/myDiscoveryProxy/getStringResponse")]
        System.Threading.Tasks.Task<string> getStringAsync(string msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface myDiscoveryProxyChannel : DiscoveryProxyClient.ServiceReference2.myDiscoveryProxy, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class myDiscoveryProxyClient : System.ServiceModel.ClientBase<DiscoveryProxyClient.ServiceReference2.myDiscoveryProxy>, DiscoveryProxyClient.ServiceReference2.myDiscoveryProxy {
        
        public myDiscoveryProxyClient() {
        }
        
        public myDiscoveryProxyClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public myDiscoveryProxyClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public myDiscoveryProxyClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public myDiscoveryProxyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string getString(string msg) {
            return base.Channel.getString(msg);
        }
        
        public System.Threading.Tasks.Task<string> getStringAsync(string msg) {
            return base.Channel.getStringAsync(msg);
        }
    }
}
