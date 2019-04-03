using System;
using System.Windows.Input;

namespace _52North.Model.Commands
{
    public class DelegateCommand : ICommand
    {

        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public DelegateCommand(Action action, Func<bool> canExecute)
            : this(action)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

    }
}
