using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using System.Data;
using _04Tienda.Models;
namespace _04Tienda.Constrollers
{
    class PaiseController
    {
      private PaisesModel paisesModel = new PaisesModel();

      public List<PaisesModel> todos()
        {
            List<PaisesModel> listaPaises = new List<PaisesModel>();
            listaPaises = paisesModel.Todos();
            return listaPaises;
        }
        public string insertar(PaisesModel pais)
        {
            return paisesModel.insertar(pais);
        }
        public string editar(PaisesModel pais)
        {
            return paisesModel.editar(pais);
        }
        public string eliminar(PaisesModel pais)
        {
            return paisesModel.eliminar(pais);
        }
    }
}
