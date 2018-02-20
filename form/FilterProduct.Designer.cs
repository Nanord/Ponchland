namespace Ponchland
{
    partial class FilterProduct
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
            this.Fillter = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Fillter
            // 
            this.Fillter.Location = new System.Drawing.Point(574, 191);
            this.Fillter.Margin = new System.Windows.Forms.Padding(2);
            this.Fillter.Name = "Fillter";
            this.Fillter.Size = new System.Drawing.Size(56, 37);
            this.Fillter.TabIndex = 1;
            this.Fillter.Text = "Fillter";
            this.Fillter.UseVisualStyleBackColor = true;
            this.Fillter.Click += new System.EventHandler(this.Fillter_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(573, 233);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(56, 23);
            this.close.TabIndex = 2;
            this.close.Text = "close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.button1_Click);
            // 
            // FilterProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 268);
            this.Controls.Add(this.close);
            this.Controls.Add(this.Fillter);
            this.Name = "FilterProduct";
            this.Text = "FilterProduct";
            this.Load += new System.EventHandler(this.FilterProduct_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Fillter;
        private System.Windows.Forms.Button close;
    }
}