using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        private LogicaNegocio.LN ln = new LogicaNegocio.LN();

        public object MessageBox { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery-1.8.3.min.js",
                    DebugPath = "~/scripts/jquery-1.8.3.js",
                    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js",
                    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.js"
                });
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ln.updateCodpass(correo_text.Text);
            int codpass = ln.getCodpass(correo_text.Text);
            String subject = "Solicitud cambio contraseña";
            String body = "Has solicitado el cambio de contraseña. Sigue los pasos, utilizando el siguiente código: " + codpass;

            ln.sendMail(subject, body, correo_text.Text);
        }

        protected void confirmar_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(clave_text.Text) == ln.getCodpass(correo_text.Text))
            {
                nueva.ReadOnly = false;
                nueva2.ReadOnly = false;
                prueba.Text = "";
            }
            else
            {
                prueba.Text = "Las claves no coinciden";
            }
        }

        protected void cambiar_Click(object sender, EventArgs e)
        {
            ln.updatePassword(nueva.Text, correo_text.Text);
        }

        protected void nueva_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("http://hads22-07.azurewebsites.net/Inicio.aspx");
        }
    }
}