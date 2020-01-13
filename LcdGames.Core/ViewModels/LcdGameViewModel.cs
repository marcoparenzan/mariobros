using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LcdGames.ViewModels
{
    public abstract partial class LcdGameViewModel<TViewModel, TGameState>
        where TViewModel : LcdGameViewModel<TViewModel, TGameState>
        where TGameState : ILcdGameState<TViewModel, TGameState>
    {
        public LcdGameViewModel(int pins, ILcdGameServices services, bool history = false)
        {
            _pins = new LcdGamePinState[pins];
            _services = services;
            _isHistory = false;
            if (!history)
            {
                _history = (TViewModel) Activator.CreateInstance(typeof(TViewModel), services, true);
                _history._isHistory = true;
            }
        }

        private ILcdGameServices _services;

        public void Play(string name)
        {
            try
            {
                _services.Play(name);
            }
            catch (Exception ex)
            { 
            }
        }

        public void Execute(Action a)
        {
            try
            {
                _services.Execute(a);
            }
            catch (Exception ex)
            {
            }
        }

        private LcdGamePinState[] _pins;

        public void Off()
        {
            for (var i = 0; i < _pins.Length; i++)
            {
                Set(i, LcdGamePinState.Off);
            }
        }

        public void On()
        {
            for (var i = 0; i < _pins.Length; i++)
            {
                Set(i, LcdGamePinState.On);
            }
        }

        public LcdGamePinState Get(LcdGamePin pin)
        {
            return Get((int)pin);
        }

        public LcdGamePinState Get(int pin)
        {
            return _pins[pin];
        }

        public void Set(LcdGamePin pin, LcdGamePinState value)
        {
            Set((int)pin, value);
        }

        public void Set(int pin, LcdGamePinState value)
        {
            if (_isHistory) throw new InvalidOperationException("IsHistory");
            this._pins[pin] = value;
            Notify(pin);
        }
    }
}
