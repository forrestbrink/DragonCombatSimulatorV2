using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulatorV2
{
    class Player
    {
        //create enumeration for attacks
        public enum AttackType
        {
            Sword = 1,
            Magic,
            Heal
        }
        private int _hp;

        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }
        //give the player a name
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        //determine if they are alive
        public bool IsAlive
        {
            get { return this.HP > 0; } 
        }
        //create rng
        private Random rng = new Random();
        public Player(string name, int startingHP)
        {
            this.Name = name;
            this.HP = startingHP;
        }
        
        //choose attack
        private AttackType ChooseAttack()
        {
            //user choose attack
            Console.WriteLine("Choose your attack type:\n1.Sword\n2.Magic\n3.Heal");
            int input = int.Parse(Console.ReadLine());
            //return attack type
            return (AttackType)input;
        }
        public void Attack(Enemy enemy)
        {
            int damage;
            switch (ChooseAttack())
            {
                //if sword
                case AttackType.Sword:
                    if (rng.Next(0, 101) > 30)
                    {
                        //it is a hit
                        damage = rng.Next(20, 36);
                        enemy.HP = enemy.HP - damage;
                        //output
                        Console.WriteLine("Success! You hit " + enemy.Name + ", causing him " + damage + " damage!");
                    }
                    else
                    {
                        Console.WriteLine("You missed!");
                    }
                    break;
                case AttackType.Magic:
                    damage = rng.Next(10, 16);
                    enemy.HP = enemy.HP - damage;
                    //output
                    Console.WriteLine("You have struck the dragon with your magic, causing him " + damage + " damage!");
                    break;
                case AttackType.Heal:
                    int HealAmount = rng.Next(10, 21);
                    this.HP = this.HP + HealAmount;
                    Console.WriteLine("You have healed yourself for " + HealAmount + " HP");
                    break;
                default:
                    break;
            }
        }
    }
}
