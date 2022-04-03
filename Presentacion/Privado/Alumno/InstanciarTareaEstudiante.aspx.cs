using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Presentacion
{
    public partial class InstanciarTareaEstudiante : System.Web.UI.Page
    {
        private LogicaNegocio.LN ln = new LogicaNegocio.LN();
        private List<String> asigs = new List<String>();
        private AccesoDatos.BBDD bd = new AccesoDatos.BBDD();

        private SqlConnection conn = new SqlConnection();
        private SqlDataAdapter dapTareas = new SqlDataAdapter();
        private DataSet dsTareas = new DataSet();
        private DataTable dtTareas = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = Session["email"].ToString();
            TextBox2.Text = Request.QueryString["codigo"];
            TextBox3.Text = Request.QueryString["he"];

            conn = bd.getConnection();

            if (Page.IsPostBack)
            {
                dsTareas = (DataSet)Session["tareas_instanciadas"];
            }
            else
            {
                dapTareas = new SqlDataAdapter("SELECT email, codTarea, hEstimadas, hReales FROM EstudianteTarea", conn);
                
                SqlCommandBuilder buildTareas = new SqlCommandBuilder(dapTareas);
                dapTareas.Fill(dsTareas, "EstudianteTarea");
                dtTareas = dsTareas.Tables["EstudianteTarea"];
                gvTareas.DataSource = dtTareas;
                gvTareas.DataBind();
                Session["tareas_instanciadas"] = dsTareas;
                Session["adaptador_instanciadas"] = dapTareas;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RequiredFieldValidator4.IsValid && RegularExpressionValidator1.IsValid)
            {
                String cod = Request.QueryString["codigo"];
                int hreales = Int32.Parse(TextBox4.Text);

                bool inserted = ln.instanciarTareaAlumno(TextBox1.Text, TextBox2.Text, Int32.Parse(TextBox3.Text), hreales);
                Response.Redirect(Request.Url.ToString());

            } else
            {
                insertado.Text = "Ingresa las horas reales antes de realizar la inserción.";
            }
        }
    }
}