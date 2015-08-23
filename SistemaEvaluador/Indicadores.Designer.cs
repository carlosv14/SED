namespace SistemaEvaluador
{
    partial class Indicadores
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
            this.label4 = new System.Windows.Forms.Label();
            this.agregar = new System.Windows.Forms.Button();
            this.indicadoresEspecificos = new System.Windows.Forms.ComboBox();
            this.EspecificoRadioB = new System.Windows.Forms.RadioButton();
            this.GeneralRadioB = new System.Windows.Forms.RadioButton();
            this.Peso = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(239, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Peso";
            // 
            // agregar
            // 
            this.agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregar.Location = new System.Drawing.Point(761, 561);
            this.agregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(141, 44);
            this.agregar.TabIndex = 34;
            this.agregar.Text = "Agregar";
            this.agregar.UseVisualStyleBackColor = true;
            this.agregar.Click += new System.EventHandler(this.agregar_Click);
            // 
            // indicadoresEspecificos
            // 
            this.indicadoresEspecificos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indicadoresEspecificos.FormattingEnabled = true;
            this.indicadoresEspecificos.Location = new System.Drawing.Point(500, 350);
            this.indicadoresEspecificos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.indicadoresEspecificos.Name = "indicadoresEspecificos";
            this.indicadoresEspecificos.Size = new System.Drawing.Size(159, 28);
            this.indicadoresEspecificos.TabIndex = 33;
            // 
            // EspecificoRadioB
            // 
            this.EspecificoRadioB.AutoSize = true;
            this.EspecificoRadioB.BackColor = System.Drawing.Color.Transparent;
            this.EspecificoRadioB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EspecificoRadioB.ForeColor = System.Drawing.Color.Black;
            this.EspecificoRadioB.Location = new System.Drawing.Point(364, 350);
            this.EspecificoRadioB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EspecificoRadioB.Name = "EspecificoRadioB";
            this.EspecificoRadioB.Size = new System.Drawing.Size(118, 24);
            this.EspecificoRadioB.TabIndex = 32;
            this.EspecificoRadioB.TabStop = true;
            this.EspecificoRadioB.Text = "Especifico";
            this.EspecificoRadioB.UseVisualStyleBackColor = false;
            this.EspecificoRadioB.CheckedChanged += new System.EventHandler(this.EspecificoRadioB_CheckedChanged);
            // 
            // GeneralRadioB
            // 
            this.GeneralRadioB.AutoSize = true;
            this.GeneralRadioB.BackColor = System.Drawing.Color.Transparent;
            this.GeneralRadioB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralRadioB.ForeColor = System.Drawing.Color.Black;
            this.GeneralRadioB.Location = new System.Drawing.Point(364, 303);
            this.GeneralRadioB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GeneralRadioB.Name = "GeneralRadioB";
            this.GeneralRadioB.Size = new System.Drawing.Size(96, 24);
            this.GeneralRadioB.TabIndex = 31;
            this.GeneralRadioB.TabStop = true;
            this.GeneralRadioB.Text = "General";
            this.GeneralRadioB.UseVisualStyleBackColor = false;
            this.GeneralRadioB.CheckedChanged += new System.EventHandler(this.GeneralRadioB_CheckedChanged);
            // 
            // Peso
            // 
            this.Peso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Peso.Location = new System.Drawing.Point(364, 244);
            this.Peso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Peso.Name = "Peso";
            this.Peso.Size = new System.Drawing.Size(295, 26);
            this.Peso.TabIndex = 30;
            // 
            // Nombre
            // 
            this.Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre.Location = new System.Drawing.Point(364, 183);
            this.Nombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(452, 26);
            this.Nombre.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(239, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nombre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(40, 32);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(321, 51);
            this.label9.TabIndex = 38;
            this.label9.Text = "INDICADORES";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(759, 513);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(142, 21);
            this.checkBox1.TabIndex = 39;
            this.checkBox1.Text = "Grados Asumidos";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Indicadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(1032, 720);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.agregar);
            this.Controls.Add(this.indicadoresEspecificos);
            this.Controls.Add(this.EspecificoRadioB);
            this.Controls.Add(this.GeneralRadioB);
            this.Controls.Add(this.Peso);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Indicadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indicadores";
            this.Load += new System.EventHandler(this.Indicadores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button agregar;
        private System.Windows.Forms.ComboBox indicadoresEspecificos;
        private System.Windows.Forms.RadioButton EspecificoRadioB;
        private System.Windows.Forms.RadioButton GeneralRadioB;
        private System.Windows.Forms.TextBox Peso;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}