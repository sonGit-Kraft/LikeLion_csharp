using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion5
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

            // 다양한 출력 방식
            Console.WriteLine($"내년에는 {age + 1}살이 되겠군요!");
            Console.WriteLine("올해는 " + age + "살이군요!");
            Console.WriteLine("올해는 {0}살이군요!", age);

            // 2진수를 정수로 변환
            Console.Write("2진수를 입력하세요: ");
            string binaryInput = Console.ReadLine(); // 2진수를 문자열로 입력
            int decimalValue = Convert.ToInt32(binaryInput, 2); // 2진수 -> 10진수 변환

            // 정수를 2진수로 변환
            string binaryOutput = Convert.ToString(decimalValue, 2); // 10진수 -> 2진수 변환

            Console.WriteLine($"입력한 2진수: {binaryInput}");
            Console.WriteLine($"10진수로 변환: {decimalValue}");
            Console.WriteLine($"다시 2진수로 변환: {binaryOutput}");

            // var를 사용하여 변수 선언
            var Name = "Alice"; // 문자열로 추론
            var Age = 25; // 정수로 추론
            var isStudent = true; // 논리값으로 추론

            Console.WriteLine($"이름: {Name}, 나이: {Age}, 학생 여부: {isStudent}");

            // default 키워드를 사용한 기본값 설정
            int defaultInt = default; // 기본값: 0
            string defaultString = default; // 기본값: null
            bool defaultBool = default; // 기본값: false

            Console.WriteLine($"정수 기본값: {defaultInt}");
            Console.WriteLine($"문자열 기본값: {defaultString}");
            Console.WriteLine($"논리값 기본값: {defaultBool}");
        }
    }
}