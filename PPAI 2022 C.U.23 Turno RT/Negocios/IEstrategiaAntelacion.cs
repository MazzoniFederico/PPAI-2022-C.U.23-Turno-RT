using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    interface IEstrategiaAntelacion
    {
        List<String> buscarTurnos(DateTime fechaActual, String recursoTecnologicoSeleccionado, CentroDeInvestigacion centro);
    }
}
