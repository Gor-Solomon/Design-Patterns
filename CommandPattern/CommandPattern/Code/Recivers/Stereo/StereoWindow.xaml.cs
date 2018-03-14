using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CommandPattern.Code.Recivers.Stereo
{
    /// <summary>
    /// Interaction logic for StereoWindow.xaml
    /// </summary>
    public partial class StereoWindow : Window
    {
        public MediaPlayer mediaPlayer = new MediaPlayer();
        public string fileName;
        const string songName = "Song Name: ";
        public StereoWindow()
        {
            InitializeComponent();
            this.Closed += StereoWindow_Closed;
            this.Title += this.GetHashCode();
        }

        private void StereoWindow_Closed(object sender, EventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void btnOpenAudioFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                fileName = openFileDialog.FileName;
                mediaPlayer.Open(new Uri(openFileDialog.FileName));
            }
                

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            lb_SongName.Content = songName + new FileInfo(fileName).Name;
        }

        public void OpenAudioFile(string path)
        {

            mediaPlayer.Open(new Uri(path,UriKind.Relative));
            fileName = path;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            lb_SongName.Content = songName + new FileInfo(fileName).Name;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null && mediaPlayer.NaturalDuration.HasTimeSpan)
                lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
                lblStatus.Content = "No file selected...";
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }
    }
}
