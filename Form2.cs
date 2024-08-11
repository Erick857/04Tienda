using _04Tienda.Constrollers;
using _04Tienda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04Tienda
{
    public partial class frm_Proveedores : Form
    {
        ProveedorController proveedorController = new ProveedorController();
        public string IdProveedor;

        public frm_Proveedores()
        {
            InitializeComponent();
            CargaLista();
        }

        private void CargaLista()
        {
            lst_Proveedores.DataSource = proveedorController.Todos();
            lst_Proveedores.DisplayMember = "Nombre";
            lst_Proveedores.ValueMember = "IdProveedor";
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            ProveedorModel proveedor = new ProveedorModel
            {
                IdProveedor = string.IsNullOrEmpty(IdProveedor) ? 0 : Convert.ToInt32(IdProveedor),
                Nombre = txt_Nombre.Text
            };

            string respuesta = IdProveedor == null ? proveedorController.Insertar(proveedor) : proveedorController.Editar(proveedor);

            if (respuesta == "ok")
            {
                MessageBox.Show("Guardado con éxito");
                CargaLista();
            }
            else
            {
                MessageBox.Show("Error: " + respuesta);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Proveedores.SelectedItem != null)
            {
                ProveedorModel proveedor = new ProveedorModel
                {
                    IdProveedor = Convert.ToInt32(lst_Proveedores.SelectedValue)
                };

                string respuesta = proveedorController.Eliminar(proveedor);

                if (respuesta == "ok")
                {
                    MessageBox.Show("Eliminado con éxito");
                    CargaLista();
                }
                else
                {
                    MessageBox.Show("Error: " + respuesta);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor de la lista.");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_Nombre.Clear();
            IdProveedor = null;
        }
        private void frm_Proveedores_Load(object sender, EventArgs e)
        {
            // Código que se ejecuta cuando el formulario se carga
            CargaLista();
        }
    }
}