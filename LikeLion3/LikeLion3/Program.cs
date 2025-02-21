using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion3
{
    class Program
    {
        static void Main(string[] args)
        {
            int hp = 100; // 정수형 리터럴
            double att = 56.7; // 실수형 리터럴
            string name = "???"; // 문자열 리터럴
            char grade = 'S'; // 문자형 리터럴
             
            // 출력
            Console.WriteLine("캐릭터");
            Console.WriteLine("체력: " + hp);
            Console.WriteLine("공격력: " + att);
            Console.WriteLine("이름: " + name);
            Console.WriteLine("등급: " + grade);
        }
    }
}