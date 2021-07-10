
namespace FormsFabrica
{
    partial class FormMostrar
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
            this.textBoxMostrar = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBoxMostrar
            // 
            this.textBoxMostrar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMostrar.Location = new System.Drawing.Point(5, 3);
            this.textBoxMostrar.Name = "textBoxMostrar";
            this.textBoxMostrar.Size = new System.Drawing.Size(795, 448);
            this.textBoxMostrar.TabIndex = 0;
            this.textBoxMostrar.Text = "";
            // 
            // FormMostrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxMostrar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMostrar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMostrar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBoxMostrar;
    }
}