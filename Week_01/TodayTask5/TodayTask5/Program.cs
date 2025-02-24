using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask5
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "멋사검존";
            int att = 100;
            int weaponAtt = 0;
            string weapon = default;

            Console.Write("가지고 있는 소지금을 입력하세요: ");
            int cash = int.Parse(Console.ReadLine());

            if(cash>=0 && cash<=100)
            {
                weapon = "무한의대검";
                weaponAtt += 1;
            }
            else if (cash >= 101 && cash <= 200)
            {
                weapon = "카타나";
                weaponAtt += 2;
            }
            else if (cash >= 201 && cash <= 300)
            {
                weapon = "진은검";
                weaponAtt += 3;
            }
            else if (cash >= 301 && cash <= 400)
            {
                weapon = "집판검";
                weaponAtt += 4;
            }
            else if (cash >= 401 && cash <= 500)
            {
                weapon = "엑스칼리버";
                weaponAtt += 5;
            }
            else if (cash >= 501 && cash <= 600)
            {
                weapon = "유령검";
                weaponAtt += 6;
            }
            else if(cash >= 601)
            {
                weapon = "전설의검";
                weaponAtt += 7;
            }

            Console.WriteLine($"이름: {name}");
            Console.WriteLine($"무기: {weapon}");
            Console.WriteLine($"공격력: {att} + {weaponAtt}");
        }
    }
}