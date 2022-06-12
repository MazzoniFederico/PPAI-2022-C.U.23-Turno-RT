using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class Modelo
    {
        private String nombre { get; set; }
        private Marca marca { get; set; }

        public void setNombre(string str)
        {
            nombre = str;
        }
        public void setMarca(Marca marca)
        {
            this.marca = marca;
        }
        public string getNombre()
        {
            return nombre;
        }

        public string getNombreMarca()
        {
            return marca.getNombre();
        }
    }
}
