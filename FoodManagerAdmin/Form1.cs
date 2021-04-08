using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace FoodManagerAdmin
{
    public partial class Form1 : Form
    {
         Controller.FoodManager foodManager = new Controller.FoodManager();
        public Form1()
        {
            InitializeComponent();
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            ListBox.Text = "Номи таомро интихоб кунед";
            ListBox.DataSource = foodManager.GetFoodTypes();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ListId.Text == "")
            {
                MemoryStream ms = new MemoryStream();

                string name = textBox1.Text;
                string descr = textBox3.Text;
                string types = ListBox.Text;
                DateTime dateTime = DataTime.Value;

                if (ImageBox.Image != null && name != "" && descr != "" && types != "")
                {
                    ImageBox.Image.Save(ms, ImageBox.Image.RawFormat);
                    byte[] imag = ms.ToArray();

                    double price = double.Parse(textBox2.Text);

                    foodManager.Add(name, price, descr, types, imag,dateTime);
                    ClearText();
                    Read();
                }
                else
                {
                    Error.Text = "Майдон ё расм холи аст: Илтимос дохил намоед";
                }
            }
            else
            {
                MessageBox.Show("Дар база мавҷуд!");
            }
        }

        private void BtnChangeList_Click(object sender, EventArgs e)
        {
            if (ListId.Text != "")
            {
                MemoryStream ms = new MemoryStream();
                ImageBox.Image.Save(ms, ImageBox.Image.RawFormat);
                byte[] imag = ms.ToArray();

                int id = int.Parse(ListId.Text);
                string name = textBox1.Text;
                double price = double.Parse(textBox2.Text);
                string discr = textBox3.Text;
                string types = ListBox.Text;

                foodManager.UpdateFood(id,name, price, types, discr,imag);
                ClearText();
                Read();

            }
            else
            {
                MessageBox.Show("ID Номалум аст!");
            }

         
        }
  
        private void BtnLossList_Click(object sender, EventArgs e)
        {
            if (ListId.Text != "")
            {
                int id = int.Parse(ListId.Text);
                foodManager.DeleteFood(id);
                ClearText();
                Read();
            }
            else
            {
                MessageBox.Show("ID Номалум аст!");
            }
        }
  
        private void BtnShow_Click(object sender, EventArgs e)
        {

            Read();

        }
        public void Read()
        {
            DataListView.DataSource = null;
            DataListView.RowTemplate.Height = 60;
            DataListView.AllowUserToAddRows = true;

            DataListView.DataSource = foodManager.GetAllFood();
            
        }

        private void ClickList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Byte[] img = (byte[])this.DataListView.CurrentRow.Cells[6].Value;

            MemoryStream ms = new MemoryStream(img);
            ImageBox.Image = Image.FromStream(ms);
            ImageBox.SizeMode = ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;

            ListId.Text = (this.DataListView.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = (this.DataListView.Rows[e.RowIndex].Cells[1].Value.ToString());
            textBox2.Text = (this.DataListView.Rows[e.RowIndex].Cells[2].Value.ToString());
            ListBox.Text = (this.DataListView.Rows[e.RowIndex].Cells[3].Value.ToString());
            DataTime.Text = (this.DataListView.Rows[e.RowIndex].Cells[4].Value.ToString());
            textBox3.Text = (this.DataListView.Rows[e.RowIndex].Cells[5].Value.ToString());
            
        }

        private void BtnChooseImge_Click(object sender, EventArgs e)
        {
            OpenFileDialog chooseImage = new OpenFileDialog();
            chooseImage.Filter = "Image Files (*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (chooseImage.ShowDialog() == DialogResult.OK)
            {

                if (chooseImage != null)
                {
                    ImageBox.Image = Image.FromFile(chooseImage.FileName);
                    ImageBox.SizeMode = ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("Расмро интихоб нанамудед!");
                }
            }
        }

        private void BtnCleaner_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        public void ClearText()
        {
            ListId.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            ListBox.Text = "Номи таомро интихоб кунед";
            DataTime.Text = "";
            ImageBox.Image = null;
            label7.Text = "";
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
