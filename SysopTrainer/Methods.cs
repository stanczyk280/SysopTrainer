using SysopTrainer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SysopTrainer
{
    public static class Methods
    {
        private static readonly Random getrandom = new Random();
        public static int N { get; set; }
        private static int oldN = 0;

        private static List<Question> incoming = new List<Question>();
        private static StreamReader r = new StreamReader("QuestionsAnswers.json"); // absolute path to be implemented for now use the bin path

        public static void LoadJson()
        {
            string json = r.ReadToEnd();
            incoming = JsonSerializer.Deserialize<List<Question>>(json);
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                var random = getrandom.Next(min, max);
                if (oldN == random)
                {
                    random = getrandom.Next(min, max);
                }
                return getrandom.Next(min, max);
            }
        }

        private static string NormalizeString(string s)
            => Regex.Replace(s, @"[\s,\n]+", "").ToLower();

        public static string RandomizeQuestion()
        {
            string question;
            if (incoming != null && incoming.Count > 0)
            {
                N = GetRandomNumber(1, incoming.Count);
                oldN = N;
                question = incoming[N].question_text;
            }
            else
            {
                question = "Empty json file";
            }
            return question;
        }

        public static string GetCorrectAnswer()
        {
            try
            {
                string answer;
                if (incoming != null && incoming.Count > 0)
                {
                    answer = incoming[N].answer_text;
                }
                else
                {
                    answer = "Empty json file";
                }
                return answer;
            }
            catch
            {
                throw new ArgumentNullException(nameof(N));
            }
        }
    }

    public record struct Question(
            int question_number,
            string question_text,
            string answer_text
            );
}