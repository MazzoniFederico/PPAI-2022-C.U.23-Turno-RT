using PPAI_2022_C.U._23_Turno_RT.Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_2022_C.U._23_Turno_RT.Repositorio
{
    class RepositorioSesion
    {
        public void getSesiones()
        {
            /*BaseDatos bd = new BaseDatos();
            var consulta = "SELECT * FROM SESION INNER JOIN USUARIO u ON usuario=u.id INNER JOIN Empleado e ON u.empleado = e.dni INNER JOIN SEDE s ON e.sede=s.id";
            DataTable res = bd.consulta(consulta);


            foreach (DataRow resultado in res.Rows)
            {
                var sesion = new Sesion();

                var r = resultado["dni"];
                MessageBox.Show(r.ToString());
            }*/
        }

        public void getSesionActual()
        {
            BaseDatos bd = new BaseDatos();
            string consulta = "SELECT * FROM SESION INNER JOIN USUARIO u ON usuario=u.id WHERE fechaFin is NULL";
            DataTable res = bd.consulta(consulta);
            Sesion sesion = new Sesion();
            Usuario usuario = new Usuario();

            foreach (DataRow resultado in res.Rows)
            {
                sesion.setHoraFechaInicio(DateTime.Parse(resultado["horaFechaInicio"].ToString()));
                sesion.setHoraFechaFin(DateTime.Parse(resultado["HoraFechaFin"].ToString()));

                usuario.setClave(resultado["clave"].ToString());
                usuario.setUsuario(resultado["usuario"].ToString());

                sesion.setUsuarioEnSesion(usuario);;
            }    
        }
    }
}
