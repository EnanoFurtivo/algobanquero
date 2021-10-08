using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace algobanquero
{
    public delegate void ActualizarTablasHandler();


    public partial class FormularioTablas : Form
    {
        public event CargarMatricesClickHandler CargarMatricesClickEvent;
        public event SiguienteProcesoClickHandler SiguienteProcesoClickEvent;
        public event SiguienteProcesoEnterHandler SiguienteProcesoEnterEvent;
        public event SiguienteProcesoLeaveHandler SiguienteProcesoLeaveEvent;
        public event ReiniciarClickHandler ReiniciarClickEvent;

        private int rowCount;
        private int colCount;

        public FormularioTablas()
        {
            InitializeComponent();
        }
        
        public void inicializarTablas(int[,] necesidadMatrix, int[,] maximoMatrix, int[,] asignadoMatrix, int[] existenciaArray, int[] disponibleArray)
        {
            siguiente.Enabled = true;
            reniciar.Enabled = true;

            disponibilidad.Rows.Clear();
            disponibilidad.Columns.Clear();
            maximo.Rows.Clear();
            maximo.Columns.Clear();
            asignado.Rows.Clear();
            asignado.Columns.Clear();
            necesidad.Rows.Clear();
            necesidad.Columns.Clear();
            existencia.Rows.Clear();
            existencia.Columns.Clear();

            this.rowCount = maximoMatrix.Length / existenciaArray.Length;
            this.colCount = existenciaArray.Length;

            for (int i = 0; i < colCount; i++)
            {
                disponibilidad.Columns.Add("R" + i, "R" + i);
                disponibilidad.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                maximo.Columns.Add("R" + i, "R" + i);
                maximo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                asignado.Columns.Add("R" + i, "R" + i);
                asignado.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                necesidad.Columns.Add("R" + i, "R" + i);
                necesidad.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                existencia.Columns.Add("R" + i, "R" + i);
                existencia.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (colCount > 10)
            {
                disponibilidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                maximo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                asignado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                necesidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                existencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                maximo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                asignado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                necesidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                existencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                disponibilidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            string[] maximoAux = new string[colCount];
            string[] asignadoAux = new string[colCount];
            string[] necesidadAux = new string[colCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    maximoAux[j] = maximoMatrix[i, j].ToString();
                    asignadoAux[j] = asignadoMatrix[i, j].ToString();
                    necesidadAux[j] = necesidadMatrix[i, j].ToString();
                }

                maximo.Rows.Add(maximoAux);
                maximo.Rows[i].HeaderCell.Value = "P" + i;

                asignado.Rows.Add(asignadoAux);
                asignado.Rows[i].HeaderCell.Value = "P" + i;

                necesidad.Rows.Add(necesidadAux);
                necesidad.Rows[i].HeaderCell.Value = "P" + i;
            }

            string[] result = Array.ConvertAll(existenciaArray, x => x.ToString());
            existencia.Rows.Add(result);
            existencia.Rows[0].HeaderCell.Value = "  ";

            result = Array.ConvertAll(disponibleArray, x => x.ToString());
            disponibilidad.Rows.Add(result);
            disponibilidad.Rows[0].HeaderCell.Value = "  ";

            maximo.ClearSelection();
            asignado.ClearSelection();
            existencia.ClearSelection();
            disponibilidad.ClearSelection();
            necesidad.ClearSelection();
        }

        //FORM CONTROLS//
        public void setSiguienteEnabled(bool state)
        {
            this.siguiente.Enabled = state;
        }
        public void setLabel(string text)
        {
            this.label_existe.Text = text;
        }
        public void agregarDisponible(int[] disponibleArray, int proceso)
        {
            string[] result = Array.ConvertAll(disponibleArray, x => x.ToString());
            disponibilidad.Rows.Add(result);
            disponibilidad.Rows[disponibilidad.Rows.Count - 1].HeaderCell.Value = "P" + proceso;
        }
        public void eliminarUltimoDisponible()
        {
            disponibilidad.Rows.RemoveAt(disponibilidad.Rows.Count - 1);
        }

        //FORM EVENTS//
        private void cargar_Click(object sender, EventArgs e)
        {
            this.CargarMatricesClickEvent();
        }
        private void siguiente_Click(object sender, EventArgs e)
        {
            this.SiguienteProcesoClickEvent();
        }
        private void siguiente_MouseEnter(object sender, EventArgs e)
        {
            this.SiguienteProcesoEnterEvent();
        }
        private void siguiente_MouseLeave(object sender, EventArgs e)
        {
            this.SiguienteProcesoLeaveEvent();
        }
        private void reniciar_Click(object sender, EventArgs e)
        {
            this.ReiniciarClickEvent();
        }
    }
}
