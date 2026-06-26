using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAwarenessBot_Part2.Models
{
    public class QuizQuestion
    {
        public string Question { get; set; }

        public List<string> Options { get; set; }

        public int CorrectAnswer { get; set; }
    }
}