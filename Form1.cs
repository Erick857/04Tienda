using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using _04Tienda.Constrollers;
using _04Tienda.Models;


namespace _04Tienda
{
    public partial class frm_Paises : Form
    {
        PaiseController paiseController=new PaiseController();
        public string IdPais;
        public frm_Paises()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            PaisesModel pais = new PaisesModel
            {
                IdPais = Convert.ToInt32 (IdPais),
                Detalle = txt_Detalle.Text
            };
            if (Convert.ToInt32(IdPais) > 0)
            {
                //Editar
                respuesta = paiseController.editar(pais);
            }
            else
            {
                respuesta = paiseController.insertar(pais);               
            }
            if (respuesta == "ok")
            {
                IdPais = null;
                cargaLista();
                MessageBox.Show("Se guardo con exito");
            }
            else
            {
                IdPais = null;
                MessageBox.Show("Error al guardar");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frm_Paises_Load(object sender, EventArgs e)
        {
            cargaLista();
        }
        public void cargaLista()
        {
          
            lst_Paises.DataSource = paiseController.todos();
            lst_Paises.DisplayMember = "Detalle";
            lst_Paises.ValueMember = "IdPais";

        }

        private void lst_Paises_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (lst_Paises.SelectedItem != null)
            {
                 IdPais = lst_Paises.SelectedValue.ToString();               
                txt_Detalle.Text = lst_Paises.GetItemText(lst_Paises.SelectedItem);
            }
            else
            {
                MessageBox.Show("Seleccione un pais de la lista");
            }
          
        }

        private void lst_Paises_DoubleClick(object sender, EventArgs e)
        {
            IdPais = lst_Paises.SelectedValue.ToString();
            txt_Detalle.Text = lst_Paises.GetItemText(lst_Paises.SelectedItem);
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            PaisesModel pais = new PaisesModel
            {
                IdPais = Convert.ToInt32(lst_Paises.SelectedValue)

            };
            paiseController.eliminar(pais);
           

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
