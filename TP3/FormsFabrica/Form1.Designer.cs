
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
            this.lblCrearServer = new System.Windows.Forms.Label();
            this.btnCrearServer = new System.Windows.Forms.Button();
            this.lblCargarTxt = new System.Windows.Forms.Label();
            this.lblCargarXML = new System.Windows.Forms.Label();
            this.btnCargarTexto = new System.Windows.Forms.Button();
            this.btnCargarXML = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblComputadora
            // 
            this.lblComputadora.AutoSize = true;
            this.lblComputadora.Location = new System.Drawing.Point(59, 9);
            this.lblComputadora.Name = "lblComputadora";
            this.lblComputadora.Size = new System.Drawing.Size(98, 13);
            this.lblComputadora.TabIndex = 0;
            this.lblComputadora.Text = "Crear Computadora";
            // 
            // lblMinero
            // 
            this.lblMinero.AutoSize = true;
            this.lblMinero.Location = new System.Drawing.Point(50, 97);
            this.lblMinero.Name = "lblMinero";
            this.lblMinero.Size = new System.Drawing.Size(117, 13);
            this.lblMinero.TabIndex = 1;
            this.lblMinero.Text = "Crear Minero de Bitcoin";
            // 
            // btnCrearCompu
            // 
            this.btnCrearCompu.Location = new System.Drawing.Point(62, 25);
            this.btnCrearCompu.Name = "btnCrearCompu";
            this.btnCrearCompu.Size = new System.Drawing.Size(95, 25);
            this.btnCrearCompu.TabIndex = 4;
            this.btnCrearCompu.Text = "crear";
            this.btnCrearCompu.UseVisualStyleBackColor = true;
            this.btnCrearCompu.Click += new System.EventHandler(this.btnCrearCompu_Click);
            // 
            // btnCrearMinero
            // 
            this.btnCrearMinero.Location = new System.Drawing.Point(62, 113);
            this.btnCrearMinero.Name = "btnCrearMinero";
            this.btnCrearMinero.Size = new System.Drawing.Size(95, 25);
            this.btnCrearMinero.TabIndex = 5;
            this.btnCrearMinero.Text = "crear";
            this.btnCrearMinero.UseVisualStyleBackColor = true;
            this.btnCrearMinero.Click += new System.EventHandler(this.btnCrearMinero_Click);
            // 
            // lblGuardar
            // 
            this.lblGuardar.AutoSize = true;
            this.lblGuardar.Location = new System.Drawing.Point(5, 141);
            this.lblGuardar.Name = "lblGuardar";
            this.lblGuardar.Size = new System.Drawing.Size(100, 13);
            this.lblGuardar.TabIndex = 6;
            this.lblGuardar.Text = "Guardar como texto";
            // 
            // lblSerializar
            // 
            this.lblSerializar.AutoSize = true;
            this.lblSerializar.Location = new System.Drawing.Point(133, 141);
            this.lblSerializar.Name = "lblSerializar";
            this.lblSerializar.Size = new System.Drawing.Size(89, 13);
            this.lblSerializar.TabIndex = 7;
            this.lblSerializar.Text = "Serializar en XML";
            // 
            // btnSerializar
            // 
            this.btnSerializar.Location = new System.Drawing.Point(136, 157);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(86, 25);
            this.btnSerializar.TabIndex = 9;
            this.btnSerializar.Text = "serializar";
            this.btnSerializar.UseVisualStyleBackColor = true;
            this.btnSerializar.Click += new System.EventHandler(this.btnSerializar_Click);
            // 
            // btnGuardarTxt
            // 
            this.btnGuardarTxt.Location = new System.Drawing.Point(8, 157);
            this.btnGuardarTxt.Name = "btnGuardarTxt";
            this.btnGuardarTxt.Size = new System.Drawing.Size(95, 25);
            this.btnGuardarTxt.TabIndex = 10;
            this.btnGuardarTxt.Text = "guardar";
            this.btnGuardarTxt.UseVisualStyleBackColor = true;
            this.btnGuardarTxt.Click += new System.EventHandler(this.btnGuardarTxt_Click);
            // 
            // lblCrearServer
            // 
            this.lblCrearServer.AutoSize = true;
            this.lblCrearServer.Location = new System.Drawing.Point(74, 53);
            this.lblCrearServer.Name = "lblCrearServer";
            this.lblCrearServer.Size = new System.Drawing.Size(74, 13);
            this.lblCrearServer.TabIndex = 11;
            this.lblCrearServer.Text = "Crear Servidor";
            // 
            // btnCrearServer
            // 
            this.btnCrearServer.Location = new System.Drawing.Point(62, 69);
            this.btnCrearServer.Name = "btnCrearServer";
            this.btnCrearServer.Size = new System.Drawing.Size(95, 25);
            this.btnCrearServer.TabIndex = 12;
            this.btnCrearServer.Text = "crear";
            this.btnCrearServer.UseVisualStyleBackColor = true;
            this.btnCrearServer.Click += new System.EventHandler(this.btnCrearServer_Click);
            // 
            // lblCargarTxt
            // 
            this.lblCargarTxt.AutoSize = true;
            this.lblCargarTxt.Location = new System.Drawing.Point(5, 185);
            this.lblCargarTxt.Name = "lblCargarTxt";
            this.lblCargarTxt.Size = new System.Drawing.Size(98, 13);
            this.lblCargarTxt.TabIndex = 13;
            this.lblCargarTxt.Text = "Cargar Desde texto";
            // 
            // lblCargarXML
            // 
            this.lblCargarXML.AutoSize = true;
            this.lblCargarXML.Location = new System.Drawing.Point(133, 185);
            this.lblCargarXML.Name = "lblCargarXML";
            this.lblCargarXML.Size = new System.Drawing.Size(86, 13);
            this.lblCargarXML.TabIndex = 14;
            this.lblCargarXML.Text = "Deserializar XML";
            // 
            // btnCargarTexto
            // 
            this.btnCargarTexto.Location = new System.Drawing.Point(8, 201);
            this.btnCargarTexto.Name = "btnCargarTexto";
            this.btnCargarTexto.Size = new System.Drawing.Size(95, 25);
            this.btnCargarTexto.TabIndex = 15;
            this.btnCargarTexto.Text = "cargar";
            this.btnCargarTexto.UseVisualStyleBackColor = true;
            this.btnCargarTexto.Click += new System.EventHandler(this.btnCargarTexto_Click);
            // 
            // btnCargarXML
            // 
            this.btnCargarXML.Location = new System.Drawing.Point(135, 201);
            this.btnCargarXML.Name = "btnCargarXML";
            this.btnCargarXML.Size = new System.Drawing.Size(87, 25);
            this.btnCargarXML.TabIndex = 16;
            this.btnCargarXML.Text = "cargar";
            this.btnCargarXML.UseVisualStyleBackColor = true;
            this.btnCargarXML.Click += new System.EventHandler(this.btnCargarXML_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(8, 232);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(214, 25);
            this.btnMostrar.TabIndex = 17;
            this.btnMostrar.Text = "MOSTRAR";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // FormFabrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(234, 261);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnCargarXML);
            this.Controls.Add(this.btnCargarTexto);
            this.Controls.Add(this.lblCargarXML);
            this.Controls.Add(this.lblCargarTxt);
            this.Controls.Add(this.btnCrearServer);
            this.Controls.Add(this.lblCrearServer);
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
        private System.Windows.Forms.Label lblCrearServer;
        private System.Windows.Forms.Button btnCrearServer;
        private System.Windows.Forms.Label lblCargarTxt;
        private System.Windows.Forms.Label lblCargarXML;
        private System.Windows.Forms.Button btnCargarTexto;
        private System.Windows.Forms.Button btnCargarXML;
        private System.Windows.Forms.Button btnMostrar;
    }
}

