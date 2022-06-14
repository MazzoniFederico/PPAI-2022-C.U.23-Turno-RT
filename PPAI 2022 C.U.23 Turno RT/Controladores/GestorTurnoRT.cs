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

        public void opcionReservarTurno(PantallaAdministrarTurno pantallaAdministrarTurno, Sesion sesion)
        {
            RepositorioCentroInvestigacion repoC = new RepositorioCentroInvestigacion();
            RepositorioEstado repEstado = new RepositorioEstado();
            estados = repEstado.getEstados();
            centroDeInvestigacion = repoC.GetCentroDeInvestigaciones();
            this.sesion = sesion;
            tipoRTs = buscarTipoRT();
            pantallaAdministrarTurno.mostrarTipoRT(tipoRTs);
            pantallaAdministrarTurno.solicitarSeleccionTipoRT();
        }
        public List<TipoRT> buscarTipoRT()
        {
            return RepositorioTipoRT.GetTipoRTs();
        }

        public void tomarTipoRT(string tipoSelec, PantallaAdministrarTurno pantallaAdministrarTurno)
        {
            foreach (TipoRT t in tipoRTs)
            {
                if(t.getNombre() + " "  == tipoSelec)
                {
                    tipoRTSeleccionada = t;
                }
            }
            buscarRTPorTipo();
            pantallaAdministrarTurno.mostrarDatosRT(recursoTecnologico);
            pantallaAdministrarTurno.solicitarSeleccionRT();
        }

        public void buscarRTPorTipo()
        {
            List<string> recursosCentro = new List<string>();
            //List<string> recursoXCentro = new List<string>();
            for (var i = 0; i < centroDeInvestigacion.Count; i++)
            {
                //centro.Add(centroDeInvestigacion[i]);
                recursosCentro = centroDeInvestigacion[i].buscarRTPorTipo(tipoRTSeleccionada);
                for (int j = 0; j < recursosCentro.Count; j++)
                {
                    recursoTecnologico.Add(recursosCentro[j]);
                }
            }
            var a = recursosCentro;
        }

        public void tomarSeleccionRT(string seleccionRT, string seleccionCentro, PantallaAdministrarTurno pantallaAdministrarTurno)
        {
            seleccionadoRecursoTecnologico = seleccionRT;
            centroSeleccionado(seleccionCentro);
            if (verificarCentroInvestigacion())
            {
                buscarEmailInstitucional(sesion.getUsuario());
                pantallaAdministrarTurno.mostrarTurnos(buscarTurnoPosteriorFechaActual());
                pantallaAdministrarTurno.solicitarSeleccionTurno();
            }
            else
            {
                MessageBox.Show("El usuario no es de ese centro");
            }
        }

        public bool verificarCentroInvestigacion()
        {
             Usuario usuario = sesion.getUsuario();
             return seleccionadoCentro.esCientificoMiCentro(usuario);   
        }

        public void buscarEmailInstitucional(Usuario usuario)
        { 
             direccionEmail = seleccionadoCentro.buscarEmailCientifico(usuario);         
        }

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

        public void tomarConfirmacionReserva(PantallaAdministrarTurno pantallaAdministrarTurno, string opcionNotificacion)
        {
            buscarEstadoReservado();
            actualizarEstadoTurnoReservado();
            generarNotificacionEmail(opcionNotificacion);
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

        public void generarNotificacionEmail(string opcionNotificacion)
        {
            string mensaje = "Turno reservado en " + seleccionadoCentro.getNombre() + " " +  seleccionadoRecursoTecnologico + " " +  seleccionadoTurno;

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
