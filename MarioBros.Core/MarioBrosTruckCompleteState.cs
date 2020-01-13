using LcdGames;
using MarioBros.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    public abstract class MarioBrosTruckCompleteState : IMarioBrosState
    {
        private IMarioBrosState _lastState;

        protected IMarioBrosState LastState
        {
            get { return _lastState; }
        }

        void ILcdGameState<MarioBrosViewModel, IMarioBrosState>.Initialize(MarioBrosViewModel viewModel, IMarioBrosState lastState)
        {
            _lastState = lastState;
            OnInitialize();

            viewModel.P0 = LcdGamePinState.Off;
            viewModel.P1 = LcdGamePinState.Off;
            viewModel.P2 = LcdGamePinState.Off;
            viewModel.P3 = LcdGamePinState.Off;
            viewModel.P4 = LcdGamePinState.Off;
            viewModel.P5 = LcdGamePinState.Off;
            viewModel.P6 = LcdGamePinState.Off;
            viewModel.P7 = LcdGamePinState.Off;
            viewModel.P8 = LcdGamePinState.Off;
            viewModel.P9 = LcdGamePinState.Off;
            viewModel.P10 = LcdGamePinState.Off;
            viewModel.P11 = LcdGamePinState.Off;
            viewModel.P12 = LcdGamePinState.Off;
            viewModel.P13 = LcdGamePinState.Off;
            viewModel.P14 = LcdGamePinState.Off;
            viewModel.P15 = LcdGamePinState.Off;
            viewModel.P16 = LcdGamePinState.Off;
            viewModel.P17 = LcdGamePinState.Off;
            viewModel.P18 = LcdGamePinState.Off;
            viewModel.P19 = LcdGamePinState.Off;
            viewModel.P20 = LcdGamePinState.Off;
            viewModel.P21 = LcdGamePinState.Off;
            viewModel.P22 = LcdGamePinState.Off;
            viewModel.P23 = LcdGamePinState.Off;
            viewModel.P24 = LcdGamePinState.Off;
            viewModel.P25 = LcdGamePinState.Off;
            viewModel.P26 = LcdGamePinState.Off;
            viewModel.P27 = LcdGamePinState.Off;
            viewModel.P28 = LcdGamePinState.Off;
            viewModel.P29 = LcdGamePinState.Off;
            viewModel.P30 = LcdGamePinState.Off;
            viewModel.P31 = LcdGamePinState.Off;
            viewModel.P32 = LcdGamePinState.Off;
            viewModel.P33 = LcdGamePinState.Off;
            viewModel.P34 = LcdGamePinState.Off;
            viewModel.P35 = LcdGamePinState.Off;
            viewModel.P36 = LcdGamePinState.Off;
            viewModel.P37 = LcdGamePinState.Off;
            viewModel.P38 = LcdGamePinState.Off;
            viewModel.P39 = LcdGamePinState.Off;
            viewModel.P40 = LcdGamePinState.Off;
            viewModel.P41 = LcdGamePinState.Off;
        }

        protected virtual void OnInitialize()
        {
        }

        void ILcdGameState<MarioBrosViewModel, IMarioBrosState>.Clock(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            OnClock(viewModel, h);
        }

        protected virtual void OnClock(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            viewModel.GoTo(LastState);
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

    public abstract class MarioBrosAnimatedTruckCompleteState : MarioBrosTruckCompleteState
    {
        private enum Sequence
        {
            Start
            ,
            Points
            ,
            RunAway
            ,
            Rest // riposo
            ,
            End
        }

        protected override void OnInitialize()
        {
            _sequence = Sequence.Start;
            _multiplier = 4;
        }

        private Sequence _sequence;
        private int _count;
        private bool _alternate;
        private int _clock0;
        private int _multiplier;

        protected override void OnClock(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (_clock0 == 0)
            {

                switch (_sequence)
                {
                    case Sequence.Start:
                        OnStart(viewModel, h);
                        _sequence = Sequence.Points;
                        _count = 8;
                        _multiplier = 1;
                        _alternate = true;
                        break;
                    case Sequence.Points:
                        if (_count == 0)
                        {
                            OnPoints(_count, _alternate, viewModel, h);
                            _sequence = Sequence.RunAway;
                            _count = 4;
                            _multiplier = 4;
                            _alternate = true;
                        }
                        else
                        {
                            OnPoints(_count, _alternate, viewModel, h);
                            viewModel.AddScore();
                            _count--;
                            _alternate = !_alternate;
                        }
                        break;
                    case Sequence.RunAway:
                        if (_count == 0)
                        {
                            OnRunAway(_count, _alternate, viewModel, h);
                            _sequence = Sequence.Rest;
                            _count = 6;
                            _alternate = true;
                        }
                        else
                        {
                            OnRunAway(_count, _alternate, viewModel, h);
                            _count--;
                            _alternate = !_alternate;
                        }
                        break;
                    case Sequence.Rest:
                        if (_count == 0)
                        {
                            OnRest(_count, _alternate, viewModel, h);
                            _sequence = Sequence.End;
                        }
                        else
                        {
                            OnRest(_count, _alternate, viewModel, h);
                            _count--;
                            _alternate = !_alternate;
                        }
                        break;
                    case Sequence.End:
                        OnEnd(viewModel, h);
                        LastState.Initialize(viewModel, this);
                        viewModel.GoTo(LastState);
                        break;
                }
            }

            _clock0 = (_clock0 + 1) % _multiplier;
        }
        protected virtual void OnEnd(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            viewModel.L0On();
            viewModel.M1On();
            viewModel.T0 = LcdGamePinState.On;
        }

        protected virtual void OnStart(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }

        protected virtual void OnPoints(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }

        protected virtual void OnRunAway(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }

        protected virtual void OnRest(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }
    }

    public class MarioBrosTruckCommonCompleteState : MarioBrosAnimatedTruckCompleteState
    {
        private LcdGamePinState _M0;
        private LcdGamePinState _M0L;
        private LcdGamePinState _M0R;
        private LcdGamePinState _M1;
        private LcdGamePinState _M1L;
        private LcdGamePinState _M1R;
        private LcdGamePinState _M2;
        private LcdGamePinState _M2L;
        private LcdGamePinState _M2R;
        private LcdGamePinState _L0;
        private LcdGamePinState _L0L;
        private LcdGamePinState _L0R;
        private LcdGamePinState _L1;
        private LcdGamePinState _L1L;
        private LcdGamePinState _L1R;
        private LcdGamePinState _L2L;
        private LcdGamePinState _L2R;

        protected override void OnStart(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            base.OnStart(viewModel, h);
            
            _L0 = h.L0; viewModel.L0 = LcdGamePinState.Off;
            _L0L = h.L0L; viewModel.L0L = LcdGamePinState.Off;
            _L0R = h.L0R; viewModel.L0R = LcdGamePinState.Off;
            _L1 = h.L1; viewModel.L1 = LcdGamePinState.Off;
            _L1L = h.L1L; viewModel.L1L = LcdGamePinState.Off;
            _L1R = h.L1R; viewModel.L1R = LcdGamePinState.Off;
            _L2L = h.L2L; viewModel.L2L = LcdGamePinState.Off;
            _L2R = h.L2R; viewModel.L2R = LcdGamePinState.Off;

            _M0 = h.M0; viewModel.M0 = LcdGamePinState.Off;
            _M0L = h.M0L; viewModel.M0L = LcdGamePinState.Off;
            _M0R = h.M0R; viewModel.M0R = LcdGamePinState.Off;
            _M1 = h.M1; viewModel.M1 = LcdGamePinState.Off;
            _M1L = h.M1L; viewModel.M1L = LcdGamePinState.Off;
            _M1R = h.M1R; viewModel.M1R = LcdGamePinState.Off;
            _M2 = h.M2; viewModel.M2 = LcdGamePinState.Off;
            _M2L = h.M2L; viewModel.M2L = LcdGamePinState.Off;
            _M2R = h.M2R; viewModel.M2R = LcdGamePinState.Off;
         
            viewModel.T4 = LcdGamePinState.On;
            viewModel.T5 = LcdGamePinState.On;
        }

        protected override void OnEnd(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            base.OnEnd(viewModel, h);
      
            viewModel.L0 = _L0;
            viewModel.L0L = _L0L;
            viewModel.L0R = _L0R;
            viewModel.L1 = _L1;
            viewModel.L1L = _L1L;
            viewModel.L1R = _L1R;
            viewModel.L2L = _L2L;
            viewModel.L2R = _L2R;

            viewModel.M0 = _M0;
            viewModel.M0L = _M0L;
            viewModel.M0R = _M0R;
            viewModel.M1 = _M1;
            viewModel.M1L = _M1L;
            viewModel.M1R = _M1R;
            viewModel.M2 = _M2;
            viewModel.M2L = _M2L;
            viewModel.M2R = _M2R;
        }

        protected override void OnPoints(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            viewModel.T1 = LcdGamePinState.Off;
        }


        protected override void OnRunAway(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            switch (count)
            {
                case 4:
                    break;
                case 3:
                    viewModel.T0 = LcdGamePinState.Off;

                    viewModel.PT0 = LcdGamePinState.Off;
                    viewModel.PT1 = LcdGamePinState.Off;
                    viewModel.PT2 = LcdGamePinState.Off;
                    viewModel.PT3 = LcdGamePinState.Off;
                    viewModel.PT4 = LcdGamePinState.Off;
                    viewModel.PT5 = LcdGamePinState.Off;
                    viewModel.PT6 = LcdGamePinState.Off;
                    viewModel.PT7 = LcdGamePinState.Off;
                    break;
                case 2:
                    viewModel.T2 = LcdGamePinState.Off;
                    viewModel.T3 = LcdGamePinState.Off;
                    break;
                case 1:
                    viewModel.T4 = LcdGamePinState.Off;
                    break;
                case 0:
                    viewModel.T5 = LcdGamePinState.Off;
                    break;
            }
        }

        protected override void OnRest(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.MFL = LcdGamePinState.Off;
                viewModel.MFR = LcdGamePinState.Off;
                viewModel.LFL = LcdGamePinState.Off;
                viewModel.LFR = LcdGamePinState.Off;
            }
            else
            {
                viewModel.MFR = alternate ? LcdGamePinState.On : LcdGamePinState.Off;
                viewModel.MFL = !alternate ? LcdGamePinState.On : LcdGamePinState.Off;
                viewModel.LFR = alternate ? LcdGamePinState.On : LcdGamePinState.Off;
                viewModel.LFL = !alternate ? LcdGamePinState.On : LcdGamePinState.Off;
            }
        }
    }
}
