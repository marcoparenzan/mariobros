using LcdGames;
using LcdGames.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MarioBros.ViewModels
{
    public partial class MarioBrosViewModel : LcdGameViewModel<MarioBrosViewModel, IMarioBrosState>
    {
        public MarioBrosViewModel(ILcdGameServices services, bool history = false)
            : base(MarioBrosPin.Count, services, history)
        {
            // controls
            _marioUp = new LcdGameButton(arg =>
            {
                CurrentState.MarioUp(this);
            });
            _marioDown = new LcdGameButton(arg =>
            {
                CurrentState.MarioDown(this);
            });
            _luigiUp = new LcdGameButton(arg =>
            {
                CurrentState.LuigiUp(this);
            });
            _luigiDown = new LcdGameButton(arg =>
            {
                CurrentState.LuigiDown(this);
            });
            _gameA = new LcdGameButton(arg =>
            {
                CurrentState.GameA(this);
            });
            _gameB = new LcdGameButton(arg =>
            {
                CurrentState.GameB(this);
            });
            _time = new LcdGameButton(arg =>
            {
                CurrentState.Time(this);
            });
            _acl = new LcdGameButton(arg =>
            {
                CurrentState.ACL(this);
            });
            _alarm = new LcdGameButton(arg =>
            {
                CurrentState.Alarm(this);
            });
            _pause = new LcdGameButton(arg =>
            {
                CurrentState.Pause(this);
            });
            _mute = new LcdGameButton(arg =>
            {
                CurrentState.Mute(this);
            });

            this.Notify("MarioUp");
            this.Notify("MarioDown");
            this.Notify("LuigiUp");
            this.Notify("LuigiDown");

            GoTo<MarioBrosFreeState>();
        }

        private ICommand _marioUp;
        private ICommand _marioDown;
        private ICommand _luigiUp;
        private ICommand _luigiDown;
        private ICommand _gameA;
        private ICommand _gameB;
        private ICommand _time;
        private ICommand _acl;
        private ICommand _alarm;
        private ICommand _pause;
        private ICommand _mute;

        public void AddScore()
        {
            int score = 0;
            if (int.TryParse(Score, out score))
            {
                score++;
                Play("point");
                Score = score.ToString();
            }
        }

        public ICommand MarioUp
        {
            get
            {
                return _marioUp;
            }
        }

        public ICommand MarioDown
        {
            get
            {
                return _marioDown;
            }
        }

        public ICommand LuigiUp
        {
            get
            {
                return _luigiUp;
            }
        }

        public ICommand LuigiDown
        {
            get
            {
                return _luigiDown;
            }
        }

        public ICommand GameA
        {
            get
            {
                return _gameA;
            }
        }

        public ICommand GameB
        {
            get
            {
                return _gameB;
            }
        }

        public ICommand Time
        {
            get
            {
                return _time;
            }
        }

        public ICommand ACL
        {
            get
            {
                return _acl;
            }
        }

        public ICommand Alarm
        {
            get
            {
                return _alarm;
            }
        }

        public ICommand Pause
        {
            get
            {
                return _pause;
            }
        }

        public ICommand Mute
        {
            get
            {
                return _mute;
            }
        }

        protected override void Notify(int i)
        {
            Notify(MarioBrosPin.Names[i]);
        }

        public LcdGamePinState State(string name) => (LcdGamePinState) typeof(MarioBrosViewModel).GetProperty(name).GetValue(this);
    }
}
