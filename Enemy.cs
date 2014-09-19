using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulatorV2
{
    class Enemy
    {
        public bool IsAlive
        {
            get { return this.HP > 0; }
        }
        
        //name of the enemy
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value.ToUpper(); }
        }
        //health of the enemy
        private int _hp;

        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }
        //create random number generator
        private Random rng = new Random();
        //CREATE THE CONSTRUCTOR
        public Enemy(string name, int startingHP)
        {
            this.HP = startingHP;
            this.Name = name;
        }
        //attack
        public void Attack(Player player)
        {
            if (rng.Next(0,101) >= 20)
            {
                //it is a hit
                int damage = rng.Next(5, 16);
                player.HP -= damage;
                //output
                Console.WriteLine(this.Name + " has hit you, causing you " + damage + " damage.");
            }
            else
            {
                //the dragon missed
                Console.WriteLine("You got lucky this time! " + this.Name + " has barely missed you!");
            }
        }
        
    }
}
