
namespace Control_Progreso {
    partial class PrimeraVentana {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.btnIniciarPelea = new System.Windows.Forms.Button();
            this.listPersonajesCreados = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Crear Personaje";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIniciarPelea
            // 
            this.btnIniciarPelea.Location = new System.Drawing.Point(29, 135);
            this.btnIniciarPelea.Name = "btnIniciarPelea";
            this.btnIniciarPelea.Size = new System.Drawing.Size(175, 51);
            this.btnIniciarPelea.TabIndex = 1;
            this.btnIniciarPelea.Text = "PELEA!";
            this.btnIniciarPelea.UseVisualStyleBackColor = true;
            this.btnIniciarPelea.Click += new System.EventHandler(this.btnIniciarPelea_Click);
            // 
            // listPersonajesCreados
            // 
            this.listPersonajesCreados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listPersonajesCreados.HideSelection = false;
            this.listPersonajesCreados.Location = new System.Drawing.Point(236, 28);
            this.listPersonajesCreados.Name = "listPersonajesCreados";
            this.listPersonajesCreados.Size = new System.Drawing.Size(328, 217);
            this.listPersonajesCreados.TabIndex = 2;
            this.listPersonajesCreados.UseCompatibleStateImageBehavior = false;
            this.listPersonajesCreados.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 1000;
            // 
            // PrimeraVentana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 282);
            this.Controls.Add(this.listPersonajesCreados);
            this.Controls.Add(this.btnIniciarPelea);
            this.Controls.Add(this.button1);
            this.Name = "PrimeraVentana";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIniciarPelea;
        private System.Windows.Forms.ListView listPersonajesCreados;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

