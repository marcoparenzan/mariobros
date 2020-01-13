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
        private TViewModel _history;
        private bool _isHistory;

        protected TViewModel Commit()
        {
            if (_isHistory) throw new InvalidOperationException("Commit");
            Array.Copy(_pins, _history._pins, _pins.Length);
            _history._score = this._score;
            _history._lostLives = this._lostLives;
            _history._isHistory = this._isHistory;
            return _history;
        }
    }
}
