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

        //Le pide a personal cientifico que compare usuario del personal con el logeado
        public string esCientificoDeMiCentro(Usuario usuario)
        {
            if(personalCientifico.validarUsuarioLogeado(usuario))
            {
                return personalCientifico.getEmailInstitucional();
            }    
            else
            {
                return "";
            }
        }
        
        public bool esVigente()
        {
            if (fechaHasta.ToString() == "1/1/0001 00:00:00")
            {
                return true;
            }
            return false;
        }
    }
}
