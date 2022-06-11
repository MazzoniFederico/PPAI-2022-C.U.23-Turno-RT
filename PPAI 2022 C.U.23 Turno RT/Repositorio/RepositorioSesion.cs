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
            string consulta = "SELECT * FROM SESION INNER JOIN USUARIO u ON usuario=u.id INNER JOIN PERSONALCIENTIFICO pc ON u.personalCientifico = pc.legajo INNER JOIN ASIGNACIONCIENTIFICODELCI aci ON pc.legajo = aci.legajo INNER JOIN CENTRODEINVESTIGACION ci ON aci.nombreCentro = ci.nombre WHERE fechaFin is NULL";
            DataTable res = bd.consulta(consulta);
            Sesion sesion = new Sesion();
            Usuario usuario = new Usuario();
            PersonalCientifico personalCientifico = new PersonalCientifico();
            AsignacionCientificoCI asignacionCientificoCI = new AsignacionCientificoCI();
            CentroDeInvestigacion centroDeInvestigacion = new CentroDeInvestigacion();

            foreach (DataRow resultado in res.Rows)
            {
                sesion.setHoraInicio(resultado["horaInicio"].ToString());
                sesion.setFechaInicio(DateTime.Parse(resultado["fechaInicio"].ToString()));

                usuario.setNombre(resultado["nombreUsuario"].ToString());
                /*if (resultado["caducidad"].ToString() != "")
                    usuario.setCaducidad(Int32.Parse(resultado["caducidad"].ToString()));*/
                usuario.setContraseña(resultado["contraseña"].ToString());


                sesion.setUsuario(usuario);

                personalCientifico.setLegajo(Int64.Parse(resultado["legajo"].ToString()));
                personalCientifico.setNombre(resultado["nombre"].ToString());
                personalCientifico.setApellido(resultado["apellido"].ToString());
                personalCientifico.setNumeroDocumento(Int64.Parse(resultado["dni"].ToString()));
                personalCientifico.setcorreoElectronicoInstitucional(resultado["correoIntitucional"].ToString());
                personalCientifico.setcorreoElectronicoPersonal(resultado["correoPersonal"].ToString());
                personalCientifico.setTelefonoCelular(Int64.Parse(resultado["telefonoCelular"].ToString()));

                personalCientifico.setUsuario(usuario);

                asignacionCientificoCI.setFechaDesde(resultado["fechaDesde"].ToString());
                asignacionCientificoCI.setFechaHasta(resultado["fechaHasta"].ToString());

                asignacionCientificoCI.setPersonalCientifico(personalCientifico);

                centroDeInvestigacion.setNombre(resultado["nombreCentro"].ToString());
                centroDeInvestigacion.setSigla(resultado["sigla"].ToString());
                centroDeInvestigacion.setDireccion(resultado["direccion"].ToString());
                centroDeInvestigacion.setEdificio(resultado["edificio"].ToString());
                centroDeInvestigacion.setPiso(resultado["piso"].ToString());
                centroDeInvestigacion.setCoordenadas(resultado["coordenadas"].ToString());
                centroDeInvestigacion.setTelefonoContacto(resultado["telefonoContacto"].ToString());
                centroDeInvestigacion.setCorreoElectronico(resultado["correoElectronico"].ToString());
                centroDeInvestigacion.setNumeroResolucionCreacion(Int32.Parse(resultado["numeroResolucionCreacion"].ToString()));
                centroDeInvestigacion.setFechaResolucionCreacion(DateTime.Parse(resultado["fechaResolucionCreacion"].ToString()));
                centroDeInvestigacion.setReglamento(resultado["reglamento"].ToString());
                centroDeInvestigacion.setCaracteristicasGenerales(resultado["caracteristicasGenerales"].ToString());
                centroDeInvestigacion.setFechaAlta(DateTime.Parse(resultado["fechaAlta"].ToString()));
                centroDeInvestigacion.setTiempoAntelacionReserva(resultado["tiempoAntelacionReserva"].ToString());
                if (resultado["fechaBaja"].ToString() != null) {
                    centroDeInvestigacion.setFechaBaja(DateTime.Parse(resultado["fechaBaja"].ToString()));
                    centroDeInvestigacion.setMotivoBaja(DateTime.Parse(resultado["motivoBaja"].ToString()));
                }

                centroDeInvestigacion.setAsignacionCientificoCI(asignacionCientificoCI);
            }

            string consulta2 = "SELECT * FROM RECURSOTECNOLOGICO WHERE ci_nombre = " + centroDeInvestigacion.getNombre();
            DataTable resRecursos = bd.consulta(consulta2);

            RecursoTecnologico recursoTecnologico = new RecursoTecnologico();
            foreach (DataRow respuesta in resRecursos.Rows)
            {
                recursoTecnologico.setNumeroRT(Int32.Parse(respuesta["numeroRT"].ToString()));
                recursoTecnologico.setFechaAlta(respuesta["fechaAlta"].ToString());
                recursoTecnologico.setImagenes(respuesta["imagenes"].ToString());
                recursoTecnologico.setPeriodicidadMantenimientoPreventivo(respuesta["periodicidadMantenimientoPreventivo"].ToString());
                recursoTecnologico.setDuracionMantenimientoPreventivo(respuesta["duracionMantenimientoPreventivo"].ToString());
                recursoTecnologico.setFraccionHorarioTurnos(respuesta["fraccionHorarioTurnos"].ToString());

                centroDeInvestigacion.setRecursoTecnologico(recursoTecnologico);
            }


            string consulta3 = "SELECT * FROM TURNO WHERE numero_RT = " + recursoTecnologico.getNumeroRT().ToString();
            DataTable resTurno = bd.consulta(consulta3);

            Turno turno = new Turno();
            foreach (DataRow respuesta in resTurno.Rows)
            {
                turno.setFechaGeneracion(DateTime.Parse(respuesta["fechaGeneracion"].ToString()));
                turno.setDiaSemana(respuesta["diaSemana"].ToString());
                turno.setFechaHoraInicio(DateTime.Parse(respuesta["fechaHoraInicio"].ToString()));
                turno.setFechaHoraFin(DateTime.Parse(respuesta["fechaHoraFin"].ToString()));

                recursoTecnologico.SetTurno(turno);
            }

            string consulta4 = "SELECT * FROM CAMBIOESTADOTURNO INNER JOIN ESTADO e ON id = e.id_Cambio_Estado WHERE fechaHoraInicio_Turno = " + turno.getFechaHoraInicio() );
            DataTable resEstado = bd.consulta(consulta4);

            Estado estado = new Estado();
            CambioDeEstadoTurno cambioDeEstadoTurno = new CambioDeEstadoTurno();
        }
    }
}
