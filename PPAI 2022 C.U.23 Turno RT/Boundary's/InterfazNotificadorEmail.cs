using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

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


            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("Maxwelcito@outlook.com", "Centro investigacion", System.Text.Encoding.UTF8);//Correo de salida
            correo.To.Add(direccionEmail); //Correo destino?
            correo.Subject = "Recurso reservado"; //Asunto
            correo.Body = mensaje; //Mensaje del correo
            correo.IsBodyHtml = false;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp-mail.outlook.com"; //Host del servidor de correo
            smtp.Port = 587; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("Maxwelcito@outlook.com", "Maxwel12");//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);
        }
    }
}
