using SysopTrainer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Printing;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace SysopTrainer.ViewModels
{
    public class QuestionAnswerViewModel : INotifyPropertyChanged
    {
        private QuestionAnswerModel model = new QuestionAnswerModel();

        public string QuestionText
        {
            get => model.QuestionText;
            set
            {
                model.QuestionText = value;
                OnPropertyChanged(nameof(QuestionText));
            }
        }

        public string AnswerText
        {
            get => model.AnswerText;
            set
            {
                model.AnswerText = value;
                OnPropertyChanged(nameof(AnswerText));
            }
        }

        private ICommand updateQuestionText;
        private ICommand checkAnswer;
        private ICommand showAnswer;

        public ICommand UpdateQuestionTextCommand
        {
            get
            {
                if (updateQuestionText == null) updateQuestionText = new RelayCommand(
                    (object o) =>
                    {
                        model.UpdateQuestionTextBlock();
                        OnPropertyChanged(nameof(QuestionText));
                    },
                    (object o) =>
                    {
                        return model.QuestionText != null;
                    });
                return updateQuestionText;
            }
        }

        public ICommand CheckAnswerCommand
        {
            get
            {
                if (checkAnswer == null) checkAnswer = new RelayCommand(
                    (object o) =>
                    {
                        model.CheckAnswer();
                        OnPropertyChanged(nameof(AnswerText));
                    },
                    (object o) =>
                    {
                        return model.AnswerText != null;
                    });
                return checkAnswer;
            }
        }

        public ICommand ShowAnswerCommand
        {
            get
            {
                if (showAnswer == null) showAnswer = new RelayCommand(
                    (object o) =>
                    {
                        model.ShowAnswer();
                        OnPropertyChanged(nameof(AnswerText));
                    },
                    (object o) =>
                    {
                        return model.AnswerText != null;
                    });
                return showAnswer;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}