using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ponchland.controller;
using Ponchland.generalData;

namespace Ponchland
{
    public partial class Add : Form
    {
        protected Controller controller;
        protected List<UserCategory> category;
        private UserProduct product;
        public String result;

        public Add(Controller controller)
        {
            InitializeComponent();

            this.controller = controller;
            category = controller.LoadCategory();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            LoadDataGredCategory();
            addProduct.DialogResult = DialogResult.OK;
            Close.DialogResult = DialogResult.Cancel;
        }

        private void LoadDataGredCategory()
        {
            foreach (UserCategory tmp in category)
            {
                dataGridCategory.Rows.Add(tmp.name, tmp.description);
            }
        }

        private bool IsNum(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c)) return false;
            }
            return true;
        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            if (name.Text != null && cost.Text != null && IsNum(cost.Text) && description.Text != null && product.category.name != null)
            {
                product.name = name.Text;
                product.cost = Convert.ToInt32(cost.Text);
                product.description = description.Text;
                result = controller.AddProduct(product);
                Close();
            }
            else
            {
                MessageBox.Show("Введите данные правильно");
            }
        }

        private UserCategory getCat(int row)
        {
            String name = dataGridCategory.Rows[row].Cells[0].Value.ToString();
            foreach(UserCategory tmp in category)
            {
                if(tmp.name == name)
                {
                    return tmp;
                }
            }
            return category[0];
        }

        private void dataGridCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            product.category = getCat(e.RowIndex);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            result = "Отмена";
            Close();
        }
    }
}
