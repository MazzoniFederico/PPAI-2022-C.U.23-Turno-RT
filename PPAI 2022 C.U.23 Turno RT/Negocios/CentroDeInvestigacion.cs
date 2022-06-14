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


        //Buscamos RT por tipo que no sean baja y formateamos el string de respuesta
        public List<string> buscarRTPorTipo(TipoRT tipoRT)
        {
            List<RecursoTecnologico> recurso = new List<RecursoTecnologico>();
            var datosRercurso = new List<string>();

            //Busca RT por tipo que no sean baja los que cumplan con esto se agregan a una lista
            for (int i = 0; i < recursoTecnologico.Count; i++)
            {
                if (recursoTecnologico[i].esTipoRTSeleccionado(tipoRT))
                {
                    recurso.Add(recursoTecnologico[i]);
                }
            }

            //Realizamos los gets para poder mostrar los datos necesarios y formateamos el mensaje
            foreach (var i in recurso)
            {
                string var = "";
                var += this.nombre;
                var += "- " + i.getNumeroRT().ToString();
                var += "- " + i.miModeloYMarca();
                var += "- " + i.getEstado();
                datosRercurso.Add(var);                
            }
            //Retorna una lista de string con los datos de los distintos RT
            return datosRercurso;
            
        }

       
        public string getNombre()
        {
            return nombre;
        }
        //comapara usuario logeado con usuario de cintifico del centro
        public bool esCientificoMiCentro(Usuario usuario)
        {
            //recorre las asignaciones del centro buscando el usuario correcto
            foreach (var asignacion in asignacionCientificoCI)
            {
                if(asignacion.esCientificoMiCentro(usuario))
                {
                    return true;
                }
            }
            return false;
        }

        //Buscamos el email para el usuario logeado
        public string buscarEmailCientifico(Usuario usuario)
        {
            //busca el personal cientifico que tenga ese usuario
            foreach (var asignacion in asignacionCientificoCI)
            {
                if (asignacion.esCientificoMiCentro(usuario))
                {
                    //busca el mail y lo retorna
                    return asignacion.getEmailCientifico();
                }
            }
            return "";
        }

        //Devuelve el recurso seleccionado
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

        //Busca los turnos para el RT seleccionado
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
