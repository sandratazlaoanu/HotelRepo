using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Hotel.Model;

namespace Hotel.Commands
{
    public class RelayCommand : ICommand
    {
        private Action<object> commandTask;
        private Predicate<object> canExecuteTask;
        private List<User> list;
        private object v;

        public RelayCommand(Action<object> workToDo)
            : this(workToDo, DefaultCanExecute)
        {
            commandTask = workToDo;
        }

        public RelayCommand(Action<object> workToDo, Predicate<object> canExecute)
        {
            commandTask = workToDo;
            canExecuteTask = canExecute;
        }

        public RelayCommand(object v)
        {
            this.v = v;
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteTask != null && canExecuteTask(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            commandTask(parameter);
        }

        public static readonly ICommand CloseCommand =
        new RelayCommand(o => ((Window)o).Close());
    }
}
