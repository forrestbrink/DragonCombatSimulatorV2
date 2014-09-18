using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulatorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            //call the game
            Game game = new Game();

            game.PlayGame();
            //keep the console open
            Console.ReadKey();
        }
    }
}
