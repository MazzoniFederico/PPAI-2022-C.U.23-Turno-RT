
namespace PPAI_2022_C.U._23_Turno_RT.Boundary_s
{
    partial class InterfazNotificadorEmail
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
            this.lbl_mail = new System.Windows.Forms.Label();
            this.lbl_Mensaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_mail
            // 
            this.lbl_mail.AutoSize = true;
            this.lbl_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_mail.Location = new System.Drawing.Point(254, 61);
            this.lbl_mail.Name = "lbl_mail";
            this.lbl_mail.Size = new System.Drawing.Size(185, 20);
            this.lbl_mail.TabIndex = 0;
            this.lbl_mail.Text = "Correo enviado con Exito";
            // 
            // lbl_Mensaje
            // 
            this.lbl_Mensaje.AutoSize = true;
            this.lbl_Mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_Mensaje.Location = new System.Drawing.Point(107, 119);
            this.lbl_Mensaje.Name = "lbl_Mensaje";
            this.lbl_Mensaje.Size = new System.Drawing.Size(51, 20);
            this.lbl_Mensaje.TabIndex = 1;
            this.lbl_Mensaje.Text = "label1";
            // 
            // InterfazNotificadorEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_Mensaje);
            this.Controls.Add(this.lbl_mail);
            this.Name = "InterfazNotificadorEmail";
            this.Text = "InterfazNotificadorEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_mail;
        private System.Windows.Forms.Label lbl_Mensaje;
    }
}