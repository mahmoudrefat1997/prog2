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
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
namespace WindowsFormsApp1
{
    public partial class startingpoint : Form
    {
        
        public startingpoint()
        {
            InitializeComponent();
        }

        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;



        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            picPreview.Visible = true;
            button3.Text = " save";

            ApplyFilter(true);
            richTextBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button3.Text = " save";

                richTextBox1.Visible = false;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Select an image file.";
                ofd.Filter = "Jpeg Images(*.jpg)|*.jpg|Png Images(*.png)|*.png";
                ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    StreamReader streamReader = new StreamReader(ofd.FileName);
                    originalBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                    streamReader.Close();

                    previewBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);

                    picPreview.Height = previewBitmap.Height;
                    picPreview.Width = previewBitmap.Width;
                    picPreview.Image = previewBitmap;
                    ApplyFilter(true);

                }
                picPreview.Visible = true;
            }
            catch (Exception eer) { Console.WriteLine(eer.StackTrace); };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
            if (button3.Text == " save")
            {
             SaveFileDialog chooser1 = new SaveFileDialog();
                chooser1.ShowDialog();
                chooser1.Filter = " |*.*";
                string place = chooser1.FileName;

                    if (System.IO.File.Exists(chooser1.FileName + ".jpg"))
                    {
                        MessageBox.Show("the image already exists");
                    }
                    else
                    {
                    resultBitmap =(Bitmap) picPreview.Image;
                    resultBitmap.Save(chooser1.FileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        MessageBox.Show("image saved ");

                    }
                
            }
            else
            {
                Clipboard.SetText(richTextBox1.Text);
            }

        }
            catch (Exception eer) { Console.WriteLine(eer.StackTrace); };
}
        private void ApplyFilter(bool preview)
        {
            try { 
            if (previewBitmap == null)
            {
                return;
            }
            filter f = new WindowsFormsApp1.filter();
                f.Factor = double.Parse(textBox10.Text);
                f.filterMatrix[0, 0] = int.Parse(textBox1.Text);

            f.filterMatrix[0, 1] = int.Parse(textBox2.Text);

            f.filterMatrix[0, 2] = int.Parse(textBox3.Text);

            f.filterMatrix[1, 0] = int.Parse(textBox6.Text);

            f.filterMatrix[1, 1] = int.Parse(textBox5.Text);

            f.filterMatrix[1, 2] = int.Parse(textBox4.Text);

            f.filterMatrix[2, 0] = int.Parse(textBox7.Text);

            f.filterMatrix[2, 1] = int.Parse(textBox8.Text);

            f.filterMatrix[2, 2] = int.Parse(textBox9.Text);
            

          
                picPreview.Image = previewBitmap.ConvolutionFilter(f);
            
            
        }
            catch (Exception eer) { Console.WriteLine(eer.StackTrace); };
}
        private void button4_Click(object sender, EventArgs e)
        {
            try { 
            button3.Text = " copy asci art";
          int res = Convert.ToInt32(11- trackBar1.Value);
            richTextBox1.Text = ExtBitmap.ASCIIFilter(originalBitmap, res);


            // richTextBox1.Text = ExtBitmap.ASCIIFilter(originalBitmap, 1, 1);
            richTextBox1.Visible = true;
            picPreview.Visible = false;
        }
            catch (Exception eer) { Console.WriteLine(eer.StackTrace); };
}

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText=="original")
            {
                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";
                textBox4.Text = "0";
                textBox5.Text = "1";
                textBox6.Text = "0";
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox9.Text = "0";
                textBox10.Text = "1";


            }
            else if (richTextBox1.SelectedText  =="Mean filter")
            {

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "1";
                textBox4.Text = "1";
                textBox5.Text = "1";
                textBox6.Text = "1";
                textBox7.Text = "1";
                textBox8.Text = "1";
                textBox9.Text = "1";
                textBox10.Text = ".1";

            }
        }
    }

    }

