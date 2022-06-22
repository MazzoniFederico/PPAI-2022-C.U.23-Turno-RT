using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_2022_C.U._23_Turno_RT.Repositorio
{
    class BaseDatos
    {
        SqlConnection conexion = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        //SqlTransaction transaction;

        private void conectar()
        {
            conexion.ConnectionString = "Data Source=DESKTOP-1AC1E0M;Initial Catalog=GestionRT;Integrated Security=True";
            conexion.Open();
            cmd.Connection = conexion;
            cmd.CommandType = System.Data.CommandType.Text;
        }

        private void desconectar()
        {
            conexion.Close();
        }

        public DataTable consulta(string sql)
        {
            conectar();
            cmd.CommandText = sql;
            DataTable tabla = new DataTable();
            try
            {
                tabla.Load(cmd.ExecuteReader());
            }
            catch(Exception e)
            {
                MessageBox.Show("Error con la Base de Datos" + "\n"
                                + "En el comando:" + "\n"
                                + sql + "\n"
                                + "El mensaje es:" + "\n"
                                + e.Message);
                Console.WriteLine(sql);
            }
            desconectar();
            return tabla;
        }

        public void insertar(string sql)
        {
            conectar();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            desconectar();
        }
    }
}
