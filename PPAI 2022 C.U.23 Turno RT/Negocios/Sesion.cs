using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    public class Sesion
    {
        private DateTime horaFechaInicio { get; set; }
        private DateTime horaFechaFin { get; set; }
        private Usuario usuarioEnSesion { get; set; }

        public void setHoraFechaInicio(DateTime fecha)
        {
            horaFechaInicio = fecha;
        }
        public void setHoraFechaFin(DateTime fecha)
        {
            horaFechaFin = fecha;
        }
        public void setUsuarioEnSesion(Usuario usuario)
        {
            usuarioEnSesion = usuario;
        }
        public Usuario GetUsuario()
        {
            return usuarioEnSesion;
        }

    }
}
