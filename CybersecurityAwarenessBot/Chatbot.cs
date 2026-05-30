using System;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    internal class Chatbot
    {
        // Automatic property
        public string UserName { get; set; }

        /// <summary>
        /// Starts the chatbot and manages the interaction flow.
        /// </summary>
        public void StartChat()
        {
            AudioManager.PlayGreeting();
            LogoDisplay.DisplayLogo();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================================");
            Console.WriteLine("        CYBERSECURITY AWARENESS ASSISTANT");
            Console.WriteLine("========================================================");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("      Helping South Africans Stay Safe Online");
            Console.WriteLine("========================================================");
            Console.ResetColor();

            /// <summary>
            /// Prompts the user to enter their name and validates input.
            /// </summary>
            GetUserName();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n========================================================");
            Console.WriteLine($" Hello, {UserName}! 👋");
            Console.WriteLine(" Welcome to the Cybersecurity Awareness Assistant.");
            Console.WriteLine($" {UserName}, I’m here to help you stay safe online.");
            Console.WriteLine("========================================================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\n========================================================");
            Console.WriteLine("               THINGS YOU CAN ASK ME");
            Console.WriteLine("========================================================");

            Console.WriteLine(" • Password safety");
            Console.WriteLine(" • Phishing scams");
            Console.WriteLine(" • Safe browsing");
            Console.WriteLine(" • Suspicious links");
            Console.WriteLine(" • Cybersecurity");
            Console.WriteLine(" • My purpose");
            Console.WriteLine(" • How are you?");

            Console.WriteLine("\n Type 'exit' or 'bye' anytime to leave the chat.");

            Console.WriteLine("========================================================");

            Console.ResetColor();

            /// <summary>
            /// Keeps the chatbot conversation running until the user exits.
            /// </summary>
            ChatLoop();
        }

        private void GetUserName()
        {
            Console.Write("\nPlease enter your name: ");
            UserName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(UserName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Please enter a valid name: ");
                Console.ResetColor();

                UserName = Console.ReadLine();
            }
        }

        private void ChatLoop()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"\n{UserName}: ");
                Console.ResetColor();
                Console.ResetColor();

                string userInput = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[Bot]: {UserName}, please type a cybersecurity question.");
                    Console.ResetColor();
                    continue;
                }

                if (userInput == "exit" || userInput == "bye")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n[Bot]: Goodbye, {UserName}! Stay safe online.");
                    Console.ResetColor();
                    keepRunning = false;
                    continue;
                }

                ResponseHandler.HandleResponse(userInput, UserName);

                Thread.Sleep(700);
            }
        }
    }
}