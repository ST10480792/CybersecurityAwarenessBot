using System;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    internal class TypingEffect
    {
        public static void ShowTyping()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n[Bot is typing");

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }

            Console.WriteLine("]");
            Console.ResetColor();
        }

        public static void TypeText(string message)
        {
            foreach (char letter in message)
            {
                Console.Write(letter);
                Thread.Sleep(20);
            }

            Console.WriteLine();
        }
    }
}