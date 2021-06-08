
namespace FormsFabrica
{
    partial class FormFabrica
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblComputadora = new System.Windows.Forms.Label();
            this.lblMinero = new System.Windows.Forms.Label();
            this.btnCrearCompu = new System.Windows.Forms.Button();
            this.btnCrearMinero = new System.Windows.Forms.Button();
            this.lblGuardar = new System.Windows.Forms.Label();
            this.lblSerializar = new System.Windows.Forms.Label();
            this.btnSerializar = new System.Windows.Forms.Button();
            this.btnGuardarTxt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblComputadora
            // 
            this.lblComputadora.AutoSize = true;
            this.lblComputadora.Location = new System.Drawing.Point(48, 44);
            this.lblComputadora.Name = "lblComputadora";
            this.lblComputadora.Size = new System.Drawing.Size(98, 13);
            this.lblComputadora.TabIndex = 0;
            this.lblComputadora.Text = "Crear Computadora";
            // 
            // lblMinero
            // 
            this.lblMinero.AutoSize = true;
            this.lblMinero.Location = new System.Drawing.Point(311, 44);
            this.lblMinero.Name = "lblMinero";
            this.lblMinero.Size = new System.Drawing.Size(117, 13);
            this.lblMinero.TabIndex = 1;
            this.lblMinero.Text = "Crear Minero de Bitcoin";
            // 
            // btnCrearCompu
            // 
            this.btnCrearCompu.Location = new System.Drawing.Point(49, 64);
            this.btnCrearCompu.Name = "btnCrearCompu";
            this.btnCrearCompu.Size = new System.Drawing.Size(95, 25);
            this.btnCrearCompu.TabIndex = 4;
            this.btnCrearCompu.Text = "crear";
            this.btnCrearCompu.UseVisualStyleBackColor = true;
            // 
            // btnCrearMinero
            // 
            this.btnCrearMinero.Location = new System.Drawing.Point(324, 64);
            this.btnCrearMinero.Name = "btnCrearMinero";
            this.btnCrearMinero.Size = new System.Drawing.Size(95, 25);
            this.btnCrearMinero.TabIndex = 5;
            this.btnCrearMinero.Text = "crear";
            this.btnCrearMinero.UseVisualStyleBackColor = true;
            // 
            // lblGuardar
            // 
            this.lblGuardar.AutoSize = true;
            this.lblGuardar.Location = new System.Drawing.Point(46, 351);
            this.lblGuardar.Name = "lblGuardar";
            this.lblGuardar.Size = new System.Drawing.Size(100, 13);
            this.lblGuardar.TabIndex = 6;
            this.lblGuardar.Text = "Guardar como texto";
            // 
            // lblSerializar
            // 
            this.lblSerializar.AutoSize = true;
            this.lblSerializar.Location = new System.Drawing.Point(166, 351);
            this.lblSerializar.Name = "lblSerializar";
            this.lblSerializar.Size = new System.Drawing.Size(89, 13);
            this.lblSerializar.TabIndex = 7;
            this.lblSerializar.Text = "Serializar en XML";
            // 
            // btnSerializar
            // 
            this.btnSerializar.Location = new System.Drawing.Point(169, 377);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(86, 25);
            this.btnSerializar.TabIndex = 9;
            this.btnSerializar.Text = "serializar";
            this.btnSerializar.UseVisualStyleBackColor = true;
            // 
            // btnGuardarTxt
            // 
            this.btnGuardarTxt.Location = new System.Drawing.Point(49, 377);
            this.btnGuardarTxt.Name = "btnGuardarTxt";
            this.btnGuardarTxt.Size = new System.Drawing.Size(95, 25);
            this.btnGuardarTxt.TabIndex = 10;
            this.btnGuardarTxt.Text = "guardar";
            this.btnGuardarTxt.UseVisualStyleBackColor = true;
            // 
            // FormFabrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGuardarTxt);
            this.Controls.Add(this.btnSerializar);
            this.Controls.Add(this.lblSerializar);
            this.Controls.Add(this.lblGuardar);
            this.Controls.Add(this.btnCrearMinero);
            this.Controls.Add(this.btnCrearCompu);
            this.Controls.Add(this.lblMinero);
            this.Controls.Add(this.lblComputadora);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFabrica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Garcia.Ian.TP3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComputadora;
        private System.Windows.Forms.Label lblMinero;
        private System.Windows.Forms.Button btnCrearCompu;
        private System.Windows.Forms.Button btnCrearMinero;
        private System.Windows.Forms.Label lblGuardar;
        private System.Windows.Forms.Label lblSerializar;
        private System.Windows.Forms.Button btnSerializar;
        private System.Windows.Forms.Button btnGuardarTxt;
    }
}

