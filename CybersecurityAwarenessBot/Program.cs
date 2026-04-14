using System;
using System.Media;
using System.IO;

namespace CybersecurityAwarenessBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Call the method that starts our bot
            RunChatbot();
        }

        /// <summary>
        /// Initializes and runs the core chatbot features.
        /// </summary>
        static void RunChatbot()
        {
            // Play the voice first
            PlayGreeting();

            // Question 2: Display ASCII Logo
            DisplayLogo();

            // Question 6: Enhanced UI (Colors and Borders)
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("**********************************************");
            Console.WriteLine("* WELCOME TO THE CYBER-AWARE ASSISTANT    *");
            Console.WriteLine("**********************************************");
            Console.ResetColor();

            // Question 3: User Interaction
            Console.Write("\n[System]: To begin, please enter your name: ");
            string userName = Console.ReadLine();

            // Question 5: Input Validation (The "2nd Year" Polish)
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid input. Please enter a valid name: ");
                Console.ResetColor();
                userName = Console.ReadLine();
            }

            // Question 3: Personalised Response
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHello, {userName}! It's great to meet you.");
            Console.WriteLine("I'm here to help you navigate the world of cybersecurity safely.");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to open the Learning Menu...");
            Console.ReadKey();
        }

        static void PlayGreeting()
        {
            try
            {
                // We point to the Media folder where your file is
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Media", "GreetingVoice.wav");

                if (File.Exists(audioPath))
                {
                    SoundPlayer player = new SoundPlayer(audioPath);
                    Console.Beep();
                    player.PlaySync(); // Use .PlaySync() if you want the program to wait for the audio to finish
                }
                else
                {
                    Console.WriteLine("Audio file not found at: " + audioPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }
        /// <summary>
        /// Renders the Cybersecurity shield logo in the console.
        /// </summary>
        static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // The '@' allows us to use a "verbatim string" for the multi-line art
            Console.WriteLine(@"
                 .----------.
                /          / \
               /          /   \
              /          /     \
             /__________/       \
             |          |       |
             |  [SAFE]  |       |
             |          |       |
             \          /       /
              \        /       /
               \      /       /
                \    /       /
                 \  /       /
                  \/_______/
            ");
            Console.WriteLine("      SOUTH AFRICAN CYBER-AWARE      ");
            Console.WriteLine("=====================================");
            Console.ResetColor();
        }
    }
}

