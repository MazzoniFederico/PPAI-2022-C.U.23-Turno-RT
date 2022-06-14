
namespace PPAI_2022_C.U._23_Turno_RT.Boundary_s
{
    partial class PantallaAdministrarTurno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_Centro = new System.Windows.Forms.Label();
            this.CB_CentroInvestigacion = new System.Windows.Forms.ComboBox();
            this.btn_Opcion_Registrar_Turno = new System.Windows.Forms.Button();
            this.CBTipoRT = new System.Windows.Forms.ComboBox();
            this.btn_tipoRT = new System.Windows.Forms.Button();
            this.gridRT = new System.Windows.Forms.DataGridView();
            this.btn_seleccionarRT = new System.Windows.Forms.Button();
            this.Grid_turno = new System.Windows.Forms.DataGridView();
            this.horaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Calendario = new System.Windows.Forms.DataGridView();
            this.dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_dia = new System.Windows.Forms.Button();
            this.Grid_Turnos = new System.Windows.Forms.DataGridView();
            this.Centro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeloRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_seleccionarTurno = new System.Windows.Forms.Button();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaHoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_datosRT = new System.Windows.Forms.Label();
            this.lbl_datosTurno = new System.Windows.Forms.Label();
            this.cb_modoNotificacion = new System.Windows.Forms.ComboBox();
            this.lbl_modoNotificacion = new System.Windows.Forms.Label();
            this.btn_confirmarTurno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridRT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_turno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Calendario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Turnos)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Centro
            // 
            this.lbl_Centro.AutoSize = true;
            this.lbl_Centro.Location = new System.Drawing.Point(187, 62);
            this.lbl_Centro.Name = "lbl_Centro";
            this.lbl_Centro.Size = new System.Drawing.Size(129, 13);
            this.lbl_Centro.TabIndex = 0;
            this.lbl_Centro.Text = "Centros de investigacion: ";
            this.lbl_Centro.Visible = false;
            // 
            // CB_CentroInvestigacion
            // 
            this.CB_CentroInvestigacion.FormattingEnabled = true;
            this.CB_CentroInvestigacion.Location = new System.Drawing.Point(14, 59);
            this.CB_CentroInvestigacion.Name = "CB_CentroInvestigacion";
            this.CB_CentroInvestigacion.Size = new System.Drawing.Size(167, 21);
            this.CB_CentroInvestigacion.TabIndex = 1;
            this.CB_CentroInvestigacion.Visible = false;
            this.CB_CentroInvestigacion.SelectedIndexChanged += new System.EventHandler(this.CB_CentroInvestigacion_SelectedIndexChanged);
            // 
            // btn_Opcion_Registrar_Turno
            // 
            this.btn_Opcion_Registrar_Turno.Location = new System.Drawing.Point(152, 295);
            this.btn_Opcion_Registrar_Turno.Name = "btn_Opcion_Registrar_Turno";
            this.btn_Opcion_Registrar_Turno.Size = new System.Drawing.Size(232, 41);
            this.btn_Opcion_Registrar_Turno.TabIndex = 2;
            this.btn_Opcion_Registrar_Turno.Text = "Opcion Registrar turno";
            this.btn_Opcion_Registrar_Turno.UseVisualStyleBackColor = true;
            this.btn_Opcion_Registrar_Turno.Click += new System.EventHandler(this.btn_Opcion_Registrar_Turno_Click);
            // 
            // CBTipoRT
            // 
            this.CBTipoRT.FormattingEnabled = true;
            this.CBTipoRT.Location = new System.Drawing.Point(14, 59);
            this.CBTipoRT.Name = "CBTipoRT";
            this.CBTipoRT.Size = new System.Drawing.Size(217, 21);
            this.CBTipoRT.TabIndex = 3;
            this.CBTipoRT.Visible = false;
            // 
            // btn_tipoRT
            // 
            this.btn_tipoRT.Location = new System.Drawing.Point(247, 57);
            this.btn_tipoRT.Name = "btn_tipoRT";
            this.btn_tipoRT.Size = new System.Drawing.Size(137, 23);
            this.btn_tipoRT.TabIndex = 4;
            this.btn_tipoRT.Text = "Confirmar Tipo RT";
            this.btn_tipoRT.UseVisualStyleBackColor = true;
            this.btn_tipoRT.Visible = false;
            this.btn_tipoRT.Click += new System.EventHandler(this.btn_tipoRT_Click);
            // 
            // gridRT
            // 
            this.gridRT.AllowUserToAddRows = false;
            this.gridRT.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridRT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Centro,
            this.NombreRT,
            this.modeloRT,
            this.marcaRT,
            this.estadoRT});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRT.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridRT.Location = new System.Drawing.Point(12, 148);
            this.gridRT.Name = "gridRT";
            this.gridRT.ReadOnly = true;
            this.gridRT.RowHeadersVisible = false;
            this.gridRT.Size = new System.Drawing.Size(653, 150);
            this.gridRT.TabIndex = 5;
            this.gridRT.Visible = false;
            // 
            // btn_seleccionarRT
            // 
            this.btn_seleccionarRT.Location = new System.Drawing.Point(169, 304);
            this.btn_seleccionarRT.Name = "btn_seleccionarRT";
            this.btn_seleccionarRT.Size = new System.Drawing.Size(201, 23);
            this.btn_seleccionarRT.TabIndex = 6;
            this.btn_seleccionarRT.Text = "Seleccionar Recurso Tecnologico";
            this.btn_seleccionarRT.UseVisualStyleBackColor = true;
            this.btn_seleccionarRT.Visible = false;
            this.btn_seleccionarRT.Click += new System.EventHandler(this.btn_seleccionarRT_Click);
            // 
            // Grid_turno
            // 
            this.Grid_turno.AllowUserToAddRows = false;
            this.Grid_turno.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.Grid_turno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_turno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.horaInicio,
            this.horaFin,
            this.estado});
            this.Grid_turno.Location = new System.Drawing.Point(12, 148);
            this.Grid_turno.Name = "Grid_turno";
            this.Grid_turno.ReadOnly = true;
            this.Grid_turno.Size = new System.Drawing.Size(642, 150);
            this.Grid_turno.TabIndex = 9;
            this.Grid_turno.Visible = false;
            // 
            // horaInicio
            // 
            this.horaInicio.HeaderText = "Hora inicio";
            this.horaInicio.Name = "horaInicio";
            this.horaInicio.ReadOnly = true;
            // 
            // horaFin
            // 
            this.horaFin.HeaderText = "Hora fin";
            this.horaFin.Name = "horaFin";
            this.horaFin.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 200;
            // 
            // Grid_Calendario
            // 
            this.Grid_Calendario.AllowUserToAddRows = false;
            this.Grid_Calendario.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.Grid_Calendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Calendario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dia,
            this.mes});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Calendario.DefaultCellStyle = dataGridViewCellStyle5;
            this.Grid_Calendario.Location = new System.Drawing.Point(12, 148);
            this.Grid_Calendario.Name = "Grid_Calendario";
            this.Grid_Calendario.ReadOnly = true;
            this.Grid_Calendario.Size = new System.Drawing.Size(250, 150);
            this.Grid_Calendario.TabIndex = 10;
            this.Grid_Calendario.Visible = false;
            // 
            // dia
            // 
            this.dia.HeaderText = "Dia";
            this.dia.Name = "dia";
            this.dia.ReadOnly = true;
            // 
            // mes
            // 
            this.mes.HeaderText = "Mes";
            this.mes.Name = "mes";
            this.mes.ReadOnly = true;
            // 
            // btn_dia
            // 
            this.btn_dia.Location = new System.Drawing.Point(88, 304);
            this.btn_dia.Name = "btn_dia";
            this.btn_dia.Size = new System.Drawing.Size(75, 23);
            this.btn_dia.TabIndex = 11;
            this.btn_dia.Text = "Elegir dia";
            this.btn_dia.UseVisualStyleBackColor = true;
            this.btn_dia.Visible = false;
            this.btn_dia.Click += new System.EventHandler(this.btn_dia_Click);
            // 
            // Grid_Turnos
            // 
            this.Grid_Turnos.AllowUserToAddRows = false;
            this.Grid_Turnos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.Grid_Turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Turnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.fechaHoraInicio,
            this.fechaHoraFin,
            this.estadoTurno,
            this.numero});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Turnos.DefaultCellStyle = dataGridViewCellStyle6;
            this.Grid_Turnos.Location = new System.Drawing.Point(295, 148);
            this.Grid_Turnos.Name = "Grid_Turnos";
            this.Grid_Turnos.Size = new System.Drawing.Size(372, 150);
            this.Grid_Turnos.TabIndex = 12;
            this.Grid_Turnos.Visible = false;
            // 
            // Centro
            // 
            this.Centro.HeaderText = "Nombre Centro";
            this.Centro.Name = "Centro";
            this.Centro.ReadOnly = true;
            this.Centro.Visible = false;
            this.Centro.Width = 150;
            // 
            // NombreRT
            // 
            this.NombreRT.HeaderText = "Nombre";
            this.NombreRT.Name = "NombreRT";
            this.NombreRT.ReadOnly = true;
            // 
            // modeloRT
            // 
            this.modeloRT.HeaderText = "Modelo";
            this.modeloRT.Name = "modeloRT";
            this.modeloRT.ReadOnly = true;
            // 
            // marcaRT
            // 
            this.marcaRT.HeaderText = "Marca";
            this.marcaRT.Name = "marcaRT";
            this.marcaRT.ReadOnly = true;
            // 
            // estadoRT
            // 
            this.estadoRT.HeaderText = "Estado";
            this.estadoRT.Name = "estadoRT";
            this.estadoRT.ReadOnly = true;
            this.estadoRT.Width = 200;
            // 
            // btn_seleccionarTurno
            // 
            this.btn_seleccionarTurno.Location = new System.Drawing.Point(431, 304);
            this.btn_seleccionarTurno.Name = "btn_seleccionarTurno";
            this.btn_seleccionarTurno.Size = new System.Drawing.Size(75, 23);
            this.btn_seleccionarTurno.TabIndex = 13;
            this.btn_seleccionarTurno.Text = "Elegir turno";
            this.btn_seleccionarTurno.UseVisualStyleBackColor = true;
            this.btn_seleccionarTurno.Visible = false;
            this.btn_seleccionarTurno.Click += new System.EventHandler(this.btn_seleccionarTurno_Click);
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.Visible = false;
            // 
            // fechaHoraInicio
            // 
            this.fechaHoraInicio.HeaderText = "Hora inicio";
            this.fechaHoraInicio.Name = "fechaHoraInicio";
            // 
            // fechaHoraFin
            // 
            this.fechaHoraFin.HeaderText = "Hora fin";
            this.fechaHoraFin.Name = "fechaHoraFin";
            // 
            // estadoTurno
            // 
            this.estadoTurno.HeaderText = "Estado";
            this.estadoTurno.Name = "estadoTurno";
            // 
            // numero
            // 
            this.numero.HeaderText = "numeroTurno";
            this.numero.Name = "numero";
            this.numero.Visible = false;
            // 
            // lbl_datosRT
            // 
            this.lbl_datosRT.AutoSize = true;
            this.lbl_datosRT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_datosRT.Location = new System.Drawing.Point(12, 36);
            this.lbl_datosRT.Name = "lbl_datosRT";
            this.lbl_datosRT.Size = new System.Drawing.Size(57, 20);
            this.lbl_datosRT.TabIndex = 14;
            this.lbl_datosRT.Text = "label1";
            this.lbl_datosRT.Visible = false;
            // 
            // lbl_datosTurno
            // 
            this.lbl_datosTurno.AutoSize = true;
            this.lbl_datosTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_datosTurno.Location = new System.Drawing.Point(205, 36);
            this.lbl_datosTurno.Name = "lbl_datosTurno";
            this.lbl_datosTurno.Size = new System.Drawing.Size(57, 20);
            this.lbl_datosTurno.TabIndex = 15;
            this.lbl_datosTurno.Text = "label1";
            this.lbl_datosTurno.Visible = false;
            // 
            // cb_modoNotificacion
            // 
            this.cb_modoNotificacion.FormattingEnabled = true;
            this.cb_modoNotificacion.Location = new System.Drawing.Point(180, 132);
            this.cb_modoNotificacion.Name = "cb_modoNotificacion";
            this.cb_modoNotificacion.Size = new System.Drawing.Size(121, 21);
            this.cb_modoNotificacion.TabIndex = 16;
            this.cb_modoNotificacion.Visible = false;
            // 
            // lbl_modoNotificacion
            // 
            this.lbl_modoNotificacion.AutoSize = true;
            this.lbl_modoNotificacion.Location = new System.Drawing.Point(4, 135);
            this.lbl_modoNotificacion.Name = "lbl_modoNotificacion";
            this.lbl_modoNotificacion.Size = new System.Drawing.Size(170, 13);
            this.lbl_modoNotificacion.TabIndex = 17;
            this.lbl_modoNotificacion.Text = "Seleccione metodo de notificacion";
            this.lbl_modoNotificacion.Visible = false;
            // 
            // btn_confirmarTurno
            // 
            this.btn_confirmarTurno.Location = new System.Drawing.Point(88, 189);
            this.btn_confirmarTurno.Name = "btn_confirmarTurno";
            this.btn_confirmarTurno.Size = new System.Drawing.Size(150, 23);
            this.btn_confirmarTurno.TabIndex = 18;
            this.btn_confirmarTurno.Text = "Confirmar turno";
            this.btn_confirmarTurno.UseVisualStyleBackColor = true;
            this.btn_confirmarTurno.Visible = false;
            this.btn_confirmarTurno.Click += new System.EventHandler(this.btn_confirmarTurno_Click);
            // 
            // PantallaAdministrarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1036, 558);
            this.Controls.Add(this.btn_confirmarTurno);
            this.Controls.Add(this.lbl_modoNotificacion);
            this.Controls.Add(this.cb_modoNotificacion);
            this.Controls.Add(this.lbl_datosTurno);
            this.Controls.Add(this.lbl_datosRT);
            this.Controls.Add(this.btn_seleccionarTurno);
            this.Controls.Add(this.Grid_Turnos);
            this.Controls.Add(this.btn_dia);
            this.Controls.Add(this.Grid_Calendario);
            this.Controls.Add(this.Grid_turno);
            this.Controls.Add(this.btn_seleccionarRT);
            this.Controls.Add(this.gridRT);
            this.Controls.Add(this.btn_tipoRT);
            this.Controls.Add(this.CBTipoRT);
            this.Controls.Add(this.btn_Opcion_Registrar_Turno);
            this.Controls.Add(this.CB_CentroInvestigacion);
            this.Controls.Add(this.lbl_Centro);
            this.MinimizeBox = false;
            this.Name = "PantallaAdministrarTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reserva de Turno";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridRT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_turno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Calendario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Turnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Centro;
        private System.Windows.Forms.ComboBox CB_CentroInvestigacion;
        private System.Windows.Forms.Button btn_Opcion_Registrar_Turno;
        private System.Windows.Forms.ComboBox CBTipoRT;
        private System.Windows.Forms.Button btn_tipoRT;
        private System.Windows.Forms.DataGridView gridRT;
        private System.Windows.Forms.Button btn_seleccionarRT;
        private System.Windows.Forms.DataGridView Grid_turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridView Grid_Calendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dia;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.Button btn_dia;
        private System.Windows.Forms.DataGridView Grid_Turnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Centro;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreRT;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeloRT;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaRT;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoRT;
        private System.Windows.Forms.Button btn_seleccionarTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaHoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.Label lbl_datosRT;
        private System.Windows.Forms.Label lbl_datosTurno;
        private System.Windows.Forms.ComboBox cb_modoNotificacion;
        private System.Windows.Forms.Label lbl_modoNotificacion;
        private System.Windows.Forms.Button btn_confirmarTurno;
    }
}