using PPAI_2022_C.U._23_Turno_RT.Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Repositorio
{
    class RepositorioTurno
    {
        public void desmaterializar(Turno turno)
        {
            BaseDatos bd = new BaseDatos();


            foreach (CambioDeEstadoTurno cambio in turno.GetCambioDeEstadoTurnos())
            {
                modificarCambioEstado(cambio);
            }

            CambioDeEstadoTurno utlcambio = turno.GetCambioDeEstadoTurnos()[turno.GetCambioDeEstadoTurnos().Count];

        }

        public void modificarCambioEstado(CambioDeEstadoTurno cambioDeEstadoTurno)
        {
            BaseDatos bd = new BaseDatos();
            var consulta = "Select id FROM ESTADO where nombre = '" + cambioDeEstadoTurno.getEstado().getNombre() +
            "' AND ambito = '" + cambioDeEstadoTurno.getEstado().getAmbito() + "'";
            DataTable res = bd.consulta(consulta);

            string sql = "UPDATE CAMBIO_ESTADO_TURNO Set";
            sql += "fechaHoraHasta = '" + cambioDeEstadoTurno.getFechaHoraHasta().ToString("yyyy-MM-dd") + "'";
            sql += " WHERE fechaHoraDesde = '" + cambioDeEstadoTurno.getFechaHoraHasta().ToString("yyyy-MM-dd") + "' AND idEstado = " + res.Rows[0]["id"].ToString();

            bd.insertar(sql);
        }

        public void cargarCambioEstado(CambioDeEstadoTurno cambioDeEstadoTurno)
        {
            BaseDatos bd = new BaseDatos();
            var consulta = "Select id FROM ESTADO where nombre = '" + cambioDeEstadoTurno.getEstado().getNombre() +
            "' AND ambito = '" + cambioDeEstadoTurno.getEstado().getAmbito() + "'";
            DataTable res = bd.consulta(consulta);

            //ESTA MAL FALTA EL TEMA DEL ID AUTOMATICO

            string insert = @"INSERT INTO CAMBIO_ESTADO_TURNO(fechaHoraDesde, fechaHoraHasta, idEstado) VALUES('"
                + cambioDeEstadoTurno.getFechaHoraDesde().ToString("yyyy-MM-dd") + "'," +
                "NULL, " + res.Rows[0]["id"].ToString() + ");";
            bd.insertar(insert);

            int num = int.Parse(bd.consulta("SELECT MAX(id) max_id FROM CAMBIO_ESTADO_TURNO").Rows[0]["max_id"].ToString());

            string insert2 = @"INSERT INTO CAMBIO_ESTADOS_X_TURNO(idTurno, idCambioEstadoT) VALUES("
                + num;
                
        }
    }
}
