using LcdGames;
using MarioBros.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    public abstract class MarioBrosErrorState : IMarioBrosState
    {
        private IMarioBrosState _lastState;

        protected bool FromFreeState
        {
            get
            {
                return _lastState is MarioBrosFreeState;
            }
        }

        protected IMarioBrosState LastState
        {
            get { return _lastState; }
        }

        void ILcdGameState<MarioBrosViewModel, IMarioBrosState>.Initialize(MarioBrosViewModel viewModel, IMarioBrosState lastState)
        {
            _lastState = lastState;
            OnInitialize();
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

    public abstract class MarioBrosAnimatedErrorState : MarioBrosErrorState
    {
        private enum Sequence
        {
            Start
            ,
            Blink
            ,
            Crash
            ,
            Reproach // rimprovero
            ,
            End
        }

        protected override void OnInitialize()
        {
            _sequence = Sequence.Start;
        }

        private Sequence _sequence;
        private int _count;
        private bool _alternate;

        protected void Play(MarioBrosViewModel viewModel, string sound)
        {
            if (FromFreeState) return;
            if (viewModel.MT == LcdGamePinState.On) return;
            viewModel.Play(sound);
        }

        protected override void OnClock(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {   
            switch (_sequence)
            {
                case Sequence.Start:
                    _sequence = Sequence.Blink;
                    _count = 4;
                    _alternate = true;
                    OnStart(viewModel, h);
                    break;
                case Sequence.Blink:
                    if (_count == 0)
                    {
                        OnBlink(_count, _alternate, viewModel, h);
                        _sequence = Sequence.Crash;
                        _count = 1;
                        _alternate = true;
                        Play(viewModel, "miss2");
                        OnCrash(_count, _alternate, viewModel, h);
                    }
                    else
                    {
                        OnBlink(_count, _alternate, viewModel, h);
                        _count--;
                        if (_alternate)
                        {
                            Play(viewModel, "miss1");
                        }
                        _alternate = !_alternate;
                    }
                    break;
                case Sequence.Crash:
                    if (_count == 0)
                    {
                        OnCrash(_count, _alternate, viewModel, h);
                        _sequence = Sequence.Reproach;
                        _count = 8;
                        _alternate = true;
                        Play(viewModel, "miss1");
                    }
                    else
                    {
                        //OnCrash(_count, _alternate, viewModel, h);
                        _count--;
                        //_alternate = !_alternate;
                    }
                    break;
                case Sequence.Reproach:
                    if (_count == 0)
                    {
                        OnReproach(_count, _alternate, viewModel, h);
                        _sequence = Sequence.End;
                    }
                    else
                    {
                        _count--;
                        if (_count % 2 == 0)
                        {
                            OnReproach(_count, _alternate, viewModel, h);
                            Play(viewModel, "miss1");
                            _alternate = !_alternate;
                        }
                    }
                    break;
                case Sequence.End:
                    viewModel.LooseLife();
                    OnEnd(viewModel, h);
                    if (viewModel.LostLives == 3)
                    {
                        viewModel.GoTo<MarioBrosLooseGameState>();
                        return;
                    }
                    else
                    {
                        viewModel.GoTo(LastState);
                    }
                    break;
            }
        }

        protected virtual void OnEnd(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }

        protected virtual void OnStart(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }

        protected virtual void OnBlink(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }

        protected virtual void OnCrash(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }

        protected virtual void OnReproach(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }
    }

    public abstract class MarioBrosMarioErrorState : MarioBrosAnimatedErrorState
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

        protected override void OnStart(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            base.OnStart(viewModel, h);
        }

        protected override void OnEnd(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            base.OnEnd(viewModel, h);
            RestoreMario(viewModel);
        }

        protected void RestoreMario(MarioBrosViewModel viewModel)
        {
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

        protected override void OnCrash(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.PC1 = LcdGamePinState.Off;
                SaveMario(viewModel, h);
            }
            else
            {
                viewModel.PC1 = alternate ? LcdGamePinState.On : LcdGamePinState.Off;
            }
        }

        protected void SaveMario(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            _M0 = h.M0; viewModel.M0 = LcdGamePinState.Off;
            _M0L = h.M0L; viewModel.M0L = LcdGamePinState.Off;
            _M0R = h.M0R; viewModel.M0R = LcdGamePinState.Off;
            _M1 = h.M1; viewModel.M1 = LcdGamePinState.Off;
            _M1L = h.M1L; viewModel.M1L = LcdGamePinState.Off;
            _M1R = h.M1R; viewModel.M1R = LcdGamePinState.Off;
            _M2 = h.M2; viewModel.M2 = LcdGamePinState.Off;
            _M2L = h.M2L; viewModel.M2L = LcdGamePinState.Off;
            _M2R = h.M2R; viewModel.M2R = LcdGamePinState.Off;
        }

        protected override void OnReproach(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.MEL = LcdGamePinState.Off;
                viewModel.MER = LcdGamePinState.Off;
            }
            else if (alternate)
            {
                viewModel.MEL = LcdGamePinState.On;
                viewModel.MER = LcdGamePinState.Off;
            }
            else
            {
                viewModel.MEL = LcdGamePinState.Off;
                viewModel.MER = LcdGamePinState.On;
            }
        }
    }

    public class MarioBrosP2ErrorState : MarioBrosMarioErrorState
    {
        protected override void OnStart(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            base.OnStart(viewModel, h);
            viewModel.P2 = LcdGamePinState.Off;
        }

        protected override void OnBlink(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.P2 = LcdGamePinState.Off;
            }
            else
            {
                viewModel.P2 = alternate ? LcdGamePinState.On : LcdGamePinState.Off;
            }
        }

        protected override void OnCrash(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.PC0 = LcdGamePinState.Off;
                SaveMario(viewModel, h);
            }
            else
            {
                viewModel.PC0 = alternate ? LcdGamePinState.On : LcdGamePinState.Off;
            }
        }
    }

    public class MarioBrosP17ErrorState : MarioBrosMarioErrorState
    {
        protected override void OnStart(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            base.OnStart(viewModel, h);
            viewModel.P17 = LcdGamePinState.Off;
        }

        protected override void OnBlink(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.P17 = LcdGamePinState.Off;
            }
            else
            {
                viewModel.P17 = alternate ? LcdGamePinState.On : LcdGamePinState.Off;
            }
        }
    }

    public class MarioBrosP33ErrorState : MarioBrosAnimatedErrorState
    {
        protected override void OnStart(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            base.OnStart(viewModel, h);
            viewModel.P33 = LcdGamePinState.Off;
        }

        protected override void OnBlink(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.P33 = LcdGamePinState.Off;
            }
            else
            {
                viewModel.P33 = alternate ? LcdGamePinState.On : LcdGamePinState.Off;
            }
        }
    }

    public abstract class MarioBrosLuigiErrorState : MarioBrosAnimatedErrorState
    {
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
        }

        protected override void OnEnd(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            base.OnEnd(viewModel, h);
            RestoreLuigi(viewModel);
        }

        private void RestoreLuigi(MarioBrosViewModel viewModel)
        {
            viewModel.L0 = _L0;
            viewModel.L0L = _L0L;
            viewModel.L0R = _L0R;
            viewModel.L1 = _L1;
            viewModel.L1L = _L1L;
            viewModel.L1R = _L1R;
            viewModel.L2L = _L2L;
            viewModel.L2R = _L2R;
        }

        protected override void OnCrash(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.PC2 = LcdGamePinState.Off;
                SaveLuigi(viewModel, h);
            }
            else
            {
                viewModel.PC2 = alternate ? LcdGamePinState.On : LcdGamePinState.Off;
            }
        }

        private void SaveLuigi(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            _L0 = h.L0; viewModel.L0 = LcdGamePinState.Off;
            _L0L = h.L0L; viewModel.L0L = LcdGamePinState.Off;
            _L0R = h.L0R; viewModel.L0R = LcdGamePinState.Off;
            _L1 = h.L1; viewModel.L1 = LcdGamePinState.Off;
            _L1L = h.L1L; viewModel.L1L = LcdGamePinState.Off;
            _L1R = h.L1R; viewModel.L1R = LcdGamePinState.Off;
            _L2L = h.L2L; viewModel.L2L = LcdGamePinState.Off;
            _L2R = h.L2R; viewModel.L2R = LcdGamePinState.Off;
        }

        protected override void OnReproach(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.LEL = LcdGamePinState.Off;
                viewModel.LER = LcdGamePinState.Off;
            }
            else if (alternate)
            {
                viewModel.LEL = LcdGamePinState.On;
                viewModel.LER = LcdGamePinState.Off;
            }
            else
            {
                viewModel.LEL = LcdGamePinState.Off;
                viewModel.LER = LcdGamePinState.On;
            }
        }
    }

    public class MarioBrosP9ErrorState : MarioBrosLuigiErrorState
    {
        protected override void OnStart(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            base.OnStart(viewModel, h);
            viewModel.P9 = LcdGamePinState.Off;
        }

        protected override void OnBlink(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.P9 = LcdGamePinState.Off;
            }
            else
            {
                viewModel.P9 = alternate ? LcdGamePinState.On : LcdGamePinState.Off;
            }
        }
    }

    public class MarioBrosP25ErrorState : MarioBrosLuigiErrorState
    {
        protected override void OnStart(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            base.OnStart(viewModel, h);
            viewModel.P25 = LcdGamePinState.Off;
        }

        protected override void OnBlink(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.P25 = LcdGamePinState.Off;
            }
            else
            {
                viewModel.P25 = alternate ? LcdGamePinState.On : LcdGamePinState.Off;
            }
        }
    }

    public class MarioBrosP41ErrorState : MarioBrosLuigiErrorState

    {
        protected override void OnStart(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            base.OnStart(viewModel, h);
            viewModel.P41 = LcdGamePinState.Off;
        }

        protected override void OnBlink(int count, bool alternate, MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (count == 0)
            {
                viewModel.P41 = LcdGamePinState.Off;
            }
            else
            {
                viewModel.P41 = alternate ? LcdGamePinState.On : LcdGamePinState.Off;
            }
        }
    }
}
