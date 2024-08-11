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
    public partial class frm_Clientes : Form
    {
        ClienteController clienteController = new ClienteController();
        public string IdCliente;

        public frm_Clientes()
        {
            InitializeComponent();
            CargaLista();
        }

        private void CargaLista()
        {
            lst_Clientes.DataSource = clienteController.Todos();
            lst_Clientes.DisplayMember = "Nombre";
            lst_Clientes.ValueMember = "IdCliente";
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            ClienteModel cliente = new ClienteModel
            {
                IdCliente = string.IsNullOrEmpty(IdCliente) ? 0 : Convert.ToInt32(IdCliente),
                Nombre = txt_Nombre.Text,
                Direccion = txt_Direccion.Text
            };

            string respuesta = IdCliente == null ? clienteController.Insertar(cliente) : clienteController.Editar(cliente);

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
            if (lst_Clientes.SelectedItem != null)
            {
                ClienteModel cliente = new ClienteModel
                {
                    IdCliente = Convert.ToInt32(lst_Clientes.SelectedValue)
                };

                string respuesta = clienteController.Eliminar(cliente);

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
                MessageBox.Show("Seleccione un cliente de la lista.");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_Nombre.Clear();
            txt_Direccion.Clear();
            IdCliente = null;
        }
        private void frm_Clientes_Load(object sender, EventArgs e)
        {

        }
    }
}