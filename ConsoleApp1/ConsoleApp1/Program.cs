using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder mapData = new StringBuilder(@"██████████████████████████████████████████████████
██                                              ██
██  ██  ░░  ██  ██  ██  ██  ██  ██  ░░  ██  ██  ██
██  ░░      ██      ██      ██      ██      ██  ██
██  ██  ██  ██  ░░  ██  ░░  ██  ██  ██  ██  ██  ██
██      ██      ██      ░░      ██      ██      ██
██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██
██  ░░      ░░      ██      ░░      ██      ░░  ██
██  ██  ░░  ██  ██  ░░  ██  ██  ██  ██  ░░  ██  ██
██      ██      ██      ██      ░░      ██      ██
██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██
██  ██      ██      ░░      ██      ░░      ██  ██
██  ██  ░░  ██  ░░  ██  ██  ██  ██  ██  ░░  ██  ██
██      ██      ██      ██      ██      ██      ██
██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██
██  ░░      ░░      ██      ░░      ██      ░░  ██
██  ██  ░░  ██  ██  ░░  ██  ██  ██  ██  ░░  ██  ██
██      ██      ██      ██      ░░      ██      ██
██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██  ██
██████████████████████████████████████████████████");

            for (int i = 0; i < mapData.Length; i++)
                Console.WriteLine($"{i} + {mapData[i]}");
            int width = 50;
            int x = 4, y = 2;
            int index = y * (width + 2) + x; // 개행 포함
            mapData.Remove(index, 2);       // 두 칸 삭제
            mapData.Insert(index, "  ");    // 공백 두 칸 삽입
            for (int i = 0; i < mapData.Length; i++)
                Console.Write($"{mapData[i]}");

            Console.WriteLine($"Index 50: '{mapData[50]}'");
            Console.WriteLine($"Index 50 ASCII value: {(int)mapData[50]}"); // ASCII 값도 확인
        }
    }
}
