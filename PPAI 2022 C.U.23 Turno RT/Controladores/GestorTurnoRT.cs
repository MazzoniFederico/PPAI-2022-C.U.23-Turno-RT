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
            centroSeleccionado(seleccionCentro, seleccionRT);
            if (verificarCentroInvestigacion())
            {
                buscarEmailInstitucional(sesion.GetUsuario());
                pantallaAdministrarTurno.mostrarTurnos(buscarTurnoPosteriorFechaActual());
                pantallaAdministrarTurno.solicitarSeleccionTurno();
            }
        }

        public bool verificarCentroInvestigacion()
        {
             Usuario usuario = sesion.GetUsuario();
             return seleccionadoCentro.esCientificoMiCentro(usuario);   
        }

        public void buscarEmailInstitucional(Usuario usuario)
        { 
             direccionEmail = seleccionadoCentro.buscarEmailCientifico(usuario);         
        }

        public void centroSeleccionado(string seleccionado, string seleccionRT)
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
            List<String> turnosPorDia = null;
            for (int i = 0; i < turnos.Count; i++)
            {
                turnosPorDia[i] = turnos[i].getFechaHoraInicio().ToString("dd-MM-yyyy");
                turnosPorDia[i] += " " + turnos[i].cambioEstadoActual().getEstado().getNombre();
                turnosPorDia[i] += " " + turnos[i].getFechaHoraInicio().ToString();
                turnosPorDia[i] += " " + turnos[i].getFechaHoraFin().ToString();
                //a[i][4] = turnos[i].getDiaSemana();
            }
            return turnosPorDia;
        }

        public void tomarSeleccionTurno(string turno, PantallaAdministrarTurno pantallaAdministrarTurno)
        {
            string opcionesNotificacion = "";
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
            Estado e = new Estado();
            estadoReservado = e;
        }

        public void actualizarEstadoTurnoReservado()
        {
            Turno turnoSeleccionado = seleccionadoCentro.esRecursoSeleccionado(seleccionadoRecursoTecnologico).esTurnoSeleccionado(seleccionadoTurno);
            turnoSeleccionado.actualizarEstadoTurnoReservado(fechaActual, estadoReservado);
        }

        public void generarNotificacionEmail(string opcionNotificacion)
        {
            interfazNotificadorEmail.enviarNotificacionEmail(opcionNotificacion, direccionEmail);
        }

        public void finCU(PantallaAdministrarTurno pantallaAdministrarTurno)
        {
            MessageBox.Show("Turno registrado con exito");
            pantallaAdministrarTurno.Close();
        }
    }
}
