using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AlexNet
{
    public partial class Form1 : Form
    {
        Alexnet alexnet = new Alexnet();
        Image image;
        Size size = new Size(224, 224);

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
        }

       
        private void btn_predict_Click(object sender, EventArgs e)
        {   
            if (mainPictureBox.Image != null)
            {
                // pass a copy of the image through the alexnet neural network
                var predictions = alexnet.predict((Image)image.Clone());
                // make the textboxes appear and display the top 3 predictions in these boxes
                textBox4.Visible = true;
                textBox1.Visible = true;
                textBox1.Text = predictions.Keys.ToList()[0];
                textBox2.Visible = true;
                textBox2.Text = predictions.Keys.ToList()[1];
                textBox3.Visible = true;
                textBox3.Text = predictions.Keys.ToList()[2];
            }
        
           
        }

        

        private void btn_browse_Click(object sender, EventArgs e)
        {
            
            // open file explorer   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // read image
                string imgpath = open.FileName;
                Image img = Image.FromFile(imgpath);
                image = (Image)new Bitmap(img, size);
                // display image in picture box with name above
                imgTitle.Text = (string)imgpath;
                mainPictureBox.Image = image;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }



        private void samples_Click(object sender, EventArgs e)
        {
            //open the form/window containing the sample pictures
            Form2 samples = new Form2();
            samples.ShowDialog();
            
            //return the selected in the samples window to the main window
            image = samples.sampleImg.Image;
            imgTitle.Text = (string)samples.sampleImg.Tag;
            mainPictureBox.Image = image;
        }

        private void close_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        /// <summary>
        /// Opens the README file in new window
        /// </summary>
        private void about_Click(object sender, EventArgs e)
        {
            Form readme = new README();
            readme.ShowDialog();
        }

        private void background_Click(object sender, EventArgs e)
        {

        }
    }
}
