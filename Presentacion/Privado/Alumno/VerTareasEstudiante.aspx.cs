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
    public partial class VerTareasEstudiante : System.Web.UI.Page
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
            if (Page.IsPostBack)
            {
                // dsTareas = Session["tareas_genericas"];
                
            }
            else
            {
                asigs = ln.getAsignaturasAlumno(Session["email"].ToString());
                foreach (String a in asigs)
                {
                    asignaturas_ddl.Items.Add(a);
                }

                conn = bd.getConnection();

                CommandField select = new CommandField();
                select.ShowSelectButton = true;
                select.SelectText = "Instanciar";

                dapTareas = new SqlDataAdapter("SELECT codigo, descripcion, hEstimadas, tipoTarea FROM TareaGenerica WHERE (codAsig = @codAsig) AND (explotacion = @explotacion) AND (codigo NOT IN (SELECT codTarea FROM EstudianteTarea AS ET WHERE (email = @email)))", conn);
                dapTareas.SelectCommand.Parameters.AddWithValue("@codAsig", asignaturas_ddl.SelectedValue);
                dapTareas.SelectCommand.Parameters.AddWithValue("@explotacion", true);
                dapTareas.SelectCommand.Parameters.AddWithValue("@email", Session["email"].ToString());
                SqlCommandBuilder buildTareas = new SqlCommandBuilder(dapTareas);
                dapTareas.Fill(dsTareas, "TareaGenerica");
                dtTareas = dsTareas.Tables["TareaGenerica"];
                GridView1.DataSource = dtTareas;
                GridView1.Columns.Add(select);
                GridView1.DataBind();
                Session["tareas_genericas"] = dsTareas;
                Session["adaptador_genericas"] = dapTareas;
            }

        }


        protected void asignaturas_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = bd.getConnection();
            dapTareas = new SqlDataAdapter("SELECT codigo, descripcion, hEstimadas, tipoTarea FROM TareaGenerica WHERE (codAsig = @codAsig) AND (explotacion = @explotacion) AND (codigo NOT IN (SELECT codTarea FROM EstudianteTarea AS ET WHERE (email = @email)))", conn);
            dapTareas.SelectCommand.Parameters.AddWithValue("@codAsig", asignaturas_ddl.SelectedValue);
            dapTareas.SelectCommand.Parameters.AddWithValue("@explotacion", true);
            dapTareas.SelectCommand.Parameters.AddWithValue("@email", Session["email"].ToString());
            SqlCommandBuilder buildTareas = new SqlCommandBuilder(dapTareas);
            dapTareas.Fill(dsTareas, "TareaGenerica");
            dtTareas = dsTareas.Tables["TareaGenerica"];
            GridView1.DataSource = dtTareas;
            GridView1.DataBind();
            Session["tareas_genericas"] = dsTareas;
            Session["adaptador_genericas"] = dapTareas;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String codigo = GridView1.SelectedRow.Cells[1].Text;
            String he = GridView1.SelectedRow.Cells[3].Text;

            Response.Redirect("http://hads22-07.azurewebsites.net/InstanciarTareaEstudiante.aspx?codigo=" + codigo + "&he=" + he);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("http://hads22-07.azurewebsites.net/Inicio.aspx");
        }
    }
}