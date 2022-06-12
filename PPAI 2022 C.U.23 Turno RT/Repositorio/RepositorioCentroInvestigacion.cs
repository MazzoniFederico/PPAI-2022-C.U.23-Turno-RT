using PPAI_2022_C.U._23_Turno_RT.Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Repositorio
{
    class RepositorioCentroInvestigacion
    {
        public void GetCentroDeInvestigaciones()
        {
            BaseDatos bd = new BaseDatos();
            string consulta = "SELECT * FROM CENTRODEINVESTIGACION";
            List<CentroDeInvestigacion> centroDeInvestigaciones = new List<CentroDeInvestigacion>();
            CentroDeInvestigacion centroDeInvestigacion = new CentroDeInvestigacion();

            foreach (DataRow resultado in bd.consulta(consulta).Rows)
            {
                
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
                if (resultado["fechaBaja"].ToString() != null)
                {
                    centroDeInvestigacion.setFechaBaja(DateTime.Parse(resultado["fechaBaja"].ToString()));
                    centroDeInvestigacion.setMotivoBaja(resultado["motivoBaja"].ToString());
                }
                string consulta2 = "SELECT * FROM RECURSOTECNOLOGICO WHERE nombreCentro = " + centroDeInvestigacion.getNombre();
                DataTable resRT = bd.consulta(consulta);
                RecursoTecnologico recursoTecnologico = new RecursoTecnologico();
                List<RecursoTecnologico> recursoTecnologicos = null;

                foreach (DataRow res in resRT.Rows)
                {
                    recursoTecnologico.setNumeroRT(Int32.Parse(res["numeroRT"].ToString()));
                    recursoTecnologico.setFechaAlta(DateTime.Parse(res["fechaAlta"].ToString()));
                    recursoTecnologico.setImagenes(res["imagenes"].ToString());
                    recursoTecnologico.setPeriodicidadMantenimientoPreventivo(Int32.Parse(res["periodicidadMantenimientoPreventivo"].ToString()));
                    recursoTecnologico.setDuracionMantenimientoPreventivo(Int32.Parse(res["duracionMantenimientoPreventivo"].ToString()));
                    recursoTecnologico.setFraccionHorarioTurnos(Int32.Parse(res["fraccionHorarioTurnos"].ToString()));

                    recursoTecnologicos.Add(recursoTecnologico);

                    string consulta8 = "SELECT * FROM TURNO WHERE numero_RT = " + recursoTecnologico.getNumeroRT().ToString();
                    DataTable resTurno = bd.consulta(consulta8);

                    Turno turno = new Turno();
                    List<Turno> listaTurnos = null;
                    foreach (DataRow respuesta in resTurno.Rows)
                    {

                        turno.setFechaGeneracion(DateTime.Parse(respuesta["fechaGeneracion"].ToString()));
                        turno.setDiaSemana(respuesta["diaSemana"].ToString());
                        turno.setFechaHoraInicio(DateTime.Parse(respuesta["fechaHoraInicio"].ToString()));
                        turno.setFechaHoraFin(DateTime.Parse(respuesta["fechaHoraFin"].ToString()));

                        listaTurnos.Add(turno);

                        string consulta4 = "SELECT * FROM CAMBIOESTADOTURNO INNER JOIN ESTADO e ON id = e.id_Cambio_Estado WHERE fechaHoraInicio_Turno = " + turno.getFechaHoraInicio();
                        DataTable resEstado = bd.consulta(consulta4);

                        Estado estado = new Estado();
                        CambioDeEstadoTurno cambioDeEstadoTurno = new CambioDeEstadoTurno();
                        List<CambioDeEstadoTurno> cambioDeEstadoTurnos = null;
                        foreach (DataRow resE in resEstado.Rows)
                        {

                            estado.setNombre(resE["nombreEstado"].ToString());
                            estado.setDescripcion(resE["descripcion"].ToString());
                            estado.setAmbito(resE["ambito"].ToString());

                            cambioDeEstadoTurno.setFechaHoraHasta(DateTime.Parse(resE["fechaHoraHasta"].ToString()));
                            cambioDeEstadoTurno.setFechaHoraDesde(DateTime.Parse(resE["fechaHoraDesde"].ToString()));

                            cambioDeEstadoTurno.setEstado(estado);

                            cambioDeEstadoTurnos.Add(cambioDeEstadoTurno);
                        }

                        turno.setCambioDeEstadoTurno(cambioDeEstadoTurnos);

                    }
                    string consulta7 = "SELECT * FROM TIPORT WHERE numeroRT= " + recursoTecnologico.getNumeroRT();
                    DataTable resTipoRT = bd.consulta(consulta7);
                    TipoRT tipoRT = new TipoRT();
                    foreach (DataRow resTipo in resTipoRT.Rows)
                    {
                        tipoRT.setNombre(resTipo["nombre"].ToString());
                        tipoRT.setDescripcion(resTipo["descripcion"].ToString());
                    }
                    recursoTecnologico.setTipoRT(tipoRT);

                    string consulta6 = "SELECT * FROM MODELO INNER JOIN MARCA m ON idMarca = m.id WHERE numeroRT= " + recursoTecnologico.getNumeroRT();
                    DataTable resMarcas = bd.consulta(consulta6);
                    Modelo modelo = new Modelo();
                    Marca marca = new Marca();
                    foreach (DataRow resMarca in resMarcas.Rows)
                    {
                        modelo.setNombre(resMarca["nombreModelo"].ToString());
                        marca.setNombre(resMarca["nombreMarca"].ToString());

                        modelo.setMarca(marca);
                    }

                    recursoTecnologico.setModelo(modelo);

                    string consulta5 = "SELECT * FROM CAMBIOESTADORT INNER JOIN ESTADO e ON id = e.id_Cambio_Estado WHERE numeroRT = " + recursoTecnologico.getNumeroRT();
                    DataTable resEstadoRT = bd.consulta(consulta5);
                    Estado estadoRT = new Estado();
                    CambioDeEstadoRT cambioDeEstadoRT = new CambioDeEstadoRT();
                    List<CambioDeEstadoRT> cambioDeEstadoRTs = null;
                    foreach (DataRow resERT in resEstadoRT.Rows)
                    {
                        estadoRT.setNombre(resERT["nombreEstado"].ToString());
                        estadoRT.setDescripcion(resERT["descripcion"].ToString());
                        estadoRT.setAmbito(resERT["ambito"].ToString());

                        cambioDeEstadoRT.setFechaHoraHasta(DateTime.Parse(resERT["fechaHoraHasta"].ToString()));
                        cambioDeEstadoRT.setFechaHoraDesde(DateTime.Parse(resERT["fechaHoraDesde"].ToString()));

                        cambioDeEstadoRT.setEstado(estadoRT);

                        cambioDeEstadoRTs.Add(cambioDeEstadoRT);
                    }

                    recursoTecnologico.setTurno(listaTurnos);
                }

                string consulta3 = "SELECT * FROM ASIGNACIONCIENTIFICODELCI INNER JOIN PERSONALCIENTIFICO pc ON id = pcIdAsignacion INNER JOIN USUARIO u ON pc.numeroUsuario = u.usuario WHERE nombreCI = " + centroDeInvestigacion.getNombre();
                DataTable resPersonal = bd.consulta(consulta3);
                AsignacionCientificoCI asignacionCientificoCI = new AsignacionCientificoCI();
                PersonalCientifico personalCientifico = new PersonalCientifico();
                Usuario usuario = new Usuario();
                List<AsignacionCientificoCI> asignacionCientificoCIs = null;
                foreach (DataRow resP in resPersonal.Rows)
                {

                    personalCientifico.setLegajo(Int32.Parse(resP["legajo"].ToString()));
                    personalCientifico.setNombre(resP["nombre"].ToString());
                    personalCientifico.setApellido(resP["apellido"].ToString());
                    personalCientifico.setNumeroDocumento(Int32.Parse(resP["dni"].ToString()));
                    personalCientifico.setCorreoElectronicoInstitucional(resP["correoIntitucional"].ToString());
                    personalCientifico.setCorreoElectronicoPersonal(resP["correoPersonal"].ToString());
                    personalCientifico.setTelefonoCelular(resP["telefonoCelular"].ToString());

                    asignacionCientificoCI.setFechaDesde(DateTime.Parse(resP["fechaDesde"].ToString()));
                    asignacionCientificoCI.setFechaHasta(DateTime.Parse(resP["fechaHasta"].ToString()));

                    asignacionCientificoCI.setPersonalCientifico(personalCientifico);

                    asignacionCientificoCIs.Add(asignacionCientificoCI);

                    usuario.setUsuario(resP["usuario"].ToString());
                    usuario.setClave(resP["contraseña"].ToString());
                    usuario.setHabilitado(bool.Parse(resP["habilitado"].ToString()));

                    personalCientifico.setUsuario(usuario);
                }

                centroDeInvestigacion.setRecursoTecnologico(recursoTecnologicos);
                centroDeInvestigacion.setAsignacionCientificoCI(asignacionCientificoCIs);
            }

            

        }
    }
}
