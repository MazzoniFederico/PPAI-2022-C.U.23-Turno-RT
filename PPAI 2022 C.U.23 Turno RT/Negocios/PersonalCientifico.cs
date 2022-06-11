using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class PersonalCientifico
    {
        private int legajo { get; set; }
        private String nombre { get; set; }
        private String apellido { get; set; }
        private String numeroDocumento { get; set; }
        private String correoElectronicoInstitucional { get; set; }
        private String correoElectronicoPersonal { get; set; }
        private String telefonoCelular { get; set; }
        private Usuario usuario { get; set; }


        //Deberia ser SESION
        public bool validarUsuarioLogeado(Usuario usuario)
        {
            if (this.usuario == usuario)
            {
                return true;
            }
            return false;
        }

        public string getEmailInstitucional()
        {
            return correoElectronicoInstitucional;
        }
    }
}
