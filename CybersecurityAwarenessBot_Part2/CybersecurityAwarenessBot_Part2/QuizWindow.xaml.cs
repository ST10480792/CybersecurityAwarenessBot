using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CybersecurityAwarenessBot_Part2.Models;

namespace CybersecurityAwarenessBot_Part2
{
    public partial class QuizWindow : Window
    {
        private List<QuizQuestion> questions = new List<QuizQuestion>();

        private int currentQuestion = 0;

        private int score = 0;
        public QuizWindow()
        {
            InitializeComponent();

            LoadQuestions();

            DisplayQuestion();
        }

        private void LoadQuestions()
        {
            questions.Add(new QuizQuestion
            {
                Question = "1. What is the strongest password?",
                Options = new List<string>
        {
            "12345678",
            "Password",
            "P@ssw0rd!2026",
            "abcdef"
        },
                CorrectAnswer = 2
            });

            questions.Add(new QuizQuestion
            {
                Question = "2. What is phishing?",
                Options = new List<string>
        {
            "A type of fish",
            "A fake message trying to steal information",
            "Installing antivirus",
            "Updating Windows"
        },
                CorrectAnswer = 1
            });

            questions.Add(new QuizQuestion
            {
                Question = "3. What does 2FA mean?",
                Options = new List<string>
        {
            "Two-Factor Authentication",
            "Two Free Accounts",
            "Two File Access",
            "Two Fast Applications"
        },
                CorrectAnswer = 0
            });

            questions.Add(new QuizQuestion
            {
                Question = "4. What should you do before clicking a link?",
                Options = new List<string>
        {
            "Click immediately",
            "Ignore it",
            "Check if it is trusted",
            "Share it"
        },
                CorrectAnswer = 2
            });

            questions.Add(new QuizQuestion
            {
                Question = "5. Which software helps protect your computer?",
                Options = new List<string>
        {
            "Calculator",
            "Paint",
            "Antivirus",
            "Notepad"
        },
                CorrectAnswer = 2
            });
        }

        private void DisplayQuestion()
        {
            QuestionText.Text = questions[currentQuestion].Question;

            OptionA.Content = questions[currentQuestion].Options[0];
            OptionB.Content = questions[currentQuestion].Options[1];
            OptionC.Content = questions[currentQuestion].Options[2];
            OptionD.Content = questions[currentQuestion].Options[3];

            OptionA.IsChecked = false;
            OptionB.IsChecked = false;
            OptionC.IsChecked = false;
            OptionD.IsChecked = false;
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedAnswer = -1;

            if (OptionA.IsChecked == true)
                selectedAnswer = 0;

            else if (OptionB.IsChecked == true)
                selectedAnswer = 1;

            else if (OptionC.IsChecked == true)
                selectedAnswer = 2;

            else if (OptionD.IsChecked == true)
                selectedAnswer = 3;

            if (selectedAnswer == -1)
            {
                MessageBox.Show("Please select an answer first.");
                return;
            }

            if (selectedAnswer == questions[currentQuestion].CorrectAnswer)
            {
                score++;
            }

            currentQuestion++;

            if (currentQuestion < questions.Count)
            {
                DisplayQuestion();
            }
            else
            {
                string message;

                if (score == 5)
                {
                    message = "🏆 Excellent!\n\nYou scored 5/5.\nYou have outstanding cybersecurity knowledge!";
                }
                else if (score >= 4)
                {
                    message = $"🎉 Great Job!\n\nYou scored {score}/5.\nYou have very good cybersecurity awareness.";
                }
                else if (score >= 3)
                {
                    message = $"👍 Good Effort!\n\nYou scored {score}/5.\nKeep practising to improve your cybersecurity skills.";
                }
                else
                {
                    message = $"📚 Keep Learning!\n\nYou scored {score}/5.\nReview cybersecurity topics and try again.";
                }

                MessageBox.Show(message, "Quiz Results");

                Close();
            }
        }
    }
}
