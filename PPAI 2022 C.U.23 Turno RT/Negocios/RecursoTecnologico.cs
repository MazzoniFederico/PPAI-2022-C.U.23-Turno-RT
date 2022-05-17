﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class RecursoTecnologico
    {
        private int numeroRT { get; set; }
        private DateTime fechaAlta { get; set; }
        private String imagenes { get; set; } /* no estoy seguro */
        private int periodicidadMantenimientoPreventivo { get; set; }
        private int duracionMantenimientoPreventivo { get; set; }
        private int fraccionHorarioTurnos { get; set; }
        private List<Turno> turno { get; set; }
        private List<CambioDeEstadoRT> cambioDeEstadoRT { get; set; }
        private TipoRT tipoRT { get; set;  }
    }
}
