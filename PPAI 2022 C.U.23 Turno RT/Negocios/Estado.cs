using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class Estado
    {
        private String nombre { get; set; }
        private String descripcion { get; set; }
        private String ambito { get; set; } /* usaria la otra tipificacion, pero no se si se puede en diseño*/
        private bool esReservable { get; set; }
        private bool esCancelable { get; set; }

        public void setNombre(string str)
        {
            nombre = str;
        }
        public void setDescripcion(string str)
        {
            descripcion = str;
        }
        public void setAmbito(string str)
        {
            ambito = str;
        }

        public bool estasDadoDeBaja()
        {
            if (nombre != "Baja definitiva")
            {
                return false;
            }
            return true;
        }

        public string getNombre()
        {
            return nombre;
        }

    }
}
