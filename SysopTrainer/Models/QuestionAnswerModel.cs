using SysopTrainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SysopTrainer.Models
{
    public class QuestionAnswerModel
    {
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        private string CorrectAnswer { get; set; }

        public QuestionAnswerModel()
        {
            QuestionText = "Tutaj pojawi się pytanie";
            AnswerText = "Tutaj wprowadź swoją odpowiedź";
        }

        public void ShowAnswer()
        {
            AnswerText = Methods.GetCorrectAnswer();
        }

        public void UpdateQuestionTextBlock()
        {
            QuestionText = Methods.RandomizeQuestion();
            CorrectAnswer = Methods.GetCorrectAnswer();
            AnswerText = string.Empty;
        }

        public void CheckAnswer()
        {
            if (AnswerText == CorrectAnswer)
            {
                AnswerText += "\n Correct!";
            }
            else
            {
                AnswerText += "\n Incorrect!";
            }
        }
    }
}