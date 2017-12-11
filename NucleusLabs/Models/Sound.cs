
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media;

namespace NucleusLabs
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Sound
    {
        public MediaPlayer player = new MediaPlayer();
        private Uri filename { get; set; }
        public string File { get; set; }
        public bool Looping { get; set; }
        public String Name { get; set; }
        public Double Duration { get; set; }


        public Sound(String _Name, String _File,bool _Looping)
        {
            Name = _Name;
            File = _File;
            Looping = _Looping;
            Uri.TryCreate((Environment.CurrentDirectory +"/" +File), UriKind.Absolute, out Uri uriname);
            filename = uriname;
            player.Open(filename);
            //player.Open(new System.Uri(@"C:\Users\sshawl\Desktop\school\CIT195-2017\Sounds_OpenAL\OpenALDemo\OpenALDemo\Media\BackgroundMusic.wav"));
            while (!player.NaturalDuration.HasTimeSpan) { } //wait for the file to finish loading
            Duration = player.NaturalDuration.TimeSpan.Milliseconds;
        }

        public void Play()
        {

            //player.Open(filename);
            player.Position = TimeSpan.Zero;
            player.Play();
        }

        public void PlayLoop()
        {
            
            //player.MediaEnded += this.onMediaEnded;
            Looping = true;
            player.Position = TimeSpan.Zero;
            player.Play(); 
        }
        public void Stop()
        {
            //player.MediaEnded -= this.onMediaEnded;
            Looping = false;
            player.Stop();
        }

        

        public bool isLooping
        {
            get { return Looping; }
            //set { }
        }

        //public void onMediaEnded(object sender, EventArgs e)
        //{
        //    var thisplayer = sender as MediaPlayer;
        //    thisplayer.Position = TimeSpan.Zero;
        //    thisplayer.Play();
        //}

        public void CheckLoop() {
            if (player.NaturalDuration.TimeSpan.Milliseconds == player.Position.Milliseconds)
            {
                //End of file and we're suppose to loop
                player.Position = TimeSpan.Zero;
                player.Play();
            }
        }


}
}

