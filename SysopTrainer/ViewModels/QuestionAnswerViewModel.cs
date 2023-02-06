using SysopTrainer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

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
        private ICommand updateAnswerText;
        private ICommand checkAnswer;

        public ICommand UpdateQuestionTextCommand
        {
            get
            {
                if (updateQuestionText == null)
                {
                    updateQuestionText = new RelayCommand
                        (
                        (object o) =>
                        {
                            model.UpdateQuestionTextBlock();
                            OnPropertyChanged(nameof(QuestionText));
                        },
                        (object o) =>
                        {
                            return model.QuestionText != null;
                        }
                        );
                }
                return updateQuestionText;
            }
        }

        public ICommand UpdateAnswerTextCommand
        {
            get
            {
                if (updateAnswerText == null)
                {
                    updateAnswerText = new RelayCommand
                        (
                        (object o) =>
                        {
                            model.UpdateAnswerTextBox(AnswerText);
                            OnPropertyChanged(nameof(AnswerText));
                        },
                        (object o) =>
                        {
                            return model.AnswerText != null;
                        }
                        );
                }
                return updateAnswerText;
            }
        }

        public ICommand CheckAnswerCommand
        {
            get
            {
                if (checkAnswer == null)
                {
                    checkAnswer = new RelayCommand
                        (
                        (object o) =>
                        {
                            model.CheckAnswer();
                            OnPropertyChanged(nameof(AnswerText));
                        },
                        (object o) =>
                        {
                            return model.AnswerText != null;
                        }
                        );
                }
                return checkAnswer;
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

    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));
            else this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}