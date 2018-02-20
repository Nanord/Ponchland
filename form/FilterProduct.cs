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

namespace Ponchland
{

    public partial class FilterProduct : Form
    {
        //FilterDelegate d;
        Label[] names;
        TextBox[] text_boxs;
        CheckBox[] enables;
        RadioButton[,] radio_buttons;
        Panel[] groupButtons;
        List<String> fields;
        public  Dictionary<FieldProduct, FieldType> field;
        public FilterProduct()
        {
            InitializeComponent();
            fields = new List<string>();
            fields.Add("name");
            fields.Add("description");
            fields.Add("cost");
            
        }

        private void FilterProduct_Load(object sender, EventArgs e)
        {
            Fillter.DialogResult = DialogResult.OK;
            close.DialogResult = DialogResult.Cancel;

            int[] x_pos = { 10, 110, 250, 300 };
            int y_pos = 10;
            int n_fields = 3;

            names = new Label[n_fields];
            text_boxs = new TextBox[n_fields];
            enables = new CheckBox[n_fields];
            radio_buttons = new RadioButton[n_fields, 4];
            groupButtons = new Panel[n_fields];

            for (int k = 0; k < n_fields; ++k)
            {
                names[k] = new Label();
                text_boxs[k] = new TextBox();
                enables[k] = new CheckBox();
                for (int t = 0; t < 4; ++t) radio_buttons[k, t] = new RadioButton();
                groupButtons[k] = new Panel();
            }

            for (int i = 0; i < n_fields; ++i)
            {
                y_pos += 30;

                int index = 0;


                names[i].Text = fields[i]; names[i].Left = x_pos[index++]; names[i].Top = y_pos; names[i].Name = fields[i];
                text_boxs[i].Width = 120; text_boxs[i].Left = x_pos[index++]; text_boxs[i].Top = y_pos;
                enables[i].Text = "Нет"; enables[i].Left = x_pos[index++]; enables[i].Top = y_pos; enables[i].Width = 50; enables[i].Checked = true;


                groupButtons[i].Left = 300; groupButtons[i].Top = y_pos;
                groupButtons[i].Height = 30; groupButtons[i].Width = 400;
                radio_buttons[i, 0].Text = "="; radio_buttons[i, 0].Left = 10; radio_buttons[i, 0].Top = 0; radio_buttons[i, 0].Width = 50;
                radio_buttons[i, 1].Text = "!="; radio_buttons[i, 1].Left = 60; radio_buttons[i, 1].Top = 0; radio_buttons[i, 1].Width = 50;
                radio_buttons[i, 2].Left = 110; radio_buttons[i, 2].Top = 0; radio_buttons[i, 2].Width = 100;
                radio_buttons[i, 3].Left = 220; radio_buttons[i, 3].Top = 0; radio_buttons[i, 3].Width = 100;

                radio_buttons[i, 2].Text = "Содержит";
                radio_buttons[i, 3].Text = "Не содержит";
                if (names[i].Text == "cost")
                {
                    radio_buttons[i, 0].Text = "<";
                    radio_buttons[i, 1].Visible = false;
                    radio_buttons[i, 2].Visible = false;
                    radio_buttons[i, 3].Text = ">";
                }



            }

            for (int k = 0; k < n_fields; ++k)
            {
                this.Controls.Add(names[k]);
                this.Controls.Add(text_boxs[k]);
                this.Controls.Add(enables[k]);
                for (int t = 0; t < 4; ++t) groupButtons[k].Controls.Add(radio_buttons[k, t]);
                this.Controls.Add(groupButtons[k]);
            }
        }
        //private void FormFilter_Load(object sender, EventArgs e)
        //{

        //}

        private void Fillter_Click(object sender, EventArgs e)
        {
            try
            {
                int n_fields = 3;
                field = new Dictionary<FieldProduct, FieldType>();
                for (int i = 0; i < n_fields; ++i)
                {
                    bool[] mark = new bool[4];
                    int n_radio_but = -1;

                    for (int k = 0; k < 4; ++k)
                    {
                        mark[k] = radio_buttons[i, k].Checked;
                        if (mark[k]) n_radio_but = k + 1;
                    }

                    if (enables[i].Checked == false && (n_radio_but != -1))
                    {
                        FieldType fieldType;
                        if (n_radio_but == 1)
                        {
                            if (i != 2)
                                fieldType = new FieldType() { status = Status.EQUAL };
                            else
                                fieldType = new FieldType() { status = Status.LESS };
                        }
                        else if (n_radio_but == 2)
                        {
                            fieldType = new FieldType() { status = Status.NOT_EQUAL };
                        }
                        else if (n_radio_but == 3)
                        {
                            fieldType = new FieldType() { status = Status.CONTAINS };
                        }
                        else
                        {
                            if (i != 2)
                                fieldType = new FieldType() { status = Status.NOT_CONTAINS };
                            else
                                fieldType = new FieldType() { status = Status.MORE };
                        }
                        fieldType.value = text_boxs[i].Text;
                        FieldProduct fieldProduct;
                        if (fields[i] == "name")
                        {
                            fieldProduct = FieldProduct.NAME;
                        }
                        else if (fields[i] == "description")
                        {
                            fieldProduct = FieldProduct.DESCRIPRION;
                        }
                        else
                        {
                            fieldProduct = FieldProduct.COST;
                        }
                        field.Add(fieldProduct, fieldType);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Close();
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            field = null;
            Close();
            
        }
    }
}