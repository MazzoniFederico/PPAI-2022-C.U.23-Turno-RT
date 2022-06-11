using PPAI_2022_C.U._23_Turno_RT.Boundary_s;
using PPAI_2022_C.U._23_Turno_RT.Negocios;
using PPAI_2022_C.U._23_Turno_RT.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Controladores
{
    public class GestorTurnoRT
    {
        private Usuario usuario;
        private List<TipoRT> tipoRTs;
        private List<TipoRT> tipoRTSeleccionada;
        private List<CentroDeInvestigacion> centroDeInvestigacion;
        private List<string> recursoTecnologico;
        private List<List<string>> recursoTecnologicoPorCentro;

        public GestorTurnoRT(Usuario usuario)
        {
            this.usuario = usuario;
        }

        public void opcionReservarTurno(PantallaAdministrarTurno pantallaAdministrarTurno)
        {
            tipoRTs = buscarTipoRT();
            pantallaAdministrarTurno.mostrarTipoRT(tipoRTs);
            //pantalla inicia tomarTipoRT
            buscarRTPorTipo();
            pantallaAdministrarTurno.mostrarDatosRT(recursoTecnologicoPorCentro);
            pantallaAdministrarTurno.solicitarSeleccionRT();
            
        }

        public List<TipoRT> buscarTipoRT()
        {
            // iterador que retorne tipoRTs
            return RepositorioTipoRT.GetTipoRTs();
        }

        public void tomarTipoRT(List<TipoRT> tipoRT)
        {
            this.tipoRTSeleccionada = tipoRT;
            return;
        }

        public void buscarRTPorTipo()
        {
          
            List<string> recursosCentro;
            for (var i = 0; i < centroDeInvestigacion.Count; i++)
            {
                string nombreCentro = centroDeInvestigacion[i].getNombre();
                recursosCentro = centroDeInvestigacion[i].buscarRTPorTipo(tipoRTSeleccionada);

                for (int j = 0; j < recursosCentro.Count; j++)
                {
                    recursoTecnologico.Add(recursosCentro[j]);
                    
                    recursoTecnologicoPorCentro[j][0] = nombreCentro;
                    recursoTecnologicoPorCentro[j][1] = recursosCentro[j];


                }

            }



        }

        public void ordenarRTPorCentroDeInvestigacion()
        {

        }
    }
}
