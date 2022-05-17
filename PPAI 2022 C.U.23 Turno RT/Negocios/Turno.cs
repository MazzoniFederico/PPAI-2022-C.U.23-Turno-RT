using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class Turno
    {
        private DateTime fechaGeneracion { get; set; }
        private String diaSemana { get; set; }
        private DateTime fechaHoraInicio { get; set; }
        private DateTime fechaHoraFin { get; set; }
        private List<CambioDeEstadoTurno> cambioDeEstadoTurno { get; set; }

    }
}
