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

        public String getTiempoAntelacionReserva()
        {
            return tiempoAntelacionReserva;
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
            List<CambioDeEstadoRT> cambioDeEstadoRT = new List<CambioDeEstadoRT>();
            var datosRercurso = new List<string>();

            //Busca RT por tipo que no sean baja los que cumplan con esto se agregan a una lista
            for (int i = 0; i < recursoTecnologico.Count; i++)
            {
                var cambio = recursoTecnologico[i].esTipoRTSeleccionado(tipoRT);
                if (null != cambio)
                {
                    cambioDeEstadoRT.Add(cambio);
                    recurso.Add(recursoTecnologico[i]);
                }
            }

            //Realizamos los gets para poder mostrar los datos necesarios y formateamos el mensaje
            for (int i = 0; i < recurso.Count; i++)
            {
                string var = "";
                var += this.nombre;
                var += "- " + recurso[i].getNumeroRT().ToString();
                var += "- " + recurso[i].miModeloYMarca();
                var += "- " + recurso[i].getEstado(cambioDeEstadoRT[i]);
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
        public string esCientificoDeMiCentro(Usuario usuario)
        {

            //recorre las asignaciones del centro buscando el usuario correcto
            foreach (var asignacion in asignacionCientificoCI)
            {
                if (asignacion.esVigente())
                {
                    string email = asignacion.esCientificoDeMiCentro(usuario);
                    if ("" != email)
                    {
                        return email;
                    }
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
        public List<string> buscarTurnoPosteriorFechaActual(DateTime fechaActual, string RT)
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

        //Envia el mensaje a recurso tecnologico
        public void registrarReservaTurno(string RT, string turno, DateTime fechaActual, Estado estadoReservado)
        {
            esRecursoSeleccionado(RT).registrarReservaTurno(turno, fechaActual, estadoReservado);
        }
    }
}
