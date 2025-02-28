using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask13
{
    class Marin
    {
        public string Name { get; private set; } = "마린";
        public int Mineral { get; set; } = 100;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Marin marin = new Marin();

            Console.WriteLine($"이름: {marin.Name}, 미네랄: {marin.Mineral}");
        }
    }
}