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
        private List<TipoRT> tipoRT;
        public GestorTurnoRT(Usuario usuario)
        {
            this.usuario = usuario;
        }

        public void opcionReservarTurno(PantallaAdministrarTurno pantallaAdministrarTurno)
        {
            tipoRT = buscarTipoRT();
            pantallaAdministrarTurno.mostrarTipoRT(tipoRT);
        }

        public List<TipoRT> buscarTipoRT()
        {
            // iterador que retorne tipoRTs
            return RepositorioTipoRT.GetTipoRTs();
        }
    }
}
