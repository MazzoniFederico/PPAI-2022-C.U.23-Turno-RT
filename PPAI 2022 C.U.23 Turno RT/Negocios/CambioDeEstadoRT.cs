using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class CambioDeEstadoRT
    {
        private DateTime fechaHoraDesde { get; set; }
        private DateTime fechaHoraHasta { get; set; }
        private Estado estado { get; set; }


        public void setFechaHoraDesde(DateTime fecha)
        {
            fechaHoraDesde = fecha;
        }
        public void setFechaHoraHasta(DateTime fecha)
        {
            fechaHoraHasta = fecha;
        }
        public void setEstado(Estado estado)
        {
            this.estado = estado;
        }

        public bool queEstadoActivo()
        {
            //verifica que el cambio de estado sea el actual
            if (esActual())
            {
                //verifica si esta dado de baja (si esta dado de baja retorna true)
                if(estado.estasDadoDeBaja())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool esActual()
        {
            //Compara si la fecha hora Hasta es "Null" pero DateTime no acepta formato null
            if (fechaHoraHasta.ToString() == "1/1/0001 00:00:00")
            {
                return true;
            }
            return false;
        }

        public string getEstado()
        {
            if(esActual())
            {
                return estado.getNombre();
            }
            else
            {
                return null;
            }
        }
    }
}
