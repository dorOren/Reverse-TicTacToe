using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    static class Program
    {
        public static void Main()
        {
            GameManager game = new GameManager();
            game.Start();
        }
    }
}