using System;
using System.Media;
using System.Runtime.InteropServices;

namespace vatACARS.Util
{
    public static class AudioInterface
    {
        private static SoundPlayer SoundPlayer = new SoundPlayer();
        private static string dirPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\vatACARS\\audio";

        [DllImport("winmm.dll", EntryPoint = "waveOutSetVolume")]
        private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public static void playSound(string sound)
        {
            try
            {
                int volume = (int)(Properties.Settings.Default.volume * 6553.5);
                SetVolume(volume);

                SoundPlayer.SoundLocation = $"{dirPath}\\{sound}.wav";
                SoundPlayer.Play();
            }
            catch { }
        }

        private static void SetVolume(int volume)
        {
            uint newVolume = (uint)((volume & 0x0000ffff) | (volume << 16));
            waveOutSetVolume(IntPtr.Zero, newVolume);
        }
    }
}
