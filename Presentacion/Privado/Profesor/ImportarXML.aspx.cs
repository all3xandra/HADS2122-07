using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Presentacion
{
    public partial class ImportarXML : System.Web.UI.Page
    {
        private LogicaNegocio.LN ln = new LogicaNegocio.LN();
        private XmlDocument xml_doc = new XmlDocument();
        private XmlNodeList caracs;
        private String xml_file;
        private String xsl_file;

        private String codAsig;
        private String codTarea;
        private String descripcion;
        private int hestimadas;
        private String tipotarea;
        private bool explotacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            codAsig = import_list.SelectedValue;
            xml_file = Server.MapPath("App_Data/" + codAsig + ".xml");
            xsl_file = Server.MapPath("App_Data/VerTablaTareas.xsl");
            if (File.Exists(xml_file))
            {
                try
                {
                    Xml_Table.DocumentSource = xml_file;
                    Xml_Table.TransformSource = xsl_file;

                    xml_doc.Load(xml_file);

                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void import_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void importar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (XmlNode tarea in xml_doc.DocumentElement.ChildNodes)
                {
                    codTarea = tarea.Attributes["codigo"].InnerText;
                    caracs = tarea.ChildNodes;
                    descripcion = caracs[0].InnerText;
                    hestimadas = Int32.Parse(caracs[1].InnerText);
                    tipotarea = caracs[2].InnerText;
                    explotacion = Boolean.Parse(caracs[3].InnerText);

                    ln.insertTareaConExplotacion(codTarea, descripcion, codAsig, hestimadas, explotacion, tipotarea);
                }
            } catch (Exception ex)
            {
                insercion.Text = "Inserción fallada.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://hads22-07.azurewebsites.net/Profesor.aspx");
        }
    }
}