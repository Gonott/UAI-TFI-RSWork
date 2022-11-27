using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;


namespace RSWork
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DashboardBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Dashboard.aspx");
            }           
            catch(ThreadAbortException)
            {
                Thread.ResetAbort();
            }
            catch (Exception ex)
            {
                Session["ExcepcionControlada"] = null;
                Session["ExcepcionControlada"] = ex;
                Response.Redirect("Excepcion.aspx");
            }


        }
    }
}