using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SERVICIOS;

namespace RSWork
{
    public partial class Excepcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception exep = new Exception();

            exep = (Exception)Session["ExcepcionControlada"];

            MessageLabel.Text = "Message: " + exep.Message.ToString();

            TipoLabel.Text = "Type: "+ exep.GetType().ToString();

            StackTraceLabel.Text = "Stack Trace: " + exep.StackTrace.ToString();

            SourceLabel.Text = "Source: "+ exep.Source.ToString();

            TimeStampLabel.Text = "TimeStamp: "+ System.DateTime.Now.ToString();





            
        }
    }
}