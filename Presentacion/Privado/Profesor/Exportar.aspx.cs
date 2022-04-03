using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.IO;

namespace Presentacion
{
    public partial class Exportar : System.Web.UI.Page
    {
        private SqlDataAdapter dapTareas = new SqlDataAdapter();
        private DataSet dsTareas = new DataSet();
        private DataTable dtTareas = new DataTable();

        private XmlDocument doc = new XmlDocument();

        private LogicaNegocio.LN ln = new LogicaNegocio.LN();
        private AccesoDatos.BBDD bd = new AccesoDatos.BBDD();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            dapTareas = ln.getTareasFromDLL(export_list.SelectedValue, Session["email"].ToString());

            SqlCommandBuilder buildTareas = new SqlCommandBuilder(dapTareas);
            dapTareas.Fill(dsTareas, "TareaGenerica");
            dtTareas = dsTareas.Tables["TareaGenerica"];
            gridview.DataSource = dtTareas;
            gridview.DataBind();
            Session["tareas_genericas"] = dsTareas;

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://hads22-07.azurewebsites.net/Profesor.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            dtTareas.DataSet.DataSetName= "tareas";
            dtTareas.TableName = "tarea";
            dtTareas.Columns[0].ColumnMapping = MappingType.Attribute;
            dtTareas.Columns[2].ColumnName = "hestimadas";
            dtTareas.Columns[4].ColumnName = "tipotarea";
            dtTareas.Columns[3].SetOrdinal(dtTareas.Columns.Count - 1);

            dsTareas.WriteXml(Server.MapPath("App_Data/") + export_list.SelectedValue + ".xml");
            exportado.Text = "XML Exportado";
            /*
            XmlElement root = doc.CreateElement("tareas");
            doc.AppendChild(root);

            for (int i=0; i < gridview.Rows.Count; i++)
            {
                XmlElement tarea = doc.CreateElement("tarea");
                root.AppendChild(tarea);

                XmlAttribute codigo = doc.CreateAttribute("codigo");
                codigo.Value = gridview.Rows[i].Cells[0].Text;
                tarea.Attributes.Append(codigo);
                
                XmlElement descripcion = doc.CreateElement("descripcion");
                descripcion.InnerText = gridview.Rows[i].Cells[1].Text;
                tarea.AppendChild(descripcion);

                XmlElement hestimadas = doc.CreateElement("hestimadas");
                hestimadas.InnerText = gridview.Rows[i].Cells[2].Text;
                tarea.AppendChild(hestimadas);

                XmlElement tipotarea = doc.CreateElement("tipotarea");
                tipotarea.InnerText = gridview.Rows[i].Cells[4].Text;
                tarea.AppendChild(tipotarea);

                XmlElement explotacion = doc.CreateElement("explotacion");
                CheckBox cb = (CheckBox)gridview.FindControl("gridview_ctl00");
                if (cb != null) {
                    explotacion.InnerText = cb.Checked.ToString();
                }
                tarea.AppendChild(explotacion);

            }
            doc.Save(@Server.MapPath("App_Data/") + export_list.SelectedValue + ".xml");
            exportado.Text = "Exportado";
            //doc.WriteXML(Server.MapPath("App_Data"));
            */
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            dtTareas.DataSet.DataSetName = "tareas";
            dtTareas.TableName = "tarea";
            dtTareas.Columns[0].ColumnMapping = MappingType.Attribute;
            dtTareas.Columns[2].ColumnName = "hestimadas";
            dtTareas.Columns[4].ColumnName = "tipotarea";
            dtTareas.Columns[3].SetOrdinal(dtTareas.Columns.Count - 1);

            string json = JsonConvert.SerializeObject(dtTareas);
            using (var u = new StreamWriter(Server.MapPath("App_Data/" + export_list.Text + ".json"), true))
            {
                u.WriteLine(json.ToString());
                u.Close();
                exportado.Text = "Json Exportado.";
            }

        }
    }
}