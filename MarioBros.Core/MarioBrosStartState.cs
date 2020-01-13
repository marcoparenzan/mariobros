using LcdGames;
using MarioBros.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    public class MarioBrosStartState : IMarioBrosState
    {
        private int _count;

        void ILcdGameState<MarioBrosViewModel, IMarioBrosState>.Initialize(MarioBrosViewModel viewModel, IMarioBrosState lastState)
        {
            viewModel.Off();

            viewModel.M1On();
            viewModel.L0On();
            viewModel.T0 = LcdGamePinState.On;

            viewModel.Score = 0.ToString();
            viewModel.LostLives = 0;

            _count = 2;
        }

        void ILcdGameState<MarioBrosViewModel, IMarioBrosState>.Clock(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (_count == 0)
            {
                viewModel.GoTo<MarioBrosPlayState>();
            }
            else
            {
                _count--;
            }
        }
        void IMarioBrosState.MarioUp(MarioBrosViewModel viewModel)
        {
           
        }

        void IMarioBrosState.MarioDown(MarioBrosViewModel viewModel)
        {
           
        }

        void IMarioBrosState.LuigiUp(MarioBrosViewModel viewModel)
        {
           
        }

        void IMarioBrosState.LuigiDown(MarioBrosViewModel viewModel)
        {
           
        }

        void IMarioBrosState.GameA(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.GameB(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.Time(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.ACL(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.Alarm(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.Pause(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.Mute(MarioBrosViewModel viewModel)
        {
        }
    }
}
