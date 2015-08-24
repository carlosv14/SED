using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEvaluador
{
    public class Indicadores_Arr:IComparable<Indicadores_Arr>
    {

       public string descp;
       public float peso;

       public List<Indicadores_Arr> IndicadoresEspecificos;
        public Indicadores_Arr(string descp, float peso)
        {
            this.descp = descp;
            this.peso = peso;
            IndicadoresEspecificos=new List<Indicadores_Arr>();
        }

        public int CompareTo(Indicadores_Arr obj)
        {
            if (this.peso > obj.peso)
                return 1;
            else if (this.peso < obj.peso)
                return -1;
            else
                return 0;
        }
    }
}
