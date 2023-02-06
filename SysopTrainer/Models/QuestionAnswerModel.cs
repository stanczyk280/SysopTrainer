using System;
using System.Collections.Generic;
using System.Linq;
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

        public QuestionAnswerModel()
        {
            QuestionText = "Tutaj pojawi się pytanie";
            AnswerText = "Tutaj wprowadź swoją odpowiedź";
        }

        public void ShowAnswer(string answer)
        {
            AnswerText = answer;
        }

        public void UpdateQuestionTextBlock(string question)
        {
            QuestionText = question;
        }

        public void CheckAnswer()
        {
            if (AnswerText == "answer")
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