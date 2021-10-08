using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algobanquero
{
    public class Proceso
    {
        public string name;
        public int id;

        private int[] necesidades;
        private int[] maximos;
        private int[] asignados;

        public Proceso(int idProceso, int[] existenciaArray, int[,] maximoMatrix, int[,] asignadoMatrix, int[,] necesidadMatrix)
        {
            this.id = idProceso;
            this.name = "P" + id;
            
            necesidades = new int[existenciaArray.Length];
            maximos = new int[existenciaArray.Length];
            asignados = new int[existenciaArray.Length];

            for (int recurso = 0; recurso < existenciaArray.Length; recurso++)
            {
                this.maximos[recurso] = maximoMatrix[idProceso, recurso];
                this.asignados[recurso] = asignadoMatrix[idProceso, recurso];
                this.necesidades[recurso] = necesidadMatrix[idProceso, recurso];
            }
        }

        public int maximo(int idRecurso)
        {
            return this.maximos[idRecurso];
        }
        public int necesidad(int idRecurso)
        {
            return this.necesidades[idRecurso];
        }
        public int asignado(int idRecurso)
        {
            return this.asignados[idRecurso];
        }
    }
}
