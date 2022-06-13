
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_Centro = new System.Windows.Forms.Label();
            this.CB_CentroInvestigacion = new System.Windows.Forms.ComboBox();
            this.btn_Opcion_Registrar_Turno = new System.Windows.Forms.Button();
            this.CBTipoRT = new System.Windows.Forms.ComboBox();
            this.btn_tipoRT = new System.Windows.Forms.Button();
            this.gridRT = new System.Windows.Forms.DataGridView();
            this.NombreRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeloRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridRT)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Centro
            // 
            this.lbl_Centro.AutoSize = true;
            this.lbl_Centro.Location = new System.Drawing.Point(402, 181);
            this.lbl_Centro.Name = "lbl_Centro";
            this.lbl_Centro.Size = new System.Drawing.Size(129, 13);
            this.lbl_Centro.TabIndex = 0;
            this.lbl_Centro.Text = "Centros de investigacion: ";
            this.lbl_Centro.Visible = false;
            // 
            // CB_CentroInvestigacion
            // 
            this.CB_CentroInvestigacion.FormattingEnabled = true;
            this.CB_CentroInvestigacion.Location = new System.Drawing.Point(547, 178);
            this.CB_CentroInvestigacion.Name = "CB_CentroInvestigacion";
            this.CB_CentroInvestigacion.Size = new System.Drawing.Size(167, 21);
            this.CB_CentroInvestigacion.TabIndex = 1;
            this.CB_CentroInvestigacion.Visible = false;
            this.CB_CentroInvestigacion.SelectedIndexChanged += new System.EventHandler(this.CB_CentroInvestigacion_SelectedIndexChanged);
            // 
            // btn_Opcion_Registrar_Turno
            // 
            this.btn_Opcion_Registrar_Turno.Location = new System.Drawing.Point(386, 493);
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
            this.CBTipoRT.Location = new System.Drawing.Point(314, 102);
            this.CBTipoRT.Name = "CBTipoRT";
            this.CBTipoRT.Size = new System.Drawing.Size(217, 21);
            this.CBTipoRT.TabIndex = 3;
            this.CBTipoRT.Visible = false;
            // 
            // btn_tipoRT
            // 
            this.btn_tipoRT.Location = new System.Drawing.Point(547, 100);
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
            this.gridRT.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridRT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreRT,
            this.modeloRT,
            this.marcaRT,
            this.estadoRT});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRT.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridRT.Location = new System.Drawing.Point(314, 223);
            this.gridRT.Name = "gridRT";
            this.gridRT.Size = new System.Drawing.Size(441, 150);
            this.gridRT.TabIndex = 5;
            this.gridRT.Visible = false;
            this.gridRT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // NombreRT
            // 
            this.NombreRT.HeaderText = "Nombre";
            this.NombreRT.Name = "NombreRT";
            // 
            // modeloRT
            // 
            this.modeloRT.HeaderText = "Modelo";
            this.modeloRT.Name = "modeloRT";
            // 
            // marcaRT
            // 
            this.marcaRT.HeaderText = "Marca";
            this.marcaRT.Name = "marcaRT";
            // 
            // estadoRT
            // 
            this.estadoRT.HeaderText = "Estado";
            this.estadoRT.Name = "estadoRT";
            // 
            // PantallaAdministrarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1036, 558);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreRT;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeloRT;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaRT;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoRT;
    }
}