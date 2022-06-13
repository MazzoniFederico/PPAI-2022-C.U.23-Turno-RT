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
        private String telefonoContacto { get; set; }
        private String correoElectronico { get; set; }
        private int numeroResolucionCreacion { get; set; }
        private DateTime fechaResolucionCreacion { get; set; }
        private String reglamento { get; set; }
        private String caracteristicasGenerales { get; set; }
        private DateTime fechaAlta { get; set; }
        private String tiempoAntelacionReserva { get; set; }
        private DateTime fechaBaja { get; set; } 
        private String motivoBaja { get; set; }
        private List<AsignacionCientificoCI> asignacionCientificoCI { get; set; }
        private List<RecursoTecnologico> recursoTecnologico { get; set; }

        public void setFechaAlta(DateTime fecha)
        {
            fechaAlta = fecha;
        }
        public void setFechaBaja(DateTime fecha)
        {
            fechaBaja = fecha;
        }
        public void setFechaResolucionCreacion(DateTime fecha)
        {
            fechaResolucionCreacion = fecha;
        }
        public void setSigla(string sigla)
        {
            this.sigla = sigla;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void setDireccion(string direccion)
        {
            this.direccion = direccion;
        }
        public void setEdificio(string edificio)
        {
            this.edificio = edificio;
        }
        public void setPiso(string piso)
        {
            this.piso = piso;
        }
        public void setCoordenadas(string coordenadas)
        {
            this.coordenadas = coordenadas;
        }
        public void setTelefonoContacto(string telefono)
        {
            telefonoContacto = telefono;
        }
        public void setCorreoElectronico(string correo)
        {
            correoElectronico = correo;
        }
        public void setNumeroResolucionCreacion(int numero)
        {
            numeroResolucionCreacion = numero;
        }
        public void setReglamento(string reglamento)
        {
            this.reglamento = reglamento;
        }
        public void setCaracteristicasGenerales(string caracteristicas)
        {
            caracteristicasGenerales = caracteristicas;
        }
        public void setTiempoAntelacionReserva(string tiempoAntelacion)
        {
            this.tiempoAntelacionReserva = tiempoAntelacion;
        }
        public void setMotivoBaja(string motivo)
        {
            motivoBaja = motivo;
        }
        public void setAsignacionCientificoCI(List<AsignacionCientificoCI> asignacionCientificoCI)
        {
            this.asignacionCientificoCI = asignacionCientificoCI;
        }
        public void setRecursoTecnologico(List<RecursoTecnologico> recurso)
        {
            recursoTecnologico = recurso;
        }
        public List<RecursoTecnologico> getRecursoTecnologicos()
        {
            return recursoTecnologico;
        }



        public List<string> buscarRTPorTipo(TipoRT tipoRT)
        {
            //int numRec = new int();
            List<RecursoTecnologico> recurso = new List<RecursoTecnologico>();
            var datosRercurso = new List<string>();
            for (int i = 0; i < recursoTecnologico.Count; i++)
            {
                if (recursoTecnologico[i].esTipoRTSeleccionado(tipoRT))
                {
                    recurso.Add(recursoTecnologico[i]);
                    //numRec += 1;
                }
            }

            //datosRercurso.Clear();
            foreach (var i in recurso)
            {
                string var = "";
                var += this.nombre;
                var += "- " + i.getNumeroRT().ToString();
                var += "- " + i.miModeloYMarca();
                var += "- " + i.getEstado();
                datosRercurso.Add(var);
                //numRec = i.getNumeroRT();
                
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
