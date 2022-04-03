using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class GestionTareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://hads22-07.azurewebsites.net/Profesor.aspx");
        }
    }
}