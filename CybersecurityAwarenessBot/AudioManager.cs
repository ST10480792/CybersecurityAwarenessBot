using System;
using System.IO;
using System.Media;

namespace CybersecurityAwarenessBot
{
    internal class AudioManager
    {
        public static void PlayGreeting()
        {
            try
            {
                string audioPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Media",
                    "GreetingVoice.wav"
                );

                if (File.Exists(audioPath))
                {
                    SoundPlayer player = new SoundPlayer(audioPath);
                    player.PlaySync();
                }
                else
                {
                    Console.WriteLine("Greeting voice file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }
    }
}