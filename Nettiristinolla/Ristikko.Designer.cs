namespace Nettiristinolla
{
    partial class Ristikko
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Ristikko
            // 
            this.SizeChanged += new System.EventHandler(this.Ristikko_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Ristikko_Paint);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Ristikko_MouseUp);
            this.ResumeLayout(false);

        }



        #endregion
    }
}
