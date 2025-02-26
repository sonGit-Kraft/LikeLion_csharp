using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion8
{
    class Program
    {
        static void Main(string[] args)
        {
            // 배열
            // index 0 부터 시작
            int[] num = new int[3]; // 3개의 메모리 생성

            num[0] = 10;
            num[1] = 20;
            num[2] = 30;

            /*
            Console.WriteLine(num[0]);
            Console.WriteLine(num[1]);
            Console.WriteLine(num[2]);
            */

            for (int i = 0; i < 3; i++)
                Console.WriteLine(num[i]);

            int[] numbers = { 1, 2, 3 }; // 간단한 선언과 초기화 (배열 크기: 3)
            int[] numbers2 = new int[3]; // 크기만 지정 (배열 크기: 3)
            int[] numbers3 = new int[] { 1, 2, 3 }; // 초기화와 함께 선언 (배열 크기: 3)

            string[] fruits = { "사과", "바나나", "오렌지" }; // 문자열 배열 생성

            for (int i = 0; i < 3; i++)
                Console.WriteLine(fruits[i]);

            int[] Kscore = new int[3];
            int[] Escore = new int[3];
            int[] Mscore = new int[3];

            int[] sum = new int[3];
            float[] avg = new float[3];

            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine($"{i + 1}번 학생 점수 입력");
                Console.Write("국어 점수 입력: ");
                Kscore[i] = int.Parse(Console.ReadLine());
                Console.Write("영어 점수 입력: ");
                Escore[i] = int.Parse(Console.ReadLine());
                Console.Write("수학 점수 입력: ");
                Mscore[i] = int.Parse(Console.ReadLine());

                sum[i] = Kscore[i] + Escore[i] + Mscore[i];
                avg[i] = (float)sum[i] / 3;

                Console.WriteLine();
            }

            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine($"{i + 1}번 학생");
                Console.WriteLine($"국어: {Kscore[i]} 영어: {Escore[i]} 수학: {Mscore[i]}");
                Console.WriteLine($"총점: {sum[i]}");
                Console.WriteLine($"평균: {avg[i]}");
                Console.WriteLine();
            }

            // 1차원 배열
            int[] scores = new int[3];

            scores[0] = 80;
            scores[1] = 90;
            scores[2] = 70;

            for (int i = 0; i < scores.Length; i++) // Length: 배열의 길이
                Console.WriteLine($"점수 {i + 1}: {scores[i]}");

            // 소수점 자릿수 설정하는 포맷
            double value = 123123123.123123;
            Console.WriteLine(value.ToString("F2")); // 소수점 둘째 자리까지
            Console.WriteLine($"{value:F3}"); // 소수점 셋째 자리까지
            Console.WriteLine(string.Format("{0:F4}", value)); // 소수점 넷째 자리까지
            Console.WriteLine(value.ToString("F0")); // 정수 부분만 출력
            Console.WriteLine(value.ToString("N2")); // 소수점 둘째 자리까지 (천 단위 구분 기호를 포함)

            // 2차원 배열
            int[,] matrix = new int[2, 3] // [행, 열]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write($"{matrix[i, j]} ");

                Console.WriteLine();
            }

            int[][] mat = new int[2][];
            mat[0] = new int[3];
            mat[1] = new int[3];

            mat[0][0] = 1;
            mat[0][1] = 2;
            mat[0][2] = 3;

            mat[1][0] = 4;
            mat[1][1] = 5;
            mat[1][2] = 6;

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                    Console.Write($"{matrix[i, j]} ");

                Console.WriteLine();
            }

            // 가변 배열
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2 };
            jaggedArray[1] = new int[] { 3, 4, 5 };
            jaggedArray[2] = new int[] { 6 };

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                    Console.Write($"{jaggedArray[i][j]} ");

                Console.WriteLine();
            }

            /*
            int[][] matrix = new int[2][3]; → X 잘못된 문법
            int[][] matrix = new int[2][]; (가변 배열 선언 후 각 행 초기화 필요)
            int[,] matrix = new int[2, 3]; (다차원 배열, 크기 고정)
            */

            // var 키워드로 배열 선언
            var numbers4 = new[] { 1, 2, 3, 4, 5 };
            Console.WriteLine($"배열 타입: {numbers4.GetType()}");
        }
    }
}