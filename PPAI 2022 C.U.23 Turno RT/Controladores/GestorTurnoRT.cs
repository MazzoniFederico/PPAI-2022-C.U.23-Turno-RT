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
        private List<TipoRT> tipoRTs;
        private TipoRT tipoRTSeleccionada;
        private List<CentroDeInvestigacion> centroDeInvestigacion;
        private List<string> recursoTecnologico = new List<string>();
        private string seleccionadoRecursoTecnologico;
        private CentroDeInvestigacion seleccionadoCentro;
        private string direccionEmail;
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
            //Estado todos los estados posibles
            RepositorioEstado repEstado = new RepositorioEstado();
            estados = repEstado.getEstados();
            centroDeInvestigacion = repoC.GetCentroDeInvestigaciones();

            //Asignamos la sesion logueada
            this.sesion = sesion;

            //Buscamos todos los tipos de recursos
            tipoRTs = buscarTipoRT();
            //Se muestra y solicita la seleccion de TipoRT
            pantallaAdministrarTurno.mostrarTipoRT(tipoRTs);
            pantallaAdministrarTurno.solicitarSeleccionTipoRT();
        }
        public List<TipoRT> buscarTipoRT()
        {
            //Buscamos todos los tipos de recurso desde la BD
            return RepositorioTipoRT.GetTipoRTs();
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

            //verifica y asigna el centro seleccionado
            centroSeleccionado(seleccionCentro);
            if (verificarCentroInvestigacion())
            {
                //obtiene el mail institucional para el usuario logeado
                buscarEmailInstitucional(sesion.getUsuario());

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
        public bool verificarCentroInvestigacion()
        {
            //Busca el usuario logeado
             Usuario usuario = sesion.getUsuario();
             usuarioLogeado = usuario.getUsuario();
            //comparamos el usuario logeado con los usuarios de los cientificos del centro seleccionado
             return seleccionadoCentro.esCientificoMiCentro(usuario);   
        }

        //Busca Email institucional para este camino del caso de uso
        // (Podrian generarse otros metodos para devolver los otros modos de notificacion)
        public void buscarEmailInstitucional(Usuario usuario)
        { 
             direccionEmail = seleccionadoCentro.buscarEmailCientifico(usuario);         
        }

        public void centroSeleccionado(string seleccionado)
        {
            //recorre la lista de centros y guarda el que fue seleccionado
            foreach (var centro in centroDeInvestigacion)
            {
                if (centro.esCentroSeleccionado(seleccionado))
                {
                    seleccionadoCentro = centro;
                }
            }      
        }

        public List<String> buscarTurnoPosteriorFechaActual()
        {
            List<Turno> turnos = seleccionadoCentro.buscarTurnoPosteriorFechaActual(fechaActual, seleccionadoRecursoTecnologico);
            turnos.OrderBy(turno => turno.getFechaHoraInicio());
            List<String> turnosPorDia = new List<string>();
            for (int i = 0; i < turnos.Count; i++)
            {
                turnosPorDia.Add("");
                turnosPorDia[i] = turnos[i].getFechaHoraInicio().ToString();
                turnosPorDia[i] += "-" + turnos[i].cambioEstadoActual().getEstado().getNombre();
                turnosPorDia[i] += "-" + turnos[i].getFechaHoraFin().ToString();
                turnosPorDia[i] += "-" + turnos[i].getID().ToString();
                //a[i][4] = turnos[i].getDiaSemana();
            }
            return turnosPorDia;
        }

        public void tomarSeleccionTurno(string turno, PantallaAdministrarTurno pantallaAdministrarTurno)
        {
            string opcionesNotificacion = "Email institucion-Email personal-Mensaje de texto";
            seleccionadoTurno = turno;
            pantallaAdministrarTurno.mostrarDatosRTSeleccionado(seleccionadoRecursoTecnologico);
            pantallaAdministrarTurno.mostrarDatosTurnoSeleccionado(seleccionadoTurno);
            pantallaAdministrarTurno.mostrarOpcionesNoitificacion(opcionesNotificacion);
            pantallaAdministrarTurno.solicitarConfirmacion();
        }

        public void tomarConfirmacionReserva(PantallaAdministrarTurno pantallaAdministrarTurno, string opcionNotificacion, string confirmacion)
        {
            buscarEstadoReservado();
            actualizarEstadoTurnoReservado();
            generarNotificacionEmail(opcionNotificacion, confirmacion);
            finCU(pantallaAdministrarTurno);
        }

        public void buscarEstadoReservado()
        {
            foreach (Estado estado in estados)
            {
                if (estado.getNombre() == "Reservado") ;
                estadoReservado = estado;
            }
        }

        public void actualizarEstadoTurnoReservado()
        {
            Turno turnoSeleccionado = seleccionadoCentro.esRecursoSeleccionado(seleccionadoRecursoTecnologico).esTurnoSeleccionado(seleccionadoTurno);
            turnoSeleccionado.actualizarEstadoTurnoReservado(fechaActual, estadoReservado);
        }

        public void generarNotificacionEmail(string opcionNotificacion,string confirmacion)
        {
            string[] mensaje = confirmacion.Split('\n'); 

            if (opcionNotificacion != "Mensaje de texto")
            {
                interfazNotificadorEmail.enviarNotificacionEmail(direccionEmail, mensaje);
            }
            interfazNotificadorEmail.ShowDialog();
            
        }

        public void finCU(PantallaAdministrarTurno pantallaAdministrarTurno)
        {
            MessageBox.Show("Turno registrado con exito");
            pantallaAdministrarTurno.Close();
        }
    }
}
