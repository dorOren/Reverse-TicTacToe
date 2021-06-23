using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public static class Program
    {
        static void Main()
        {
            GameManager game = new GameManager();
            game.Start();
        }
    }
}