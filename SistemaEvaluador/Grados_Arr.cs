using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEvaluador
{
    public class Grados_Arr
    {
        string descp;
        float peso;
        int id_indicador;
        public Grados_Arr(string descp, float peso,int id_indicador)
        {
            this.descp = descp;
            this.peso = peso;
            this.id_indicador = id_indicador;
        }
    }
}
