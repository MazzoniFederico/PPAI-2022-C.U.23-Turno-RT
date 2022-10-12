using PPAI_2022_C.U._23_Turno_RT.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Repositorio
{
    class RepositorioTurno
    {
        public void desmaterializar(Turno turno)
        {
            BaseDatos bd = new BaseDatos();

            
            foreach (CambioDeEstadoTurno cambio in turno.GetCambioDeEstadoTurnos())
            {
                modificarCambioEstado(cambio);
            }
        }

        public void modificarCambioEstado(CambioDeEstadoTurno cambioDeEstadoTurno)
        {
            string sql = "UPDATE CAMBIO_ESTADO_TURNO Set";
            sql += "fechaHoraHasta = '" + cambioDeEstadoTurno.getFechaHoraHasta().ToString() + "'";
            sql += " WHERE fechaHoraDesde = '" + cambioDeEstadoTurno.getFechaHoraHasta().ToString() + "' AND ";
        }
    }
}
