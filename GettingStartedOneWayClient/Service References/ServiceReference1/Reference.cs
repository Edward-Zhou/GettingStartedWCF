﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GettingStartedOneWayClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="ServiceReference1.IOneWayCalculator")]
    public interface IOneWayCalculator {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/Add")]
        void Add(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/Add")]
        System.Threading.Tasks.Task AddAsync(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/Subtract")]
        void Subtract(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/Subtract")]
        System.Threading.Tasks.Task SubtractAsync(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/Multiply")]
        void Multiply(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/Multiply")]
        System.Threading.Tasks.Task MultiplyAsync(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/Divide")]
        void Divide(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/Divide")]
        System.Threading.Tasks.Task DivideAsync(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/SayHello", ReplyAction="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/SayHelloResponse")]
        string SayHello(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/SayHello", ReplyAction="http://Microsoft.ServiceModel.Samples/IOneWayCalculator/SayHelloResponse")]
        System.Threading.Tasks.Task<string> SayHelloAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOneWayCalculatorChannel : GettingStartedOneWayClient.ServiceReference1.IOneWayCalculator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OneWayCalculatorClient : System.ServiceModel.ClientBase<GettingStartedOneWayClient.ServiceReference1.IOneWayCalculator>, GettingStartedOneWayClient.ServiceReference1.IOneWayCalculator {
        
        public OneWayCalculatorClient() {
        }
        
        public OneWayCalculatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OneWayCalculatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OneWayCalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OneWayCalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Add(double n1, double n2) {
            base.Channel.Add(n1, n2);
        }
        
        public System.Threading.Tasks.Task AddAsync(double n1, double n2) {
            return base.Channel.AddAsync(n1, n2);
        }
        
        public void Subtract(double n1, double n2) {
            base.Channel.Subtract(n1, n2);
        }
        
        public System.Threading.Tasks.Task SubtractAsync(double n1, double n2) {
            return base.Channel.SubtractAsync(n1, n2);
        }
        
        public void Multiply(double n1, double n2) {
            base.Channel.Multiply(n1, n2);
        }
        
        public System.Threading.Tasks.Task MultiplyAsync(double n1, double n2) {
            return base.Channel.MultiplyAsync(n1, n2);
        }
        
        public void Divide(double n1, double n2) {
            base.Channel.Divide(n1, n2);
        }
        
        public System.Threading.Tasks.Task DivideAsync(double n1, double n2) {
            return base.Channel.DivideAsync(n1, n2);
        }
        
        public string SayHello(string name) {
            return base.Channel.SayHello(name);
        }
        
        public System.Threading.Tasks.Task<string> SayHelloAsync(string name) {
            return base.Channel.SayHelloAsync(name);
        }
    }
}
