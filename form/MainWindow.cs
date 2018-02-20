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
    public partial class MainWindow : Form
    {
        private Controller controller;
        private User curUser;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controller = new Controller();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            curUser = new User(login.Text, password.Text);
            if (controller.User(curUser))
            {
                MainMenu mainMenu = new MainMenu(controller, curUser);
                mainMenu.Show(); 
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void Registr_Click(object sender, EventArgs e)
        {
            Registr registr = new Registr(controller);
            DialogResult result = registr.ShowDialog();
            if(registr.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(registr.result);
            }
        }
    }
}
