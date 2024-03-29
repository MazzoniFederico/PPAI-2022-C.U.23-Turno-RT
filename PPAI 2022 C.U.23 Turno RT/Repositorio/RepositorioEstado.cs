﻿using PPAI_2022_C.U._23_Turno_RT.Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Repositorio
{
    class RepositorioEstado
    {
        public List<Estado> getEstados()
        {
            BaseDatos bd = new BaseDatos();
            string consulta = "SELECT * FROM ESTADO";
            var estados = new List<Estado>();

            foreach (DataRow i in bd.consulta(consulta).Rows)
            {
                var estado = new Estado();
                estado.setNombre(i["nombre"].ToString());
                estado.setDescripcion(i["descripcion"].ToString());
                estado.setAmbito(i["ambito"].ToString());
                estados.Add(estado);
            }
            return estados;
        }
    }
}
