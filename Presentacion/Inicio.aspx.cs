using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Inicio1 : System.Web.UI.Page
    {
        private LogicaNegocio.LN ln = new LogicaNegocio.LN();
        private AccesoDatos.BBDD bd = new AccesoDatos.BBDD();
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
            if (ln.searchEmail(correo_text.Text))
            {
                string psw_hash = ln.getHash(psw_text);
                if (psw_hash.Equals(ln.getPassword(correo_text.Text)))
                {
                    if (ln.getConfirmed(correo_text.Text))
                    {
                        Session["email"] = correo_text.Text;
                        String tipo = ln.getRol(correo_text.Text);
                        if (tipo.Equals("Alumno"))
                        {
                            Response.Redirect("http://hads22-07.azurewebsites.net/Alumno.aspx");
                        }
                        else
                        {
                            Response.Redirect("http://hads22-07.azurewebsites.net/Profesor.aspx");
                        }

                    }
                    else
                    {
                        error_login.Text = "Tu cuenta no está confirmada. Pulsa en el siguiente botón para obtener un nuevo correo de confirmación:\n";
                        enlace.Visible = true;
                    }
                }
                else
                {
                    error_login.Text = "Contraseña no válida";
                }
            }
            else
            {
                error_login.Text = "Correo no existe";
            }
        }

        protected void enlace_Click(object sender, EventArgs e)
        {
            int numconfir = ln.getNumconfir(correo_text.Text);
            String subject = "Confirmación registro";
            String body = "Para confirmar el registro en la página HADS22-07, accesa el siguiente enlace:\nhttp://hads22-07.azurewebsites.net/Confirmar.aspx?mbr=" + correo_text.Text + "&numconf=" + numconfir;
            ln.sendMail(subject, body, correo_text.Text);
            correo_enviado.Text = "Correo enviado. Verifica tu buzón.";
        }
    }
}