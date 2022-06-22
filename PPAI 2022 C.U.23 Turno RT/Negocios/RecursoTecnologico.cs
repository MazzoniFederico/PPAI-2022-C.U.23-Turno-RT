using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class RecursoTecnologico
    {
        private int numeroRT { get; set; }
        private DateTime fechaAlta { get; set; }
        private String imagenes { get; set; } /* no estoy seguro */
        private int periodicidadMantenimientoPreventivo { get; set; }
        private int duracionMantenimientoPreventivo { get; set; }
        private int fraccionHorarioTurnos { get; set; }
        private List<Turno> turno { get; set; }
        private List<CambioDeEstadoRT> cambioDeEstadoRT { get; set; }
        private TipoRT tipoRT { get; set;  }
        private Modelo modelo { get; set; }

        public void setNumeroRT(int numero)
        {
            numeroRT = numero;
        }
        public void setFechaAlta(DateTime fecha)
        {
            fechaAlta = fecha;
        }
        public void setImagenes(string imagen)
        {
            imagenes = imagen;
        }
        public void setPeriodicidadMantenimientoPreventivo(int numero)
        {
            periodicidadMantenimientoPreventivo = numero;
        }
        public void setDuracionMantenimientoPreventivo(int numero)
        {
            duracionMantenimientoPreventivo = numero;
        }
        public void setFraccionHorarioTurnos(int numero)
        {
            fraccionHorarioTurnos = numero;
        }
        public void setTurno(List<Turno> turno)
        {
            this.turno = turno;
        }
        public void setCambioEstadoRT(List<CambioDeEstadoRT> cambioEstado)
        {
            cambioDeEstadoRT = cambioEstado;
        }
        public void setTipoRT(TipoRT tipo)
        {
            tipoRT = tipo;
        }
        public void setModelo(Modelo modelo)
        {
            this.modelo = modelo;
        }

        public CambioDeEstadoRT esTipoRTSeleccionado(TipoRT tipo)
        {
            //Compara tipo RT seleccionado con el tipo RT de este recurso
            if(tipoRT.esTipoRTSeleccionado(tipo))
            {
                //Verifica que el ultimo estado sea actual y no sea baja tecnica
                for (int j = 0; j < cambioDeEstadoRT.Count; j++)
                {
                    if(cambioDeEstadoRT[j].queEstadoActivo())
                    {
                        return cambioDeEstadoRT[j];
                    }
                }
                    
            }
            //retorna falso porque no es del mismo tipo o porque es baja 
            return null;
        }

        public int getNumeroRT()
        {
            return numeroRT;
        }

        public string miModeloYMarca()
        {
            string modeloYMarca = "";

            modeloYMarca += modelo.getNombre();
            modeloYMarca += "- " + modelo.miMarca();

            return modeloYMarca;
        }

        public bool esRecursoSeleccionado(string RT)
        {
            if(RT == " " + numeroRT.ToString())
            {
                return true;
            }
            return false;
        }

        //Busca entre los turnos del recurso los que son posteriores a la fecha actual
        public List<string> buscarTurnoPosteriorFechaActual(DateTime fechaActual)
        {
            List<string> turnosDia = new List<string>();

            for (int i = 0; i < turno.Count; i++)
            {
                if (turno[i].esPosteriorFechaActual(fechaActual))
                {
                    //Agrega el turno que cumpla con esta condicion
                    turnosDia.Add("");
                    turnosDia[i] = turno[i].getFechaHoraInicio().ToString();
                    turnosDia[i] += "-" + turno[i].cambioEstadoActual().getEstado().getNombre();
                    turnosDia[i] += "-" + turno[i].getFechaHoraFin().ToString();
                    turnosDia[i] += "-" + turno[i].getID().ToString();
                }
            }
            return turnosDia;
        }

        //Busca el turno seleccionado para el RT seleccionado
        public Turno esTurnoSeleccionado(String turnoSeleccionado)
        {
            foreach (Turno T in turno)
            {
                //valida que sea ese turno y lo retorna
                if(T.esTurnoSeleccionado(turnoSeleccionado))
                {
                    return T;
                }
            }
            return null;
        }

        public string getEstado(CambioDeEstadoRT cambio)
        {
            return cambio.getEstado();
        }

        //Envia el mensaje a turno
        public void registrarReservaTurno(string turno, DateTime fechaActual, Estado estadoReservado)
        {
            esTurnoSeleccionado(turno).registrarReservaTurno(fechaActual, estadoReservado);
        }
    }

    
}
