using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEvaluador
{
    public class Evaluador_Calculos
    {

        public List<Indicadores_Calc_arr> calculos;
        public float resultado;
        public List<float> triangulares;
        public List<float> posibles_triangulares;
        public Evaluador_Calculos(List<Indicadores_Calc_arr> calculos)
        {
           this.calculos = calculos;
            this.resultado = 0;
            triangulares = new List<float>();
            posibles_triangulares = new List<float>();

            posibles_triangulares.Add(0);
        }

        public void Calcular_Indicador()
        {
            Indicadores_Calc_arr indicador = null;
            float peso=0;
            float oper=0;
            for (int j = 1; j <= indicador.cantidad_grados; j++)
            {
                posibles_triangulares.Add(j / (indicador.cantidad_grados - 1));
            }

            triangulares.Add(posibles_triangulares.ElementAt(0));
            triangulares.Add(posibles_triangulares.ElementAt(0));
            for (int i = 1; i < posibles_triangulares.Count; i++)
            {
                triangulares.Add(posibles_triangulares.ElementAt(i));
                triangulares.Add(posibles_triangulares.ElementAt(i - 1));
                triangulares.Add(posibles_triangulares.ElementAt(i));
            }

            for (int i = 0; i < calculos.Count; i++)
            {
                 
                indicador = calculos.ElementAt(i);
                peso = indicador.indicador.peso/100;
                oper = (indicador.grado_selec/(indicador.cantidad_grados));
                resultado = peso*oper;
                indicador.respuesta = resultado;
                resultado = 0;
            }

            

        }
    }
}
