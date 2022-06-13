using PPAI_2022_C.U._23_Turno_RT.Controladores;
using PPAI_2022_C.U._23_Turno_RT.Negocios;
using PPAI_2022_C.U._23_Turno_RT.Repositorio;
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
        public PantallaAdministrarTurno(GestorTurnoRT gestorTurno)//, RepositorioSesion repositorioSesion)
        {
            InitializeComponent();
            this.gestor = gestorTurno;
            //this.sesion = repositorioSesion.getSesionActual();
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
            btn_Opcion_Registrar_Turno.Visible = false;
            CBTipoRT.Visible = true;
            CBTipoRT.Items.Clear();
            CBTipoRT.Items.Add("Todos");
            CBTipoRT.SelectedItem = "Todos";
            foreach (TipoRT tipoRT in tipoRTs)
            {
                CBTipoRT.Items.Add(tipoRT.toString());
            }

        }

        public void solicitarSeleccionTipoRT()
        {
            btn_tipoRT.Visible = true;
        }

        public void tomarTipoRT()
        {
            string[] tipoSelec = CBTipoRT.SelectedItem.ToString().Split('-');
            if(tipoSelec[0] == "Todos")
            {
                MessageBox.Show("No puede seleccionar todos(?");
            }
            else
            {
                gestor.tomarTipoRT(tipoSelec[0], this);
            }
            
        }

        private void btn_tipoRT_Click(object sender, EventArgs e)
        {
            tomarTipoRT();
        }

        public void mostrarDatosRT(List<string> datosRTPorCentro)
        {
            btn_tipoRT.Visible = false;
            CBTipoRT.Visible = false;
            lbl_Centro.Visible = true;
            CB_CentroInvestigacion.Visible = true;
            //gridRT.Visible = true;


            CB_CentroInvestigacion.Items.Clear();
            for (int i = 0; i < datosRTPorCentro.Count(); i++)
            {
                string[] datos = datosRTPorCentro[i].Split('-');
                if (i > 0 && datos[i-1] != datosRTPorCentro[i].Split('-')[0])
                {
                    CB_CentroInvestigacion.Items.Add(datos[0]);
                }
                if(i == 0)
                {
                    CB_CentroInvestigacion.Items.Add(datos[0]);
                }

                gridRT.Rows.Add();
                gridRT.Rows[i].Cells[0].Value = datos[1];
                gridRT.Rows[i].Cells[1].Value = datos[2];
                gridRT.Rows[i].Cells[2].Value = datos[3];
                gridRT.Rows[i].Cells[3].Value = datos[4];
                if (datos[4] == " Disponible")
                {
                    gridRT.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                }
                if (datos[4] == " En mantenimiento")
                {
                    gridRT.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                if (datos[4] == " Inicio Mantenimiento preventivo")
                {
                    gridRT.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }

        public void solicitarSeleccionRT(List<string> datosRTPorCentro)
        {
            
            //gestor.tomarSeleccionRT("seleccionCentro", "SeleccionRT", this);
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

        private void btn_Opcion_Registrar_Turno_Click(object sender, EventArgs e)
        {
            opcionReservarTurno();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CB_CentroInvestigacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridRT.Visible = true;
            btn_seleccionarRT.Visible = true;
            for (int i = 0; i < gridRT.Rows.Count; i++)
            {
                if(gridRT.Rows[i].Cells[0].ToString() != CB_CentroInvestigacion.SelectedIndex.ToString())
                {
                    gridRT.Rows[i].ReadOnly = true;
                }
            }

        }

        private void btn_seleccionarRT_Click(object sender, EventArgs e)
        {
            
        }
    }
}
