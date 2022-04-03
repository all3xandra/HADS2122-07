using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Registro : System.Web.UI.Page
    {
        private LogicaNegocio.LN ln = new LogicaNegocio.LN();
        private AccesoDatos.BBDD bd = new AccesoDatos.BBDD();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-1.8.3.min.js",
                DebugPath = "~/scripts/jquery-1.8.3.js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.js"
            });

        }

        protected void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void pw_TextChanged(object sender, EventArgs e)
        {

        }

        protected void correo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RequiredFieldValidator1.IsValid)
            {
                Random generator = new Random();
                int numconf = (int)(generator.NextDouble() * 9000000) + 1000000;
                String subject = "Confirmación registro";
                String body = "Para confirmar el registro en la página HADS22-07, accesa el siguiente enlace:\nhttp://hads22-07.azurewebsites.net/Confirmar.aspx?mbr=" + correo_text.Text + "&numconf=" + numconf;
                ln.sendMail(subject, body, correo_text.Text);
                ln.insertUser(correo_text.Text, nombre.Text, apellidos.Text, numconf, rol_radio.SelectedValue.ToString(), pw_text.Text);
            }
        }
    }
}