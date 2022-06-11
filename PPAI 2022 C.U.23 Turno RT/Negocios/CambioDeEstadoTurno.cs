using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class CambioDeEstadoTurno
    {
        private DateTime fechaHoraDesde { get; set; }
        private DateTime fechaHoraHasta { get; set; }
        private Estado estado { get; set; }

        public CambioDeEstadoTurno(Estado nuevoEstado, DateTime desde)
        {
            estado = nuevoEstado;
            fechaHoraDesde = desde;
        }
        public Estado GetEstado()
        {
            return estado;
        }

        public bool esActual()
        {
            if (fechaHoraHasta == null)
            {
                return true;
            }
            return false;
        }

        public void setFechaHoraHasta(DateTime fechaActual)
        {
            fechaHoraHasta = fechaActual;
        }
    }
}
