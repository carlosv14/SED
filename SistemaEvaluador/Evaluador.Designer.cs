namespace SistemaEvaluador
{
    partial class Evaluador
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.guardarEvauacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatoEvaluadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Fecha = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indicadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 142);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1045, 519);
            this.dataGridView1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha";
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(221, 110);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(113, 17);
            this.Nombre.TabIndex = 6;
            this.Nombre.Text = "---------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre del Empleado";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarEvauacionToolStripMenuItem,
            this.formatoEvaluadorToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1107, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // guardarEvauacionToolStripMenuItem
            // 
            this.guardarEvauacionToolStripMenuItem.Name = "guardarEvauacionToolStripMenuItem";
            this.guardarEvauacionToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.guardarEvauacionToolStripMenuItem.Text = "Guardar Evauacion";
            // 
            // formatoEvaluadorToolStripMenuItem
            // 
            this.formatoEvaluadorToolStripMenuItem.Name = "formatoEvaluadorToolStripMenuItem";
            this.formatoEvaluadorToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.formatoEvaluadorToolStripMenuItem.Text = "Formato Evaluador";
            this.formatoEvaluadorToolStripMenuItem.Click += new System.EventHandler(this.formatoEvaluadorToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "---------------------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "ID Empleado";
            // 
            // Fecha
            // 
            this.Fecha.AutoSize = true;
            this.Fecha.Location = new System.Drawing.Point(221, 140);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(113, 17);
            this.Fecha.TabIndex = 8;
            this.Fecha.Text = "---------------------";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 569);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradosToolStripMenuItem,
            this.indicadoresToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // gradosToolStripMenuItem
            // 
            this.gradosToolStripMenuItem.Name = "gradosToolStripMenuItem";
            this.gradosToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.gradosToolStripMenuItem.Text = "Grados";
            this.gradosToolStripMenuItem.Click += new System.EventHandler(this.gradosToolStripMenuItem_Click);
            // 
            // indicadoresToolStripMenuItem
            // 
            this.indicadoresToolStripMenuItem.Name = "indicadoresToolStripMenuItem";
            this.indicadoresToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.indicadoresToolStripMenuItem.Text = "Indicadores";
            this.indicadoresToolStripMenuItem.Click += new System.EventHandler(this.indicadoresToolStripMenuItem_Click);
            // 
            // Evaluador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 614);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Fecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Evaluador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluador";
            this.Load += new System.EventHandler(this.Evaluador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem guardarEvauacionToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Fecha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem formatoEvaluadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indicadoresToolStripMenuItem;
    }
}