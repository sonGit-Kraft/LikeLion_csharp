using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion18
{
    class Program
    {
        static void Main(string[] args)
        {
            // 값 형식과 참조 형식
            // 값 형식: 스택에 저장, 참조 형식: 힙에 저장
            int valueType = 10; // 값 형식
            object referenceType = valueType; // 참조 형식

            valueType = 20;

            Console.WriteLine($"ValueType: {valueType}");
            Console.WriteLine($"ReferenceType: {referenceType}");

            // 박싱과 언박싱
            // 값 형식을 참조 형식으로 변환(박싱), 다시 값 형식으로 변환(언박싱)
            int value = 42;
            object boxed = value; // 박싱
            int unboxed = (int)boxed; // 언박싱

            Console.WriteLine($"Boxed: {boxed}, Unboxed: {unboxed}");

            // is 연산자 (형식 비교)
            // 객체가 특정 형식인지 확인
            object obj1 = "Hello";

            Console.WriteLine(obj1 is string); // true
            Console.WriteLine(obj1 is int); // false

            // as 연산자 (형식 변환)
            // 안전하게 형 변환 수행
            object obj2 = "Hello";
            string str = obj2 as string; // 형 변환
            Console.WriteLine(str is string);

            var obj3 = 42;
            Console.WriteLine(obj3 is int);

            // 문자열 다루기
            string greeting = "Hello";
            string name = "Alice";
            string message = greeting + ", " + name + '!';

            Console.WriteLine(message);
            Console.WriteLine($"Length of name:  {name.Length}"); // 문자열 길이
            Console.WriteLine($"To Upper: {name.ToUpper()}"); // 대문자 변환
            Console.WriteLine($"Substring: {name.Substring(1)}"); // 부분 문자열

            // string 다양한 메서드
            string text1 = "C# is awesome!";
            Console.WriteLine($"Contains 'awesome': {text1.Contains("awesome")}");
            Console.WriteLine($"Starts with 'C#': {text1.StartsWith("C#")}");
            Console.WriteLine($"Index of 'is': {text1.IndexOf("is")}");
            Console.WriteLine($"Replace 'awesome' with 'great': {text1.Replace("awesome", "great")}");

            // StringBuilder 클래스를 사용하여 문자열 연결
            StringBuilder sb1 = new StringBuilder("Hello");
            sb1.Append(", ");
            sb1.Append("World!");
            Console.WriteLine(sb1.ToString()); // Hello, World!

            // String 과 StringBuilder 클래스의 성능 차이 비교
            // 반복적으로 문자열 수정할 때 StringBuilder가 더 효율적
            int iterations = 10000;
            Stopwatch sw = Stopwatch.StartNew();
            string text2 = "";

            for (int i = 0; i < iterations; i++)
                text2 += "a";

            sw.Stop();
            Console.WriteLine($"String: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            StringBuilder sb2 = new StringBuilder();

            for (int i = 0; i < iterations; i++)
                sb2.Append("a");

            sw.Stop();
            Console.WriteLine($"StringBuilder: {sw.ElapsedMilliseconds} ms");

            // 예외 처리
            // 예외: 프로그램 실행 중 발생하는 오류
            // 예외를 처리하면 프로그램이 중단되지 않고 실행을 계속할 수 있음
            // try catch
            // try catch 없이 예외 발생 시 프로그램이 죽어버림
            try
            {
                int[] numbers = { 1, 2, 3 };
                Console.WriteLine(numbers[5]); // IndexOutOfRangeException 발생 (인덱스 3은 없음)
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // finally 블록은 예외 발생 여부와 상관없이 항상 실행
            try
            {
                int number = int.Parse("NotANumber"); // 오류 발생
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Execution finished.");
            }

            // Exception 클래스
            // 모든 예외의 기본 클래스 (모든 예외를 다 잡아줌)
            try
            {
                int number = int.Parse("ABC"); // 오류 발생
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }

            // throw 구문으로 직접 예외 발생시키기
            try
            {
                int age = -5;
                // throw 를 사용하여 특정 조건에서 예외를 발생
                if (age < 0)
                {
                    throw new ArgumentException("Age cannot be negative");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}