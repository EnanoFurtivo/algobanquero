using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace algobanquero
{
    //Delegados de formulario de tablas
    public delegate void CargarMatricesClickHandler();
    public delegate void SiguienteProcesoClickHandler();
    public delegate void SiguienteProcesoEnterHandler();
    public delegate void SiguienteProcesoLeaveHandler();
    public delegate void ReiniciarClickHandler();

    static class Program
    {
        static private Banquero banquero = null;

        static private int[] existenciaArray = null;
        static private int[,] maximoMatrix = null;
        static private int[,] asignadoMatrix = null;
        static private int[,] necesidadMatrix = null;

        static private FormularioCargaMatrices formularioCarga;
        static private FormularioTablas formularioTablas;

        static private bool previewDrawn;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formularioTablas = new FormularioTablas();
            formularioTablas.CargarMatricesClickEvent += new CargarMatricesClickHandler(abrirFormularioCarga);
            formularioTablas.SiguienteProcesoClickEvent += new SiguienteProcesoClickHandler(siguienteProcesoClick);
            formularioTablas.SiguienteProcesoEnterEvent += new SiguienteProcesoEnterHandler(siguienteProcesoEnter);
            formularioTablas.SiguienteProcesoLeaveEvent += new SiguienteProcesoLeaveHandler(siguienteProcesoLeave);
            formularioTablas.ReiniciarClickEvent += new ReiniciarClickHandler(reiniciarClick);
            Application.Run(formularioTablas);
        }

        static private void abrirFormularioTablas(object sender, EventArgs e)
        {
            if (!formularioCarga.cancelado)
            {
                existenciaArray = formularioCarga.existenciaArray;
                maximoMatrix = formularioCarga.maximoMatrix;
                asignadoMatrix = formularioCarga.asignadoMatrix;
                necesidadMatrix = formularioCarga.necesidadMatrix;

                banquero = new Banquero(existenciaArray, maximoMatrix, asignadoMatrix, necesidadMatrix); //creo el banquero en base a las tablas

                formularioTablas.inicializarTablas(necesidadMatrix, maximoMatrix, asignadoMatrix, existenciaArray, banquero.disponible);

                if (banquero.existenEstadosSeguros())
                    formularioTablas.setLabel("Existen Estados Seguros");
                else
                    formularioTablas.setLabel("No Existe Estado Seguro");
            }

            //Evito problemas :)
            bool notshown = true;
            while (notshown)
            {
                try
                {
                    formularioTablas.Show();
                    notshown = false;
                }
                catch (Exception) {; }
            }
        }
        static private void abrirFormularioCarga()
        {
            if (existenciaArray == null)
                formularioCarga = new FormularioCargaMatrices();
            else
                formularioCarga = new FormularioCargaMatrices(existenciaArray, maximoMatrix, asignadoMatrix);

            formularioCarga.FormClosing += new FormClosingEventHandler(abrirFormularioTablas);

            bool nothidden = true;
            while (nothidden)
            {
                try
                {
                    formularioTablas.Hide();
                    nothidden = false;
                }
                catch (Exception) {;}
            }
            
            bool notshown = true;
            while (notshown)
            {
                try
                {
                    formularioCarga.Show();
                    notshown = false;
                }
                catch (Exception) {;}
            }
        }
        
        static private void siguienteProcesoClick()
        {
            if (banquero == null)
                return;

            if (banquero.calcularSiguienteDisponibilidad() || banquero.procesosRestantesCantidad == 0)
            {
                previewDrawn = false;
                formularioTablas.agregarDisponible(banquero.disponible, banquero.ultimoProceso.id);
                dibujarPreview();

                if (banquero.procesosRestantesCantidad == 0)
                    informarSeguro();
            }
            else
                informarBloqueo();
        }
        static private void siguienteProcesoEnter()
        {
            if (banquero == null)
                return;

            dibujarPreview();
        }
        static private void siguienteProcesoLeave()
        {
            if (banquero == null)
                return;

            if (previewDrawn)
                formularioTablas.eliminarUltimoDisponible();
        }
        static private void reiniciarClick()
        {
            if (banquero == null)
                return;

            banquero.reiniciarSecuencia();
            formularioTablas.setSiguienteEnabled(true);
            formularioTablas.inicializarTablas(banquero.necesidad, maximoMatrix, asignadoMatrix, existenciaArray, banquero.disponible);
        }
        static private void dibujarPreview()
        {
            if (banquero.calcularSiguienteDisponibilidadPreview())
            {
                previewDrawn = true;
                formularioTablas.agregarDisponible(banquero.disponiblePreview, banquero.ultimoProceso.id);
            }
            else if (banquero.procesosRestantesCantidad != 0)
            {
                previewDrawn = false;
                informarBloqueo();
            }
        }

        static void informarBloqueo()
        {
            MessageBox.Show("La secuencia de procesos se encuentra en estado de interbloqueo\nNo existen caminos seguros para esta configuracion...", "Bloqueo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            formularioTablas.setSiguienteEnabled(false);
        }
        static void informarSeguro()
        {
            formularioTablas.setSiguienteEnabled(false);
            MessageBox.Show("La configuracion planteada es segura!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
