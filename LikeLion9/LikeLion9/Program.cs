using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion9
{
    class Program
    {
        static void Main(string[] args)
        {
            // 사용자 입력을 문자열로 받기
            Console.Write("이름을 입력하세요: ");
            string userName = Console.ReadLine(); // 사용자로부터 입력 받기
            
            Console.WriteLine($"안녕하세요, {userName}님!"); // 입력값 출력

            // 문자열을 정수로 변환
            // Console.ReadLine()은 항상 문자열로 입력을 받으므로
            // 숫자 등 다른 데이터 형식으로 사용할 경우 변환이 필요
            Console.Write("나이를 입력하세요: ");
            string input = Console.ReadLine(); // 입력
            int age = int.Parse(input); // string -> int (문자열을 정수로 변환)

            Console.WriteLine($"내년에는 {age + 1}살이 되겠군요!");
            Console.WriteLine("올해는 " + age + "살이군요!");
            Console.WriteLine("올해는 {0}살이군요!", age);
        }
    }
}