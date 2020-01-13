using LcdGames;
using MarioBros.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    public interface IMarioBrosState : ILcdGameState<MarioBrosViewModel, IMarioBrosState>
    {
        void GameA(MarioBrosViewModel viewModel);
        void GameB(MarioBrosViewModel viewModel);
        void Time(MarioBrosViewModel viewModel);
        void ACL(MarioBrosViewModel viewModel);
        void Alarm(MarioBrosViewModel viewModel);
        void Pause(MarioBrosViewModel viewModel);
        void Mute(MarioBrosViewModel viewModel);

        void MarioUp(MarioBrosViewModel viewModel);
        void MarioDown(MarioBrosViewModel viewModel);
        void LuigiUp(MarioBrosViewModel viewModel);
        void LuigiDown(MarioBrosViewModel viewModel);
    }
}
