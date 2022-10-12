using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class SinAntelacion : IEstrategiaAntelacion 
    {
        public List<string> buscarTurnos(DateTime fechaActual, String recursoTecnologicoSeleccionado, CentroDeInvestigacion centro)
        {
            return centro.buscarTurnoPosteriorFechaActual(fechaActual, recursoTecnologicoSeleccionado);
        }
    }
}
