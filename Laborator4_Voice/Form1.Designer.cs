namespace Laborator4_Voice
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.connect_click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(74, 56);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(100, 20);
            this.txt_IP.TabIndex = 3;
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(74, 83);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(100, 20);
            this.txt_port.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(74, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 89);
            this.button2.TabIndex = 5;
            this.button2.Text = "ShareMyVoice";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(279, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 89);
            this.button3.TabIndex = 6;
            this.button3.Text = "StopSharing";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // connect_click
            // 
            this.connect_click.Location = new System.Drawing.Point(242, 56);
            this.connect_click.Name = "connect_click";
            this.connect_click.Size = new System.Drawing.Size(96, 55);
            this.connect_click.TabIndex = 7;
            this.connect_click.Text = "Connect";
            this.connect_click.UseVisualStyleBackColor = true;
            this.connect_click.Click += new System.EventHandler(this.connect_click_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 430);
            this.Controls.Add(this.connect_click);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button connect_click;
    }
}

