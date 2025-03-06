using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion35
{
    class Program
    {
        // 메서드 ref, out
        // ref: 참조자(Reference) (값 자체가 아니라 변수의 참조(주소)를 전달)
        // 메서드 내부에서 값을 변경하면 원본 변수에도 영향을 미침
        static void Increase(ref int x)
        {
            x++;
        }

        // out: 메서드의 매개변수를 참조 방식으로 전달, 메서드 내부에서 값을 반드시 초기화해서 반환
        // 반환이 여러개일 때 유용
        // 메서드에서 값 반환용 임무수행원
        static void OutFunc(int a, int b, out int x, out int y)
        {
            x = a;
            y = b;
        }

        static void Main(string[] args)
        {
            int num = 10;

            Increase(ref num); // 메서드 호출 시에도 ref 키워드를 함께 사용

            Console.WriteLine(num);

            int a = 10;
            int b = 20;
            int x, y;

            OutFunc(a, b, out x, out y);

            Console.WriteLine("x: " + x + " y: " + y);
        }
    }
}