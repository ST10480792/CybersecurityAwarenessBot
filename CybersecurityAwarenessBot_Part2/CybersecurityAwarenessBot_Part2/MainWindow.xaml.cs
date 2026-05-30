using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows;

namespace CybersecurityAwarenessBot_Part2
{
    public partial class MainWindow : Window
    {

        private string userName = "User";
        private Random random = new Random();
        private string lastTopic = "";
        private string favouriteTopic = "";

        // Stores chatbot responses for cybersecurity topics
        private Dictionary<string, List<string>> chatbotResponses =
            new Dictionary<string, List<string>>
        {
    {
        "password",
        new List<string>
        {
            "Use strong passwords with uppercase, lowercase, symbols, and numbers.",
            "Avoid using birthdays or names in passwords.",
            "Use a different password for every important account."
        }
    },

    {
        "phishing",
        new List<string>
        {
            "Be careful of emails asking for personal information.",
            "Check links carefully before clicking them.",
            "Scammers often pretend to be trusted companies."
        }
    },

    {
        "privacy",
        new List<string>
        {
            "Review your privacy settings regularly.",
            "Avoid sharing personal information publicly online.",
            "Protect your accounts using strong passwords and privacy settings."
        }
    },

    {
        "scam",
        new List<string>
        {
            "Be cautious of messages promising free money or prizes.",
            "Scammers often create urgency to pressure victims.",
            "Never share personal details with unknown people online."
        }
    },

    {
        "safe browsing",
        new List<string>
        {
            "Always check that websites use HTTPS before entering personal details.",
            "Avoid downloading files from unknown websites.",
            "Be cautious when clicking links online."
        }
    },

    {
        "suspicious links",
        new List<string>
        {
            "Hover over a link before clicking to inspect where it leads.",
            "Avoid clicking links from unknown senders.",
            "If a message feels urgent or suspicious, verify it first."
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

                bool foundKeyword = false;

                foreach (var topic in chatbotResponses.Keys)
                {
                    if (userInput.ToLower().Contains(topic))
                    {
                        foundKeyword = true;
                        lastTopic = topic;

                        List<string> responses =
                            chatbotResponses[topic];

                        string selectedResponse =
                            responses[random.Next(responses.Count)];

                        ChatDisplay.AppendText(
                            $"Bot: {selectedResponse}\n\n");

                        break;
                    }
                }

                if (!foundKeyword)
                {
                    ChatDisplay.AppendText(
                        $"Bot: Sorry {userName}, I didn't fully understand that.\n");

                    ChatDisplay.AppendText(
                        "Bot: You can ask me about passwords, phishing, scams, privacy, malware, suspicious links, or safe browsing.\n\n");
                }
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