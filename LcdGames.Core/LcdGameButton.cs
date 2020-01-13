using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LcdGames
{
    public class LcdGameButton: ICommand
    {
        private Action<object> _handler;

        public LcdGameButton(Action<object> handler)
        {
            _handler = handler;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add {  }
            remove {  }
        }

        void ICommand.Execute(object parameter)
        {
            _handler(parameter);
        }
    }
}
