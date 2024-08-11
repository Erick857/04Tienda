using _04Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Tienda.Constrollers
{
    class ClienteController
    {
        private ClienteModel clienteModel = new ClienteModel();

        public List<ClienteModel> Todos()
        {
            return clienteModel.Todos();
        }

        public string Insertar(ClienteModel cliente)
        {
            return clienteModel.Insertar(cliente);
        }

        public string Editar(ClienteModel cliente)
        {
            return clienteModel.Editar(cliente);
        }

        public string Eliminar(ClienteModel cliente)
        {
            return clienteModel.Eliminar(cliente);
        }
    }
}
