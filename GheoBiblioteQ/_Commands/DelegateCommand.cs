using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GheoBiblioteQ._Commands
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged 
        {
            add 
            {
                CommandManager.RequerySuggested +=value;
            }
            remove 
            { 
                CommandManager.RequerySuggested -=value; 
            }
        }

        private Action<object> execute;
        private Predicate<object> canExecute;

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute(parameter as string);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter as string);
        }
    }
}
