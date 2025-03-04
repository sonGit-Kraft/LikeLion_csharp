using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LikeLion17
{
    // 클래스 시그니처 기본 구성
    // 클래스 시그니처는 클래스의 선언부를 의미

    // [접근 지정자] [수정자] class 클래스 이름 : 부모클래스, 인터페이스
    // public       abstract                  : BaseClass, IComparable
    // private      sealed
    // protected    static
    //              partial
    
    // 기본 클래스
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    // 상속하는 클래스
    public class Warrior : Player
    {
        public int Strength { get; set; }
    }

    /*
    // 인터페이스 구현 클래스
    public class Enemy : IAttackable, IMovable
    {
        public void Attack() { }
        public void Move() { }
    }
    */

    // 추상 클래스 (abstract)
    public abstract class Animal
    {
        public abstract void MakeSound();
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 환경 변수 사용
            string path = Environment.GetEnvironmentVariable("PATH");
            Console.WriteLine($"PATH: {path}");

            // Random 클래스를 사용하여 난수 생성
            Random random = new Random();
            int randomNumber = random.Next(1, 101); // 1 ~ 100
            Console.WriteLine($"Random Number: {randomNumber}");

            // 프로그램 실행 시간 구하기
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 100000000; i++) { } // 실행 코드 (연산 1억 회 -> 대략 1초)

            stopwatch.Stop();
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");

            // 정규식
            string input = "Hello, my phone number is 010-1234-5678";
            string pattern = @"\d{3}-\d{4}-\d{4}$";
            bool isMatch = Regex.IsMatch(input, pattern);

            Console.WriteLine(isMatch);

            // Environment 클래스로 프로그램 강제 종료
            Console.WriteLine("프로그램 종료");
            Environment.Exit(0); // 프로그램 강제 종료
        }
    }
}