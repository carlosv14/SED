using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEvaluador
{
    public class CoordenadaTriangular
    {
        public List<NumeroTriangular> NumeroBorrosoTriangular;
        public List<string> NombreCoordenada ;
        public float cantidadGrados;
        public string Indicador;

        public CoordenadaTriangular(List<string> NombreCoordenada, float cg,string Indicador)
        {
        
            this.NombreCoordenada = NombreCoordenada;
            this.cantidadGrados = cg;
            this.Indicador = Indicador;
            this.NumeroBorrosoTriangular = new List<NumeroTriangular>();
            GenerarBorroso();
        }

        public void GenerarBorroso()
        {
            
            for (int i = 0; i < cantidadGrados ; i++)
            {
                NumeroTriangular nt = new NumeroTriangular();
                if (i == 0)
                {
                    nt.x = 0;
                    nt.y = 0;
                    nt.z = (i + 1)/(cantidadGrados - 1);
                }
                else if (i != cantidadGrados - 1)
                {
                    nt.x = (i - 1)/(cantidadGrados - 1);
                    nt.y = i/(cantidadGrados - 1);
                    nt.z = (i + 1)/(cantidadGrados - 1);
                }
                else
                {
                    nt.x = (i - 1) / (cantidadGrados - 1);
                    nt.y = 1;
                    nt.z = 1;
                }
                NumeroBorrosoTriangular.Add(nt);
            }
        }

    }
}
