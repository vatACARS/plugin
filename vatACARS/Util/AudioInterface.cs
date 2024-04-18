using System;
using System.Media;

namespace vatACARS.Util
{
    public static class AudioInterface
    {
        private static SoundPlayer SoundPlayer = new SoundPlayer();
        private static string dirPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\vatACARS\\audio";

        public static void playSound(string sound)
        {
            try
            {
                SoundPlayer.SoundLocation = $"{dirPath}\\{sound}.wav";
                SoundPlayer.Play();
            }
            catch { }
        }
    }
}
