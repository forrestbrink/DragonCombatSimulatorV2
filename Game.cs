using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulatorV2
{
    class Game
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
        //create a constructor
        public Game()
        {
            this.Player = new Player("Forrest", 100);
            this.Enemy = new Enemy("Dragon", 200);
        }

        //create methods
        private void DisplayInfo()
        {
            //display current HP's
            Console.WriteLine("You have " + Player.HP + " HP left, versus the dragon's " + Enemy.HP + " HP left.");
        }
        public void PlayGame()
        {
            //keep playing until one dies
            while (Player.IsAlive && Enemy.IsAlive)
            {
                //player attacks enemy, enemy attacks player
                DisplayInfo();
                Player.Attack(Enemy);
                Enemy.Attack(Player);
            }
            //game is over
            //player is dead
            if (!Player.IsAlive)
            {
               
                Console.WriteLine("You died! " + Enemy.Name + " has won!");
            }
                //dragon is dead
            else
            {
                Console.WriteLine("Congratulations!!!!  You have defeated the almighty " + Enemy.Name);
            }
        }
    }
}
