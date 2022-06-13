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
        public List<CentroDeInvestigacion> GetCentroDeInvestigaciones()
        {
            BaseDatos bd = new BaseDatos();
            string consulta = "SELECT * FROM CENTRO_INVESTIGACION";
            var centroDeInvestigaciones = new List<CentroDeInvestigacion>();
            

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
                //centroDeInvestigacion.setFechaResolucionCreacion(DateTime.Parse(resultado["fechaResolucionCreacion"].ToString()));
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

                foreach (DataRow res in resRT.Rows)
                {
                    var recursoTecnologico = new RecursoTecnologico();
                    recursoTecnologico.setNumeroRT(Int32.Parse(res["numeroRT"].ToString()));
                    recursoTecnologico.setFechaAlta(DateTime.Parse(res["fechaAlta"].ToString()));
                    recursoTecnologico.setImagenes(res["imagenes"].ToString());
                    recursoTecnologico.setPeriodicidadMantenimientoPreventivo(Int32.Parse(res["periodicidadMantenimientoPreventivo"].ToString()));
                    recursoTecnologico.setDuracionMantenimientoPreventivo(Int32.Parse(res["duracionMantenimientoPreventivo"].ToString()));
                    recursoTecnologico.setFraccionHorarioTurnos(Int32.Parse(res["fraccionHorarioTurnos"].ToString()));

                    
                    //recursoTecnologicos.Add(recursoTecnologico);

                    string consulta8 = "SELECT * FROM TURNO t JOIN TURNOS_X_RT x ON t.id = x.idTurno WHERE x.idRT = " + recursoTecnologico.getNumeroRT().ToString();
                    DataTable resTurno = bd.consulta(consulta8);

                    
                    var listaTurnos = new List<Turno>();
                    foreach (DataRow respuesta in resTurno.Rows)
                    {
                        var turno = new Turno();
                        turno.setFechaGeneracion(DateTime.Parse(respuesta["fechaGeneracion"].ToString()));
                        turno.setDiaSemana(respuesta["diaSemana"].ToString());
                        turno.setFechaHoraInicio(DateTime.Parse(respuesta["fechaHoraInicio"].ToString()));
                        turno.setFechaHoraFin(DateTime.Parse(respuesta["fechaHoraFin"].ToString()));
                        listaTurnos.Add(turno);

                        string consulta4 = "SELECT * FROM CAMBIO_ESTADO_TURNO ce INNER JOIN ESTADO e ON ce.idEstado = e.id JOIN CAMBIO_ESTADOS_X_TURNO x ON ce.id = x.idCambioEstadoT JOIN TURNO t ON x.idTurno = t.id WHERE t.fechaHoraInicio = '" + turno.getFechaHoraInicio() + "'";
                        DataTable resEstado = bd.consulta(consulta4);

                        
                        var cambioDeEstadoTurnos = new List<CambioDeEstadoTurno>();
                        foreach (DataRow resE in resEstado.Rows)
                        {
                            var estado = new Estado();
                            var cambioDeEstadoTurno = new CambioDeEstadoTurno();
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
                    string consulta7 = "SELECT * FROM TIPO_RT t  JOIN RECURSO_TECNOLOGICO rt ON rt.idTipoRT = t.id WHERE rt.numeroRT = " + recursoTecnologico.getNumeroRT();
                    DataTable resTipoRT = bd.consulta(consulta7);
                    
                    foreach (DataRow resTipo in resTipoRT.Rows)
                    {
                        var tipoRT = new TipoRT();
                        tipoRT.setNombre(resTipo["nombre"].ToString());
                        tipoRT.setDescripcion(resTipo["descripcion"].ToString());

                        recursoTecnologico.setTipoRT(tipoRT);
                    }
                    

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

                    string consulta5 = "SELECT * FROM CAMBIO_ESTADO_RT ce INNER JOIN ESTADO e ON e.id = ce.idEstado JOIN CAMBIO_ESTADOS_X_RT x ON x.idCambioEstadoRT = ce.id  WHERE x.idRT = " + recursoTecnologico.getNumeroRT();
                    DataTable resEstadoRT = bd.consulta(consulta5);
                    
                    var cambioDeEstadoRTs = new List<CambioDeEstadoRT>();
                    foreach (DataRow resERT in resEstadoRT.Rows)
                    {
                        var estadoRT = new Estado();
                        var cambioDeEstadoRT = new CambioDeEstadoRT();
                        estadoRT.setNombre(resERT["nombre"].ToString());
                        estadoRT.setDescripcion(resERT["descripcion"].ToString());
                        estadoRT.setAmbito(resERT["ambito"].ToString());

                        if (resERT["fechaHoraHasta"].ToString() != "")
                        {
                            cambioDeEstadoRT.setFechaHoraHasta(DateTime.Parse(resERT["fechaHoraHasta"].ToString()));
                        }
                        cambioDeEstadoRT.setFechaHoraDesde(DateTime.Parse(resERT["fechaHoraDesde"].ToString()));

                        cambioDeEstadoRT.setEstado(estadoRT);

                        cambioDeEstadoRTs.Add(cambioDeEstadoRT);
                    }

                    recursoTecnologico.setCambioEstadoRT(cambioDeEstadoRTs);
                    recursoTecnologico.setTurno(listaTurnos);
                    recursoTecnologicos.Add(recursoTecnologico);
                }

                string consulta3 = "SELECT * FROM ASIGNACION_CIENTIFICO_CI a INNER JOIN PERSONAL_CIENTIFICO pc ON a.idCientifico = pc.legajo INNER JOIN USUARIO u ON pc.legajo = u.legajoPersonal JOIN ASIGNACIONES_X_CI x ON x.idAsignacion = a.id JOIN CENTRO_INVESTIGACION ci ON ci.id = x.idCI WHERE ci.nombreCentro = '" + centroDeInvestigacion.getNombre() + "'";
                DataTable resPersonal = bd.consulta(consulta3);
                
                var asignacionCientificoCIs = new List<AsignacionCientificoCI>();
                foreach (DataRow resP in resPersonal.Rows)
                {
                    var asignacionCientificoCI = new AsignacionCientificoCI();
                    var personalCientifico = new PersonalCientifico();
                    var usuario = new Usuario();

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

                    usuario.setUsuario(resP["usuario"].ToString());
                    usuario.setClave(resP["contraseña"].ToString());
                    usuario.setHabilitado(bool.Parse(resP["habilitado"].ToString()));

                    personalCientifico.setUsuario(usuario);
                }

                centroDeInvestigacion.setRecursoTecnologico(recursoTecnologicos);
                centroDeInvestigacion.setAsignacionCientificoCI(asignacionCientificoCIs);
                centroDeInvestigaciones.Add(centroDeInvestigacion);
            }

            return centroDeInvestigaciones;

        }
    }
}
