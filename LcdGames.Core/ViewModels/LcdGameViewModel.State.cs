using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LcdGames.ViewModels
{
    public partial class LcdGameViewModel<TViewModel, TGameState>
    {
        private TGameState _currentState;

        protected TGameState CurrentState
        {
            get { return _currentState; }
        }

        public void Clock()
        {
            if (_isHistory) throw new InvalidOperationException("Clock");
            var h = this.Commit();
            CurrentState.Clock((TViewModel)this, h);
        }
    
        public TGameState GoTo<TState>()
            where TState : TGameState
        {
            if (_isHistory) throw new InvalidOperationException("GoTo");
            var state = (TGameState)Activator.CreateInstance(typeof(TState));
            state.Initialize((TViewModel)this, _currentState);
            _currentState = state;
            return _currentState;
        }

        public TGameState GoTo(TGameState state)
        {
            if (_isHistory) throw new InvalidOperationException("GoTo");
            _currentState = state;
            return _currentState;
        }

    }
}
