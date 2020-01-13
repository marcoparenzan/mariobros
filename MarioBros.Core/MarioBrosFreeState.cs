using LcdGames;
using MarioBros.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    public class MarioBrosFreeState : MarioBrosRunState
    {
        protected override void OnInitialize(MarioBrosViewModel viewModel, IMarioBrosState lastState)
        {
            viewModel.Off();

            viewModel.M1On();
            viewModel.L0On();
            viewModel.T0 = LcdGamePinState.On;
        }


        protected override void OnClock2(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            var now = DateTime.Now;
            if (viewModel.Score == null)
            {
                viewModel.Score = now.ToString("h mm");
            }
            else if (viewModel.Score.Contains(":"))
            {
                viewModel.Score = now.ToString("h mm");
            }
            else
            {
                viewModel.Score = now.ToString("h:mm");
            }
            viewModel.AM = now.Hour < 12 ? LcdGamePinState.On : LcdGamePinState.Off;
            viewModel.PM = now.Hour >= 12 ? LcdGamePinState.On : LcdGamePinState.Off;
        }

        protected override void OnP1(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
            PushIfOn(vm, vm.M2, MarioDown);
            DelayedPushIfOn(vm, vm.M1, MarioDown);
        }

        protected override void OnP8(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
            PushIfOn(vm, vm.L2, LuigiDown);
            DelayedPushIfOn(vm, vm.L1, LuigiDown);
        }

        protected override void OnP16(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
            PushIfOn(vm, vm.M2, MarioDown);
            PushIfOn(vm, vm.M0, MarioUp);
        }

        protected override void OnP24(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
            PushIfOn(vm, vm.L2, LuigiDown);
            PushIfOn(vm, vm.L0, LuigiUp);
        }

        protected override void OnP32(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
            PushIfOn(vm, vm.M0, MarioUp);
            DelayedPushIfOn(vm, vm.M1, MarioUp);
        }

        protected override void OnP40(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
            PushIfOn(vm, vm.L0, LuigiUp);
            DelayedPushIfOn(vm, vm.L1, LuigiUp);
        }

        protected override void OnGameA(MarioBrosViewModel viewModel)
        {
            viewModel.GoTo<MarioBrosStartState>();
        }
    }
}
