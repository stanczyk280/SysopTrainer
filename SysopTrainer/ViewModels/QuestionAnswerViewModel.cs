using SysopTrainer.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace SysopTrainer.ViewModels
{
    public class QuestionAnswerViewModel : INotifyPropertyChanged
    {
        private readonly QuestionAnswerModel model = new();

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
                updateQuestionText ??= new RelayCommand(
                    (object o) =>
                    {
                        model.UpdateQuestionTextBlock();
                        OnPropertyChanged(nameof(QuestionText));
                        OnPropertyChanged(nameof(AnswerText));
                    },
                    (object o) => model.QuestionText != null);
                return updateQuestionText;
            }
        }

        public ICommand CheckAnswerCommand
        {
            get
            {
                checkAnswer ??= new RelayCommand(
                    (object o) =>
                    {
                        model.CheckAnswer();
                        OnPropertyChanged(nameof(AnswerText));
                    },
                    (object o) => model.AnswerText != null);
                return checkAnswer;
            }
        }

        public ICommand ShowAnswerCommand
        {
            get
            {
                showAnswer ??= new RelayCommand(
                    (object o) =>
                    {
                        model.ShowAnswer();
                        OnPropertyChanged(nameof(AnswerText));
                    },
                    (object o) => model.AnswerText != null);
                return showAnswer;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}