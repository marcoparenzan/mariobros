using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcdGames
{
    public interface ILcdGameServices
    {
        void Play(string name);
        void Execute(Action action);
    }
}
