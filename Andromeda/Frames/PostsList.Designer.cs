namespace Andromeda
{
    partial class PostsList
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.postsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(546, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = " Create ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(30, 617);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // postsPanel
            // 
            this.postsPanel.BackColor = System.Drawing.Color.Transparent;
            this.postsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.postsPanel.Location = new System.Drawing.Point(30, 87);
            this.postsPanel.Name = "postsPanel";
            this.postsPanel.Size = new System.Drawing.Size(689, 506);
            this.postsPanel.TabIndex = 0;
            this.postsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.postsPanel_Paint);
            // 
            // PostsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 705);
            this.Controls.Add(this.postsPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "PostsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PostsList";
            this.Load += new System.EventHandler(this.PostsList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel postsPanel;
    }
}