
namespace algobanquero
{
    partial class FormularioCargaMatrices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioCargaMatrices));
            this.existencia = new System.Windows.Forms.DataGridView();
            this.maximo = new System.Windows.Forms.DataGridView();
            this.asignado = new System.Windows.Forms.DataGridView();
            this.finalizar_carga = new System.Windows.Forms.Button();
            this.cancelar_carga = new System.Windows.Forms.Button();
            this.procesosCantidad = new System.Windows.Forms.NumericUpDown();
            this.recursosCantidad = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.existencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asignado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procesosCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosCantidad)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // existencia
            // 
            this.existencia.AllowUserToAddRows = false;
            this.existencia.AllowUserToDeleteRows = false;
            this.existencia.AllowUserToResizeColumns = false;
            this.existencia.AllowUserToResizeRows = false;
            this.existencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.existencia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.existencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.existencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.existencia.Location = new System.Drawing.Point(215, 3);
            this.existencia.MultiSelect = false;
            this.existencia.Name = "existencia";
            this.existencia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.existencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.existencia.Size = new System.Drawing.Size(509, 69);
            this.existencia.TabIndex = 6;
            // 
            // maximo
            // 
            this.maximo.AllowUserToAddRows = false;
            this.maximo.AllowUserToDeleteRows = false;
            this.maximo.AllowUserToResizeColumns = false;
            this.maximo.AllowUserToResizeRows = false;
            this.maximo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.maximo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.maximo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.maximo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maximo.Location = new System.Drawing.Point(215, 78);
            this.maximo.MultiSelect = false;
            this.maximo.Name = "maximo";
            this.maximo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.maximo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.maximo.Size = new System.Drawing.Size(509, 188);
            this.maximo.TabIndex = 5;
            // 
            // asignado
            // 
            this.asignado.AllowUserToAddRows = false;
            this.asignado.AllowUserToDeleteRows = false;
            this.asignado.AllowUserToResizeColumns = false;
            this.asignado.AllowUserToResizeRows = false;
            this.asignado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.asignado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.asignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.asignado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asignado.Location = new System.Drawing.Point(215, 272);
            this.asignado.MultiSelect = false;
            this.asignado.Name = "asignado";
            this.asignado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.asignado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.asignado.Size = new System.Drawing.Size(509, 188);
            this.asignado.TabIndex = 4;
            // 
            // finalizar_carga
            // 
            this.finalizar_carga.Dock = System.Windows.Forms.DockStyle.Top;
            this.finalizar_carga.Location = new System.Drawing.Point(0, 83);
            this.finalizar_carga.Name = "finalizar_carga";
            this.finalizar_carga.Size = new System.Drawing.Size(144, 23);
            this.finalizar_carga.TabIndex = 7;
            this.finalizar_carga.Text = "Finalizar Carga";
            this.finalizar_carga.UseVisualStyleBackColor = true;
            this.finalizar_carga.Click += new System.EventHandler(this.finalizar_carga_Click);
            // 
            // cancelar_carga
            // 
            this.cancelar_carga.Dock = System.Windows.Forms.DockStyle.Top;
            this.cancelar_carga.Location = new System.Drawing.Point(0, 61);
            this.cancelar_carga.Name = "cancelar_carga";
            this.cancelar_carga.Size = new System.Drawing.Size(144, 22);
            this.cancelar_carga.TabIndex = 8;
            this.cancelar_carga.Text = "Cancelar Carga";
            this.cancelar_carga.UseVisualStyleBackColor = true;
            this.cancelar_carga.Click += new System.EventHandler(this.cancelar_carga_Click);
            // 
            // procesosCantidad
            // 
            this.procesosCantidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.procesosCantidad.Location = new System.Drawing.Point(75, 4);
            this.procesosCantidad.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.procesosCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.procesosCantidad.Name = "procesosCantidad";
            this.procesosCantidad.ReadOnly = true;
            this.procesosCantidad.Size = new System.Drawing.Size(52, 20);
            this.procesosCantidad.TabIndex = 9;
            this.procesosCantidad.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.procesosCantidad.ValueChanged += new System.EventHandler(this.procesosCantidad_ValueChanged);
            // 
            // recursosCantidad
            // 
            this.recursosCantidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.recursosCantidad.Location = new System.Drawing.Point(75, 6);
            this.recursosCantidad.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.recursosCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recursosCantidad.Name = "recursosCantidad";
            this.recursosCantidad.ReadOnly = true;
            this.recursosCantidad.Size = new System.Drawing.Size(52, 20);
            this.recursosCantidad.TabIndex = 10;
            this.recursosCantidad.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.recursosCantidad.ValueChanged += new System.EventHandler(this.recursosCantidad_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Procesos";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Recursos";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.maximo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.asignado, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.existencia, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(727, 463);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Existencia";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Maximo";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Asignados";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.finalizar_carga);
            this.panel1.Controls.Add(this.cancelar_carga);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 188);
            this.panel1.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.procesosCantidad, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 32);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(144, 29);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.recursosCantidad, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(144, 32);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // FormularioCargaMatrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(727, 463);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormularioCargaMatrices";
            this.Text = "Carga de matrices";
            ((System.ComponentModel.ISupportInitialize)(this.existencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asignado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procesosCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosCantidad)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView existencia;
        private System.Windows.Forms.DataGridView maximo;
        private System.Windows.Forms.DataGridView asignado;
        private System.Windows.Forms.Button finalizar_carga;
        private System.Windows.Forms.Button cancelar_carga;
        private System.Windows.Forms.NumericUpDown procesosCantidad;
        private System.Windows.Forms.NumericUpDown recursosCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}