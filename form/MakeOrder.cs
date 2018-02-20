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
    public delegate void FilterDelegate(Dictionary<FieldProduct, FieldType> fi);

    public partial class MakeOrder : Form
    {

        private Controller controller;
        private List<UserProduct> product;
        private List<UserCategory> category;
        private UserOrder newOrder;
        private Dictionary<UserProduct, int> listProduct; 
        private UserRegistr user;
        private List<int> idProduct;
        private Dictionary<FieldProduct, FieldType> field;


        public String result;

        public  MakeOrder(Controller controller, UserRegistr curUser)
        {
            InitializeComponent();

            this.controller = controller;
            this.user = curUser;

            this.product = controller.LoadProduct();
            category = controller.LoadCategory();
            //category = new List<UserCategory>();
            
            //int i = 0;
            //foreach (UserProduct tmpProduct in this.product)
            //{
            //    if (i > 1 && category[i - 1].id == tmpProduct.category.id)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        category.Add(tmpProduct.category);
            //    }
            //    i++;
            //}
            listProduct = new Dictionary<UserProduct, int>();
        }

        private void MakeOrder_Load(object sender, EventArgs e)
        {
            label1.Text = user.name + user.last_name;
            ok.DialogResult = DialogResult.OK;
            close.DialogResult = DialogResult.Cancel;
            LoadDataGredCategory();
        }

        private void LoadDataGredCategory()
        {
            foreach (UserCategory tmp in category)
            {
                dataGridCategory.Rows.Add(tmp.name, tmp.description);
            }
        }

        private void LoadDataGredProduct(int row)
        {
            String nameCategory = dataGridCategory.Rows[row].Cells[0].Value.ToString();
            foreach (UserProduct tmpList in product)
            {
                if (tmpList.category.name == nameCategory)
                {
                    dataGridProduct.Rows.Add(tmpList.name, tmpList.cost, tmpList.description);
                }

            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if(listProduct.Count > 0)
            {
                newOrder.user = user;
                newOrder.date = DateTime.Now.ToString();
                newOrder.product = listProduct;
                newOrder.pickup = pickup.Checked;
                newOrder.cash = cash.Checked;
                newOrder.id = 0;
                newOrder.user = user;

                result = controller.MakeOrder(newOrder);
                Close();
            }
            else
            {
                result = "заказ пуст";
            }
            
        }

        private void dataGridCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridProduct.Rows.Clear();
            add.Visible = false;
            remove.Visible = false;
            LoadDataGredProduct(e.RowIndex);
        }

        private int rowProduct;

        private void dataGridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            add.Visible = true;
            rowProduct = e.RowIndex;
        }

        private bool checkProduct(string name)
        {
            foreach(UserProduct tmp in listProduct.Keys)
            {
                if(tmp.name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void Add()
        {
            string name = dataGridProduct.Rows[rowProduct].Cells[0].Value.ToString();
            if (name != null)
            {
                if (!checkProduct(name))
                {
                    int i = 1;
                    UserProduct userProduct;
                    foreach (UserProduct tmpList in product)
                    {
                        if (tmpList.name == name)
                        {
                            userProduct = tmpList;
                            listProduct.Add(userProduct, i);
                        }
                    }
                }
                else
                {
                    UserProduct tmp = product[0];
                    foreach (UserProduct tmpList in listProduct.Keys)
                    {                    
                        if (tmpList.name == name)
                        {
                            tmp = tmpList;
                            
                        }
                    }
                    int i = listProduct[tmp];
                    i++;
                    listProduct[tmp] = i;
                }
            }
            else
            {
                MessageBox.Show("Выберите товар");
            }
            
        }
        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                Add();
                dataGridOrder.Rows.Clear();
                LoadDataGredOrder();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Remove()
        {
            string name = dataGridOrder.Rows[rowRemoteProduct].Cells[0].Value.ToString();
            if (listProduct == null)
            {
                MessageBox.Show("пусто");
            }
            else
            {
                if (name != null)
                {
                    UserProduct tmp = product[0];
                    bool i = false;
                    foreach (UserProduct tmpList in listProduct.Keys)
                    {
                        if (tmpList.name == name)
                        {
                            if(listProduct[tmpList] == 1)
                            {
                                tmp = tmpList;
                                i = true;
                                
                                
                            }
                            else
                            {
                                i = false;
                                tmp = tmpList;
                            }
                            
                        }
                    }
                    if (i)
                    {
                        listProduct.Remove(tmp);
                    }
                    else
                    {
                        int a = listProduct[tmp];
                        a--;
                        listProduct[tmp] = a;
                    }
                   
                }
                else
                {
                    MessageBox.Show("Выберите товар");
                }
            }
        }
        private void remove_Click(object sender, EventArgs e)
        {
            try
            {
                Remove();
                dataGridOrder.Rows.Clear();
                LoadDataGredOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadDataGredOrder()
        {
            if(listProduct.Count != 0)
            {
                foreach (KeyValuePair<UserProduct, int> tmp in listProduct)
                {
                    int i = tmp.Key.cost * tmp.Value;
                    dataGridOrder.Rows.Add(tmp.Key.name, i, tmp.Key.description, tmp.Value);
                }
            }
            else
            {
                dataGridOrder.Rows.Add("пусто");
            }
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            result = "Заказ не выполнен";
            Close();
        }

        private int rowRemoteProduct;

        private void dataGridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            remove.Visible = true;
            rowRemoteProduct = e.RowIndex;
        }

        private void LoadDataGredFilterProduct()
        {

            foreach (UserProduct tmpList in product)
            {

                foreach(int id in idProduct)
                {
                    if(id == tmpList.id)
                    {
                        dataGridProduct.Rows.Add(tmpList.name, tmpList.cost, tmpList.description);
                    }
                }
            }
        }


        private void Filter_Click(object sender, EventArgs e)
        {
            idProduct = new List<int>();
            
            FilterProduct filter = new FilterProduct();
            DialogResult result = filter.ShowDialog();
            if(filter.DialogResult == DialogResult.OK)
            {
                idProduct = controller.Filter(filter.field);
                dataGridProduct.Rows.Clear();
                LoadDataGredFilterProduct();
            }
            
            
        }
    }
}
 