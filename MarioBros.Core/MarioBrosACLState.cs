using LcdGames;
using MarioBros.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    public class MarioBrosACLState : IMarioBrosState
    {
        void ILcdGameState<MarioBrosViewModel, IMarioBrosState>.Initialize(MarioBrosViewModel viewModel, IMarioBrosState lastState)
        {
            viewModel.On();
        }

        void ILcdGameState<MarioBrosViewModel, IMarioBrosState>.Clock(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
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
            viewModel.GoTo<MarioBrosFreeState>();
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
