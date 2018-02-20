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
    public partial class AddCategory : Form
    {
        private Controller controller;
        private UserCategory category;
        public String result;
        public AddCategory(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {

        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            if (name.Text != null && description.Text != null)
            {
                category.name = name.Text;
                category.description = description.Text;
                result = controller.AddCategory(category);
                Close();
            }
            else
            {
                MessageBox.Show("Введите данные правильно");
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            result = "Отмена";
            Close();
        }
    }
}
