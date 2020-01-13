
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
        public void AddLife()
        {
            if (_isHistory) throw new InvalidOperationException("AddLife");
            if (LostLives > 0)
                LostLives -= 1;
        }

        public void LooseLife()
        {
            if (_isHistory) throw new InvalidOperationException("LooseLife");
            LostLives += 1;
        }

        private int _lostLives;

        public int LostLives
        {
            get
            {
                return _lostLives;
            }

            set
            {
                if (_isHistory) throw new InvalidOperationException("LostLives");
                if (_lostLives != value)
                {
                    _lostLives = value;
                    Notify("LostLives");
                }
            }
        }
    }
}

