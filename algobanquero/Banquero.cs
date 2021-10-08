using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algobanquero
{
    public class Banquero
    {
        private int nProcesos;
        private int nRecursos;
        
        public int[] existencia;
        public int[] disponible;
        public int[] disponiblePreview;

        public int[,] maximo;
        public int[,] asignado;
        public int[,] necesidad;
        public int procesosRestantesCantidad;

        public Proceso ultimoProceso;

        private Dictionary<int, Proceso> procesos = new Dictionary<int, Proceso>();
        private Dictionary<int, Proceso> procesosRestantes = new Dictionary<int, Proceso>();

        public Banquero(int[] existencia, int[,] maximo, int[,] asignado, int[,] necesidad)
        {
            //ASIGNAR MATRICES Y VECTORES//
            this.nRecursos = existencia.Length;
            this.nProcesos = maximo.Length / existencia.Length;
            this.existencia = existencia;
            this.maximo = maximo;
            this.asignado = asignado;
            this.necesidad = necesidad;
            this.disponiblePreview = new int[nRecursos];

            //CALCULAR NECESIDAD Y DISPONIBILIDAD//
            this.calcularDisponibilidadInicial();

            //CREAR PROCESOS//
            for (int proceso = 0; proceso < nProcesos; proceso++)
            {
                procesos.Add(proceso, new Proceso(proceso, existencia, maximo, asignado, necesidad));
                procesosRestantes.Add(proceso, new Proceso(proceso, existencia, maximo, asignado, necesidad));
            }

            //ELIMINAR PROCESOS SIN ASIGNACION NI NECESIDAD//
            bool procesoInvalido = true;
            foreach (KeyValuePair<int, Proceso> proceso in procesos)
            {
                procesoInvalido = true;
                for (int recurso = 0; recurso < nRecursos; recurso++)
                {
                    if (proceso.Value.asignado(recurso) != 0 || proceso.Value.necesidad(recurso) != 0)
                        procesoInvalido = false;
                }
                if (procesoInvalido)
                    procesosRestantes.Remove(proceso.Key);
            }

            this.procesosRestantesCantidad = this.procesos.Count;

            eliminarProcesosInnecesarios();
        }
        
        private int siguienteProcesoValido()
        {
            bool valido = true;
            foreach (KeyValuePair<int, Proceso> proceso in procesosRestantes)
            {
                valido = true;
                for (int recurso = 0; recurso < nRecursos; recurso++)
                    if (proceso.Value.necesidad(recurso) > disponible[recurso])
                        valido = false;

                if (valido)
                    return proceso.Key;
            }
            return -1;
        } //Devuelve el id del proximo proceso que puede ejecutar o si se encuentra en interbloqueo (-1)
        public bool existenEstadosSeguros()
        {
            while (calcularSiguienteDisponibilidad()) ; //calculo la disponibilidad
            int aux = procesosRestantesCantidad;        
            reiniciarSecuencia();                       //dejamos todo como estaba

            if (aux == 0)                               //me fijo si ejecutaron todos los procesos
                return true;
            else
                return false;
        } //Chequea si hay estados seguros y deja todo como estaba
        public bool calcularSiguienteDisponibilidadPreview()
        {
            int siguienteProceso = siguienteProcesoValido();
            if (siguienteProceso != -1)
            {
                for (int recurso = 0; recurso < nRecursos; recurso++)
                    disponiblePreview[recurso] = disponible[recurso] - procesos[siguienteProceso].necesidad(recurso);
                ultimoProceso = procesos[siguienteProceso];
                return true;
            }
            else
                return false;   //interbloqueo
        } //calcula el vector de disponibilidad en base al siguiente proceso valido (solo resta la necesidad para mostrar a modo de preview)
        public bool calcularSiguienteDisponibilidad()
        {
            if (procesosRestantesCantidad == 0)
                return false;

            int siguienteProceso = siguienteProcesoValido();
            if (siguienteProceso != -1)
            {
                for (int recurso = 0; recurso < nRecursos; recurso++)
                    disponible[recurso] = disponible[recurso] - procesos[siguienteProceso].necesidad(recurso) + procesos[siguienteProceso].maximo(recurso);
                procesosRestantes.Remove(siguienteProceso);
                ultimoProceso = procesos[siguienteProceso];
                procesosRestantesCantidad--;
                return true;
            }
            else
                return false;   //interbloqueo
        } //calcula el vector de disponibilidad en base al siguiente proceso valido
        public void reiniciarSecuencia()
        {
            this.procesosRestantesCantidad = this.procesos.Count;
            this.procesosRestantes.Clear();
            foreach (KeyValuePair<int, Proceso> proceso in procesos)
                procesosRestantes.Add(proceso.Key, proceso.Value);
            eliminarProcesosInnecesarios();
            calcularDisponibilidadInicial();
        } //reinicia la lista de procesos restantes, su cantidad, y calcula la disponibilidad inical

        private void calcularDisponibilidadInicial()
        {
            //CALCULAR DISPONIBILIDAD INICIAL//
            disponible = new int[existencia.Length];
            Array.Copy(this.existencia, this.disponible, this.existencia.Length);
            for (int proceso = 0; proceso < nProcesos; proceso++)
                for (int recurso = 0; recurso < nRecursos; recurso++)
                    disponible[recurso] -= asignado[proceso, recurso];
        } //calcula la disponibilidad incial
        private void eliminarProcesosInnecesarios()
        {
            bool procesoInvalido = true;
            foreach (KeyValuePair<int, Proceso> proceso in procesos)
            {
                procesoInvalido = true;
                for (int recurso = 0; recurso < nRecursos; recurso++)
                {
                    if (proceso.Value.asignado(recurso) != 0 || proceso.Value.necesidad(recurso) != 0)
                        procesoInvalido = false;
                }
                if (procesoInvalido)
                {
                    procesosRestantesCantidad--;
                    procesosRestantes.Remove(proceso.Key);
                }
            }
        }
    }
}
