namespace LAB_2_IDWEB
{
    partial class Messages
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
            this.mess = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // mess
            // 
            this.mess.Location = new System.Drawing.Point(59, 43);
            this.mess.Name = "mess";
            this.mess.Size = new System.Drawing.Size(646, 287);
            this.mess.TabIndex = 0;
            this.mess.Text = "";
            this.mess.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Messages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mess);
            this.Name = "Messages";
            this.Text = "Messages";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox mess;
    }
}