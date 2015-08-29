using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEvaluador
{
    public class Resultado_Indicadores_Generales
    {
        private string Indicador;
        private float value;
        public Resultado_Indicadores_Generales(string Indicador, float value)
        {
            this.Indicador = Indicador;
            this.value = value;
        }
    }
}
