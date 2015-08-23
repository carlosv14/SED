using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEvaluador
{
    public class Grados_Arr:IComparable<Grados_Arr>
    {

       public string descp;
       public float peso;
        public Grados_Arr(string descp, float peso)

        {
            this.descp = descp;
            this.peso = peso;
           
        }

        public int CompareTo(Grados_Arr obj)
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
