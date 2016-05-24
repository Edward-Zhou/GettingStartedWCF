﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsynchronousServiceConsumer.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SampleMethodTest", ReplyAction="http://tempuri.org/IService1/SampleMethodTestResponse")]
        string SampleMethodTest(string msg);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/SampleMethodTest", ReplyAction="http://tempuri.org/IService1/SampleMethodTestResponse")]
        System.IAsyncResult BeginSampleMethodTest(string msg, System.AsyncCallback callback, object asyncState);
        
        string EndSampleMethodTest(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SampleMethod", ReplyAction="http://tempuri.org/IService1/SampleMethodResponse")]
        string SampleMethod(string msg);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/SampleMethod", ReplyAction="http://tempuri.org/IService1/SampleMethodResponse")]
        System.IAsyncResult BeginSampleMethod(string msg, System.AsyncCallback callback, object asyncState);
        
        string EndSampleMethod(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ServiceAsyncMethod", ReplyAction="http://tempuri.org/IService1/ServiceAsyncMethodResponse")]
        string ServiceAsyncMethod(string msg);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/ServiceAsyncMethod", ReplyAction="http://tempuri.org/IService1/ServiceAsyncMethodResponse")]
        System.IAsyncResult BeginServiceAsyncMethod(string msg, System.AsyncCallback callback, object asyncState);
        
        string EndServiceAsyncMethod(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : AsynchronousServiceConsumer.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SampleMethodTestCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SampleMethodTestCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SampleMethodCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SampleMethodCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceAsyncMethodCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ServiceAsyncMethodCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<AsynchronousServiceConsumer.ServiceReference1.IService1>, AsynchronousServiceConsumer.ServiceReference1.IService1 {
        
        private BeginOperationDelegate onBeginSampleMethodTestDelegate;
        
        private EndOperationDelegate onEndSampleMethodTestDelegate;
        
        private System.Threading.SendOrPostCallback onSampleMethodTestCompletedDelegate;
        
        private BeginOperationDelegate onBeginSampleMethodDelegate;
        
        private EndOperationDelegate onEndSampleMethodDelegate;
        
        private System.Threading.SendOrPostCallback onSampleMethodCompletedDelegate;
        
        private BeginOperationDelegate onBeginServiceAsyncMethodDelegate;
        
        private EndOperationDelegate onEndServiceAsyncMethodDelegate;
        
        private System.Threading.SendOrPostCallback onServiceAsyncMethodCompletedDelegate;
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<SampleMethodTestCompletedEventArgs> SampleMethodTestCompleted;
        
        public event System.EventHandler<SampleMethodCompletedEventArgs> SampleMethodCompleted;
        
        public event System.EventHandler<ServiceAsyncMethodCompletedEventArgs> ServiceAsyncMethodCompleted;
        
        public string SampleMethodTest(string msg) {
            return base.Channel.SampleMethodTest(msg);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSampleMethodTest(string msg, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSampleMethodTest(msg, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndSampleMethodTest(System.IAsyncResult result) {
            return base.Channel.EndSampleMethodTest(result);
        }
        
        private System.IAsyncResult OnBeginSampleMethodTest(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string msg = ((string)(inValues[0]));
            return this.BeginSampleMethodTest(msg, callback, asyncState);
        }
        
        private object[] OnEndSampleMethodTest(System.IAsyncResult result) {
            string retVal = this.EndSampleMethodTest(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSampleMethodTestCompleted(object state) {
            if ((this.SampleMethodTestCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SampleMethodTestCompleted(this, new SampleMethodTestCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SampleMethodTestAsync(string msg) {
            this.SampleMethodTestAsync(msg, null);
        }
        
        public void SampleMethodTestAsync(string msg, object userState) {
            if ((this.onBeginSampleMethodTestDelegate == null)) {
                this.onBeginSampleMethodTestDelegate = new BeginOperationDelegate(this.OnBeginSampleMethodTest);
            }
            if ((this.onEndSampleMethodTestDelegate == null)) {
                this.onEndSampleMethodTestDelegate = new EndOperationDelegate(this.OnEndSampleMethodTest);
            }
            if ((this.onSampleMethodTestCompletedDelegate == null)) {
                this.onSampleMethodTestCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSampleMethodTestCompleted);
            }
            base.InvokeAsync(this.onBeginSampleMethodTestDelegate, new object[] {
                        msg}, this.onEndSampleMethodTestDelegate, this.onSampleMethodTestCompletedDelegate, userState);
        }
        
        public string SampleMethod(string msg) {
            return base.Channel.SampleMethod(msg);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSampleMethod(string msg, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSampleMethod(msg, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndSampleMethod(System.IAsyncResult result) {
            return base.Channel.EndSampleMethod(result);
        }
        
        private System.IAsyncResult OnBeginSampleMethod(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string msg = ((string)(inValues[0]));
            return this.BeginSampleMethod(msg, callback, asyncState);
        }
        
        private object[] OnEndSampleMethod(System.IAsyncResult result) {
            string retVal = this.EndSampleMethod(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSampleMethodCompleted(object state) {
            if ((this.SampleMethodCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SampleMethodCompleted(this, new SampleMethodCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SampleMethodAsync(string msg) {
            this.SampleMethodAsync(msg, null);
        }
        
        public void SampleMethodAsync(string msg, object userState) {
            if ((this.onBeginSampleMethodDelegate == null)) {
                this.onBeginSampleMethodDelegate = new BeginOperationDelegate(this.OnBeginSampleMethod);
            }
            if ((this.onEndSampleMethodDelegate == null)) {
                this.onEndSampleMethodDelegate = new EndOperationDelegate(this.OnEndSampleMethod);
            }
            if ((this.onSampleMethodCompletedDelegate == null)) {
                this.onSampleMethodCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSampleMethodCompleted);
            }
            base.InvokeAsync(this.onBeginSampleMethodDelegate, new object[] {
                        msg}, this.onEndSampleMethodDelegate, this.onSampleMethodCompletedDelegate, userState);
        }
        
        public string ServiceAsyncMethod(string msg) {
            return base.Channel.ServiceAsyncMethod(msg);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginServiceAsyncMethod(string msg, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginServiceAsyncMethod(msg, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndServiceAsyncMethod(System.IAsyncResult result) {
            return base.Channel.EndServiceAsyncMethod(result);
        }
        
        private System.IAsyncResult OnBeginServiceAsyncMethod(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string msg = ((string)(inValues[0]));
            return this.BeginServiceAsyncMethod(msg, callback, asyncState);
        }
        
        private object[] OnEndServiceAsyncMethod(System.IAsyncResult result) {
            string retVal = this.EndServiceAsyncMethod(result);
            return new object[] {
                    retVal};
        }
        
        private void OnServiceAsyncMethodCompleted(object state) {
            if ((this.ServiceAsyncMethodCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ServiceAsyncMethodCompleted(this, new ServiceAsyncMethodCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ServiceAsyncMethodAsync(string msg) {
            this.ServiceAsyncMethodAsync(msg, null);
        }
        
        public void ServiceAsyncMethodAsync(string msg, object userState) {
            if ((this.onBeginServiceAsyncMethodDelegate == null)) {
                this.onBeginServiceAsyncMethodDelegate = new BeginOperationDelegate(this.OnBeginServiceAsyncMethod);
            }
            if ((this.onEndServiceAsyncMethodDelegate == null)) {
                this.onEndServiceAsyncMethodDelegate = new EndOperationDelegate(this.OnEndServiceAsyncMethod);
            }
            if ((this.onServiceAsyncMethodCompletedDelegate == null)) {
                this.onServiceAsyncMethodCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnServiceAsyncMethodCompleted);
            }
            base.InvokeAsync(this.onBeginServiceAsyncMethodDelegate, new object[] {
                        msg}, this.onEndServiceAsyncMethodDelegate, this.onServiceAsyncMethodCompletedDelegate, userState);
        }
    }
}