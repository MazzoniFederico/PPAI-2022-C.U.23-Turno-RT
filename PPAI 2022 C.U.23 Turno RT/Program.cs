using PPAI_2022_C.U._23_Turno_RT.Boundary_s;
using PPAI_2022_C.U._23_Turno_RT.Controladores;
using PPAI_2022_C.U._23_Turno_RT.Negocios;
using PPAI_2022_C.U._23_Turno_RT.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_2022_C.U._23_Turno_RT
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RepositorioCentroInvestigacion repo = new RepositorioCentroInvestigacion();
            InterfazNotificadorEmail interfazNotificadorEmail = new InterfazNotificadorEmail();
            GestorTurnoRT gestor = new GestorTurnoRT(interfazNotificadorEmail);
            RepositorioSesion repsesion = new RepositorioSesion();
            Application.Run(new PantallaAdministrarTurno(gestor, repsesion));
        }
    }
}
