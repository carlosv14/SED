﻿namespace SistemaEvaluador
{
    partial class ListaEmpleados
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
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.bVolver = new System.Windows.Forms.Button();
            this.tEmpleado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bEliminar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tRazon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(39, 259);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.RowTemplate.Height = 24;
            this.dgvEmpleados.Size = new System.Drawing.Size(740, 311);
            this.dgvEmpleados.TabIndex = 0;
            this.dgvEmpleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpleados_CellDoubleClick);
            // 
            // bVolver
            // 
            this.bVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.bVolver.Location = new System.Drawing.Point(640, 196);
            this.bVolver.Name = "bVolver";
            this.bVolver.Size = new System.Drawing.Size(139, 44);
            this.bVolver.TabIndex = 1;
            this.bVolver.Text = "Volver a Menú";
            this.bVolver.UseVisualStyleBackColor = true;
            this.bVolver.Click += new System.EventHandler(this.bVolver_Click);
            // 
            // tEmpleado
            // 
            this.tEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.tEmpleado.Location = new System.Drawing.Point(273, 77);
            this.tEmpleado.Name = "tEmpleado";
            this.tEmpleado.Size = new System.Drawing.Size(150, 26);
            this.tEmpleado.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(58, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID Empleado";
            // 
            // bEliminar
            // 
            this.bEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.bEliminar.Location = new System.Drawing.Point(640, 77);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(139, 44);
            this.bEliminar.TabIndex = 4;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(58, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Razón de desactivación";
            // 
            // tRazon
            // 
            this.tRazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.tRazon.Location = new System.Drawing.Point(273, 137);
            this.tRazon.Multiline = true;
            this.tRazon.Name = "tRazon";
            this.tRazon.Size = new System.Drawing.Size(308, 103);
            this.tRazon.TabIndex = 5;
            // 
            // ListaEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(807, 582);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tRazon);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tEmpleado);
            this.Controls.Add(this.bVolver);
            this.Controls.Add(this.dgvEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListaEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListaEmpleados";
            this.Load += new System.EventHandler(this.ListaEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Button bVolver;
        private System.Windows.Forms.TextBox tEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.TextBox tRazon;
        private System.Windows.Forms.Label label2;
    }
}