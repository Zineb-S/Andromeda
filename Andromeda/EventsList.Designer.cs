namespace Andromeda
{
    partial class EventsList
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
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(27, 604);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 51);
            this.button2.TabIndex = 4;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(27, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 476);
            this.panel1.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(617, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 50);
            this.button3.TabIndex = 8;
            this.button3.Text = " Create ";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // EventsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 676);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Name = "EventsList";
            this.Text = "EventsList";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
    }
}