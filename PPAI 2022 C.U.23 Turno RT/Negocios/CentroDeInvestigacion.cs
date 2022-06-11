using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class CentroDeInvestigacion
    {
        private String nombre { get; set; }
        private String sigla { get; set; }
        private String direccion { get; set; }
        private String edificio { get; set; }
        private String piso { get; set; }
        private String coordenadas { get; set; }
        private String telefonosContacto { get; set; }
        private String correoElectronico { get; set; }
        private String numeroResolucionCreacion { get; set; }
        private DateTime fechaResolucionCreacion { get; set; }
        private String reglamento { get; set; }
        private String caracteristicasGenerales { get; set; }
        private DateTime fechaAlta { get; set; }
        private String tiempoAntelacionReserva { get; set; }
        private DateTime fechaBaja { get; set; } 
        private String motivoBaja { get; set; }
        private List<AsignacionCientificoCI> asignacionCientificoCI { get; set; }
        private List<RecursoTecnologico> recursoTecnologico { get; set; }


        public List<string> buscarRTPorTipo(List<TipoRT> tipoRT)
        {
            List<RecursoTecnologico> recurso = null;
            List<string> datosRercurso = null;
            for (int i = 0; i < recursoTecnologico.Count; i++)
            {
                if (recursoTecnologico[i].esTipoRTSeleccionado(tipoRT))
                {
                    recurso.Add(recursoTecnologico[i]);
                }
            }

            foreach (var i in recurso)
            {
                string var = "";
                var += this.nombre;
                var += " " + i.getNumeroRT().ToString();
                var += " " + i.miModeloYMarca();
                var += " " + i.getEstado();
                datosRercurso.Add(var);
            }
            return datosRercurso;
            
        }
       
        public string getNombre()
        {
            return nombre;
        }

        public bool esCientificoMiCentro(Usuario usuario)
        {
            foreach (var asignacion in asignacionCientificoCI)
            {
                if(asignacion.esCientificoMiCentro(usuario))
                {
                    return true;
                }
            }
            return false;
        }

        public string buscarEmailCientifico(Usuario usuario)
        {
            foreach (var asignacion in asignacionCientificoCI)
            {
                if (asignacion.esCientificoMiCentro(usuario))
                {
                    return asignacion.getEmailCientifico();
                }
            }
            return "";
        }

        public RecursoTecnologico esRecursoSeleccionado(string RT)
        {
            foreach (RecursoTecnologico recurso in recursoTecnologico)
            {
                if (recurso.esRecursoSeleccionado(RT))
                {
                    return recurso;
                }
            }
            return null;
        }

        public List<Turno> buscarTurnoPosteriorFechaActual(DateTime fechaActual, string RT)
        {
            return esRecursoSeleccionado(RT).buscarTurnoPosteriorFechaActual(fechaActual);
            
        }

        public bool esCentroSeleccionado(string nombre)
        {
            if(this.nombre == nombre)
            {
                return true;
            }
            return false;
        }
    }
}
