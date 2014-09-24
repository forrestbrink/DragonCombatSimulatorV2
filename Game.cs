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
        static void AddHighScore(int playerscore)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            ForrestEntities db = new ForrestEntities();

            HighScore newHighScore = new HighScore();
            newHighScore.Name = playername;
            newHighScore.Date = DateTime.Now;
            newHighScore.Game = "Dragon Combat V2";
            newHighScore.Score = playerscore;

            db.HighScores.Add(newHighScore);

            db.Save();
        }
        static void DisplayHighScore()
    {
            Console.WriteLine("High Scores");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            ForrestEntities db = new ForrestEntities();
            List<HighScore> HighScoreList = db.HighScores.Where(x => x.Game == "Dragon Combat V2").OrderBy(x => x.Score).Take(10).ToList();

            foreach (HighScore highscore in HighScoreList)
	{
		    Console.WriteLine("{0}, {1} Took {2} tries to win! {3}", HighScoreList.IndexOf(highscore) + 1, highscore.Score, highscore.Date.Value.ToShortDateString());
	}
    }
}
    }
}
