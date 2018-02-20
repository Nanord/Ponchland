namespace Ponchland
{
    partial class Add
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
            this.addProduct = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.cost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridCategory = new System.Windows.Forms.DataGridView();
            this.nameCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriprionCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // addProduct
            // 
            this.addProduct.Location = new System.Drawing.Point(131, 221);
            this.addProduct.Name = "addProduct";
            this.addProduct.Size = new System.Drawing.Size(75, 23);
            this.addProduct.TabIndex = 0;
            this.addProduct.Text = "Добвить";
            this.addProduct.UseVisualStyleBackColor = true;
            this.addProduct.Click += new System.EventHandler(this.addProduct_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(131, 250);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 1;
            this.Close.Text = "Отмена";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(95, 14);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(177, 20);
            this.name.TabIndex = 3;
            // 
            // cost
            // 
            this.cost.Location = new System.Drawing.Point(95, 40);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(177, 20);
            this.cost.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Цена";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Описание";
            // 
            // dataGridCategory
            // 
            this.dataGridCategory.AllowUserToAddRows = false;
            this.dataGridCategory.AllowUserToDeleteRows = false;
            this.dataGridCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCategory,
            this.descriprionCategory});
            this.dataGridCategory.Location = new System.Drawing.Point(12, 123);
            this.dataGridCategory.Name = "dataGridCategory";
            this.dataGridCategory.ReadOnly = true;
            this.dataGridCategory.Size = new System.Drawing.Size(296, 92);
            this.dataGridCategory.TabIndex = 8;
            this.dataGridCategory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCategory_CellContentClick);
            // 
            // nameCategory
            // 
            this.nameCategory.HeaderText = "Название";
            this.nameCategory.Name = "nameCategory";
            this.nameCategory.ReadOnly = true;
            // 
            // descriprionCategory
            // 
            this.descriprionCategory.HeaderText = "Описание";
            this.descriprionCategory.Name = "descriprionCategory";
            this.descriprionCategory.ReadOnly = true;
            this.descriprionCategory.Width = 150;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(96, 69);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(175, 48);
            this.description.TabIndex = 9;
            this.description.Text = "";
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 283);
            this.Controls.Add(this.description);
            this.Controls.Add(this.dataGridCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.addProduct);
            this.Name = "Add";
            this.Text = "Add";
            this.Load += new System.EventHandler(this.Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addProduct;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox cost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriprionCategory;
        private System.Windows.Forms.RichTextBox description;
    }
}