using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion22
{
    class Program
    {
        static void Main(string[] args)
        {
            // 화살표 연산자와 람다 식으로 조건 처리
            string[] names = { "Charlie", "Alice", "Bob" };
            var sortedNames = names.OrderBy(n => n); // OrderBy(): 오름차순 정렬
                                                     // n => n: 각 요소 n을 그대로 반환해라

            foreach (var name in sortedNames)
                Console.WriteLine(name);

            var firstName = names.First(n => n.StartsWith("A")); // A로 시작하는 첫번째(First) 요소 찾기

            Console.WriteLine($"First name starting with A: {firstName}");

            // 메서드 구문과 쿼리 구문
            int[] nums = { 5, 3, 8, 1 };

            // 메서드 구문
            var sortedMethod = nums.OrderByDescending(n => n); // OrderByDescending(): 내림차순 정렬

            // 쿼리 구문
            var sortedQuery = from n in nums
                              orderby n
                              select n;

            Console.WriteLine("Method syntax:");
            foreach (var n in sortedMethod)
                Console.WriteLine(n);

            Console.WriteLine("Query syntax:");
            foreach (var n in sortedQuery)
                Console.WriteLine(n);

            // Select()
            // LINQ 쿼리 연산자 중 하나
            // *각 요소를 변환하여 새로운 컬렉션을 생성*
            string[] words = { "apple", "banana", "cherry" };

            var lengths = words.Select(w => w.Length); // Select()로 길이 값 반환
            Console.WriteLine("Length:");
            foreach (var length in lengths)
                Console.WriteLine(length);

            var upperWords = words.Select(w => w.ToUpper()); // Select()로 대문자 변환 값 반환
            Console.WriteLine("ToUpper:");
            foreach (var upperWord in upperWords)
                Console.WriteLine(upperWord);

            // Sum 알고리즘
            int[] datas = { 1, 2, 3, 4, 5 };
            int sum = 0;

            foreach (int data in datas)
                sum += data;

            Console.WriteLine($"Sum: {sum}");

            // Count
            int count = datas.Length; // 개수
            Console.WriteLine($"Count: {count}");

            // Average
            double avg = datas.Average();
            Console.WriteLine($"Average: {avg}");

            // Max
            int max = datas.Max();
            Console.WriteLine($"Max: {max}");

            // Min
            int min = datas.Min();
            Console.WriteLine($"Min: {min}");

            // Near 알고리즘 (근삿값 구하기)
            int target = 4;
            int nearest = datas[0];

            foreach (var data in datas)
                if (Math.Abs(data - target) < Math.Abs(nearest - target)) // Abs(): 절대값 함수
                    nearest = data;

            Console.WriteLine($"Nearest to {target}: {nearest}");

            // Rank 알고리즘
            int[] scores = { 90, 88, 75, 100, 56 };
            for (int i = 0; i < scores.Length; i++)
            {
                int rank = 1;
                for (int j = 0; j < scores.Length; j++)
                    if (scores[j] > scores[i])
                        rank++;

                Console.WriteLine($"Score: {scores[i]}, Rank: {rank}");
            }

            // Sort
            int[] arr = { 5, 2, 8, 1, 9 };

            Array.Sort(arr); // 오름차순 정렬

            foreach (int value in arr)
                Console.WriteLine(value);

            // Search 알고리즘 (선형 검색)
            int[] Data = { 5, 2, 8, 1, 9 };
            int Target = 8;
            int Index = -1;
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] == Target)
                {
                    Index = i;
                    break;
                }
            }
            Console.WriteLine(Index >= 0 ? $"Found at index {Index}" : "Not found");

            // Group 알고리즘
            // 데이터를 특정 기준으로 그룹화
            string[] fruits = { "apple", "banana", "blueberry", "cherry", "apricot" };
            var groups = fruits.GroupBy(f => f[0]); // LINQ의 GroupBy()를 통해 첫 글자로 그룹화

            foreach (var group in groups)
            {
                Console.WriteLine($"Key: {group.Key}"); // Key: 그룹화된 항목의 기준 값(키)
                                                        // 여기서 키는 첫 글자
                foreach(var item in group)
                    Console.WriteLine($" {item}");
            }    
        }
    }
}
