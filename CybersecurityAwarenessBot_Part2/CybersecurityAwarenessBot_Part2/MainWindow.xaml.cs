using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows;
using MySql.Data.MySqlClient;
using CybersecurityAwarenessBot_Part2.Database;

namespace CybersecurityAwarenessBot_Part2
{
    public partial class MainWindow : Window
    {

        private string userName = "User";
        private Random random = new Random();
        private string lastTopic = "";
        private string favouriteTopic = "";
        private List<string> activityLog = new List<string>();

        private void TestDatabaseConnection()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MessageBox.Show(
                        "Database connected successfully!",
                        "Success",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        // Stores chatbot responses for cybersecurity topics
        private Dictionary<string, List<string>> chatbotResponses =
            new Dictionary<string, List<string>>
        {
    {
        "password",
new List<string>
{
@"A strong password is one of the best ways to protect your online accounts.

Create passwords with at least 12 characters that include uppercase letters, lowercase letters, numbers, and special symbols.

Avoid using names, birthdays, or common words because hackers can guess them easily.

Use a different password for every account and consider using a password manager to store them securely.

Extra Tip: Enable Two-Factor Authentication (2FA) for an extra layer of security."
}
},

    {
        "phishing",
new List<string>
{
@"Phishing is a cyberattack where criminals pretend to be trusted companies to steal personal information such as passwords or banking details.

Always check the sender's email address, avoid clicking suspicious links, and never provide sensitive information through email or text messages.

If a message creates urgency, threatens you, or promises prizes, treat it with caution.

Extra Tip: Visit the company's official website directly instead of clicking links."
}
    },

    {
        "privacy",
new List<string>
{
@"Protecting your online privacy means controlling who can access your personal information.

Avoid sharing sensitive details on social media, review your privacy settings regularly, and only use trusted websites.

Public Wi-Fi networks should be used carefully because attackers can intercept your data.

Extra Tip: Use a VPN when accessing sensitive information on public networks."
}
    },

    {
       "scam",
new List<string>
{
@"Online scams are designed to trick people into sending money or revealing personal information.

Be cautious of offers that seem too good to be true, unexpected prizes, or messages requesting urgent payments.

Always verify the identity of the sender before responding.

Extra Tip: Never send banking information through email or messaging apps."
}
    },

    {
       "safe browsing",
new List<string>
{
@"Safe browsing helps protect you from cyber threats while using the internet.

Keep your browser updated, avoid downloading files from unknown websites, and only install software from trusted sources.

Regularly update your operating system and antivirus software to stay protected.

Extra Tip: Look for HTTPS and the padlock icon before entering personal information on a website."
}
    },

    {
       "suspicious links",
new List<string>
{
@"Suspicious links may lead to fake websites or install malware on your device.

Before clicking, carefully inspect the URL for spelling mistakes or unusual website addresses.

Hover over links to preview where they lead, and only click links from trusted sources.

Extra Tip: When unsure, type the website address manually into your browser."
}
    },

    {
        "malware",
        new List<string>
        {
            "Malware is harmful software that can damage devices or steal information.",
            "Keep antivirus software updated to protect against malware.",
            "Avoid downloading unknown attachments or files."
        }
    }
        };

        // Plays greeting voice when application starts
        private void PlayGreeting()
        {
            try
            {
                string audioPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Media",
                    "GreetingVoice.wav");

                if (File.Exists(audioPath))
                {
                    SoundPlayer player =
                        new SoundPlayer(audioPath);

                    player.Play();
                }
                else
                {
                    MessageBox.Show(
                        "Greeting voice file not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error playing audio: " + ex.Message);
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            PlayGreeting();

            TestDatabaseConnection();

            ChatDisplay.AppendText(
    "Bot: Welcome to the Cybersecurity Awareness Assistant!\n");

            ChatDisplay.AppendText(
                "Bot: I'm here to help you stay safe online and learn about cybersecurity threats.\n");

            ChatDisplay.AppendText(
                "Bot: Before we begin, what is your name?\n\n");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = UserInputBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show(
                    "Please type a message first.",
                    "Input Error");
                return;
            }
             

            ChatDisplay.AppendText($"{userName}: {userInput}\n");

            // Ask for name first
            if (userName == "User")
            {
                userName = userInput;

                ChatDisplay.AppendText(
                    $"Bot: Nice to meet you, {userName}! " +
                    "I can help you learn about cybersecurity.\n");

                ChatDisplay.AppendText(
                    "Bot: Ask me about passwords, phishing, privacy, scams, or safe browsing.\n\n");
            }
            else
            {
                if (userInput.ToLower().Contains("tell me more") ||
                    userInput.ToLower().Contains("another tip") ||
                    userInput.ToLower().Contains("explain more"))
                {
                    if (!string.IsNullOrEmpty(lastTopic))
                    {
                        List<string> responses =
                            chatbotResponses[lastTopic];

                        string selectedResponse =
                            responses[random.Next(responses.Count)];

                        ChatDisplay.AppendText(
                            $"Bot: Here's more about {lastTopic}: {selectedResponse}\n\n");
                    }
                    else
                    {
                        ChatDisplay.AppendText(
                            "Bot: Please ask me about a cybersecurity topic first.\n\n");
                    }

                    UserInputBox.Clear();
                    return;
                }

                // MEMORY DETECTION 
                foreach (var topic in chatbotResponses.Keys)
                {
                    if (userInput.ToLower().Contains("i like") &&
                        userInput.ToLower().Contains(topic))
                    {
                        favouriteTopic = topic;

                        ChatDisplay.AppendText(
                            $"Bot: Great {userName}! I'll remember that you're interested in {topic}. It's an important cybersecurity topic.\n\n");

                        UserInputBox.Clear();
                        return;
                    }
                }

                if (userInput.ToLower().Contains("activity log") ||
                   userInput.ToLower().Contains("what have you done"))
                {
                    ChatDisplay.AppendText("Bot: Recent Activity\n\n");

                    foreach (string item in activityLog)
                    {
                        ChatDisplay.AppendText("• " + item + "\n");
                    }

                    ChatDisplay.AppendText("\n");

                    UserInputBox.Clear();
                    return;
                }

                // MEMORY RECALL 
                if (userInput.ToLower().Contains("remember") ||
                    userInput.ToLower().Contains("what do i like") ||
                    userInput.ToLower().Contains("my topic"))
                {
                    if (!string.IsNullOrEmpty(favouriteTopic))
                    {
                        ChatDisplay.AppendText(
                            $"Bot: {userName}, since you're interested in {favouriteTopic}, remember to stay informed and practise safe online habits.\n\n");
                    }
                    else
                    {
                        ChatDisplay.AppendText(
                            "Bot: You haven't told me your favourite cybersecurity topic yet.\n\n");
                    }

                    UserInputBox.Clear();
                    return;
                }
                if (userInput.ToLower().Contains("worried"))
                {
                    ChatDisplay.AppendText(
                        "Bot: It's understandable to feel worried about cybersecurity. Let me help you stay safe.\n");

                    ChatDisplay.AppendText(
                        "Bot: A good tip is to avoid clicking suspicious links and never share passwords online.\n\n");

                    UserInputBox.Clear();
                    return;
                }

                if (userInput.ToLower().Contains("frustrated"))
                {
                    ChatDisplay.AppendText(
                        "Bot: Cybersecurity can feel frustrating sometimes, but you're learning and improving.\n");

                    ChatDisplay.AppendText(
                        "Bot: Start with simple habits like stronger passwords and careful browsing.\n\n");

                    UserInputBox.Clear();
                    return;
                }

                if (userInput.ToLower().Contains("curious"))
                {
                    ChatDisplay.AppendText(
                        "Bot: I love curiosity! Learning about cybersecurity is one of the best ways to stay safe online.\n");

                    ChatDisplay.AppendText(
                        "Bot: Try asking about phishing, scams, passwords, or privacy.\n\n");

                    UserInputBox.Clear();
                    return;
                }


                string input = userInput.ToLower();

                if (input.Contains("password"))
                {
                    lastTopic = "password";
                    ChatDisplay.AppendText($"Bot: {chatbotResponses["password"][0]}\n\n");
                    UserInputBox.Clear();
                    return;
                }
                else if (input.Contains("phishing") ||
                         input.Contains("email") ||
                         input.Contains("fake email"))

                {
                    lastTopic = "phishing";
                    ChatDisplay.AppendText($"Bot: {chatbotResponses["phishing"][0]}\n\n");
                    UserInputBox.Clear();
                    return;
                }
                else if (input.Contains("privacy") ||
                         input.Contains("personal information"))
                {
                    lastTopic = "privacy";
                    ChatDisplay.AppendText($"Bot: {chatbotResponses["privacy"][0]}\n\n");
                    UserInputBox.Clear();
                    return;
                }
                else if (input.Contains("scam") ||
                         input.Contains("scams") ||
                         input.Contains("fraud"))
                {
                    lastTopic = "scam";
                    ChatDisplay.AppendText($"Bot: {chatbotResponses["scam"][0]}\n\n");
                    UserInputBox.Clear();
                    return;
                }
                else if (input.Contains("malware") ||
                         input.Contains("virus"))
                {
                    lastTopic = "malware";
                    ChatDisplay.AppendText($"Bot: {chatbotResponses["malware"][0]}\n\n");
                    UserInputBox.Clear();
                    return;
                }
                else if (input.Contains("link") ||
                         input.Contains("url"))
                {
                    lastTopic = "suspicious links";
                    ChatDisplay.AppendText($"Bot: {chatbotResponses["suspicious links"][0]}\n\n");
                    UserInputBox.Clear();
                    return;
                }
                else if (input.Contains("browse") ||
                     input.Contains("browsing") ||
                      input.Contains("safe browsing") ||
                       input.Contains("browser") ||
                       input.Contains("website"))
                {
                    lastTopic = "safe browsing";
                    ChatDisplay.AppendText($"Bot: {chatbotResponses["safe browsing"][0]}\n\n");
                    UserInputBox.Clear();
                    return;
                }
                else
                {
                    ChatDisplay.AppendText(
                        $"Bot: Sorry {userName}, I didn't understand that.\n");

                    ChatDisplay.AppendText(
                        "Bot: Try asking about passwords, phishing, malware, scams, privacy, suspicious links or safe browsing.\n\n");
                    UserInputBox.Clear();
                    return;
                }

                
            }
            UserInputBox.Clear();
            UserInputBox.Focus();

        }

        private void TaskButton_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.ShowDialog();
        }

        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {
            QuizWindow quizWindow = new QuizWindow();
            quizWindow.ShowDialog();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void UserInputBox_KeyDown(object sender,
            System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                SendButton.RaiseEvent(
                    new RoutedEventArgs(
                        System.Windows.Controls.Button.ClickEvent));
            }
        }
    }
}