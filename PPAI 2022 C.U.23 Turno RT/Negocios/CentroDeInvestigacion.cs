using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class CentroDeInvestigacion
    {
        private String nombre { get; set; }
        private String sigla { get; set; }
        private String direccion { get; set; }
        private String edificio { get; set; }
        private String piso { get; set; }
        private String coordenadas { get; set; }
        private String telefonosContacto { get; set; }
        private String correoElectronico { get; set; }
        private String numeroResolucionCreacion { get; set; }
        private DateTime fechaResolucionCreacion { get; set; }
        private String reglamento { get; set; }
        private String caracteristicasGenerales { get; set; }
        private DateTime fechaAlta { get; set; }
        private String tiempoAntelacionReserva { get; set; }
        private DateTime fechaBaja { get; set; } 
        private String motivoBaja { get; set; }
        private List<AsignacionCientificoCI> asignacionCientificoCI { get; set; }
        private List<RecursoTecnologico> recursoTecnologico { get; set; }

    }
}
