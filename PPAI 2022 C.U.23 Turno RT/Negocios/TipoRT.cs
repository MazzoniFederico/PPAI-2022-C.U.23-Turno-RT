using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    public class TipoRT
    {
        private string nombre { get; set; }
        private string descripcion { get; set; }


        public void setNombre(string nom)
        {
            nombre = nom;
        }

        public void setDescripcion(string des)
        {
            descripcion = des;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string toString()
        {
            string respuesta = "";
            respuesta += nombre;
            respuesta += " - " + descripcion;

            return respuesta;
        }
    }
}
