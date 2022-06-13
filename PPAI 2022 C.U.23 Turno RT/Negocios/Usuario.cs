using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    public class Usuario
    {
        private String clave { get; set; }
        private String usuario { get; set; }
        private bool habilitado { get; set; } = false;

        public void setClave(string str)
        {
            clave = str;
        }
        public void setUsuario(string str)
        {
            usuario = str;
        }
        public void setHabilitado(bool habilitado)
        {
            this.habilitado = habilitado;
        }

        public string getUsuario()
        {
            return usuario;
        }

        public bool esUsuarioLog(Usuario user)
        {
            if(usuario == user.getUsuario())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
