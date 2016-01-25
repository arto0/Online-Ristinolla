namespace Nettiristinolla
{
    partial class Numerovalitsin
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
            this.textBoxArvo = new System.Windows.Forms.TextBox();
            this.labelNimi = new System.Windows.Forms.Label();
            this.hScrollBarPalkki = new System.Windows.Forms.HScrollBar();
            this.labelRajat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxArvo
            // 
            this.textBoxArvo.Location = new System.Drawing.Point(87, 0);
            this.textBoxArvo.Name = "textBoxArvo";
            this.textBoxArvo.Size = new System.Drawing.Size(49, 20);
            this.textBoxArvo.TabIndex = 1;
            this.textBoxArvo.Leave += new System.EventHandler(this.textBoxArvo_Leave);
            // 
            // labelNimi
            // 
            this.labelNimi.AutoSize = true;
            this.labelNimi.Location = new System.Drawing.Point(3, 3);
            this.labelNimi.Name = "labelNimi";
            this.labelNimi.Size = new System.Drawing.Size(36, 13);
            this.labelNimi.TabIndex = 16;
            this.labelNimi.Text = "Teksti";
            // 
            // hScrollBarPalkki
            // 
            this.hScrollBarPalkki.LargeChange = 1;
            this.hScrollBarPalkki.Location = new System.Drawing.Point(189, 3);
            this.hScrollBarPalkki.Minimum = 3;
            this.hScrollBarPalkki.Name = "hScrollBarPalkki";
            this.hScrollBarPalkki.Size = new System.Drawing.Size(92, 16);
            this.hScrollBarPalkki.TabIndex = 15;
            this.hScrollBarPalkki.Value = 3;
            this.hScrollBarPalkki.ValueChanged += new System.EventHandler(this.hScrollBarPalkki_ValueChanged);
            // 
            // labelRajat
            // 
            this.labelRajat.AutoSize = true;
            this.labelRajat.Location = new System.Drawing.Point(142, 3);
            this.labelRajat.Name = "labelRajat";
            this.labelRajat.Size = new System.Drawing.Size(0, 13);
            this.labelRajat.TabIndex = 18;
            // 
            // Numerovalitsin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelRajat);
            this.Controls.Add(this.textBoxArvo);
            this.Controls.Add(this.labelNimi);
            this.Controls.Add(this.hScrollBarPalkki);
            this.Name = "Numerovalitsin";
            this.Size = new System.Drawing.Size(285, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxArvo;
        private System.Windows.Forms.Label labelNimi;
        private System.Windows.Forms.HScrollBar hScrollBarPalkki;
        private System.Windows.Forms.Label labelRajat;
    }
}
