using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LcdGames.ViewModels
{
    public partial class LcdGameViewModel<TViewModel, TGameState> : INotifyPropertyChanged
    {
        protected void Notify([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private PropertyChangedEventHandler PropertyChanged;

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => PropertyChanged += value;
            remove => PropertyChanged -= value;
        }

        protected void SetProperty<T>(ref T text, T value, [CallerMemberName] string propertyName = null)
        {
            text = value;
            Notify(propertyName);
        }

        protected abstract void Notify(int i);

        protected void Notify(LcdGamePin pin)
        {
            Notify((int) pin);
        }
    }
}
