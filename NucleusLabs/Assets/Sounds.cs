using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace NucleusLabs
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Sounds
    {
        private Timer _timerSounds;

        public List<Sound> GameSounds = new List<Sound> { };

        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            //timer ticked Tell sounds to check all of it's loops
            foreach (Sound gameSound in GameSounds.Where(b => b.Looping == true))
            {
                if(gameSound.Duration == gameSound.player.Position.Milliseconds)
                {
                    gameSound.Play();
                }
                //gameSound.CheckLoop();
            }
        }







        //GameSounds.Add(new Sound
        //{
        //    Name = "BackgroundMusic",
        //    File = @"Media/BackgroundMusic.wav",
        //    Looping = false
        //});

        //GameSounds.Add(new Sound
        //{
        //    Name = "DoorLockSuccess",
        //    File = @"Media /DoorLockSuccess.wav",
        //    Looping = false
        //});
        //GameSounds.Add(new Sound
        //{
        //    Name = "DoorLockError",
        //    File = @"Media /DoorLockError.wav",
        //    Looping = false
        //});
        //GameSounds.Add(new Sound
        //{
        //    Name = "OofFemale",
        //    File = @"Media /Oof-Female.wav",
        //    Looping = false
        //});
        //GameSounds.Add(new Sound
        //{
        //    Name = "OofMale",
        //    File = @"Media /Oof-Male.wav",
        //    Looping = false
        //});
        //GameSounds.Add(new Sound
        //{
        //    Name = "FootSteps",
        //    File = @"Media /FootSteps.wav",
        //    Looping = false
        //});
        //GameSounds.Add(new Sound
        //{
        //    Name = "HealthAlert",
        //    File = @"Media /HealthAlert.wav",
        //    Looping = false
        //});

        public Sound BackgroundMusic = new Sound("BackgroundMusic", @"Media/BackgroundMusic.wav", false);            

        public Sound DoorLockSuccess = new Sound("DoorLockSuccess",@"Media/DoorLockSuccess.wav",false);

        public Sound DoorLockError = new Sound("DoorLockError", @"Media/DoorLockError.wav", false);

        public Sound OofFemale = new Sound("OofFemale", @"Media/Oof-Female.wav", false);

        public Sound OofMale = new Sound("OofMale", @"Media/Oof-Male.wav", false);

        public Sound FootSteps = new Sound("FootSteps", @"Media/FootSteps.wav", false);

        public Sound FemaleBreathing = new Sound("FemaleBreathing", @"Media/FemaleBreathing.wav", false);
        public Sound MaleBreathing = new Sound("MaleBreathing", @"Media/MaleBreathing.wav", false);


        public Sounds()
        {
            GameSounds.Add(BackgroundMusic);
            GameSounds.Add(DoorLockSuccess);
            GameSounds.Add(DoorLockError);
            GameSounds.Add(OofFemale);
            GameSounds.Add(OofMale);
            GameSounds.Add(FootSteps);
            GameSounds.Add(FemaleBreathing);
            GameSounds.Add(MaleBreathing);


            _timerSounds = new Timer(1000);
            _timerSounds.Elapsed += (sender, e) =>timer_Elapsed(sender, e);


            //GameSounds.Where(b => b.Name == "BackgroundMusic").First().PlayLoop();
            BackgroundMusic.Play();
            //_timerSounds.Start();
        }
    }
    
}
