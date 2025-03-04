using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask14
{
    class Warrior
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Strength { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();
            warrior.Name = "멋사";
            warrior.Score = 90;
            warrior.Strength = 100;

            Console.WriteLine($"Name: {warrior.Name}");
            Console.WriteLine($"Score: {warrior.Score}");
            Console.WriteLine($"Strength: {warrior.Strength}");
        }
    }
}
