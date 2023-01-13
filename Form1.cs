using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using System.IO;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;


namespace new_player_2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
            axWindowsMediaPlayer1.Visible = false;
            listBox1.Visible = false;
            timer2.Enabled = true;
        }
       
        string path;
        string[] mmp3;
        

        //bunlari internetden goturmusem ne oldugu haqqinda melumatim yoxdu:)   formu hereket etdirmek ucundur.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel2_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // bura kimi
       
        private void button1_Click(object sender, EventArgs e)
        {
            //button1.BackgroundImage = Properties.Resources._1865153b;
            //button2.BackgroundImage = Properties.Resources._608365a;
            //button3.BackgroundImage = Properties.Resources._2099058a;
            button4.BackgroundImage = Properties.Resources._4210456a;

           
            if (listBox1.Visible==true)
            {
                listBox1.Visible = false;
                button1.BackgroundImage = Properties.Resources._608386a;
            }
            else
            {
                listBox1.Visible = true;
                button1.BackgroundImage = Properties.Resources._608386b;
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackgroundImage = Properties.Resources._608365b;
            //button1.BackgroundImage = Properties.Resources._1865153a;
            button3.BackgroundImage = Properties.Resources._4202608a;
            button4.BackgroundImage = Properties.Resources._4210456a;
            try
            {
             listBox1.Items.Clear();
            mmp3 = null;
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            if (DialogResult.OK == file.ShowDialog())
                    try
                    {
                     mmp3 = file.FileNames;
                        for (int i = 0; i < mmp3.Length; i++)
                        {
                            DirectoryInfo listden = new DirectoryInfo(mmp3[i]);
                            string fileAd = listden.Name;
                            listBox1.Items.Add(fileAd);
                        }
                     axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex];
            //         TagLib.File file1 = TagLib.File.Create(mmp3[listBox1.SelectedIndex]);
            //var MS1 = new MemoryStream();
            //var pic1 = file1.Tag.Pictures.FirstOrDefault();
            //if (pic1 != null)
            //{
            //    byte[] pData1 = pic1.Data.Data;
            //    MS1.Write(pData1, 0, Convert.ToInt32(pData1.Length));
            //    var BM1 = new Bitmap(MS1, false);
            //    MS1.Dispose();
            //    pictureBox1.Image = BM1;
            //}
            //else
            //{
            //    // pictureBox1.Visible = false;
            //}

            //pictureBox2.Visible = false;
            //pictureBox3.Visible = false;
            //pictureBox4.Visible = false;
            //pictureBox5.Visible = false;
            //pictureBox6.Visible = false;
                    
                    }
                    catch (Exception)
                    {

                      
                    }
           
           

           
            //DirectoryInfo pathfile = new DirectoryInfo(path);
            //string filename = pathfile.Name;
            //listBox1.Items.Add(filename);


           
            }
            catch (Exception)
            {

                
            }
            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            button3.BackgroundImage = Properties.Resources._4202608b;
            button2.BackgroundImage = Properties.Resources._608365a;
            //button1.BackgroundImage = Properties.Resources._1865153a;
            button4.BackgroundImage = Properties.Resources._4210456a;

            listBox1.Items.Clear();

            //mmp3 = Directory.GetFiles(dir, "*.jpg", SearchOption.AllDirectories);
            //mmp3=Directory.GetFiles(@"d:\SearchDir", "*.mp3", SearchOption.AllDirectories);
            try
            {
                mmp3=Directory.GetFiles(@"D:", "*.mp3", SearchOption.AllDirectories);
                for (int i = 0; i < mmp3.Length; i++)
            {
                DirectoryInfo files = new DirectoryInfo(mmp3[i]);
                string filename = files.Name;
                listBox1.Items.Add(filename);

            }
            }
            catch (Exception)
            {

            
            }
        

          
            
        }
             Form2 info = new Form2();
        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackgroundImage = Properties.Resources._4210456b;
            button2.BackgroundImage = Properties.Resources._608365a;
            //button1.BackgroundImage = Properties.Resources._1865153a;
            button3.BackgroundImage = Properties.Resources._4202608a;
              
            if (info.Visible==true)
            {
                info.Visible=false;
                    button4.BackgroundImage = Properties.Resources._4210456a;
            }

            else
            {
                info.Show();
                button4.BackgroundImage = Properties.Resources._4210456b;
                
            }

            //    if (button4.BackgroundImage == Properties.Resources._4210456a)
            //    {

            //    }
            //    else
            //    {
            //        info.Close();
            //       button4.BackgroundImage = Properties.Resources._4210456a;
            //    }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count - listBox1.SelectedIndex > 4)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 4;
                axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             int say = listBox1.Items.Count;
            if (mmp3 != null )
            {

                DirectoryInfo siyahidan = new DirectoryInfo(mmp3[listBox1.SelectedIndex]);
                string siyahidanad = siyahidan.FullName;
                axWindowsMediaPlayer1.URL = siyahidanad;
                label1.Text = siyahidan.Name;

                TagLib.File file1 = TagLib.File.Create(mmp3[listBox1.SelectedIndex]);
                var MS1 = new MemoryStream();
                var pic1 = file1.Tag.Pictures.FirstOrDefault();
                if (pic1 != null)
                {
                   
                    byte[] pData1 = pic1.Data.Data;
                    MS1.Write(pData1, 0, Convert.ToInt32(pData1.Length));
                    var BM1 = new Bitmap(MS1, false);
                    MS1.Dispose();
                    pictureBox1.Image = BM1;
                }
                else
                {
                    pictureBox1.Image = null;
                }
                if (say - listBox1.SelectedIndex > 1)
                {
                    TagLib.File file2 = TagLib.File.Create(mmp3[listBox1.SelectedIndex + 1]);
                    var MS2 = new MemoryStream();
                    var pic2 = file2.Tag.Pictures.FirstOrDefault();
                    if (pic2 != null)
                    {
                        
                        byte[] pData2 = pic2.Data.Data;
                        MS2.Write(pData2, 0, Convert.ToInt32(pData2.Length));
                        var BM2 = new Bitmap(MS2, false);
                        MS2.Dispose();
                        pictureBox2.Image = BM2;
                    }
                    else
                    {
                        pictureBox2.Image = null;
                    }
                }
                if (say - listBox1.SelectedIndex > 2)
                {
                    TagLib.File file3 = TagLib.File.Create(mmp3[listBox1.SelectedIndex + 2]);
                    var MS3 = new MemoryStream();
                    var pic3 = file3.Tag.Pictures.FirstOrDefault();
                    if (pic3 != null)
                    {
                        
                        byte[] pData3 = pic3.Data.Data;
                        MS3.Write(pData3, 0, Convert.ToInt32(pData3.Length));
                        var BM3 = new Bitmap(MS3, false);
                        MS3.Dispose();
                        pictureBox3.Image = BM3;
                    }
                    else
                    {
                        pictureBox3.Image = null;
                    }
                }
                if (say - listBox1.SelectedIndex > 3)
                {
                    TagLib.File file4 = TagLib.File.Create(mmp3[listBox1.SelectedIndex + 3]);
                    var MS4 = new MemoryStream();
                    var pic4 = file4.Tag.Pictures.FirstOrDefault();
                    if (pic4 != null)
                    {
                       
                        byte[] pData4 = pic4.Data.Data;
                        MS4.Write(pData4, 0, Convert.ToInt32(pData4.Length));
                        var BM4 = new Bitmap(MS4, false);
                        MS4.Dispose();
                        pictureBox4.Image = BM4;
                    }
                    else
                    {
                        pictureBox4.Image = null;
                    }
                }
                if (say - listBox1.SelectedIndex > 4)
                {
                    TagLib.File file5 = TagLib.File.Create(mmp3[listBox1.SelectedIndex + 4]);
                    var MS5 = new MemoryStream();
                    var pic5 = file5.Tag.Pictures.FirstOrDefault();
                    if (pic5 != null)
                    {
                        
                        byte[] pData5 = pic5.Data.Data;
                        MS5.Write(pData5, 0, Convert.ToInt32(pData5.Length));
                        var BM5 = new Bitmap(MS5, false);
                        MS5.Dispose();
                        pictureBox5.Image = BM5;
                    }
                    else
                    {
                        pictureBox5.Image = null;
                    }
                }
                if (say - listBox1.SelectedIndex > 5)
                {

                    TagLib.File file6 = TagLib.File.Create(mmp3[listBox1.SelectedIndex + 5]);
                    var MS6 = new MemoryStream();
                    var pic6 = file6.Tag.Pictures.FirstOrDefault();
                    if (pic6 != null)
                    {
                        
                        byte[] pData6 = pic6.Data.Data;
                        MS6.Write(pData6, 0, Convert.ToInt32(pData6.Length));
                        var BM6 = new Bitmap(MS6, false);
                        MS6.Dispose();
                        pictureBox6.Image = BM6;
                    }
                    else
                    {
                        pictureBox6.Image = null;
                    }
                }

                if (say - listBox1.SelectedIndex < 6)
                {
                    pictureBox6.Image = null;

                }
                    if (say-listBox1.SelectedIndex<5)
                {
                    pictureBox6.Image = null;
                    pictureBox5.Image = null;
                }
                if (say - listBox1.SelectedIndex < 4)
                {
                    pictureBox6.Image = null;
                    pictureBox5.Image = null;
                    pictureBox4.Image = null;

                }
                if (say - listBox1.SelectedIndex < 3)
                {
                    pictureBox6.Image = null;
                    pictureBox5.Image = null;
                    pictureBox4.Image = null;
                    pictureBox3.Image = null;
                }
                if (say - listBox1.SelectedIndex < 2)
                {
                    pictureBox6.Image = null;
                    pictureBox5.Image = null;
                    pictureBox4.Image = null;
                    pictureBox3.Image = null;
                    pictureBox2.Image = null;
                }
                



            }
            else
               axWindowsMediaPlayer1.URL = path;
            
            if (listBox1.SelectedIndex == 0)
            {
                button6.Enabled = false;
            }
            else
                button6.Enabled = true;

            if (listBox1.SelectedIndex == listBox1.Items.Count - 1)
            {
                button7.Enabled = false;
            }
            else
                button7.Enabled = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (mmp3 != null)
            {
                if (listBox1.SelectedIndex != 0)
                {
                    listBox1.SelectedIndex--;
                    axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex];
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (mmp3 != null)
            {


                if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                {
                    listBox1.SelectedIndex++;
                    axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex];
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (axWindowsMediaPlayer1.playState)
            {
                case WMPLib.WMPPlayState.wmppsPlaying:
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                    button5.BackgroundImage = Properties.Resources._3874990;
                    break;
                case WMPLib.WMPPlayState.wmppsPaused:
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    button5.BackgroundImage = Properties.Resources._3240602a;
                    break;
                case WMPLib.WMPPlayState.wmppsStopped:
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    break;
            }
        }
       
        private void axWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {
            
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                trackBarEx2.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;
                timer1.Start();

                button5.BackgroundImage = Properties.Resources._3240602a;
                label1.Text = axWindowsMediaPlayer1.currentMedia.getItemInfo("Album");
                label5.Text = axWindowsMediaPlayer1.currentMedia.getItemInfo("Title");

               /* TagLib.File file1 = TagLib.File.Create(axWindowsMediaPlayer1.URL=mmp3[listBox1.SelectedIndex]);
                var MS1 = new MemoryStream();
                var pic1 = file1.Tag.Pictures.FirstOrDefault();
                if (pic1 != null)
                {
                    byte[] pData1 = pic1.Data.Data;
                    MS1.Write(pData1, 0, Convert.ToInt32(pData1.Length));
                    var BM1 = new Bitmap(MS1, false);
                    MS1.Dispose();
                    pictureBox1.Image = BM1;     
                }
                else
                {
                   // pictureBox1.Visible = false;
                }
                if (say - listBox1.SelectedIndex > 1)
                {
                    TagLib.File file2 = TagLib.File.Create(axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex + 1]);
                    var MS2 = new MemoryStream();
                    var pic2 = file2.Tag.Pictures.FirstOrDefault();
                    if (pic2 != null)
                    {
                        byte[] pData2 = pic2.Data.Data;
                        MS2.Write(pData2, 0, Convert.ToInt32(pData2.Length));
                        var BM2 = new Bitmap(MS2, false);
                        MS2.Dispose();
                        pictureBox2.Image = BM2;
                    }
                    else
                    {
                       // pictureBox2.Visible = false;
                    }
                }
                if (say - listBox1.SelectedIndex > 2)
                {
                    TagLib.File file3 = TagLib.File.Create(axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex + 2]);
                    var MS3 = new MemoryStream();
                    var pic3 = file3.Tag.Pictures.FirstOrDefault();
                    if (pic3 != null)
                    {
                        byte[] pData3 = pic3.Data.Data;
                        MS3.Write(pData3, 0, Convert.ToInt32(pData3.Length));
                        var BM3 = new Bitmap(MS3, false);
                        MS3.Dispose();
                        pictureBox3.Image = BM3;
                    }
                    else
                    {
                       // pictureBox3.Visible = false;
                    }
                }
                if (say - listBox1.SelectedIndex > 3)
                {
                    TagLib.File file4 = TagLib.File.Create(axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex + 3]);
                    var MS4 = new MemoryStream();
                    var pic4 = file4.Tag.Pictures.FirstOrDefault();
                    if (pic4 != null)
                    {
                        byte[] pData4 = pic4.Data.Data;
                        MS4.Write(pData4, 0, Convert.ToInt32(pData4.Length));
                        var BM4 = new Bitmap(MS4, false);
                        MS4.Dispose();
                        pictureBox4.Image = BM4;
                    }
                    else
                    {
                      //  pictureBox4.Visible = false;
                    }
                }
                if (say - listBox1.SelectedIndex > 4)
                {
                    TagLib.File file5 = TagLib.File.Create(axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex + 4]);
                    var MS5 = new MemoryStream();
                    var pic5 = file5.Tag.Pictures.FirstOrDefault();
                    if (pic5 != null)
                    {
                        byte[] pData5 = pic5.Data.Data;
                        MS5.Write(pData5, 0, Convert.ToInt32(pData5.Length));
                        var BM5 = new Bitmap(MS5, false);
                        MS5.Dispose();
                        pictureBox5.Image = BM5;
                    }
                    else
                    {
                        //pictureBox5.Visible = false;
                    }
                }
                if (say - listBox1.SelectedIndex > 5)
                {

                    TagLib.File file6 = TagLib.File.Create(axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex + 5]);
                    var MS6 = new MemoryStream();
                    var pic6 = file6.Tag.Pictures.FirstOrDefault();
                    if (pic6 != null)
                    {
                        byte[] pData6 = pic6.Data.Data;
                        MS6.Write(pData6, 0, Convert.ToInt32(pData6.Length));
                        var BM6 = new Bitmap(MS6, false);
                        MS6.Dispose();
                        pictureBox6.Image = BM6;
                    }
                    else
                    {
                       // pictureBox6.Visible = false;
                    }
                }
               */
            }
               
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
                button5.BackgroundImage = Properties.Resources._3874990;
            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();

                trackBarEx2.Value = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {

                trackBarEx2.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                label2.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
               label3.Text = axWindowsMediaPlayer1.currentMedia.durationString.ToString();
                
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if ( e.newState==8)
            {
                listBox1.SelectedIndex++;
                this.BeginInvoke(new System.Action(() =>
                {

                    this.axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex];
                }));
            }
        }

        private void trackBarEx2_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBarEx2.Value;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
        }

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count-listBox1.SelectedIndex>1)
            {
            listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
            axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex];
            }

            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count - listBox1.SelectedIndex > 2)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 2;
                axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex];
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count - listBox1.SelectedIndex > 3)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 3;
                axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex];
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count - listBox1.SelectedIndex > 5)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 5;
                axWindowsMediaPlayer1.URL = mmp3[listBox1.SelectedIndex];
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            info.Close();
        }
    }
}
