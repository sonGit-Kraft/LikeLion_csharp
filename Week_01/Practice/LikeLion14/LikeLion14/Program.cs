using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion14
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now; // 현재 날짜 및 시간
            Console.WriteLine(now);

            TimeSpan duration = new TimeSpan(1, 30, 0); // 01:30:00 시간 표시 (h, m, s)
            Console.WriteLine(duration);
        }
    }
}
