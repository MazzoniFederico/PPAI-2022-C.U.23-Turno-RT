using PPAI_2022_C.U._23_Turno_RT.Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Repositorio
{
    static class RepositorioTipoRT
    {
        public static List<TipoRT> GetTipoRTs()
        {
            BaseDatos bd = new BaseDatos();
            string consulta = "SELECT * FROM TIPO_RT";
            List<TipoRT> tipos = new List<TipoRT>();
            
            foreach (DataRow i in bd.consulta(consulta).Rows)
            {
                TipoRT tipo = new TipoRT();
                tipo.setNombre(i[0].ToString());
                tipo.setDescripcion(i[1].ToString());
                tipos.Add(tipo);
            }
            return tipos;
        }
    }
}
