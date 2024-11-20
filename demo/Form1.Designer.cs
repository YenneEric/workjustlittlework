namespace demo
{
    partial class Form1
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
            this.box = new System.Windows.Forms.ComboBox();
            this.box2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // box
            // 
            this.box.FormattingEnabled = true;
            this.box.Location = new System.Drawing.Point(616, 52);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(121, 24);
            this.box.TabIndex = 0;
            // 
            // box2
            // 
            this.box2.FormattingEnabled = true;
            this.box2.Location = new System.Drawing.Point(60, 94);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(275, 24);
            this.box2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox box;
        private System.Windows.Forms.ComboBox box2;
    }
}

