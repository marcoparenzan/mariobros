
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LcdGames.ViewModels
{
    public partial class LcdGameViewModel<TViewModel, TGameState>
    {
        private string _score;

        public string Score
        {
            get => _score;

            set
            {
                if (_isHistory) throw new InvalidOperationException("Score");
                if (_score != value)
                {
                    _score = value;
                    Notify("Score");
                }
            }
        }
    }
}

