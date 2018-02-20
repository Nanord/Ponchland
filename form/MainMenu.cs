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
    public partial class MainMenu : Form
    {
        private Controller controller;
        private List<UserRegistr> user;
        private List<List<UserOrder>> order;
        private UserRegistr curUser;
        private bool status;


        public MainMenu(Controller controller, User curUser)
        {
            InitializeComponent();
            
            this.controller = controller;
            this.user = controller.LoadUser(curUser);
            loadOrder();
            
            status = controller.StatusUser;

        }

        private void loadOrder()
        {
            order = new List<List<UserOrder>>();
            foreach (UserRegistr tmpUser in user)
            {
                List<UserOrder> tmpOrder = controller.LoadOrder(tmpUser);
                order.Add(tmpOrder);
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            LoadDataGredUser();
            nameLabel.Text = user[0].name + " " + user[0].last_name;
            if(controller.StatusUser)
            {
                dataGridUser.Visible = true;
                this.Height = 447;
            }
            else
            {
                dataGridUser.Visible = false;
                this.Height = 310;
                addCategory.Visible = false;
                AddProduct.Visible = false;
            }
            LoadDataGredOrder(0);
        }
        
        private void LoadDataGredProduct(int row)
        {
            int idOrder = (int)dataGridOrder.Rows[row].Cells[0].Value;
            bool b = false;
            foreach (List<UserOrder> tmpList in order)
            {
                foreach (UserOrder tmpOrder in tmpList)
                {
                    if(tmpOrder.id == idOrder)
                    {
                        foreach (KeyValuePair<UserProduct, int> tmp in tmpOrder.product)
                        {
                            dataGridProduct.Rows.Add(tmp.Key.id, tmp.Key.name, tmp.Key.cost, tmp.Key.description, tmp.Value);
                        }
                        b = true;
                        break;
                    }
                    
                }
                if(b == true)
                {
                    break;
                }
            }

        }

        private void LoadDataGredUser()
        {
            foreach (UserRegistr tmp in user)
            {
                dataGridUser.Rows.Add(tmp.id, tmp.user.login, tmp.name, tmp.last_name, tmp.address);
            }
        }
        
        private void LoadDataGredOrder(int row)
        {
            dataGridOrder.Rows.Clear();
            int idUser = (int)dataGridUser.Rows[row].Cells[0].Value;
            foreach (List<UserOrder> tmpList in order)
            {
                if(tmpList.Count != 0)
                {
                    if (tmpList[0].user.id == idUser)
                    {
                        curUser = tmpList[0].user;
                        foreach (UserOrder tmpOrder in tmpList)
                        {
                            
                            dataGridOrder.Rows.Add(tmpOrder.id, tmpOrder.date, tmpOrder.pickup, tmpOrder.cash);
                        }
                        break;
                    }
                }
                else
                {
                    dataGridOrder.Rows.Add("Пусто");

                }
            }
        }

           

        private void dataGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridOrder.Rows.Clear();
            LoadDataGredOrder(e.RowIndex);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridProduct.Rows.Clear();
            LoadDataGredProduct(e.RowIndex);
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void makeOrder_Click(object sender, EventArgs e)
        {
            if(status == false)
            {
                curUser = user[0];
            }
            MakeOrder makeOrder = new MakeOrder(controller, curUser);
            DialogResult result = makeOrder.ShowDialog();
            if (makeOrder.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(makeOrder.result);
                loadOrder();
                LoadDataGredOrder(0);
            }
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            Add AddProduct = new Add(controller);
            DialogResult result = AddProduct.ShowDialog();
            if (AddProduct.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(AddProduct.result);
                loadOrder();
            }
        }

        private void addCategory_Click(object sender, EventArgs e)
        {
            AddCategory AddCategory = new AddCategory(controller);
            DialogResult result = AddCategory.ShowDialog();
            if (AddCategory.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(AddCategory.result);
                loadOrder();
            }
        }
    }
}
