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

        public bool esTipoRTSeleccionado(List<TipoRT> tipo)
        {
            for (int i = 0; i < tipo.Count; i++)
            {
                if(tipo[i] == tipoRT)
                {
                    for (int j = 0; j < cambioDeEstadoRT.Count; j++)
                    {
                        cambioDeEstadoRT[j].queEstadoActivo();
                    }
                    
                }
            }
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
            modeloYMarca += " " + modelo.getNombreMarca();

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

            return "Baja Definitiva";
        }

    }

    
}
