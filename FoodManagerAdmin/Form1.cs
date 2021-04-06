﻿using System;
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
         Controler.FoodManager foodManager = new Controler.FoodManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Номи таомро интихоб кунед";
            comboBox1.DataSource = foodManager.ShowTypeFood();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idLabel.Text == "")
            {
                MemoryStream ms = new MemoryStream();

                string name = textBox1.Text;
                string descr = textBox3.Text;
                string types = comboBox1.Text;
                DateTime dateTime = dateTimePicker1.Value;

                if (pictureBox1.Image != null && name != "" && descr != "" && types != "")
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] imag = ms.ToArray();

                    double price = double.Parse(textBox2.Text);

                    foodManager.add(name, price, descr, types, imag,dateTime);
                    Read();
                    ClearText();
                }
                else
                {
                    label6.Text = "Майдон ё расм холи аст: Илтимос дохил намоед";
                }
            }
            else
            {
                MessageBox.Show("Дар база мавҷуд!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idLabel.Text != "")
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] imag = ms.ToArray();

                int id = int.Parse(idLabel.Text);
                string name = textBox1.Text;
                double price = double.Parse(textBox2.Text);
                string discr = textBox3.Text;
                string types = comboBox1.Text;

                foodManager.DataUpdate(id,name, price, discr, types,imag);
                Read();
                ClearText();
                
            }
            else
            {
                MessageBox.Show("ID Номалум аст!");
            }

         
        }
  
        private void button4_Click(object sender, EventArgs e)
        {
            if (idLabel.Text != "")
            {
                int id = int.Parse(idLabel.Text);
                foodManager.ClearData(id);
                Read();
                ClearText();
            }
            else
            {
                MessageBox.Show("ID Номалум аст!");
            }
        }
  
        private void button6_Click(object sender, EventArgs e)
        {

            Read();

        }
        public void Read()
        {
            dataGridView1.DataSource = null;
            dataGridView1.RowTemplate.Height = 60;
            dataGridView1.AllowUserToAddRows = true;

            dataGridView1.DataSource = foodManager.ReadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dataGridView = (DataGridView)sender;

            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    Byte[] img = (byte[])dataGridView1.CurrentRow.Cells[6].Value;
                     
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                    pictureBox1.SizeMode = pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                   idLabel.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    textBox1.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    textBox2.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    comboBox1.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    dateTimePicker1.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                   textBox3.Text = (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());

                }
            }
            catch (Exception)
            {

                MessageBox.Show("You don't Click ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog chooseImage = new OpenFileDialog();
            chooseImage.Filter = "Image Files (*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (chooseImage.ShowDialog() == DialogResult.OK)
            {

                if (chooseImage != null)
                {
                    pictureBox1.Image = Image.FromFile(chooseImage.FileName);
                    pictureBox1.SizeMode = pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("Расмро интихоб нанамудед!");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        public void ClearText()
        {
            idLabel.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "Номи таомро интихоб кунед";
            dateTimePicker1.Text = "";
            pictureBox1.Image = null;
            label7.Text = "";
        }
    }
}