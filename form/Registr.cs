using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ponchland.generalData;
using Ponchland.controller;

namespace Ponchland
{
    public partial class Registr : Form
    {
        private Controller controller;
        public String result;

        public Registr(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void Registr_Load(object sender, EventArgs e)
        {
            Reg.DialogResult = DialogResult.OK;
            Close.DialogResult = DialogResult.Cancel;
            
        }

        private void Reg_Click(object sender, EventArgs e)
        {
            UserRegistr user;
            user.id = 0;
            user.user = new User(login.Text, password.Text);
            user.name = name.Text;
            user.last_name = last_name.Text;
            user.address = email.Text;
            result = controller.Registr(user);
            
            this.Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
