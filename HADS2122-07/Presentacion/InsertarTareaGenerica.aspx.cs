using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Presentacion
{
    public partial class InsertarTareaGenerica : System.Web.UI.Page
    {
        private LogicaNegocio.LN ln = new LogicaNegocio.LN();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_addTarea_Click(object sender, EventArgs e)
        {
            if (RequiredFieldValidator1.IsValid && RequiredFieldValidator2.IsValid && RequiredFieldValidator4.IsValid && RequiredFieldValidator5.IsValid && RequiredFieldValidator6.IsValid && RegularExpressionValidator1.IsValid)
            {
                int horas = int.Parse(TextBox_horasEstimada.Text);
                String cod = TextBox_Cod.Text;
                String desc = TextBox_Descripcion.Text;
                String asig = DropDownList3.SelectedValue;
                String tipoTarea = DropDownList2.SelectedValue;

                if (ln.insertTarea(cod, desc, asig, horas, tipoTarea))
                {
                    agregar.Text = "Tarea insertada.";
                }
                else
                {
                    agregar.Text = "Tarea no insertada.";
                }
            } else
            {
                agregar.Text = "Datos no válidos.";
            }

        }
    }
}