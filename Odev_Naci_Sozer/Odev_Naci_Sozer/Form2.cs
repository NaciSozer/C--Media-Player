using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;
using Microsoft.Win32;



namespace Odev_Naci_Sozer
{
    public partial class Form2 : Form
    {

        Form1 f1 = new Form1();
        
        public Form2()
        {
            InitializeComponent();

            
        }

        private void openMedia_Clik(object sender , System.EventArgs e)
        {
            


        }
        #region form yüklendiğinde 
        private void Form2_Load(object sender, EventArgs e)
        {

            try
            {
                //axWindowsMediaPlayer1.settings.volume = 100;


                WMPLib.WindowsMediaPlayer Odev_Naci_Sozer = new WMPLib.WindowsMediaPlayer();
               
                Odev_Naci_Sozer.URL = listBox1.Text;
               
                listBox1.Items.AddRange(System.IO.Directory.GetFiles(@"d:\media", "*.mp3", System.IO.SearchOption.AllDirectories));

               
                
            }

            catch
            {
                Console.WriteLine("Yanış Dosya seçtiniz");
            }
          
        }
        #endregion

        //form1 geçiş*
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
        //*
        //programdan çıkma*
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region radio butonları kontrolu
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            this.BackColor = System.Drawing.Color.DarkRed;
            button1.BackColor = Color.DarkRed;
            button3.BackColor = Color.DarkRed;
            button4.BackColor = Color.DarkRed;
            button2.BackColor = Color.DarkRed;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.CadetBlue;
            button1.BackColor = Color.CadetBlue;
            button3.BackColor = Color.CadetBlue;
            button4.BackColor = Color.CadetBlue;
            button2.BackColor = Color.CadetBlue;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.YellowGreen;
            button1.BackColor = Color.YellowGreen;
            button3.BackColor = Color.YellowGreen;
            button4.BackColor = Color.YellowGreen;
            button2.BackColor = Color.YellowGreen;

        }
        #endregion
        //*
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        #region müzik dosyasını seçme kodları
        private void button5_Click(object sender, EventArgs e)
        {
           try
            {
               

                openFileDialog1.Filter = "Media File(*.mpg,*.dat,*.avi,*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.mpg;*.dat;*.avi;*.wmv";
                
                openFileDialog1.ShowDialog();

                openFileDialog1.InitialDirectory = Application.StartupPath;
                openFileDialog1.Title = "Dosya seç";
                listBox1.Text = openFileDialog1.FileName;

                if(openFileDialog1.FileName != "")
                {
                    listBox1.Items.AddRange(openFileDialog1.FileNames);
                }

                axWindowsMediaPlayer1.URL = listBox1.Text;

            

                timer1.Enabled = true;

                

            }

            catch
            {
                MessageBox.Show("Lütfen bir müzik seçin!");
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {  
                axWindowsMediaPlayer1.URL = listBox1.Text;
               
            }

            catch
            {

            }
        }
        #endregion

        #region başlat ve duraklaktat butonları
        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            timer1.Enabled = false;
        }
        #endregion


        private void progressBar1_Click(object sender, EventArgs e)
        {

            progressBar1.BackColor = Color.Aqua;

        }

        //BURAYA BAK DAHA SONRA!!!*
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Visible = true;
            
        }
        //*
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            }

            catch
            {

            }
        }

        //durdurma ileri sarma geri sarma*
        private void button7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.previous();
            timer1.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            



        }

        private void button6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            timer1.Enabled = true;
        }
        //*
      //ses kısma açma işmeleri
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
            //axWindowsMediaPlayer1.settings.volume = 50;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBar2.Value;


        }

       
    }
}
