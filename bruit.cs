using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetNarratif
{
    internal class bruit
    {
        /*code de l'ost du menu
            SoundPlayer ostmenu = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"\ostmenu.wav"));
            bruit.Bruitostmenu();
            ostmenu.Play();*/
        public static void Bruitporteouvreplay() // bruit ouverture de portes
        {
            string bruitporteouvre = Path.Combine(Environment.CurrentDirectory + @"\porteouvertures.wav");
            using (var porteplayer = new AudioFileReader(bruitporteouvre))
            using (var porteoutput = new WaveOutEvent())
            {
                porteoutput.Init(porteplayer);
                porteoutput.Play();
                while (porteoutput.PlaybackState == PlaybackState.Playing)
                { }
            }
        }
        public static void Bruitostmenu() // bruit ouverture télé menu
        {
            string bruitostmenu = Path.Combine(Environment.CurrentDirectory + @"\ostmenustart.wav");
            using (var ostmenuplayer = new AudioFileReader(bruitostmenu))
            using (var ostmenuoutput = new WaveOutEvent())
            {
                ostmenuoutput.Init(ostmenuplayer);
                ostmenuoutput.Play();
                while (ostmenuoutput.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }
        }
        public static void clickmenu()
        {
            string clickmenu = Path.Combine(Environment.CurrentDirectory + @"\clickmenu.wav");
            using (var clickmenuplayer = new AudioFileReader(clickmenu))
            using (var clickmenuoutput = new WaveOutEvent())
            {
                clickmenuoutput.Init(clickmenuplayer);
                clickmenuoutput.Play();
                while (clickmenuoutput.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }
        }
        public static void Bruitportefermeplay()// bruit fermeture de portes
        {

        }
        public static void Bruitascenseurbipplay() // bruit arrivée ascenseur
        {

        }
        public static void Bruitascenseurporteopplay() //bruit ouverture porte ascenseur
        {

        }
        public static void Bruitascensseurportecloplay() //bruit fermeture porte ascenseur
        {

        }
        public static void Bruitvoitdép() // bruit démarage voiture
        {

        }
        public static void bruitvoitarr() // bruit arrivée voiture
        {

        }
        public static void Bruitdepasforêt1à3()
        {
            using (var bruitpas1player = new AudioFileReader(Path.Combine(Environment.CurrentDirectory + @"bruitpasf1")))
            using (var bruitpas1output = new WaveOutEvent())
            using (var bruitpas2player = new AudioFileReader(Path.Combine(Environment.CurrentDirectory + @"bruitpasf2")))
            using (var bruitpas2output = new WaveOutEvent())
            using (var bruitpas3player = new AudioFileReader(Path.Combine(Environment.CurrentDirectory + @"bruitpasf3")))
            using (var bruitpas3output = new WaveOutEvent())
            {
                Random pasforet = new Random();
                int bruitpas = pasforet.Next(1, 4);
                if (bruitpas == 1)
                {
                    bruitpas1output.Init(bruitpas1player);
                    bruitpas1output.Play();
                    while (bruitpas1output.PlaybackState == PlaybackState.Playing)
                    { }
                }
                if (bruitpas == 2)
                {
                    bruitpas2output.Init(bruitpas2player);
                    bruitpas2output.Play();
                    while (bruitpas2output.PlaybackState == PlaybackState.Playing)
                    { }
                }
                if (bruitpas == 3)
                {
                    bruitpas3output.Init(bruitpas3player);
                    bruitpas3output.Play();
                    while (bruitpas3output.PlaybackState == PlaybackState.Playing)
                    { }
                }

            }
        }
        public static void wake()
        {
            string wake = Path.Combine(Environment.CurrentDirectory + @"\wake.wav");
            using (var wakeplayer = new AudioFileReader(wake))
            using (var wakeoutput = new WaveOutEvent())
            {
                wakeoutput.Init(wakeplayer);
                wakeoutput.Play();
                while (wakeoutput.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
