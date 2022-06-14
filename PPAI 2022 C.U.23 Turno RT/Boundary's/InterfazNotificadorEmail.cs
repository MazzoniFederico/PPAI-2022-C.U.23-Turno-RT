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
    public partial class InterfazNotificadorEmail : Form
    {
        public InterfazNotificadorEmail()
        {
            InitializeComponent();
        }

        public void enviarNotificacionEmail(string direccionEmail, string[] confirm)
        {
            string mensaje = "";
            mensaje += "TURNO CONFIRMADO";
            mensaje +=  "\n" + confirm[0];
            mensaje +=  confirm[1];
            mensaje +=  confirm[2];
            mensaje += "\n" + confirm[3];
            mensaje += "\n" + confirm[4];
            mensaje += "\nFecha del turno: " + confirm[5];


            lbl_mail.Text = "Direccion Email: " + direccionEmail;
            lbl_Mensaje.Text = mensaje;
        }
    }
}
