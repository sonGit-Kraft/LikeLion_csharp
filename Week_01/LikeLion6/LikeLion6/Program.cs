using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion6
{
    class Program
    {
        static void Main(string[] args)
        {
            // 연산자
            int a = 5, b = 3;
            int sum = a + b; // 산술 연산자 사용
            Console.WriteLine($"합: {sum}");

            int number = 7;
            Console.WriteLine("짝수 홀수 판별: " + number % 2); // 0 이면 짝수, 1이면 홀수

            bool isEqual = (a == b); // 관계형 연산자 사용
            Console.WriteLine($"a와 b가 같은가? {isEqual}");

            // 단항 연산자
            int num = 5;
            Console.WriteLine(+num);
            Console.WriteLine(-num);

            bool flag = true;
            Console.WriteLine(!flag); // 논리 부정: false

            // 10 (binary: 1010) 4바이트 0000 0000 0000 0000 0000 0000 0000 1010 (10)
            // ~ 비트 반전: 0101  4바이트 1111 1111 1111 1111 1111 1111 1111 0101 (-11) 
            int Num = 10;
            int Result = ~Num;

            Console.WriteLine("원래 값: " + Num);
            Console.WriteLine("비트 반전 값: " + Result);

            // 변환 연산자 (Casting 캐스팅: 자료형 변환)
            double pi = 3.14;
            int integerPi = (int)pi; // 실수 -> 정수 변환
            Console.WriteLine(integerPi); // 3 출력 (소수 부분 버려짐)

            // 성적 계산
            int iKor = 90;
            int iEng = 75;
            int iMath = 58;

            int Sum = 0;
            float Average = 0.0f;

            Sum = iKor + iEng + iMath; // 총점
            Average = (float)Sum / 3; // 평균

            Console.WriteLine("총점 : " + Sum);
            Console.WriteLine("평균 : " + Average);

            // 산술 연산자
            int c = 10, d = 3;

            Console.WriteLine(c + d); // 덧셈
            Console.WriteLine(c - d); // 뺄셈
            Console.WriteLine(c * d); // 곱셈
            Console.WriteLine(c / d); // 나눗셈
            Console.WriteLine(c % d); // 나머지

            // 문자열 연결 연산자
            string firstName = "Alice";
            string lastName = "Smith";

            Console.WriteLine(firstName + ' ' + lastName);

            // 할당 연산자
            int e = 10;
            e += 5; // e = e + 5;
            Console.WriteLine(e);
            e -= 5; // e = e - 5;
            Console.WriteLine(e);
            e *= 5; // e = e * 5;
            Console.WriteLine(e);
            e /= 5; // e = e / 5;
            Console.WriteLine(e);
            e %= 5; // e = e % 5;
            Console.WriteLine(e);

            // 증감 연산자
            int f = 3;
            Console.WriteLine("f의 값은: " + ++f); // 전위
            Console.WriteLine("f의 값은: " + f++); // 후위
            Console.WriteLine("f의 값은: " + f); // 후위는 다음 라인에서 증가

            f = 3;
            Console.WriteLine("f의 값은: " + --f); // 전위
            Console.WriteLine("f의 값은: " + f--); // 후위
            Console.WriteLine("f의 값은: " + f); // 후위는 다음 라인에서 감소

            // 관계형 연산자
            // 두 값을 비교하여 관계를 평가
            // == != < > <= >=
            int x = 5, y = 10;
            Console.WriteLine(x == y); // 5 == 10 -> False
            Console.WriteLine(x != y); // 5 != 10 -> True
            Console.WriteLine(x < y); // 5 < 10 -> True
            Console.WriteLine(x > y); // 5 > 10 -> False
            Console.WriteLine(x <= y); // 5 <= 10 -> True
            Console.WriteLine(x >= y); // 5 >= 10 -> False

            // 논리 연산자
            bool g = true;
            bool h = false;

            Console.WriteLine(g && h); // AND: 둘 다 True이면 True (곱셈으로 생각하면 됨)
            /* AND 연산
             * 1 : 1 -> T
             * 1 : 0 -> F
             * 0 : 1 -> F
             * 0 : 0 -> F
            */
            Console.WriteLine(g || h); // OR: 둘 중 하나만 True이면 True (덧셈으로 생각하면 됨)
            /* OR 연산
             * 1 : 1 -> T
             * 1 : 0 -> T
             * 0 : 1 -> T
             * 0 : 0 -> F
            */
            Console.WriteLine(!g); // NOT: True -> False, False -> True

            // 비트 연산자
            x = 5; // 0101
            y = 3; // 0011

            Console.WriteLine(x & y);
            /* 0101
             * 0011 & AND 연산
             * 0001 (1)
            */ 
            Console.WriteLine(x | y);
            /* 0101
             * 0011 & OR 연산
             * 0111 (7)
            */
            Console.WriteLine(x ^ y);
            /* 0101
             * 0011 ^ XOR 연산 (둘이 다르면 True, 같으면 False)
             * 0110 (6)
            */
            Console.WriteLine(~x);
            /* 0101 ~ NOT 연산
             * 1010 (-6)
            */

            // 시프트 연산자
            int value = 4; // 0100
            Console.WriteLine(value << 1); // 왼쪽으로 한칸 shift 1000 (8)
            Console.WriteLine(value >> 1); // 오른쪽으로 한칸 shift 0010 (2)

            // 삼항 연산자 (?)
            a = 10; b = 20;
            int max = (a > b) ? a : b; // a > b 가 true이면 a, false이면 b 정의
            Console.WriteLine(max);

            int key = 1;
            string str = (key == 1) ? "문이 열렸습니다." : "문을 못열었습니다.";

            Console.WriteLine(str);

            // 연산자 우선순위
            int result = 10 + 2 * 5; // 곱셈이 덧셈보다 우선순위
            Console.WriteLine(result);

            int adjustedResult = (10 + 2) * 5; // 괄호로 우선순위 변경
            Console.WriteLine(adjustedResult);
        }
    }
}