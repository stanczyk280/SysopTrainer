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

        public void UpdateQuestionTextBlock()
        {
            QuestionText = "rrr";
        }

        public void UpdateAnswerTextBox(string text)
        {
            AnswerText = text;
        }

        public void CheckAnswer()
        {
            UpdateAnswerTextBox(AnswerText);
            if (QuestionText == AnswerText)
            {
                AnswerText += "\nCorrect!";
            }
            else
            {
                AnswerText += "\nIncorrect!";
            }
        }
    }
}