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
            MessageBox.Show("Save Successfully!");
        }

        private void adminbtn_Click(object sender, EventArgs e)
        {
                MessageBox.Show("Successfully Saved!", "Save");
                    
            
        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
