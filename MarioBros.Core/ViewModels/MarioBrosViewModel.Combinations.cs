using LcdGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MarioBros.ViewModels
{
    public partial class MarioBrosViewModel
    {

        public void M1On()
        {
            M0Off();
            M2Off();
            this.M1 = LcdGamePinState.On;
            if (this.M1R == LcdGamePinState.Off)
            {
                this.M1L = LcdGamePinState.Off;
                this.M1R = LcdGamePinState.On;
            }
            else
            {
                this.M1R = LcdGamePinState.Off;
                this.M1L = LcdGamePinState.On;
            }
        }

        public void M0Off()
        {
            this.M0 = LcdGamePinState.Off;
            this.M0L = LcdGamePinState.Off;
            this.M0R = LcdGamePinState.Off;
        }

        public void M2On()
        {
            M0Off();
            M1Off();
            this.M2 = LcdGamePinState.On;
            if (this.M2R == LcdGamePinState.Off)
            {
                this.M2L = LcdGamePinState.Off;
                this.M2R = LcdGamePinState.On;
            }
            else
            {
                this.M2R = LcdGamePinState.Off;
                this.M2L = LcdGamePinState.On;
            }
        }

        public void M1Off()
        {
            this.M1 = LcdGamePinState.Off;
            this.M1L = LcdGamePinState.Off;
            this.M1R = LcdGamePinState.Off;
        }
        public void M0On()
        {
            M2Off();
            M1Off();
            this.M0 = LcdGamePinState.On;
            if (this.M0R == LcdGamePinState.Off)
            {
                this.M0L = LcdGamePinState.Off;
                this.M0R = LcdGamePinState.On;
            }
            else
            {
                this.M0R = LcdGamePinState.Off;
                this.M0L = LcdGamePinState.On;
            }
        }

        public void M2Off()
        {
            this.M2 = LcdGamePinState.Off;
            this.M2L = LcdGamePinState.Off;
            this.M2R = LcdGamePinState.Off;
        }


        public void L1On()
        {
            L0Off();
            L2Off();
            this.L1 = LcdGamePinState.On;
            if (this.L1R == LcdGamePinState.Off)
            {
                this.L1L = LcdGamePinState.Off;
                this.L1R = LcdGamePinState.On;
            }
            else
            {
                this.L1R = LcdGamePinState.Off;
                this.L1L = LcdGamePinState.On;
            }
        }

        public void L0Off()
        {
            this.L0 = LcdGamePinState.Off;
            this.L0L = LcdGamePinState.Off;
            this.L0R = LcdGamePinState.Off;
        }

        public void L2On()
        {
            L0Off();
            L1Off();
            this.L2 = LcdGamePinState.On;
            if (this.L2R == LcdGamePinState.Off)
            {
                this.L2L = LcdGamePinState.Off;
                this.L2R = LcdGamePinState.On;
            }
            else
            {
                this.L2R = LcdGamePinState.Off;
                this.L2L = LcdGamePinState.On;
            }
        }

        public void L1Off()
        {
            this.L1 = LcdGamePinState.Off;
            this.L1L = LcdGamePinState.Off;
            this.L1R = LcdGamePinState.Off;
        }
        public void L0On()
        {
            L2Off();
            L1Off();
            this.L0 = LcdGamePinState.On;
            if (this.L0R == LcdGamePinState.Off)
            {
                this.L0L = LcdGamePinState.Off;
                this.L0R = LcdGamePinState.On;
            }
            else
            {
                this.L0R = LcdGamePinState.Off;
                this.L0L = LcdGamePinState.On;
            }
        }

        public void L2Off()
        {
            this.L2 = LcdGamePinState.Off;
            this.L2L = LcdGamePinState.Off;
            this.L2R = LcdGamePinState.Off;
        }
    }
}
