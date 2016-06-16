using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebService
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CallWebServicebtn_Click(object sender, EventArgs e)
        {
            WebService1 ws = new WebService1();
            string s= ws.HelloWorld();
            Label1.Text = s;
        }
    }
}