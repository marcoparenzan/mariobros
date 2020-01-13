using LcdGames.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcdGames
{
    public interface ILcdGameState<TViewModel, TGameState>
        where TViewModel: LcdGameViewModel<TViewModel, TGameState>
        where TGameState: ILcdGameState<TViewModel, TGameState>
    {
        void Initialize(TViewModel viewModel, TGameState lastState);
        void Clock(TViewModel viewModel, TViewModel h);
    }
}
