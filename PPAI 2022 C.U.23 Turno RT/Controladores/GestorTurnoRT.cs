using PPAI_2022_C.U._23_Turno_RT.Boundary_s;
using PPAI_2022_C.U._23_Turno_RT.Negocios;
using PPAI_2022_C.U._23_Turno_RT.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_2022_C.U._23_Turno_RT.Controladores
{
    public class GestorTurnoRT
    {
        private Sesion sesion;
        private string usuarioLogeado;
        private Estado estadoReservado;
        private List<Estado> estados;
        private InterfazNotificadorEmail interfazNotificadorEmail;
        private List<TipoRT> tipoRTs = new List<TipoRT>();
        private TipoRT tipoRTSeleccionada;
        private List<CentroDeInvestigacion> centroDeInvestigacion;
        private List<string> recursoTecnologico = new List<string>();
        private string seleccionadoRecursoTecnologico;
        private CentroDeInvestigacion seleccionadoCentro;
        private string direccionEmailInstitucional;
        private DateTime fechaActual = DateTime.Now;
        private string seleccionadoTurno;

        public GestorTurnoRT(InterfazNotificadorEmail interfazNotificadorEmail)
        {
            this.interfazNotificadorEmail = interfazNotificadorEmail;
        }

        //Empieza el CU
        public void opcionReservarTurno(PantallaAdministrarTurno pantallaAdministrarTurno, Sesion sesion)
        {
            //Traemos los datos desde la Base de datos
            //Centro de investigacion tiene todos los datos para los distintos centros
            RepositorioCentroInvestigacion repoC = new RepositorioCentroInvestigacion();
            RepositorioTipoRT repoTipoRT = new RepositorioTipoRT();
            //Estado todos los estados posibles
            RepositorioEstado repEstado = new RepositorioEstado();
            estados = repEstado.getEstados();
            centroDeInvestigacion = repoC.GetCentroDeInvestigaciones();
            var tipos = repoTipoRT.getTipoRT();

            //Asignamos la sesion logueada
            this.sesion = sesion;

            //Buscamos todos los tipos de recursos
            buscarTipoRT(tipos);
            //Se muestra y solicita la seleccion de TipoRT
            pantallaAdministrarTurno.mostrarTipoRT(tipoRTs);
            pantallaAdministrarTurno.solicitarSeleccionTipoRT();
        }
        public void buscarTipoRT(List<TipoRT> tipos)
        {
            //Buscamos todos los tipos de recursos
            foreach (TipoRT tipo in tipos)
            {
                tipoRTs.Add(tipo);
            }
        }

        //Toma la eleccion o elecciones de tipo RT
        public void tomarTipoRT(string tipoSelec, PantallaAdministrarTurno pantallaAdministrarTurno)
        {
            //Se utilizaria una sobrecarga en caso de que se necesite cargar mas de un tipo, no es el camino del cu
            setSeleccionadoTipoRT(tipoSelec);

            //Busca los RT por el tipo seleccionado y que no sean Baja
            buscarRTPorTipo();

            //Muestra los datos de los RT encontrados
            pantallaAdministrarTurno.mostrarDatosRT(recursoTecnologico);
            pantallaAdministrarTurno.solicitarSeleccionRT();
        }

        public void setSeleccionadoTipoRT(string tipoSelec)
        {
            foreach (TipoRT t in tipoRTs)
            {
                if (t.getNombre() + " " == tipoSelec)
                {
                    tipoRTSeleccionada = t;
                }
            }
        }

        //Busca los RT por tipo seleccionado y que no sean baja
        public void buscarRTPorTipo()
        {
            List<string> recursosCentro = new List<string>();
            //Mientras haya centro de investigacion
            for (var i = 0; i < centroDeInvestigacion.Count; i++)
            {
                //valida == seleccionado y no sea baja por cada recurso
                recursosCentro = centroDeInvestigacion[i].buscarRTPorTipo(tipoRTSeleccionada);
                foreach (string rec in recursosCentro)
                {
                    //recorremos la lista de string para poder asignar los recursos de los distintos centros
                    recursoTecnologico.Add(rec);
                }
            }
        }

        //Toma la seleccion del Recurso tecnologico
        public void tomarSeleccionRT(string seleccionRT, string seleccionCentro, PantallaAdministrarTurno pantallaAdministrarTurno)
        {
            //asigna el recurso (es un string)
            seleccionadoRecursoTecnologico = seleccionRT;

            //verifica y  asigna el centro seleccionado
            centroSeleccionado(seleccionCentro);

            //Verifica usuario logeado y busca el mail para el mismo
            direccionEmailInstitucional = verificarCentroInvestigacion();
            if (direccionEmailInstitucional != "")
            {
 
                //Busca y muestra los datos de los turnos para este RT
                pantallaAdministrarTurno.mostrarTurnos(buscarTurnoPosteriorFechaActual());
                pantallaAdministrarTurno.solicitarSeleccionTurno();
            }
            else
            {
                //Si el cientifico no es de este centro es un caso alternativo
                MessageBox.Show("El usuario no es de ese centro");
            }
        }
        //Verifica que el cientifico sea del centro seleccionado con el user logeado
        public string verificarCentroInvestigacion()
        {
            //Busca el usuario logeado
             Usuario usuario = sesion.getUsuario();
             usuarioLogeado = usuario.getUsuario();
            //comparamos el usuario logeado con los usuarios de los cientificos del centro seleccionado
             return seleccionadoCentro.esCientificoDeMiCentro(usuario);   
        }

        //recorre la lista de centros y guarda el que fue seleccionado
        public void centroSeleccionado(string seleccionado)
        {
            foreach (var centro in centroDeInvestigacion)
            {
                if (centro.esCentroSeleccionado(seleccionado))
                {
                    seleccionadoCentro = centro;
                }
            }      
        }

        //Busca los turnos que tengas fecha de inicio posterior a la fecha actual
        public List<String> buscarTurnoPosteriorFechaActual()
        {
            //Variable para recorrer los turnos encontrados y formatearlos para la pantalla 
            //(por parametro se pasa RT seleccionado y la fecha actual)
            List<string> turnosPorDia = seleccionadoCentro.buscarTurnoPosteriorFechaActual(fechaActual, seleccionadoRecursoTecnologico);

            return turnosPorDia;
        }

        //Toma la seleccion del turno y establece las opciones de notificacion
        public void tomarSeleccionTurno(string turno, PantallaAdministrarTurno pantallaAdministrarTurno)
        {
            string opcionesNotificacion = "Email institucion-Email personal-Mensaje de texto";
            //Asigna el turno seleccionado
            seleccionadoTurno = turno;

            //Muestra los Datos seleccionados para la confirmacion de la reserva
            pantallaAdministrarTurno.mostrarDatosRTSeleccionado(seleccionadoRecursoTecnologico);
            pantallaAdministrarTurno.mostrarDatosTurnoSeleccionado(seleccionadoTurno);
            pantallaAdministrarTurno.mostrarOpcionesNotificacion(opcionesNotificacion);
            //Solicita que confirme la reserva
            pantallaAdministrarTurno.solicitarConfirmacion();
        }

        //Toma la confirmacion de la reserva (por parametro viene la opcion de notificacion
        public void tomarConfirmacionReserva(PantallaAdministrarTurno pantallaAdministrarTurno, string opcionNotificacion, string confirmacion)
        {
            // Busca el estado reservado
            buscarEstadoReservado();
            //Registra la reserva
            registrarReservaTurno();

            //Genera la notificacion
            generarNotificacionEmail(opcionNotificacion, confirmacion);

            //Finaliza el CU mostrando un Message box con mensaje de exito
            finCU(pantallaAdministrarTurno, true);
        }

        //Busca el estado Reservado entre todos los estados posibles
        public void buscarEstadoReservado()
        {
            foreach (Estado estado in estados)
            {
                if(estado.esAmbitoTurno())
                {
                    if (estado.getNombre() == "Reservado")
                    {
                        estadoReservado = estado;
                    } 
                }
            }
        }

        //Registra la reserva del turno
        public void registrarReservaTurno()
        {
            // Busca el turno seleccionado
            Turno turnoSeleccionado = seleccionadoCentro.esRecursoSeleccionado(seleccionadoRecursoTecnologico).esTurnoSeleccionado(seleccionadoTurno);

            //Registrar la reserva del turno seleccionado
            turnoSeleccionado.registrarReservaTurno(fechaActual, estadoReservado);
        }

        //Formatea el mensaje de respuesta y lo manda a la interfaz para que envie el email
        public void generarNotificacionEmail(string opcionNotificacion,string confirmacion)
        {
            string[] mensaje = confirmacion.Split('\n');

            // Valida que no sea un SMS en las otras 2 opciones seria por la misma interfaz
            if (opcionNotificacion != "Mensaje de texto")
            {
                //Por parametro pasa el mensaje y direccion Email
                interfazNotificadorEmail.enviarNotificacionEmail(direccionEmailInstitucional, mensaje);
                interfazNotificadorEmail.ShowDialog();
            }
            
            
        }

        // Fin Cu muestra un mensaje de exito y cierra la pantalla de administrar reserva turno
        public void finCU(PantallaAdministrarTurno pantallaAdministrarTurno, bool condicion)
        {
            if (condicion)
            {
                MessageBox.Show("Turno registrado con exito");
                pantallaAdministrarTurno.Close();
            } 
        }
    }
}
