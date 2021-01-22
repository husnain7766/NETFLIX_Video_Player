using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NETFLIX
{
    public partial class PlayerForm : Form
    {
        private string _videoUrl;
        private string _movieName;
        private Timer _timer;
        public PlayerForm(string url, string movieName)
        {
            this._videoUrl = url;
            this._movieName = movieName.Replace(" ", "");
            Console.WriteLine(@"Movie Playing "+_movieName);
            InitializeComponent();
            LoadNewTime();
            SaveNewTime();
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            // provides the url to played element in the forms
            player.URL = _videoUrl;
            // and this will start playing
            player.settings.autoStart = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // this will stop the player
            player.Ctlcontrols.stop();
            //this will close the window
            Close();
        }

        private void fullScreenButton_Click(object sender, EventArgs e)
        {
            // turns the media full screen
            player.fullScreen = true;
        }

        // this will set the new time 
        private void SetLength(double time)
        {
            player.Ctlcontrols.currentPosition = time;
        }

        // this will start the thread that will save the time in the file after 2 milli seconds
        void SaveNewTime()
        {
            _timer = new Timer { Interval = 2000 };
            _timer.Enabled = true;
            _timer.Tick += new EventHandler(SaveToFile);
            _timer.Start();
        }

        void LoadNewTime()
        {
            // this read the time of the movie at which it is being stoped
            // you can use this to read the time form the database
            try
            {
                string[] lines = File.ReadAllLines("./DB/"+_movieName);
                try
                {
                    double time = double.Parse(lines[0]);
                    SetLength(time);
                    Console.WriteLine(@"./DB/" + _movieName + @" Loaded " + time);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        void SaveToFile(Object sender, EventArgs args)
        {
            // this will save the time in the file
            // you can set this to store in the database sql like you used in your project
            string path = "./DB/"+_movieName;
            using (StreamWriter sw = File.CreateText(path))
            {
                double time = player.Ctlcontrols.currentPosition;
                sw.WriteLine(time);
                Console.WriteLine(path+@" Saved " +time);
                sw.Close();
            }
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // when the player will close this will stop the timer since saving the time after 2000ms is working on other thread
            _timer.Stop();
        }
    }
}
