using LcdGames;
using MarioBros.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    public abstract class MarioBrosRunState : IMarioBrosState
    {
        private Action<MarioBrosViewModel, MarioBrosViewModel>[] _line0;
        private Action<MarioBrosViewModel, MarioBrosViewModel>[] _line1;
        private Action<MarioBrosViewModel, MarioBrosViewModel>[] _line2;

        private int _clock0;
        private int _clock1;
        private int _clock2;

        private Random _random;
        private int _packOn; // packs on rolls
        private int _packWait; // 
        private int _packAt; // 
        private int _packMax; // 

        void ILcdGameState<MarioBrosViewModel, IMarioBrosState>.Initialize(MarioBrosViewModel viewModel, IMarioBrosState lastState)
        {
            OnInitialize(viewModel, lastState);

            _line0 = new Action<MarioBrosViewModel, MarioBrosViewModel>[MarioBrosPin.Count];
            _line1 = new Action<MarioBrosViewModel, MarioBrosViewModel>[MarioBrosPin.Count];
            _line2 = new Action<MarioBrosViewModel, MarioBrosViewModel>[MarioBrosPin.Count];
            _clock0 = 0;
            _clock1 = 0;
            _clock2 = 2;

            _random = new Random();
            _packMax = 3;
            _packAt = 1;

            _line0[MarioBrosPin.M0L] = (vm, h) =>
            {
                M0On(vm);
            };
            _line0[MarioBrosPin.L0L] = (vm, h) =>
            {
                L0On(vm);
            };
            _line0[MarioBrosPin.M1L] = (vm, h) =>
            {
                M1On(vm);
            };
            _line0[MarioBrosPin.L1L] = (vm, h) =>
            {
                L1On(vm);
            };
            _line0[MarioBrosPin.M2L] = (vm, h) =>
            {
                M2On(vm);
            };
            _line0[MarioBrosPin.L2L] = (vm, h) =>
            {
                L2On(vm);
            };

            _line0[MarioBrosPin.P2] = (vm, h) =>
            {
                if (h.M0 == LcdGamePinState.On)
                {
                    vm.P2 = LcdGamePinState.Off;
                    vm.P3 = LcdGamePinState.On;

                    M0On(vm);
                    vm.AddScore();
                }
                else
                    vm.GoTo<MarioBrosP2ErrorState>();
            };

            _line2[MarioBrosPin.P1] = (vm, h) =>
            {
                vm.P2 =  LcdGamePinState.On;
                vm.P1 =  LcdGamePinState.Off;
                OnP1(vm, h);
            }; _line2[MarioBrosPin.P0] = (vm, h) =>
            {
                vm.P1 =  LcdGamePinState.On;
                vm.P0 =  LcdGamePinState.Off;
                
            }; 
            
            _line1[MarioBrosPin.P5] = (vm, h) =>
            {
                vm.P5P6 = LcdGamePinState.On;
                vm.P5 =  LcdGamePinState.Off;

            }; _line1[MarioBrosPin.P5P6] = (vm, h) =>
            {
                vm.P6 = LcdGamePinState.On;
                vm.P5P6 = LcdGamePinState.Off;

            }; _line1[MarioBrosPin.P4] = (vm, h) =>
            {
                vm.P5 =  LcdGamePinState.On;
                vm.P4 =  LcdGamePinState.Off;
                
            }; _line1[MarioBrosPin.P3] = (vm, h) =>
            {
                vm.P4 =  LcdGamePinState.On;
                vm.P3 =  LcdGamePinState.Off;

            }; _line0[MarioBrosPin.P9] = (vm, h) =>
            {
                if (h.L0 == LcdGamePinState.On)
                {
                    vm.P9 = LcdGamePinState.Off;
                    vm.P10 = LcdGamePinState.On;

                    L0On(vm);
                    vm.AddScore();
                }
                else
                    vm.GoTo<MarioBrosP9ErrorState>();
            }; _line1[MarioBrosPin.P8] = (vm, h) =>
            {
                vm.P9 =  LcdGamePinState.On;
                vm.P8 =  LcdGamePinState.Off;
                OnP8(vm,h);
            }; _line1[MarioBrosPin.P7] = (vm, h) =>
            {
                vm.P8 =  LcdGamePinState.On;
                vm.P7 =  LcdGamePinState.Off;
                
            }; _line1[MarioBrosPin.P6] = (vm, h) =>
            {
                vm.P7 =  LcdGamePinState.On;
                vm.P6 =  LcdGamePinState.Off;
            }; 
            
            
            _line2[MarioBrosPin.P10] = (vm, h) =>
            {
                vm.P11 =  LcdGamePinState.On;
                vm.P10 =  LcdGamePinState.Off;

            }; _line2[MarioBrosPin.P11] = (vm, h) =>
            {
                vm.P12 =  LcdGamePinState.On;
                vm.P11 =  LcdGamePinState.Off;

            }; _line2[MarioBrosPin.P12] = (vm, h) =>
            {
                vm.P13 =  LcdGamePinState.On;
                vm.P12 =  LcdGamePinState.Off;

            }; _line2[MarioBrosPin.P13] = (vm, h) =>
            {
                vm.P13P14 = LcdGamePinState.On;
                vm.P13 =  LcdGamePinState.Off;

            }; _line2[MarioBrosPin.P13P14] = (vm, h) =>
            {
                vm.P14 = LcdGamePinState.On;
                vm.P13P14 = LcdGamePinState.Off;

            }; _line2[MarioBrosPin.P14] = (vm, h) =>
            {
                vm.P15 =  LcdGamePinState.On;
                vm.P14 =  LcdGamePinState.Off;

            }; _line2[MarioBrosPin.P15] = (vm, h) =>
            {
                vm.P16 =  LcdGamePinState.On;
                vm.P15 =  LcdGamePinState.Off;

            }; _line2[MarioBrosPin.P16] = (vm, h) =>
            {
                vm.P17 =  LcdGamePinState.On;
                vm.P16 =  LcdGamePinState.Off;
                OnP16(vm, h);
            }; _line0[MarioBrosPin.P17] = (vm, h) =>
            {
                if (h.M1 == LcdGamePinState.On)
                {
                    vm.P17 = LcdGamePinState.Off;
                    vm.P18 = LcdGamePinState.On;

                    M1On(vm);
                    vm.AddScore();
                }
                else
                    vm.GoTo<MarioBrosP17ErrorState>();
            };
            
            
            _line1[MarioBrosPin.P21] = (vm, h) =>
            {
                vm.P21P22 = LcdGamePinState.On;
                vm.P21 =  LcdGamePinState.Off;

            }; _line1[MarioBrosPin.P21P22] = (vm, h) =>
            {
                vm.P22 = LcdGamePinState.On;
                vm.P21P22 = LcdGamePinState.Off;

            }; _line1[MarioBrosPin.P20] = (vm, h) =>
            {
                vm.P21 =  LcdGamePinState.On;
                vm.P20 =  LcdGamePinState.Off;

            }; _line1[MarioBrosPin.P19] = (vm, h) =>
            {
                vm.P20 =  LcdGamePinState.On;
                vm.P19 =  LcdGamePinState.Off;
            }; _line1[MarioBrosPin.P18] = (vm, h) =>
            {
                vm.P19 =  LcdGamePinState.On;
                vm.P18 =  LcdGamePinState.Off;

            }; _line0[MarioBrosPin.P25] = (vm, h) =>
            {
                if (h.L1 == LcdGamePinState.On)
                {
                    vm.P25 = LcdGamePinState.Off;
                    vm.P26 = LcdGamePinState.On;

                    L1On(vm);
                    vm.AddScore();
                }
                else
                    vm.GoTo<MarioBrosP25ErrorState>();
            }; _line1[MarioBrosPin.P24] = (vm, h) =>
            {
                vm.P25 =  LcdGamePinState.On;
                vm.P24 =  LcdGamePinState.Off;
                OnP24(vm, h);
            }; _line1[MarioBrosPin.P23] = (vm, h) =>
            {
                vm.P24 =  LcdGamePinState.On;
                vm.P23 =  LcdGamePinState.Off;

            }; _line1[MarioBrosPin.P22] = (vm, h) =>
            {
                vm.P23 =  LcdGamePinState.On;
                vm.P22 =  LcdGamePinState.Off;
                
            };


            _line2[MarioBrosPin.P26] = (vm, h) =>
            {
                vm.P27 =  LcdGamePinState.On;
                vm.P26 =  LcdGamePinState.Off;
            }; _line2[MarioBrosPin.P27] = (vm, h) =>
            {
                vm.P28 =  LcdGamePinState.On;
                vm.P27 =  LcdGamePinState.Off;
                
            }; _line2[MarioBrosPin.P28] = (vm, h) =>
            {
                vm.P29 =  LcdGamePinState.On;
                vm.P28 =  LcdGamePinState.Off;
                
            }; _line2[MarioBrosPin.P29] = (vm, h) =>
            {
                vm.P29P30 = LcdGamePinState.On;
                vm.P29 =  LcdGamePinState.Off;

            }; _line2[MarioBrosPin.P29P30] = (vm, h) =>
            {
                vm.P30 = LcdGamePinState.On;
                vm.P29P30 = LcdGamePinState.Off;

            }; _line2[MarioBrosPin.P30] = (vm, h) =>
            {
                vm.P31 =  LcdGamePinState.On;
                vm.P30 =  LcdGamePinState.Off;
                
            }; _line2[MarioBrosPin.P31] = (vm, h) =>
            {
                vm.P32 =  LcdGamePinState.On;
                vm.P31 =  LcdGamePinState.Off;
                OnP32(vm, h);
            }; _line2[MarioBrosPin.P32] = (vm, h) =>
            {
                vm.P33 =  LcdGamePinState.On;
                vm.P32 =  LcdGamePinState.Off;

            }; _line0[MarioBrosPin.P33] = (vm, h) =>
            {
                if (h.M2 == LcdGamePinState.On)
                {
                    vm.P33 = LcdGamePinState.Off;
                    vm.P34 = LcdGamePinState.On;

                    M2On(vm);
                    vm.AddScore();
                }
                else
                    vm.GoTo<MarioBrosP33ErrorState>();
            }; 
            
            
            _line1[MarioBrosPin.P37] = (vm, h) =>
            {
                vm.P37P38 = LcdGamePinState.On;
                vm.P37 =  LcdGamePinState.Off;

            }; _line1[MarioBrosPin.P37P38] = (vm, h) =>
            {
                vm.P38 = LcdGamePinState.On;
                vm.P37P38 = LcdGamePinState.Off;

            }; _line1[MarioBrosPin.P36] = (vm, h) =>
            {
                vm.P37 =  LcdGamePinState.On;
                vm.P36 =  LcdGamePinState.Off;
                
            }; _line1[MarioBrosPin.P35] = (vm, h) =>
            {
                vm.P36 =  LcdGamePinState.On;
                vm.P35 =  LcdGamePinState.Off;
                
            }; _line1[MarioBrosPin.P34] = (vm, h) =>
            {
                vm.P35 =  LcdGamePinState.On;
                vm.P34 =  LcdGamePinState.Off;

            }; _line0[MarioBrosPin.P41] = (vm, h) =>
            {
                if (h.L2R == LcdGamePinState.On)
                {
                    vm.P41 = LcdGamePinState.Off;
                    if (h.PT0 == LcdGamePinState.Off) vm.PT8 = LcdGamePinState.On;
                    else if (h.PT1 == LcdGamePinState.Off) vm.PT9 = LcdGamePinState.On;
                    else if (h.PT2 == LcdGamePinState.Off) vm.PT8 = LcdGamePinState.On;
                    else if (h.PT3 == LcdGamePinState.Off) vm.PT9 = LcdGamePinState.On;
                    else if (h.PT4 == LcdGamePinState.Off) vm.PT8 = LcdGamePinState.On;
                    else if (h.PT5 == LcdGamePinState.Off) vm.PT9 = LcdGamePinState.On;
                    else if (h.PT6 == LcdGamePinState.Off) vm.PT8 = LcdGamePinState.On;
                    else if (h.PT7 == LcdGamePinState.Off) vm.PT9 = LcdGamePinState.On;

                    L2On(vm);
                }
                else
                    vm.GoTo<MarioBrosP41ErrorState>();
            }; _line1[MarioBrosPin.P40] = (vm, h) =>
            {
                vm.P41 =  LcdGamePinState.On;
                vm.P40 =  LcdGamePinState.Off;
                OnP40(vm, h);
            }; _line1[MarioBrosPin.P39] = (vm, h) =>
            {
                vm.P40 =  LcdGamePinState.On;
                vm.P39 =  LcdGamePinState.Off;
                
            }; _line1[MarioBrosPin.P38] = (vm, h) =>
            {
                vm.P39 =  LcdGamePinState.On;
                vm.P38 =  LcdGamePinState.Off;
                
            }; 

            _line0[MarioBrosPin.PT2] = (vm, h) =>
            {
                if (h.PT0 == LcdGamePinState.Off)
                {
                    vm.PT2 =  LcdGamePinState.Off;
                    vm.PT0 =  LcdGamePinState.On;
                    
                    vm.AddScore();
                }
            }; _line0[MarioBrosPin.PT4] = (vm, h) =>
            {
                if (h.PT2 == LcdGamePinState.Off)
                {
                    vm.PT4 =  LcdGamePinState.Off;
                    vm.PT2 =  LcdGamePinState.On;
                    
                    if (h.PT0 == LcdGamePinState.On)
                    {
                        vm.AddScore();
                    }
                }
            }; _line0[MarioBrosPin.PT6] = (vm, h) =>
            {
                if (h.PT4 == LcdGamePinState.Off)
                {
                    vm.PT6 = LcdGamePinState.Off;
                    vm.PT4 = LcdGamePinState.On;
                    
                    if (h.PT2 == LcdGamePinState.On)
                    {
                        vm.AddScore();
                    }
                }
                else
                {
                    vm.T1 = LcdGamePinState.On;
                }
            }; _line0[MarioBrosPin.PT8] = (vm, h) =>
            {
                if (h.PT6 == LcdGamePinState.Off)
                {
                    vm.PT8 =  LcdGamePinState.Off;
                    vm.PT6 =  LcdGamePinState.On;
                    
                    if (h.PT4 == LcdGamePinState.On)
                    {
                        vm.AddScore();
                    }
                }
            }; _line0[MarioBrosPin.PT3] = (vm, h) =>
            {
                if (h.PT1 == LcdGamePinState.Off)
                {
                    vm.PT3 =  LcdGamePinState.Off;
                    vm.PT1 =  LcdGamePinState.On;
                    
                    vm.AddScore();
                }
            }; _line0[MarioBrosPin.PT5] = (vm, h) =>
            {
                if (h.PT3 == LcdGamePinState.Off)
                {
                    vm.PT5 =  LcdGamePinState.Off;
                    vm.PT3 =  LcdGamePinState.On;
                    
                    if (h.PT1 == LcdGamePinState.On)
                    {
                        vm.AddScore();
                    }
                }
            }; _line0[MarioBrosPin.PT7] = (vm, h) =>
            {
                if (h.PT5 == LcdGamePinState.Off)
                {
                    vm.PT7 =  LcdGamePinState.Off;
                    vm.PT5 =  LcdGamePinState.On;
                    
                    if (h.PT3 == LcdGamePinState.On)
                    {
                        vm.AddScore();
                    }
                }
                else
                    vm.GoTo<MarioBrosTruckCommonCompleteState>();
            }; _line0[MarioBrosPin.PT9] = (vm, h) =>
            {
                if (h.PT7 == LcdGamePinState.Off)
                {
                    vm.PT9 =  LcdGamePinState.Off;
                    vm.PT7 =  LcdGamePinState.On;
                    
                    if (h.PT5 == LcdGamePinState.On)
                    {
                        vm.AddScore();
                    }
                }
            }; _line0[MarioBrosPin.T1] = (vm, h) =>
            {
                if (vm.T3 == LcdGamePinState.On)
                {
                    vm.T3 = LcdGamePinState.Off;
                }
                else if (vm.T2 == LcdGamePinState.On)
                {
                    vm.T2 = LcdGamePinState.Off;
                    vm.T3 = LcdGamePinState.On;
                }
                else
                {
                    vm.T2 = LcdGamePinState.On;
                }
            }; 
        }

        protected virtual void OnP40(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
        }

        protected virtual void OnP32(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
        }

        protected virtual void OnP24(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
        }

        protected virtual void OnP16(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
        }

        protected virtual void OnP8(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
        }

        protected virtual void OnP1(MarioBrosViewModel vm, MarioBrosViewModel h)
        {
        }

        protected virtual void OnInitialize(MarioBrosViewModel viewModel, IMarioBrosState lastState)
        {
        }

        void ILcdGameState<MarioBrosViewModel, IMarioBrosState>.Clock(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
            if (viewModel.PS == LcdGamePinState.On) return;

            var movebox = false;

            if (_clock0 == 0)
            {
                for (var i = 0; i < MarioBrosPin.Count; i++)
                {
                    if (_line0[i] == null) continue;
                    if (h.Get(i) == LcdGamePinState.On)
                    {
                        _line0[i](viewModel, h);
                    }
                }

                OnClock0(viewModel, h);
            }

            if (_clock1 == 0)
            {
                for (var i = 0; i < MarioBrosPin.Count; i++)
                {
                    if (_line1[i] == null) continue;
                    if (h.Get(i) == LcdGamePinState.On)
                    {
                        _line1[i](viewModel, h);
                        movebox = true;
                        _packOn++;
                    }
                }

                OnClock1(viewModel, h);
                if (_packOn >= _packMax)
                {
                    // do nothing...wait for pack pick
                    _packMax = _random.Next(2, 5);
                }
                else if (_packWait < _packAt)
                {
                    _packWait++;
                }
                else
                {
                    viewModel.P0 = LcdGamePinState.On;
                    _packAt = _random.Next(3, 5);
                    _packWait = 0;
                }
            }

            if (_clock2 == 0)
            {
                _packOn = 0;
                for (var i = 0; i < MarioBrosPin.Count; i++)
                {
                    if (_line2[i] == null) continue;
                    if (h.Get(i) == LcdGamePinState.On)
                    {
                        _line2[i](viewModel, h);
                        _packOn++;
                        movebox = true;
                    }
                }

                OnClock2(viewModel, h);
            }
        
            if (movebox)
            {
                OnMoveBox(viewModel, h);
            }

            _clock1 = (_clock1 + 1) % 4;
            _clock2 = (_clock2 + 1) % 4;
        }

        protected virtual void OnClock0(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }

        protected virtual void OnClock1(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }

        protected virtual void OnClock2(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }

        protected virtual void OnMoveBox(MarioBrosViewModel viewModel, MarioBrosViewModel h)
        {
        }

        void IMarioBrosState.MarioUp(MarioBrosViewModel viewModel)
        {
            OnMarioUp(viewModel);
        }

        protected virtual void OnMarioUp(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.MarioDown(MarioBrosViewModel viewModel)
        {
            OnMarioDown(viewModel);
        }

        protected virtual void OnMarioDown(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.LuigiUp(MarioBrosViewModel viewModel)
        {
            OnLuigiUp(viewModel);
        }

        protected virtual void OnLuigiUp(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.LuigiDown(MarioBrosViewModel viewModel)
        {
            OnLuigiDown(viewModel);
        }

        protected virtual void OnLuigiDown(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.GameA(MarioBrosViewModel viewModel)
        {
            OnGameA(viewModel);
        }

        protected virtual void OnGameA(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.GameB(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.Time(MarioBrosViewModel viewModel)
        {
            OnTime(viewModel);
        }

        protected virtual void OnTime(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.ACL(MarioBrosViewModel viewModel)
        {
            viewModel.GoTo<MarioBrosACLState>();
        }

        void IMarioBrosState.Alarm(MarioBrosViewModel viewModel)
        {
        }

        void IMarioBrosState.Pause(MarioBrosViewModel viewModel)
        {
            OnPause(viewModel);
        }

        void IMarioBrosState.Mute(MarioBrosViewModel viewModel)
        {
            OnMute(viewModel);
        }

        protected virtual void OnPause(MarioBrosViewModel viewModel)
        {
        }

        protected virtual void OnMute(MarioBrosViewModel viewModel)
        {
        }

        protected void M1On(MarioBrosViewModel viewModel)
        {
            M0Off(viewModel);
            M2Off(viewModel);
            viewModel.M1 = LcdGamePinState.On;
            if (viewModel.M1R == LcdGamePinState.Off)
            {
                viewModel.M1L = LcdGamePinState.Off;
                viewModel.M1R = LcdGamePinState.On;
            }
            else
            {
                viewModel.M1R = LcdGamePinState.Off;
                viewModel.M1L = LcdGamePinState.On;
            }
        }

        protected void M0Off(MarioBrosViewModel viewModel)
        {
            viewModel.M0 = LcdGamePinState.Off;
            viewModel.M0L = LcdGamePinState.Off;
            viewModel.M0R = LcdGamePinState.Off;
        }

        protected void M2On(MarioBrosViewModel viewModel)
        {
            M0Off(viewModel);
            M1Off(viewModel);
            viewModel.M2 = LcdGamePinState.On;
            if (viewModel.M2R == LcdGamePinState.Off)
            {
                viewModel.M2L = LcdGamePinState.Off;
                viewModel.M2R = LcdGamePinState.On;
            }
            else
            {
                viewModel.M2R = LcdGamePinState.Off;
                viewModel.M2L = LcdGamePinState.On;
            }
        }

        protected void M1Off(MarioBrosViewModel viewModel)
        {
            viewModel.M1 = LcdGamePinState.Off;
            viewModel.M1L = LcdGamePinState.Off;
            viewModel.M1R = LcdGamePinState.Off;
        }
        protected void M0On(MarioBrosViewModel viewModel)
        {
            M2Off(viewModel);
            M1Off(viewModel);
            viewModel.M0 = LcdGamePinState.On;
            if (viewModel.M0R == LcdGamePinState.Off)
            {
                viewModel.M0L = LcdGamePinState.Off;
                viewModel.M0R = LcdGamePinState.On;
            }
            else
            {
                viewModel.M0R = LcdGamePinState.Off;
                viewModel.M0L = LcdGamePinState.On;
            }
        }

        protected void M2Off(MarioBrosViewModel viewModel)
        {
            viewModel.M2 = LcdGamePinState.Off;
            viewModel.M2L = LcdGamePinState.Off;
            viewModel.M2R = LcdGamePinState.Off;
        }


        protected void L1On(MarioBrosViewModel viewModel)
        {
            L0Off(viewModel);
            L2Off(viewModel);
            viewModel.L1 = LcdGamePinState.On;
            if (viewModel.L1R == LcdGamePinState.Off)
            {
                viewModel.L1L = LcdGamePinState.Off;
                viewModel.L1R = LcdGamePinState.On;
            }
            else
            {
                viewModel.L1R = LcdGamePinState.Off;
                viewModel.L1L = LcdGamePinState.On;
            }
        }

        protected void L0Off(MarioBrosViewModel viewModel)
        {
            viewModel.L0 = LcdGamePinState.Off;
            viewModel.L0L = LcdGamePinState.Off;
            viewModel.L0R = LcdGamePinState.Off;
        }

        protected void L2On(MarioBrosViewModel viewModel)
        {
            L0Off(viewModel);
            L1Off(viewModel);
            viewModel.L2 = LcdGamePinState.On;
            if (viewModel.L2R == LcdGamePinState.Off)
            {
                viewModel.L2L = LcdGamePinState.Off;
                viewModel.L2R = LcdGamePinState.On;
            }
            else
            {
                viewModel.L2R = LcdGamePinState.Off;
                viewModel.L2L = LcdGamePinState.On;
            }
        }

        protected void L1Off(MarioBrosViewModel viewModel)
        {
            viewModel.L1 = LcdGamePinState.Off;
            viewModel.L1L = LcdGamePinState.Off;
            viewModel.L1R = LcdGamePinState.Off;
        }
        protected void L0On(MarioBrosViewModel viewModel)
        {
            L2Off(viewModel);
            L1Off(viewModel);
            viewModel.L0 = LcdGamePinState.On;
            if (viewModel.L0R == LcdGamePinState.Off)
            {
                viewModel.L0L = LcdGamePinState.Off;
                viewModel.L0R = LcdGamePinState.On;
            }
            else
            {
                viewModel.L0R = LcdGamePinState.Off;
                viewModel.L0L = LcdGamePinState.On;
            }
        }

        protected void L2Off(MarioBrosViewModel viewModel)
        {
            viewModel.L2 = LcdGamePinState.Off;
            viewModel.L2L = LcdGamePinState.Off;
            viewModel.L2R = LcdGamePinState.Off;
        }

        protected void MarioUp(MarioBrosViewModel viewModel)
        {
            if (viewModel.M2 == LcdGamePinState.On)
            {
            }
            else if (viewModel.M1 == LcdGamePinState.On)
            {
                M2On(viewModel);
                OnMoveChar(viewModel);
            }
            else if (viewModel.M0 == LcdGamePinState.On)
            {
                M1On(viewModel);
                OnMoveChar(viewModel);
            }
        }

        protected void MarioDown(MarioBrosViewModel viewModel)
        {
            if (viewModel.M2 == LcdGamePinState.On)
            {
                M1On(viewModel);
                OnMoveChar(viewModel);
            }
            else if (viewModel.M1 == LcdGamePinState.On)
            {
                M0On(viewModel);
                OnMoveChar(viewModel);
            }
            else if (viewModel.M0 == LcdGamePinState.On)
            {
            }
        }
        protected void LuigiUp(MarioBrosViewModel viewModel)
        {
            if (viewModel.L2 == LcdGamePinState.On)
            {
            }
            else if (viewModel.L1 == LcdGamePinState.On)
            {
                L2On(viewModel);
                OnMoveChar(viewModel);
            }
            else if (viewModel.L0 == LcdGamePinState.On)
            {
                L1On(viewModel);
                OnMoveChar(viewModel);
            }
        }

        protected void LuigiDown(MarioBrosViewModel viewModel)
        {
            if (viewModel.L2 == LcdGamePinState.On)
            {
                L1On(viewModel);
                OnMoveChar(viewModel);
            }
            else if (viewModel.L1 == LcdGamePinState.On)
            {
                L0On(viewModel);
                OnMoveChar(viewModel);
            }
            else if (viewModel.L0 == LcdGamePinState.On)
            {
            }
        }

        protected virtual void OnMoveChar(MarioBrosViewModel viewModel)
        {
        }

        protected void Delay(Action<Task> a, int milliseconds = 100)
        {
            Task.Delay(milliseconds).ContinueWith(a);
        }

        protected void PushIfOn(MarioBrosViewModel viewModel, LcdGamePinState state, Action<MarioBrosViewModel> a)
        {
            if (state == LcdGamePinState.On)
            {
                a(viewModel);
            }
        }

        protected void DelayedPushIfOn(MarioBrosViewModel viewModel, LcdGamePinState state, Action<MarioBrosViewModel> a, int milliseconds = 100)
        {
            Task.Delay(milliseconds).ContinueWith(t => PushIfOn(viewModel, state, a));
        }
    }
}
