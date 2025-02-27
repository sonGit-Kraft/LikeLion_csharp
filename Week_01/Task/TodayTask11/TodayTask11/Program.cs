using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TodayTask11
{
    struct Student
    {
        public string Name;
        public int Kor;
        public int Eng;
        public int Mat;

        public void Print()
        {
            Console.WriteLine($"{Name}\t{Kor}\t{Eng}\t{Mat}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] person = new Student[3];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}번째 학생");
                Console.Write("이름: ");
                person[i].Name = Console.ReadLine();
                Console.Write("국어 점수: ");
                person[i].Kor = int.Parse(Console.ReadLine());
                Console.Write("영어 점수: ");
                person[i].Eng = int.Parse(Console.ReadLine());
                Console.Write("수학 점수: ");
                person[i].Mat = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            Console.WriteLine("이름\t국어\t영어\t수학");
            for (int i = 0; i < 3; i++)
                person[i].Print();
        }
    }
}