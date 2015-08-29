using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEvaluador
{
    public class Indicadores_Calc_arr
    {
       public Indicadores_Arr indicador;
       public int grado_selec;
        public int id_padre;
        public float respuesta;
        public float cantidad_grados;
        public Indicadores_Calc_arr(Indicadores_Arr indicador,int grado_selec, int id_padre,float respuesta,float cantidad_grados)
        {
            this.indicador = indicador;
            this.grado_selec = grado_selec;
            this.id_padre = id_padre;
            this.cantidad_grados = cantidad_grados;
            this.respuesta = respuesta;
        }  
    }
}
