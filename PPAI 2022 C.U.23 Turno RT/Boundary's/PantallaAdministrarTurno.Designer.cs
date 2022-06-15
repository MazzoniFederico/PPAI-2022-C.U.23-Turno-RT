
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_centro = new System.Windows.Forms.Label();
            this.CB_centroInvestigacion = new System.Windows.Forms.ComboBox();
            this.btn_opcionRegistrarTurno = new System.Windows.Forms.Button();
            this.CB_tipoRT = new System.Windows.Forms.ComboBox();
            this.btn_tipoRT = new System.Windows.Forms.Button();
            this.gridRT = new System.Windows.Forms.DataGridView();
            this.Centro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeloRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_seleccionarRT = new System.Windows.Forms.Button();
            this.Grid_calendario = new System.Windows.Forms.DataGridView();
            this.dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_dia = new System.Windows.Forms.Button();
            this.Grid_turnos = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaHoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_seleccionarTurno = new System.Windows.Forms.Button();
            this.lbl_datosRT = new System.Windows.Forms.Label();
            this.lbl_datosTurno = new System.Windows.Forms.Label();
            this.CB_modoNotificacion = new System.Windows.Forms.ComboBox();
            this.lbl_modoNotificacion = new System.Windows.Forms.Label();
            this.btn_confirmarTurno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridRT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_calendario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_turnos)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_centro
            // 
            this.lbl_centro.AutoSize = true;
            this.lbl_centro.Location = new System.Drawing.Point(187, 62);
            this.lbl_centro.Name = "lbl_centro";
            this.lbl_centro.Size = new System.Drawing.Size(129, 13);
            this.lbl_centro.TabIndex = 0;
            this.lbl_centro.Text = "Centros de investigacion: ";
            this.lbl_centro.Visible = false;
            // 
            // CB_centroInvestigacion
            // 
            this.CB_centroInvestigacion.FormattingEnabled = true;
            this.CB_centroInvestigacion.Location = new System.Drawing.Point(14, 59);
            this.CB_centroInvestigacion.Name = "CB_centroInvestigacion";
            this.CB_centroInvestigacion.Size = new System.Drawing.Size(167, 21);
            this.CB_centroInvestigacion.TabIndex = 1;
            this.CB_centroInvestigacion.Visible = false;
            this.CB_centroInvestigacion.SelectedIndexChanged += new System.EventHandler(this.CB_CentroInvestigacion_SelectedIndexChanged);
            // 
            // btn_opcionRegistrarTurno
            // 
            this.btn_opcionRegistrarTurno.Location = new System.Drawing.Point(152, 295);
            this.btn_opcionRegistrarTurno.Name = "btn_opcionRegistrarTurno";
            this.btn_opcionRegistrarTurno.Size = new System.Drawing.Size(232, 41);
            this.btn_opcionRegistrarTurno.TabIndex = 2;
            this.btn_opcionRegistrarTurno.Text = "Opcion Registrar turno";
            this.btn_opcionRegistrarTurno.UseVisualStyleBackColor = true;
            this.btn_opcionRegistrarTurno.Click += new System.EventHandler(this.btn_Opcion_Registrar_Turno_Click);
            // 
            // CB_tipoRT
            // 
            this.CB_tipoRT.FormattingEnabled = true;
            this.CB_tipoRT.Location = new System.Drawing.Point(14, 59);
            this.CB_tipoRT.Name = "CB_tipoRT";
            this.CB_tipoRT.Size = new System.Drawing.Size(217, 21);
            this.CB_tipoRT.TabIndex = 3;
            this.CB_tipoRT.Visible = false;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRT.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridRT.Location = new System.Drawing.Point(12, 148);
            this.gridRT.Name = "gridRT";
            this.gridRT.ReadOnly = true;
            this.gridRT.RowHeadersVisible = false;
            this.gridRT.Size = new System.Drawing.Size(653, 150);
            this.gridRT.TabIndex = 5;
            this.gridRT.Visible = false;
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
            // Grid_calendario
            // 
            this.Grid_calendario.AllowUserToAddRows = false;
            this.Grid_calendario.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.Grid_calendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_calendario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dia,
            this.mes,
            this.año});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_calendario.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_calendario.Location = new System.Drawing.Point(12, 148);
            this.Grid_calendario.Name = "Grid_calendario";
            this.Grid_calendario.ReadOnly = true;
            this.Grid_calendario.Size = new System.Drawing.Size(250, 150);
            this.Grid_calendario.TabIndex = 10;
            this.Grid_calendario.Visible = false;
            // 
            // dia
            // 
            this.dia.HeaderText = "Dia";
            this.dia.Name = "dia";
            this.dia.ReadOnly = true;
            this.dia.Width = 50;
            // 
            // mes
            // 
            this.mes.HeaderText = "Mes";
            this.mes.Name = "mes";
            this.mes.ReadOnly = true;
            this.mes.Width = 50;
            // 
            // año
            // 
            this.año.HeaderText = "Año";
            this.año.Name = "año";
            this.año.ReadOnly = true;
            this.año.Width = 50;
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
            // Grid_turnos
            // 
            this.Grid_turnos.AllowUserToAddRows = false;
            this.Grid_turnos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.Grid_turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_turnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.fechaHoraInicio,
            this.fechaHoraFin,
            this.estadoTurno,
            this.numero});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_turnos.DefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_turnos.Location = new System.Drawing.Point(295, 148);
            this.Grid_turnos.Name = "Grid_turnos";
            this.Grid_turnos.Size = new System.Drawing.Size(372, 150);
            this.Grid_turnos.TabIndex = 12;
            this.Grid_turnos.Visible = false;
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
            // CB_modoNotificacion
            // 
            this.CB_modoNotificacion.FormattingEnabled = true;
            this.CB_modoNotificacion.Location = new System.Drawing.Point(180, 132);
            this.CB_modoNotificacion.Name = "CB_modoNotificacion";
            this.CB_modoNotificacion.Size = new System.Drawing.Size(121, 21);
            this.CB_modoNotificacion.TabIndex = 16;
            this.CB_modoNotificacion.Visible = false;
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
            this.ClientSize = new System.Drawing.Size(709, 414);
            this.Controls.Add(this.btn_confirmarTurno);
            this.Controls.Add(this.lbl_modoNotificacion);
            this.Controls.Add(this.CB_modoNotificacion);
            this.Controls.Add(this.lbl_datosTurno);
            this.Controls.Add(this.lbl_datosRT);
            this.Controls.Add(this.btn_seleccionarTurno);
            this.Controls.Add(this.btn_dia);
            this.Controls.Add(this.btn_seleccionarRT);
            this.Controls.Add(this.btn_tipoRT);
            this.Controls.Add(this.btn_opcionRegistrarTurno);
            this.Controls.Add(this.CB_centroInvestigacion);
            this.Controls.Add(this.lbl_centro);
            this.Controls.Add(this.CB_tipoRT);
            this.Controls.Add(this.gridRT);
            this.Controls.Add(this.Grid_calendario);
            this.Controls.Add(this.Grid_turnos);
            this.MinimizeBox = false;
            this.Name = "PantallaAdministrarTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reserva de Turno";
            ((System.ComponentModel.ISupportInitialize)(this.gridRT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_calendario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_turnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_centro;
        private System.Windows.Forms.ComboBox CB_centroInvestigacion;
        private System.Windows.Forms.Button btn_opcionRegistrarTurno;
        private System.Windows.Forms.ComboBox CB_tipoRT;
        private System.Windows.Forms.Button btn_tipoRT;
        private System.Windows.Forms.DataGridView gridRT;
        private System.Windows.Forms.Button btn_seleccionarRT;
        private System.Windows.Forms.DataGridView Grid_calendario;
        private System.Windows.Forms.Button btn_dia;
        private System.Windows.Forms.DataGridView Grid_turnos;
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
        private System.Windows.Forms.ComboBox CB_modoNotificacion;
        private System.Windows.Forms.Label lbl_modoNotificacion;
        private System.Windows.Forms.Button btn_confirmarTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dia;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn año;
    }
}