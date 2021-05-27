using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProgrammeringsTest
{
    class Character
    {
        public string name;
        private int health;
        private int luck;
        private int power;
        public Random randnumb = new Random();

        public int Health
        {
            get { return this.health;
            }
            set
            {
                this.health = value;
            }
        }
        public int Luck
        {
            get
            {
                return this.luck;
            }
            set
            {
                this.luck = value;
            }
        }
        public int Power
        {
            get
            {
                return this.power;
            }
            set
            {
                this.power = value;
            }
        }

        public Character(bool isMC)//Creates a Main Character
        {
            name = Console.ReadLine();
            this.health = randnumb.Next(50, 100);
            this.luck = randnumb.Next(1, 10);
            this.power = randnumb.Next(1, 10);
        }
        public Character() //creates a none main character
        {
            name = Console.ReadLine();
        }
        public void CurrentStats()//Shows off a characters stats 
        {
            Console.WriteLine("\nYour current stats are:");
            Console.WriteLine("Health: " + this.health);
            Console.WriteLine("Luck: " + this.luck);
            Console.WriteLine("Power: " + this.power + "\n");
        }
       
    }
}
