using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WCFWebHTTPService
{
    public class ValidateParameterInspectorAttribute : Attribute, IParameterInspector, IOperationBehavior
    {
        public object BeforeCall(string operationName, object[] inputs)
        {
            InputParams.StartValidatingParameters(operationName, inputs);
            return null;
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {

        }


        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {

        }


        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {

            dispatchOperation.ParameterInspectors.Add(this);

        }


        public void Validate(OperationDescription operationDescription)
        {

            //throw new NotImplementedException();

        }


        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {

            //throw new NotImplementedException();

        }

    }

}
