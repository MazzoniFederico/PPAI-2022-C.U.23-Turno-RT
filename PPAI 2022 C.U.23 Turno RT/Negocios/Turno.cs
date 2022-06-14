using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class Turno
    {
        private int id;
        private DateTime fechaGeneracion { get; set; }
        private String diaSemana { get; set; }
        private DateTime fechaHoraInicio { get; set; }
        private DateTime fechaHoraFin { get; set; }
        private List<CambioDeEstadoTurno> cambioDeEstadoTurno { get; set; }

        public void setID(int id)
        {
            this.id = id;
        }
        public void setDiaSemana(string str)
        {
            diaSemana = str;
        }
        public void setFechaGeneracion(DateTime fecha)
        {
            fechaGeneracion = fecha;
        }
        public void setFechaHoraInicio(DateTime fecha)
        {
            fechaHoraInicio = fecha;
        }
        public void setFechaHoraFin(DateTime fecha)
        {
            fechaHoraFin = fecha;
        }
        public void setCambioDeEstadoTurno(List<CambioDeEstadoTurno> cambioDeEstadoTurno)
        {
            this.cambioDeEstadoTurno = cambioDeEstadoTurno;
        }

        public bool esPosteriorFechaActual(DateTime fechaActual)
        {
            if (fechaHoraInicio > fechaActual)
            {
                return true;
            }

            return false;
        }

        public int getID()
        {
            return id;
        }

        public string getDiaSemana()
        {
            return diaSemana;
        }
        
        public CambioDeEstadoTurno cambioEstadoActual()
        {
            foreach (CambioDeEstadoTurno cambio in cambioDeEstadoTurno)
            {
                if(cambio.esActual())
                {
                    return cambio;
                }
            }
            return null;
        }

        public DateTime getFechaHoraInicio()
        {
            return fechaHoraInicio;
        }

        public DateTime getFechaHoraFin()
        {
            return fechaHoraFin;
        }

        public bool esTurnoSeleccionado(string numeroTurno)
        {
            if(id.ToString() == numeroTurno)
            {
                return true;
            }
            return false;
        }

        public void actualizarEstadoTurnoReservado(DateTime fechaActual, Estado reservado)
        {
            cambioEstadoActual().setFechaHoraHasta(fechaActual);
            cambioDeEstadoTurno.Add(new CambioDeEstadoTurno(reservado, fechaActual));
        }
    }
}
