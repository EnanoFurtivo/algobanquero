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
    public partial class FormularioCargaMatrices : Form
    {
        public bool cancelado = true;
        public int[] existenciaArray = { 0, 0, 0, 0, 0 };
        public int[,] maximoMatrix = { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
        public int[,] asignadoMatrix = { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
        public int[,] necesidadMatrix = { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };

        private int columns = 5;
        private int rows = 5;

        private bool selfChange = false;

        public FormularioCargaMatrices()
        {
            InitializeComponent();
            incializarTablas();
        }
        public FormularioCargaMatrices(int[] existenciaArray, int[,] maximoMatrix, int[,] asignadoMatrix)
        {
            InitializeComponent();

            this.existenciaArray = existenciaArray;
            this.maximoMatrix = maximoMatrix;
            this.asignadoMatrix = asignadoMatrix;
            this.columns = existenciaArray.Length;
            this.rows = maximoMatrix.Length / existenciaArray.Length;
            this.selfChange = true;
            this.procesosCantidad.Value = rows;
            this.recursosCantidad.Value = columns;
            this.selfChange = false;

            incializarTablas();
        }

        //FORM METHODS//
        public void incializarTablas()
        {
            for (int i = 0; i < columns; i++)
            {
                existencia.Columns.Add("R" + i, "R" + i);
                existencia.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                maximo.Columns.Add("R" + i, "R" + i);
                maximo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                asignado.Columns.Add("R" + i, "R" + i);
                asignado.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (columns > 15)
            {
                maximo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                asignado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                existencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                maximo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                asignado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                existencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            string[] result = Array.ConvertAll(existenciaArray, x => x.ToString());
            existencia.Rows.Add(result);
            existencia.Rows[0].HeaderCell.Value = "  ";
            
            string[] maximoAux = new string[columns];
            string[] asignadoAux = new string[columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    maximoAux[j] = maximoMatrix[i,j].ToString();
                    asignadoAux[j] = asignadoMatrix[i,j].ToString();
                }

                maximo.Rows.Add(maximoAux);
                maximo.Rows[i].HeaderCell.Value = "P" + i;

                asignado.Rows.Add(asignadoAux);
                asignado.Rows[i].HeaderCell.Value = "P" + i;
            }

        }
        private void actualizarTablas()
        {
            if (maximo.RowCount < rows)
            {
                string[] initializeRow = new string[columns];
                maximo.Rows.Add(initializeRow);
                maximo.Rows[rows-1].HeaderCell.Value = "P" + (rows-1);
                asignado.Rows.Add(initializeRow);
                asignado.Rows[rows-1].HeaderCell.Value = "P" + (rows-1);
            }
            else if (maximo.RowCount > rows)
            {
                maximo.Rows.RemoveAt(maximo.Rows.GetLastRow(DataGridViewElementStates.None));
                asignado.Rows.RemoveAt(asignado.Rows.GetLastRow(DataGridViewElementStates.None));
            }

            if (maximo.ColumnCount < columns)
            {
                existencia.Columns.Add("R" + (columns-1), "R" + (columns - 1));
                maximo.Columns.Add("R" + (columns - 1), "R" + (columns - 1));
                asignado.Columns.Add("R" + (columns - 1), "R" + (columns - 1));
            }
            else if (maximo.ColumnCount > columns)
            {
                existencia.Columns.RemoveAt(existencia.Columns.GetLastColumn(DataGridViewElementStates.None, DataGridViewElementStates.None).Index);
                maximo.Columns.RemoveAt(maximo.Columns.GetLastColumn(DataGridViewElementStates.None, DataGridViewElementStates.None).Index);
                asignado.Columns.RemoveAt(asignado.Columns.GetLastColumn(DataGridViewElementStates.None, DataGridViewElementStates.None).Index);
            }

            if (columns > 15)
            {
                maximo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                asignado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                existencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                maximo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                asignado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                existencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private bool validarCarga()
        {
            bool cargaValida = true;

            //Chequear existencia//
            for (int column = 0; column < columns; column++)
            {
                if (existenciaArray[column] == 0)
                    return informarErrorDeCarga("El recurso R" + column + " ingresado, tiene existencia 0");
                else if (existenciaArray[column] < 0)
                    return informarErrorDeCarga("El recurso R" + column + " ingresado, tiene existencia negativa");
            }

            //Chequear error de necesidad negativa y procesos no validos//
            bool procesoValido = false;
            string procesosInvalidosText = "";
            int procesosInvalidos = 0;

            for (int row = 0; row < rows; row++)
            {
                procesoValido = false;

                for (int column = 0; column < columns; column++)
                {
                    if (necesidadMatrix[row,column] < 0)
                        return informarErrorDeCarga("El proceso P" + row + " ingresado, tiene mas recursos  asignados de los que indica el maximo [R" + column + "]");
                    if (maximoMatrix[row, column] != 0 || asignadoMatrix[row, column] != 0)
                        procesoValido = true;
                }

                if (!procesoValido)
                {
                    if (procesosInvalidos < 10)
                        procesosInvalidosText += "El proceso P" + row + " no se va a ejecutar ya que su necesidad y recursos asignados son 0\n\n";
                    if (procesosInvalidos == 10)
                        procesosInvalidosText += "Existen multiples procesos mas con esta condicion...";
                   procesosInvalidos++;
                }
            }

            if (procesosInvalidos == rows)
                return informarErrorDeCarga("Ningun proceso puede ejecutarse si sus necesidades y asignados son 0");
            else if (procesosInvalidos != 0)
                MessageBox.Show(procesosInvalidosText, "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return cargaValida;
        }
        private bool informarErrorDeCarga(string mensaje)
        {
            MessageBox.Show("Ingreso de datos erroneo!\n\n" + mensaje, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        //FORM EVENTS//
        private void cancelar_carga_Click(object sender, EventArgs e)
        {
            this.cancelado = true;
            this.Close();
        } //TODO
        private void finalizar_carga_Click(object sender, EventArgs e)
        {
            int value;

            maximoMatrix = new int[maximo.RowCount, maximo.ColumnCount];
            foreach (DataGridViewRow i in maximo.Rows)
            {
                if (i.IsNewRow) continue;
                foreach (DataGridViewCell j in i.Cells)
                {
                    if (j.Value == null || !int.TryParse(j.Value.ToString(), out value)) value = 0;
                    maximoMatrix[j.RowIndex, j.ColumnIndex] = value;
                }
            }

            asignadoMatrix = new int[asignado.RowCount, asignado.ColumnCount];
            foreach (DataGridViewRow i in asignado.Rows)
            {
                if (i.IsNewRow) continue;
                foreach (DataGridViewCell j in i.Cells)
                {
                    if (j.Value == null || !Int32.TryParse(j.Value.ToString(), out value)) value = 0;
                    asignadoMatrix[j.RowIndex, j.ColumnIndex] = value;
                }
            }

            existenciaArray = new int[existencia.ColumnCount];
            foreach (DataGridViewRow i in existencia.Rows)
            {
                if (i.IsNewRow) continue;
                foreach (DataGridViewCell j in i.Cells)
                {
                    if (j.Value == null || !Int32.TryParse(j.Value.ToString(), out value)) value = 0;
                    existenciaArray[j.ColumnIndex] = value;
                }
            }

            calcularNecesidad();

            if (this.validarCarga())
            {
                this.cancelado = false;
                this.Close();
            }
        } 
        private void procesosCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (selfChange)
                return;

            rows = (int)procesosCantidad.Value;
            actualizarTablas();
        }
        private void recursosCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (selfChange)
                return;

            columns = (int)recursosCantidad.Value;
            actualizarTablas();
        }

        //CALCULOS//
        private void calcularNecesidad()
        {
            this.necesidadMatrix = new int[rows, columns];
            for (int proceso = 0; proceso < rows; proceso++)
                for (int recurso = 0; recurso < columns; recurso++)
                    necesidadMatrix[proceso, recurso] = maximoMatrix[proceso, recurso] - asignadoMatrix[proceso, recurso];
        } //calcula la necesidad en base a las matrices de asignado y maximo
    }
}
