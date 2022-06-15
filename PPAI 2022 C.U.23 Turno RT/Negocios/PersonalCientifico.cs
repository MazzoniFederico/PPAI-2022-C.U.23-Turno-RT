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
        private int numeroDocumento { get; set; }
        private String correoElectronicoInstitucional { get; set; }
        private String correoElectronicoPersonal { get; set; }
        private String telefonoCelular { get; set; }
        private Usuario usuario { get; set; }

        public void setLegajo(int numero)
        {
            legajo = numero;
        }
        public void setNombre(string str)
        {
            nombre = str;
        }
        public void setApellido(string str)
        {
            apellido = str;
        }
        public void setNumeroDocumento(int numero)
        {
            numeroDocumento = numero;
        }
        public void setCorreoElectronicoInstitucional(string str)
        {
            correoElectronicoInstitucional = str;
        }
        public void setCorreoElectronicoPersonal(string str)
        {
            correoElectronicoPersonal = str;
        }
        public void setTelefonoCelular(string str)
        {
            telefonoCelular = str;
        }
        public void setUsuario(Usuario user)
        {
            usuario = user;
        }


        public string getEmailInstitucional()
        {
            return correoElectronicoInstitucional;
        }

        //Le pide a usuario que verifique si es el mismo usuario
        public bool validarUsuarioLogeado(Usuario usuario)
        {
            if (this.usuario == usuario) 
            {
                return true;
            }
            return false;
        }

    }
}
