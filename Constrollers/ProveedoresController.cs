using _04Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _04Tienda.Constrollers
{
    class ProveedorController
    {
        private ProveedorModel proveedorModel = new ProveedorModel();

        public List<ProveedorModel> Todos()
        {
            return proveedorModel.Todos();
        }

        public string Insertar(ProveedorModel proveedor)
        {
            return proveedorModel.Insertar(proveedor);
        }

        public string Editar(ProveedorModel proveedor)
        {
            return proveedorModel.Editar(proveedor);
        }

        public string Eliminar(ProveedorModel proveedor)
        {
            return proveedorModel.Eliminar(proveedor);
        }
    }
}

