using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFWebHTTPService
{
    public class InputParams
    {

        internal static void StartValidatingParameters(string operationName, object[] inputs)
        {

            var methodParam = inputs.FirstOrDefault() as Student;


            if (methodParam != null &&

                string.IsNullOrEmpty(methodParam.FirstName))
            {

                ThrowFaultException();

            }

            else if (string.IsNullOrEmpty(methodParam.LastName))
            {

                ThrowFaultException();

            }


        }


        private static void ThrowFaultException()
        {
            //throw "test";
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";

            //var wfc = new WebFaultException<Response>(new Response

            //    (

            //        false,

            //        "Oops, Invalid parameter found!"

            //    ), System.Net.HttpStatusCode.OK);

            //throw wfc;


        }


    }

}
