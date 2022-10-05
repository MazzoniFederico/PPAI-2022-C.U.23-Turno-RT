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
        public PantallaAdministrarTurno(GestorTurnoRT gestorTurno, RepositorioSesion repSesion)
        {
            InitializeComponent();
            this.gestor = gestorTurno;
            this.sesion = repSesion.getSesionActual();
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
            btn_opcionRegistrarTurno.Visible = false;
            CB_tipoRT.Visible = true;
            CB_tipoRT.Items.Clear();
            CB_tipoRT.Items.Add("Todos");
            CB_tipoRT.SelectedItem = "Todos";
            foreach (TipoRT tipoRT in tipoRTs)
            {
                CB_tipoRT.Items.Add(tipoRT.toString());
            }

        }

        public void solicitarSeleccionTipoRT()
        {
            btn_tipoRT.Visible = true;
        }

        public void tomarTipoRT()
        {
            string[] tipoSelec = CB_tipoRT.SelectedItem.ToString().Split('-');
            if(tipoSelec[0] == "Todos")
            {
                MessageBox.Show("No puede seleccionar todos");
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
            CB_tipoRT.Visible = false;
            lbl_centro.Visible = true;
            CB_centroInvestigacion.Visible = true;
            //gridRT.Visible = true;
            


            CB_centroInvestigacion.Items.Clear();
            for (int i = 0; i < datosRTPorCentro.Count(); i++)
            {
                string[] datos = datosRTPorCentro[i].Split('-');
                if (i > 0 && datos[i-1] != datosRTPorCentro[i].Split('-')[0])
                {
                    CB_centroInvestigacion.Items.Add(datos[0]);
                }
                if(i == 0)
                {
                    CB_centroInvestigacion.Items.Add(datos[0]);
                }

                gridRT.Rows.Add();
                gridRT.Rows[i].Cells[0].Value = datos[0];
                gridRT.Rows[i].Cells[1].Value = datos[1];
                gridRT.Rows[i].Cells[2].Value = datos[2];
                gridRT.Rows[i].Cells[3].Value = datos[3];
                gridRT.Rows[i].Cells[4].Value = datos[4];
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

        public void solicitarSeleccionRT()
        {
            //MessageBox.Show("Seleccione un centro de investigacion para ver los recursos existentes");
        }

        public void tomarSeleccionRT()
        {
            gestor.tomarSeleccionRT(gridRT.CurrentRow.Cells[1].Value.ToString(), gridRT.CurrentRow.Cells[0].Value.ToString(), this);
        }

        //Muestra los datos de los turnos encontrados
        public void mostrarTurnos(List<string> turnos)
        {
            Grid_calendario.Visible = true;
            gridRT.Visible = false;
            btn_seleccionarRT.Visible = false;
            btn_dia.Visible = true;
            CB_centroInvestigacion.Visible = false;
            lbl_centro.Visible = false;

            //Carga el calendario
            if (cargarCalendario(turnos))
            {
                //Carga los horarios
                cargarHorarios(turnos);
            }
            else
            {
                this.Close();
            }
            

        }

        //carga el calendario realizando splits de turnos
        public bool cargarCalendario(List<string> turnos)
        {
            bool hayDisponible = false;
            for (int i = 0; i < 30; i++)
            {
                Grid_calendario.Rows.Add();
                Grid_calendario.Rows[i].Cells[0].Value = DateTime.Now.AddDays(i).ToString("dd-MM-yyyy").Split('-')[0];
                Grid_calendario.Rows[i].Cells[1].Value = DateTime.Now.AddDays(i).ToString("dd-MM-yyyy").Split('-')[1];
                Grid_calendario.Rows[i].Cells[2].Value = DateTime.Now.AddDays(i).ToString("dd-MM-yyyy").Split('-')[2];
            }
            for (int i = 0; i < turnos.Count; i++)
            {
                string[] datos = turnos[i].Split('-');
                string[] fechaInicial = datos[0].Split(' ')[0].Split('/');
                if (datos[1] == "Disponible")
                {
                    for (int j = 0; j < Grid_calendario.Rows.Count; j++)
                    {
                        if(Grid_calendario.Rows[j].Cells[0].Value.ToString() == fechaInicial[0])
                        {
                            Grid_calendario.Rows[j].DefaultCellStyle.BackColor = Color.Blue;
                            hayDisponible = true;
                            break;
                        }
                    }
                }
            }

            //Camino alternativo cu no hay turnos disponibles para ese RT
            if (!hayDisponible)
            {
                MessageBox.Show("NO SE ENCONTRARON TURNOS DISPONIBLES PARA ESTE RECURSO TECNOLOGICO");
                gestor.finCU(this, false);
                return false;
                
            }
            else
            {
                return true;
            }
        }

        //carga el horarios realizando splits de turnos
        public void cargarHorarios(List<string> turnos)
        {
            for (int i = 0; i < turnos.Count; i++)
            {
                string[] datos = turnos[i].Split('-');
                string[] horasInicio = datos[0].Split(' ');
                string[] horasFin = datos[2].Split(' ');
                string[] dia = datos[0].Split(' ')[0].Split('/');


                Grid_turnos.Rows.Add();
                Grid_turnos.Rows[i].Cells[0].Value = dia[0] + dia[1];
                Grid_turnos.Rows[i].Cells[1].Value = horasInicio[1];
                Grid_turnos.Rows[i].Cells[2].Value = horasFin[1];
                Grid_turnos.Rows[i].Cells[3].Value = datos[1];
                Grid_turnos.Rows[i].Cells[4].Value = datos[3];

                if (Grid_turnos.Rows[i].Cells[3].Value.ToString() == "Disponible")
                {
                    Grid_turnos.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                }
                if (Grid_turnos.Rows[i].Cells[3].Value.ToString() == "Reserva pendiente confirmacion")
                {
                    Grid_turnos.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                }
                if (Grid_turnos.Rows[i].Cells[3].Value.ToString() == "Reservado")
                {
                    Grid_turnos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                if (Grid_turnos.Rows[i].Cells[3].Value.ToString() == "Cancelado")
                {
                    Grid_turnos.CurrentCell = null;
                    Grid_turnos.Rows[i].Visible = false;
                }
            }
        }

        //Muestra un mensaje
        public void solicitarSeleccionTurno()
        {
            //MessageBox.Show("Seleccione una fecha, recuerde que las fechas en rojo no tienen turnos disponibles");
        }

        //Toma seleccion de turno
        public void tomarSeleccionTurno()
        {
            gestor.tomarSeleccionTurno(Grid_turnos.SelectedRows[0].Cells[4].Value.ToString(), this);
        }

        public void mostrarDatosRTSeleccionado(string RT)
        {
            lbl_datosRT.Visible = true;
            Grid_calendario.Visible = false;
            Grid_turnos.Visible = false;
            btn_dia.Visible = false;
            btn_seleccionarTurno.Visible = false;
            string datosRT = "Numero RT: " + gridRT.CurrentRow.Cells[1].Value.ToString();
            datosRT += "\nModelo " + gridRT.CurrentRow.Cells[2].Value.ToString();
            datosRT += "\nMarca: " + gridRT.CurrentRow.Cells[3].Value.ToString();

            lbl_datosRT.Text = datosRT;
        }

        public void mostrarDatosTurnoSeleccionado(string turno)
        {
            lbl_datosTurno.Visible = true;
            string datosRT = "Hora inicio turno : " + Grid_turnos.CurrentRow.Cells[1].Value.ToString();
            datosRT += "\nHora Fin turno : " + Grid_turnos.CurrentRow.Cells[2].Value.ToString();

            lbl_datosTurno.Text = datosRT;
        }
        public void mostrarOpcionesNotificacion(string opcionesNotificacion)
        {
            lbl_modoNotificacion.Visible = true;
            CB_modoNotificacion.Visible = true;
            string[] opcion = opcionesNotificacion.Split('-');

            foreach (string op in opcion)
            {
                CB_modoNotificacion.Items.Add(op);
            }
            CB_modoNotificacion.SelectedIndex = 0;
        }

        public void solicitarConfirmacion()
        {
            btn_confirmarTurno.Visible = true;
            btn_cancelarTurno.Visible = true;
        }

        public void tomarConfirmacionReserva()
        {
            string mensaje = lbl_datosRT.Text + "\n" + lbl_datosTurno.Text + "\n" + Grid_calendario.CurrentRow.Cells[0].Value.ToString() + "/" + Grid_calendario.CurrentRow.Cells[1].Value.ToString() + "/" + Grid_calendario.CurrentRow.Cells[2].Value.ToString();
            gestor.tomarConfirmacionReserva(this, CB_modoNotificacion.SelectedItem.ToString(), mensaje);
        }

        private void btn_Opcion_Registrar_Turno_Click(object sender, EventArgs e)
        {
            opcionReservarTurno();
        }

        private void CB_CentroInvestigacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridRT.Visible = true;
            btn_seleccionarRT.Visible = true;
            for (int i = 0; i < gridRT.Rows.Count; i++)
            {


                if (gridRT.Rows[i].Cells[0].Value.ToString() != CB_centroInvestigacion.SelectedItem.ToString())
                {
                    gridRT.CurrentCell = null;
                    gridRT.Rows[i].Visible = false;
                }
                else
                {
                    gridRT.Rows[i].Visible = true;
                }
            }
        }

        private void btn_seleccionarRT_Click(object sender, EventArgs e)
        {
            if (gridRT.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un Recurso Tecnologico", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tomarSeleccionRT();
            }
        }

        private void btn_dia_Click(object sender, EventArgs e)
        {
            if (Grid_calendario.CurrentRow.Selected)
            {


                if (Grid_calendario.CurrentRow.DefaultCellStyle.BackColor == Color.Empty)
                {
                    MessageBox.Show("Este dia no cuenta con turnos disponibles", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string fechaSeleccionada = Grid_calendario.CurrentRow.Cells[0].Value.ToString() + Grid_calendario.CurrentRow.Cells[1].Value.ToString();
                    for (int i = 0; i < Grid_turnos.Rows.Count; i++)
                    {
                        if (Grid_turnos.Rows[i].Cells[0].Value.ToString() == fechaSeleccionada)
                        {
                            Grid_turnos.CurrentCell = null;
                            //Grid_turnos.Rows[i].Visible = false;
                        }
                    }
                    Grid_turnos.Visible = true;
                    btn_seleccionarTurno.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Fecha ", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_seleccionarTurno_Click(object sender, EventArgs e)
        {
            if (Grid_turnos.CurrentRow.Selected)
            {
                if (Grid_turnos.SelectedRows[0].Cells[3].Value.ToString() == "Disponible")
                {
                    tomarSeleccionTurno();
                }
                else
                {
                    MessageBox.Show("Seleccione un turno disponible");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un turno ", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //El usuario confirma reserva
        private void btn_confirmarTurno_Click(object sender, EventArgs e)
        {
            tomarConfirmacionReserva();
        }


        //Camino alternativo cu el usuario no confirma la reserva
        private void btn_cancelarTurno_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reserva Cancelada");
            this.Close();
            gestor.finCU(this, false);
        }
    }
}
