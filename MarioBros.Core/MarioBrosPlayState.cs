using LcdGames;
using MarioBros.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    public class MarioBrosPlayState : MarioBrosRunState
    {
        protected override void OnInitialize(MarioBrosViewModel viewModel, IMarioBrosState lastState)
        {
        }

        protected override void OnMoveBox(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            Play(viewModel, "movebox");
        }

        protected override void OnMarioUp(MarioBrosViewModel viewModel)
        {
            MarioUp(viewModel);
        }

        protected override void OnMarioDown(MarioBrosViewModel viewModel)
        {
            MarioDown(viewModel);
        }

        protected override void OnLuigiUp(MarioBrosViewModel viewModel)
        {
            LuigiUp(viewModel);
        }

        protected override void OnLuigiDown(MarioBrosViewModel viewModel)
        {
            LuigiDown(viewModel);
        }

        protected override void OnMoveChar(MarioBrosViewModel viewModel)
        {
            Play(viewModel, "movechar");
        }

        protected override void OnPause(MarioBrosViewModel viewModel)
        {
            viewModel.PS = viewModel.PS == LcdGamePinState.On ? LcdGamePinState.Off : LcdGamePinState.On;
        }

        protected override void OnMute(MarioBrosViewModel viewModel)
        {
            viewModel.MT = viewModel.MT == LcdGamePinState.On ? LcdGamePinState.Off : LcdGamePinState.On;
        }

        protected void Play(MarioBrosViewModel viewModel, string sound)
        {
            if (viewModel.MT == LcdGamePinState.On) return;
            viewModel.Play(sound);
        }

        protected override void OnTime(MarioBrosViewModel viewModel)
        {
            viewModel.GoTo<MarioBrosFreeState>();
        }
    }
}
