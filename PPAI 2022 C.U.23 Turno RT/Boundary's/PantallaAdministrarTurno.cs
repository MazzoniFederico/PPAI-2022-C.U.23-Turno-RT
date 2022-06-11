using PPAI_2022_C.U._23_Turno_RT.Controladores;
using PPAI_2022_C.U._23_Turno_RT.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_2022_C.U._23_Turno_RT.Boundary_s
{
    
    public partial class PantallaAdministrarTurno : Form
    {
        private GestorTurnoRT gestor;
        private Sesion sesion;
        public PantallaAdministrarTurno()
        {
            InitializeComponent();
        }

        public void opcionReservarTurno()
        {
            habilitarPantalla();
        }

        public void habilitarPantalla()
        {
            gestor.opcionReservarTurno(this, sesion);
        }

        public void mostrarTipoRT(List<TipoRT> tipoRTs)
        {
            return;
        }

        public void mostrarDatosRT(List<string> datosRTPorCentro)
        {
            return;
        }

        public void solicitarSeleccionRT()
        {
            gestor.tomarSeleccionRT("seleccionCentro", "SeleccionRT", this);
        }

        public void mostrarTurnos(List<string> turnos)
        {
            //realizar Split de turnos
        }
        public void solicitarSeleccionTurno()
        {
            gestor.tomarSeleccionTurno("turno", this);
        }

        public void mostrarDatosRTSeleccionado(string RT)
        {

        }

        public void mostrarDatosTurnoSeleccionado(string turno)
        {

        }
        public void mostrarOpcionesNoitificacion(string opcionesNotificacion)
        {

        }

        public void solicitarConfirmacion()
        {
            gestor.tomarConfirmacionReserva(this, "");
        }
    }
}
