using System;

namespace CybersecurityAwarenessBot
{
    internal class ResponseHandler
    {
        public static void HandleResponse(string userInput, string userName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypingEffect.ShowTyping();

            if (userInput.Contains("how are you"))
            {
                TypingEffect.TypeText($"\n[Bot]: I'm doing great today, {userName}! Thanks for asking. I'm always ready to help you stay safe online.");
            }

            else if (userInput.Contains("purpose"))
            {
                TypingEffect.TypeText($"\n[Bot]: My purpose is to help South African citizens learn about cybersecurity and stay protected from online threats, {userName}. I can help you understand scams, passwords, suspicious links, and safe browsing habits.");
            }

            else if (userInput.Contains("password"))
            {
                TypingEffect.TypeText($"\n[Bot]: {userName}, strong passwords are one of the best ways to protect yourself online.");
                TypingEffect.TypeText("[Bot]: A secure password should include uppercase and lowercase letters, numbers, and symbols.");
                TypingEffect.TypeText("[Bot]: Avoid using personal details like birthdays, names, or simple passwords such as '123456'.");
                TypingEffect.TypeText("[Bot]: Try using a different password for each account to improve security.");
            }

            else if (userInput.Contains("phishing"))
            {
                TypingEffect.TypeText($"\n[Bot]: {userName}, phishing is a cyber scam where criminals pretend to be trusted people or companies to steal sensitive information.");
                TypingEffect.TypeText("[Bot]: This may happen through fake emails, SMS messages, or websites asking for passwords or banking details.");
                TypingEffect.TypeText("[Bot]: Before clicking anything, check for suspicious links, spelling mistakes, or urgent messages asking for personal information.");
            }

            else if (userInput.Contains("safe browsing") || userInput.Contains("browsing"))
            {
                TypingEffect.TypeText($"\n[Bot]: {userName}, safe browsing means protecting yourself while using the internet.");
                TypingEffect.TypeText("[Bot]: Avoid suspicious websites, never download files from unknown sources, and always make sure websites are secure.");
                TypingEffect.TypeText("[Bot]: A safe website usually starts with 'https://' and shows a padlock icon in the browser.");
            }

            else if (userInput.Contains("link"))
            {
                TypingEffect.TypeText($"\n[Bot]: {userName}, suspicious links are often used by cybercriminals to trick people into scams or harmful websites.");
                TypingEffect.TypeText("[Bot]: Before clicking, hover over links to inspect them or carefully read the website address.");
                TypingEffect.TypeText("[Bot]: If a message seems urgent or suspicious, avoid clicking and verify the sender first.");
            }

            else if (userInput.Contains("what can i ask"))
            {
                TypingEffect.TypeText($"\n[Bot]: {userName}, you can ask me about:");
                TypingEffect.TypeText("• Password safety");
                TypingEffect.TypeText("• Phishing scams");
                TypingEffect.TypeText("• Safe browsing");
                TypingEffect.TypeText("• Suspicious links");
                TypingEffect.TypeText("• My purpose");
                TypingEffect.TypeText("• General cybersecurity tips");
            }

            else if (userInput.Contains("cybersecurity") || userInput.Contains("cyber security"))
            {
                TypingEffect.TypeText($"\n[Bot]: Cybersecurity is about protecting computers, phones, accounts, and personal information from online threats, {userName}.");
                TypingEffect.TypeText("[Bot]: This includes staying safe from scams, hackers, malware, phishing attacks, and identity theft.");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                TypingEffect.TypeText(
                    $"\n[Bot]: Sorry {userName}, I didn't quite understand that."
                );

                TypingEffect.TypeText(
                    "[Bot]: Try asking me about one of these cybersecurity topics:"
                );

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" • phishing");
                Console.WriteLine(" • password safety");
                Console.WriteLine(" • safe browsing");
                Console.WriteLine(" • suspicious links");
                Console.WriteLine(" • cybersecurity");
                Console.ResetColor();
            }

            Console.ResetColor();
        }
    }
}