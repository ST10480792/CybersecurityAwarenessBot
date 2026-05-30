using System;

namespace CybersecurityAwarenessBot
{
    internal class LogoDisplay
    {
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

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