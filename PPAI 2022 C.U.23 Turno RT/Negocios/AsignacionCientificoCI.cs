using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_2022_C.U._23_Turno_RT.Negocios
{
    class AsignacionCientificoCI
    {
        private DateTime fechaDesde { get; set; }
        private DateTime fechaHasta { get; set; }
        private PersonalCientifico personalCientifico {get; set; }

        public void setFechaHasta(DateTime fecha)
        {
            fechaHasta = fecha;
        }

        public void setFechaDesde(DateTime fecha)
        {
            fechaDesde = fecha;
        }

        public void setPersonalCientifico(PersonalCientifico personal)
        {
            personalCientifico = personal;
        }

        public bool esCientificoMiCentro(Usuario usuario)
        {

            return personalCientifico.validarUsuarioLogeado(usuario);
        }

        public string getEmailCientifico()
        {
            return personalCientifico.getEmailInstitucional();
        }
    }
}
