namespace Ponchland
{
    partial class Registr
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Close = new System.Windows.Forms.Button();
            this.Reg = new System.Windows.Forms.Button();
            this.email = new System.Windows.Forms.TextBox();
            this.last_name = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Close);
            this.groupBox1.Controls.Add(this.Reg);
            this.groupBox1.Controls.Add(this.email);
            this.groupBox1.Controls.Add(this.last_name);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.login);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 226);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(68, 187);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(124, 23);
            this.Close.TabIndex = 21;
            this.Close.Text = "Назад";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Reg
            // 
            this.Reg.Location = new System.Drawing.Point(68, 158);
            this.Reg.Name = "Reg";
            this.Reg.Size = new System.Drawing.Size(124, 23);
            this.Reg.TabIndex = 20;
            this.Reg.Text = "Зарегистрироваться";
            this.Reg.UseVisualStyleBackColor = true;
            this.Reg.Click += new System.EventHandler(this.Reg_Click);
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(68, 121);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(180, 20);
            this.email.TabIndex = 19;
            // 
            // last_name
            // 
            this.last_name.Location = new System.Drawing.Point(68, 94);
            this.last_name.Name = "last_name";
            this.last_name.Size = new System.Drawing.Size(180, 20);
            this.last_name.TabIndex = 18;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(68, 67);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(180, 20);
            this.name.TabIndex = 17;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(68, 40);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(180, 20);
            this.password.TabIndex = 16;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(68, 13);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(180, 20);
            this.login.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Адрес";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Login";
            // 
            // Registr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 250);
            this.Controls.Add(this.groupBox1);
            this.Name = "Registr";
            this.Text = "Registr";
            this.Load += new System.EventHandler(this.Registr_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Reg;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox last_name;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}