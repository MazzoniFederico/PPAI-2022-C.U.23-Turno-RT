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

        public bool esTipoRTSeleccionado(TipoRT tipo)
        {
            //Compara tipo RT seleccionado con el tipo RT de este recurso
            if(tipo.getNombre() == tipoRT.getNombre())
            {
                //Verifica que el ultimo estado sea actual y no sea baja tecnica
                for (int j = 0; j < cambioDeEstadoRT.Count; j++)
                {
                    if(cambioDeEstadoRT[j].queEstadoActivo())
                    {
                        return true;
                    }
                }
                    
            }
            //retorna falso porque no es del mismo tipo o porque es baja 
            return false;
        }

        public int getNumeroRT()
        {
            return numeroRT;
        }

        public string miModeloYMarca()
        {
            string modeloYMarca = "";

            modeloYMarca += modelo.getNombre();
            modeloYMarca += "- " + modelo.getNombreMarca();

            return modeloYMarca;
        }

        public string getEstado()
        {
            string var = "";
            foreach (var cambioEstado in cambioDeEstadoRT)
            {
                 var = cambioEstado.getEstado();
                if (var != null)
                {
                    return var;
                }
            }

            return "Baja";
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
        public List<Turno> buscarTurnoPosteriorFechaActual(DateTime fechaActual)
        {
            List<Turno> turnosPosteriores = new List<Turno>();

            foreach (Turno T in turno)
            {
                if(T.esPosteriorFechaActual(fechaActual))
                {
                    //Agrega el turno que cumpla con esta condicion
                    turnosPosteriores.Add(T);
                }
            }

            return turnosPosteriores;
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
    }

    
}
