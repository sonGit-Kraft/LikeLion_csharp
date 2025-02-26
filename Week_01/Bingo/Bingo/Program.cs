using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            // a b swap
            int a = 10;
            int b = 20;
            int temp; // 임시 저장소

            Console.WriteLine($"a: {a}, b: {b}"); // swap 전

            temp = a;
            a = b;
            b = temp;

            Console.WriteLine($"a: {a}, b: {b}"); // swap 후
            */

            /*
            C#의 Tuple 문법을 활용한 swap
            (nums[a], nums[b]) = (nums[b], nums[a]); 
            */

            int[] iArray = new int[25];

            for (int i = 0; i < 25; i++)
                iArray[i] = i + 1;

            // 셔플
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                int iA = rand.Next(0, 25); // index: 0 ~ 24
                int iB = rand.Next(0, 25); // index: 0 ~ 24
                int iT = 0;

                iT = iArray[iA];
                iArray[iA] = iArray[iB];
                iArray[iB] = iT;
            }

            int input = 0;
            int iBingo = 0;
            int iCount = 0;

            while (true)
            {
                Console.Clear();

                if (iBingo >= 5)
                {
                    Console.WriteLine("빙고 성공!");
                    break;
                }

                // 빙고판
                // 1차원 배열을 2차원 배열처럼
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (iArray[i * 5 + j] == 0)
                        {
                            Console.Write(" * ");
                        }
                        else
                        {
                            Console.Write(iArray[i * 5 + j].ToString("D2") + ' '); // Decimal (십진수) 형식으로 최소 2자리로 표현
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("빙고 개수: " + iBingo);
                iBingo = 0;
                Console.Write("숫자를 입력하세요: ");
                input = int.Parse(Console.ReadLine());

                for (int i = 0; i < 25; i++)
                {
                    if (iArray[i] == input)
                    {
                        iArray[i] = 0;
                        break;
                    }
                }

                // 빙고 체크 로직
                // 가로 체크
                for (int i = 0; i < 5; i++)
                {
                    iCount = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (iArray[i * 5 + j] == 0)
                            iCount++;
                    }
                    if (iCount == 5)
                        iBingo++;
                }

                // 세로 체크
                for (int i = 0; i < 5; i++)
                {
                    iCount = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (iArray[j * 5 + i] == 0)
                            iCount++;
                    }
                    if (iCount == 5)
                        iBingo++;
                }

                // 왼쪽 상단 → 오른쪽 하단 대각선 체크
                iCount = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (iArray[i * 6] == 0)
                        iCount++;
                }
                if (iCount == 5)
                    iBingo++;

                // 오른쪽 상단 → 왼쪽 하단 대각선 체크
                iCount = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (iArray[(i + 1) * 4] == 0)
                        iCount++;
                }

                if (iCount == 5)
                    iBingo++;
            }

            Console.Clear();

            // 2차원 배열을 이용한 빙고
            int[,] board = new int[5, 5]; // 5x5 빙고판
            bool[,] marked = new bool[5, 5];

            int bingoCount = 0;
            Random random = new Random();

            // 빙고판 초기화
            int[] nums = new int[25];

            for (int i = 0; i < 25; i++)
                nums[i] = i + 1;

            // 랜덤 섞기 (Fisher-Yates Shuffle)
            for (int i = 0; i < 100; i++)
            {
                int a = random.Next(25);
                int b = random.Next(25);

                // C#의 Tuple 문법을 활용한 swap
                (nums[a], nums[b]) = (nums[b], nums[a]);
            }

            // 2차원 배열로 변환
            int index = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    board[i, j] = nums[index++];

            // 게임 시작
            while (bingoCount < 5)
            {
                Console.Clear();

                // 빙고판 출력
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (marked[i, j])
                            Console.Write(" X ");
                        else
                            Console.Write($"{board[i, j],2} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("빙고 개수: " + bingoCount);
                bingoCount = 0;

                Console.Write("숫자를 입력하세요: ");
                int num = int.Parse(Console.ReadLine());

                bool found = false;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (board[i, j] == num)
                        {
                            marked[i, j] = true;
                            found = true;
                            break; // 숫자를 찾았으므로 내부 for break
                        }
                    }
                    if (found) break; // 숫자를 찾았으므로 외부 for break
                }

                // 가로 체크
                for (int i = 0; i < 5; i++)
                {
                    bool rowBingo = true;
                    for (int j = 0; j < 5; j++)
                        if (!marked[i, j]) rowBingo = false;

                    if (rowBingo) bingoCount++;
                }

                // 세로 체크
                for (int i = 0; i < 5; i++)
                {
                    bool colBingo = true;
                    for (int j = 0; j < 5; j++)
                        if (!marked[j, i]) colBingo = false;

                    if (colBingo) bingoCount++;
                }

                // 왼쪽 상단 → 오른쪽 하단 대각선 체크
                bool diag1Bingo = true;
                for (int i = 0; i < 5; i++)
                    if (!marked[i, i]) diag1Bingo = false;

                if (diag1Bingo) bingoCount++;

                // 오른쪽 상단 → 왼쪽 하단 대각선 체크
                bool diag2Bingo = true;
                for (int i = 0; i < 5; i++)
                    if (!marked[i, 4 - i]) diag2Bingo = false;

                if (diag2Bingo) bingoCount++;
            }

            Console.WriteLine("\n빙고 5개 완성!");
        }
    }
}