using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion13
{
    class Program
    {
        // 구조체
        // 클래스와 비슷하지만, 값 타입(Value Type)이며 가볍고 빠름
        // 주로 간단한 데이터 묶음을 만들 때 사용
        struct Point
        {
            // public 어디서든 사용 가능
            // private 나만 사용할려고 하는 키워드
            public int X;
            public int Y;

            // 생성자 (처음 생성될 때 동작하는 함수)
            // struct에도 생성자 사용 가능 (매개변수를 통한 초기화)
            public Point(int x, int y)
            {
                X = x; Y = y;
            }

            public void Print()
            {
                Console.WriteLine($"좌표: {X} , {Y}");
            }
        }

        struct Rectangle
        {
            public int Width;
            public int Height;

            public int GetArea() => Width * Height;
        }

        static void Main(string[] args)
        {
            Point p1; // 구조체 변수 선언

            p1.X = 10;
            p1.Y = 20;

            p1.Print();

            Point p2 = new Point(5, 15); // 생성자 호출
            p2.Print();

            var rect = new Rectangle { Width = 5, Height = 4 };
            /* 
               Rectangle rect;
               rect.Width = 5;
               rect.Height = 4;
            */
            Console.WriteLine($"Area: {rect.GetArea()}");

            // 구조체 배열
            Point[] points = new Point[2];

            points[0].X = 10;
            points[0].Y = 20;

            points[1].X = 30;
            points[1].Y = 40;

            foreach(var point in points)
                Console.WriteLine($"({point.X}, {point.Y})");
        }
    }
}