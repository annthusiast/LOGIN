using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition;

namespace Log_In
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FaceRec face = new FaceRec();
        private void opencam_Click(object sender, EventArgs e)
        {
            face.openCamera(pictureBox1, pictureBox2);
        }

        private void detect_Click(object sender, EventArgs e)
        {
            face.isTrained = true;
            label7.Text = "First Name: " + textBox1.Text;
            label8.Text = "Last Name: " + textBox2.Text;
            label9.Text = "Email: " + textBox3.Text;
            label10.Text = "Password: " + GetHiddenPass(textBox4.Text);
            label12.Text = "Usertype : " + (comboBox1.Text);
        }

        private string GetHiddenPass(string password)
        {
            // replace password with an asterisk (*)
            return new string('*', password.Length);
        }

        private void saveimg_Click(object sender, EventArgs e)
        {
            face.Save_IMAGE(textBox1.Text);
            face.Save_IMAGE(textBox2.Text);
            face.Save_IMAGE(textBox3.Text);
            face.Save_IMAGE(textBox4.Text);
            face.Save_IMAGE(comboBox1.Text);
            MessageBox.Show("Save Successfully!");
        }

        private void adminbtn_Click(object sender, EventArgs e)
        {
            string Fname = textBox1.Text;
            string Lname = textBox2.Text;
            string Email = textBox3.Text;
            string Pword = textBox4.Text;

            if (comboBox1.SelectedItem != null)
            {
                if (int.TryParse(comboBox1.SelectedValue.ToString(), out int Usertype))
                {
                    // Convert the image from PictureBox to byte array
                    ImageConverter converter = new ImageConverter();
                    byte[] PhotoBytes = (byte[])converter.ConvertTo(pictureBox2.Image, typeof(byte[]));

                    try
                    {
                        // Assuming db is an instance of your database access class
                        db.sp_save(Fname, Lname, Email, Pword, PhotoBytes, Usertype);
                        MessageBox.Show("Successfully Saved!", "Save");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
