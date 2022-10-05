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

        public List<CentroDeInvestigacion> GetCentroDeInvestigaciones(List<Estado> estados, Sesion sesion, List<TipoRT> tiposRT)
        {
            BaseDatos bd = new BaseDatos();
            string consulta = "SELECT * FROM CENTRO_INVESTIGACION";
            var centroDeInvestigaciones = new List<CentroDeInvestigacion>();
            

            //Carga los centros de investigacion
            foreach (DataRow resultado in bd.consulta(consulta).Rows)
            {
                var centroDeInvestigacion = new CentroDeInvestigacion();

                centroDeInvestigacion.setNombre(resultado["nombreCentro"].ToString());
                centroDeInvestigacion.setSigla(resultado["sigla"].ToString());
                centroDeInvestigacion.setDireccion(resultado["direccion"].ToString());
                centroDeInvestigacion.setEdificio(resultado["edificio"].ToString());
                centroDeInvestigacion.setPiso(resultado["piso"].ToString());
                centroDeInvestigacion.setCoordenadas(resultado["coordenadas"].ToString());
                centroDeInvestigacion.setTelefonoContacto(resultado["telefonoContacto"].ToString());
                centroDeInvestigacion.setCorreoElectronico(resultado["correoElectronico"].ToString());
                centroDeInvestigacion.setNumeroResolucionCreacion(Int32.Parse(resultado["numeroResolucionCreacion"].ToString()));
                centroDeInvestigacion.setReglamento(resultado["reglamento"].ToString());
                centroDeInvestigacion.setCaracteristicasGenerales(resultado["caracteristicasGenerales"].ToString());
                centroDeInvestigacion.setFechaAlta(DateTime.Parse(resultado["fechaAlta"].ToString()));
                centroDeInvestigacion.setTiempoAntelacionReserva(resultado["tiempoAntelacionReserva"].ToString());
                if (resultado["fechaBaja"].ToString() != "")
                {
                    centroDeInvestigacion.setFechaBaja(DateTime.Parse(resultado["fechaBaja"].ToString()));
                    centroDeInvestigacion.setMotivoBaja(resultado["motivoBaja"].ToString());
                }
                string consulta2 = "SELECT * FROM RECURSO_TECNOLOGICO JOIN RT_X_CI x ON numeroRT = x.idRT JOIN CENTRO_INVESTIGACION ci ON  x.idCI = ci.id WHERE ci.nombreCentro = '" + centroDeInvestigacion.getNombre() + "'";
                DataTable resRT = bd.consulta(consulta2);
                
                var recursoTecnologicos = new List<RecursoTecnologico>();

                //Carga los recursos tecnologicos de los centros
                foreach (DataRow res in resRT.Rows)
                {
                    var recursoTecnologico = new RecursoTecnologico();
                    recursoTecnologico.setNumeroRT(Int32.Parse(res["numeroRT"].ToString()));
                    recursoTecnologico.setFechaAlta(DateTime.Parse(res["fechaAlta"].ToString()));
                    recursoTecnologico.setImagenes(res["imagenes"].ToString());
                    recursoTecnologico.setPeriodicidadMantenimientoPreventivo(Int32.Parse(res["periodicidadMantenimientoPreventivo"].ToString()));
                    recursoTecnologico.setDuracionMantenimientoPreventivo(Int32.Parse(res["duracionMantenimientoPreventivo"].ToString()));
                    recursoTecnologico.setFraccionHorarioTurnos(Int32.Parse(res["fraccionHorarioTurnos"].ToString()));

                    string consulta8 = "SELECT * FROM TURNO t JOIN TURNOS_X_RT x ON t.id = x.idTurno WHERE x.idRT = " + recursoTecnologico.getNumeroRT().ToString();
                    DataTable resTurno = bd.consulta(consulta8);

                    //Carga los turnos para este RT
                    var listaTurnos = new List<Turno>();
                    foreach (DataRow respuesta in resTurno.Rows)
                    {
                        var turno = new Turno();
                        turno.setID(int.Parse(respuesta["id"].ToString()));
                        turno.setFechaGeneracion(DateTime.Parse(respuesta["fechaGeneracion"].ToString()));
                        turno.setDiaSemana(respuesta["diaSemana"].ToString());
                        turno.setFechaHoraInicio(DateTime.Parse(respuesta["fechaHoraInicio"].ToString()));
                        turno.setFechaHoraFin(DateTime.Parse(respuesta["fechaHoraFin"].ToString()));
                        listaTurnos.Add(turno);

                        string consulta4 = "SELECT * FROM CAMBIO_ESTADO_TURNO ce INNER JOIN ESTADO e ON ce.idEstado = e.id JOIN CAMBIO_ESTADOS_X_TURNO x ON ce.id = x.idCambioEstadoT WHERE x.idTurno  = " + turno.getID();
                        DataTable resEstado = bd.consulta(consulta4);

                        //Carga los cambios de estados para este turno
                        var cambioDeEstadoTurnos = new List<CambioDeEstadoTurno>();
                        foreach (DataRow resE in resEstado.Rows)
                        {
                            var cambioDeEstadoTurno = new CambioDeEstadoTurno();
                            if (resE["fechaHoraHasta"].ToString() != "")
                            {
                                cambioDeEstadoTurno.setFechaHoraHasta(DateTime.Parse(resE["fechaHoraHasta"].ToString()));
                            }
                            cambioDeEstadoTurno.setFechaHoraDesde(DateTime.Parse(resE["fechaHoraDesde"].ToString()));

                            //Valida los Estados encontrados y asigna el correspondiente a cada cambio
                            foreach (Estado est in estados)
                            {
                                if (est.esAmbitoTurno())
                                {
                                    if (est.getNombre() == resE["nombre"].ToString())
                                    {
                                        cambioDeEstadoTurno.setEstado(est);
                                    }
                                }
                            }

                            cambioDeEstadoTurnos.Add(cambioDeEstadoTurno);
                        }

                        turno.setCambioDeEstadoTurno(cambioDeEstadoTurnos);

                    }

                    //Valida los TiposRT encontrados y asigna a cada uno el correspondiente
                    string consulta7 = "SELECT * FROM TIPO_RT t  JOIN RECURSO_TECNOLOGICO rt ON rt.idTipoRT = t.id WHERE rt.numeroRT = " + recursoTecnologico.getNumeroRT();
                    DataTable resTipoRT = bd.consulta(consulta7);

                    foreach (DataRow resTipo in resTipoRT.Rows)
                    {
                        foreach (TipoRT tipo in tiposRT)
                        {
                            if (tipo.getNombre() == resTipo["nombre"].ToString())
                            {
                                recursoTecnologico.setTipoRT(tipo);
                            }
                        }
                    }
                    
                    //Carga los modelos y marca por RT
                    string consulta6 = "SELECT * FROM MODELO mo JOIN MODELOS_X_MARCA x ON x.idModelo = mo.id JOIN MARCA m ON x.idMarca = m.id JOIN RECURSO_TECNOLOGICO rt ON rt.idModelo = mo.id WHERE rt.numeroRT = " + recursoTecnologico.getNumeroRT();
                    DataTable resMarcas = bd.consulta(consulta6);
                    
                    foreach (DataRow resMarca in resMarcas.Rows)
                    {
                        var modelo = new Modelo();
                        var marca = new Marca();
                        modelo.setNombre(resMarca["nombreModelo"].ToString());
                        marca.setNombre(resMarca["nombreMarca"].ToString());

                        modelo.setMarca(marca);

                        recursoTecnologico.setModelo(modelo);
                    }

                    //Carga cada cambio de estado por cada rt
                    string consulta5 = "SELECT * FROM CAMBIO_ESTADO_RT ce INNER JOIN ESTADO e ON e.id = ce.idEstado JOIN CAMBIO_ESTADOS_X_RT x ON x.idCambioEstadoRT = ce.id  WHERE x.idRT = " + recursoTecnologico.getNumeroRT();
                    DataTable resEstadoRT = bd.consulta(consulta5);
                    
                    var cambioDeEstadoRTs = new List<CambioDeEstadoRT>();
                    foreach (DataRow resERT in resEstadoRT.Rows)
                    {
                        var cambioDeEstadoRT = new CambioDeEstadoRT();

                        if (resERT["fechaHoraHasta"].ToString() != "")
                        {
                            cambioDeEstadoRT.setFechaHoraHasta(DateTime.Parse(resERT["fechaHoraHasta"].ToString()));
                        }
                        cambioDeEstadoRT.setFechaHoraDesde(DateTime.Parse(resERT["fechaHoraDesde"].ToString()));

                        //Valida los estados encontrados y lo asigna a el cambio correspondiente
                        foreach (Estado est in estados)
                        {
                            //Primero valida el ambito del estado
                            if (!est.esAmbitoTurno())
                            {
                                if (est.getNombre() == resERT["nombre"].ToString())
                                {
                                    cambioDeEstadoRT.setEstado(est);
                                }
                            }
                        }
                        cambioDeEstadoRTs.Add(cambioDeEstadoRT);
                    }

                    recursoTecnologico.setCambioEstadoRT(cambioDeEstadoRTs);
                    recursoTecnologico.setTurno(listaTurnos);
                    recursoTecnologicos.Add(recursoTecnologico);
                }

                //Carga las asignaciones y los cientificos
                string consulta3 = "SELECT * FROM ASIGNACION_CIENTIFICO_CI a INNER JOIN PERSONAL_CIENTIFICO pc ON a.idCientifico = pc.legajo INNER JOIN USUARIO u ON pc.legajo = u.legajoPersonal JOIN ASIGNACIONES_X_CI x ON x.idAsignacion = a.id JOIN CENTRO_INVESTIGACION ci ON ci.id = x.idCI WHERE ci.nombreCentro = '" + centroDeInvestigacion.getNombre() + "'";
                DataTable resPersonal = bd.consulta(consulta3);
                
                var asignacionCientificoCIs = new List<AsignacionCientificoCI>();
                foreach (DataRow resP in resPersonal.Rows)
                {
                    var asignacionCientificoCI = new AsignacionCientificoCI();
                    var personalCientifico = new PersonalCientifico();

                    personalCientifico.setLegajo(Int32.Parse(resP["legajo"].ToString()));
                    personalCientifico.setNombre(resP["nombre"].ToString());
                    personalCientifico.setApellido(resP["apellido"].ToString());
                    personalCientifico.setNumeroDocumento(Int32.Parse(resP["dni"].ToString()));
                    personalCientifico.setCorreoElectronicoInstitucional(resP["correoInstitucional"].ToString());
                    personalCientifico.setCorreoElectronicoPersonal(resP["correoPersonal"].ToString());
                    personalCientifico.setTelefonoCelular(resP["telefonoCelular"].ToString());

                    asignacionCientificoCI.setFechaDesde(DateTime.Parse(resP["fechaDesde"].ToString()));
                    if (resP["fechaHasta"].ToString() != "")
                    {
                        asignacionCientificoCI.setFechaHasta(DateTime.Parse(resP["fechaHasta"].ToString()));
                    }

                    asignacionCientificoCI.setPersonalCientifico(personalCientifico);

                    asignacionCientificoCIs.Add(asignacionCientificoCI);


                    //Valida el usuario de la sesion con los de cada personal y los asigna a los correspondientes
                    Usuario usu = sesion.getUsuario();
                    if (usu.getUsuario() == resP["usuario"].ToString())
                    {
                        personalCientifico.setUsuario(usu);
                    }
                    else
                    {
                        var usuario = new Usuario();
                        usuario.setUsuario(resP["usuario"].ToString());
                        usuario.setClave(resP["contraseña"].ToString());
                        usuario.setHabilitado(bool.Parse(resP["habilitado"].ToString()));

                        personalCientifico.setUsuario(usuario);
                    }

                    
                }

                centroDeInvestigacion.setRecursoTecnologico(recursoTecnologicos);
                centroDeInvestigacion.setAsignacionCientificoCI(asignacionCientificoCIs);
                centroDeInvestigaciones.Add(centroDeInvestigacion);
            }

            return centroDeInvestigaciones;

        }
    }
}
