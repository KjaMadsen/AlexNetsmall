using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AlexNet
{
    public partial class Form2 : Form
    {
        public PictureBox sampleImg;
 
        List<PictureBox> imageBoxes;
        
        public Form2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Locate the sample images and put them in a picturebox
        /// </summary>
        private void Form2_Load(object sender, EventArgs e)
        {
            
            imageBoxes = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            var imagepaths = new List<String> {@"model/crane.jpg", @"model/golden.png", @"model/goldfish.jpg", @"model/laptop.jpg", @"model/terrapin.jpg", @"model/goose.jpg"};
            var images = new List<Image>();

            //Add the images form their paths to images (list)
            foreach (var path in imagepaths) 
            {
                images.Add(Bitmap.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path)));
            }

            //Fill the pictureboxes with the images 
            for (int i = 0; i < imagepaths.Count; i++) 
            {
                var img = (Image)new Bitmap(images[i], new Size(224,224));
                imageBoxes[i].Tag = imagepaths[i];
                imageBoxes[i].Image = img;
            }
        }

        /// <summary>
        /// Highlight and select the image in this picturebox
        /// </summary>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sampleImg = pictureBox1;
            pictureBox1.Size = new Size(224, 230);
            RemoveHighlight();
        }
        /// <summary>
        /// Highlight and select the image in this picturebox
        /// </summary>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sampleImg = pictureBox2;
            pictureBox2.Size = new Size(224, 230);
            RemoveHighlight();
        }
        /// <summary>
        /// Highlight and select the image in this picturebox
        /// </summary>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            sampleImg = pictureBox3;
            pictureBox3.Size = new Size(224, 230);
            RemoveHighlight();
        }
        /// <summary>
        /// Highlight and select the image in this picturebox
        /// </summary>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            sampleImg = pictureBox4;
            pictureBox4.Size = new Size(224, 230);
            RemoveHighlight();
        }
        /// <summary>
        /// Highlight and select the image in this picturebox
        /// </summary>
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            sampleImg = pictureBox5;
            pictureBox5.Size = new Size(224, 230);
            RemoveHighlight();
        }
        /// <summary>
        /// Highlight and select the image in this picturebox
        /// </summary>
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            sampleImg = pictureBox6;
            pictureBox6.Size = new Size(224, 230);
            RemoveHighlight();
        }


        /// <summary>
        /// Remove the highlights of all the images but the selected image
        /// </summary>
        private void RemoveHighlight()
        {
            foreach(var box in imageBoxes)
            {
                if (box.Image.Equals(sampleImg.Image))
                {
                    continue;
                }
                box.Size = new Size(224,224);
            }
        }


        /// <summary>
        /// Confirms the selection and close the window
        /// </summary>
        private void select_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Close the window without selecting any image
        /// </summary>
        private void close_Click(object sender, EventArgs e)
        {
            sampleImg = null;
            this.Close();
        }
    }
}
