using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TodayTask17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("문자열 입력: ");
            string str = Console.ReadLine();

            Console.WriteLine($"To Upper: {str.ToUpper()}"); // 대문자 변환
            Console.WriteLine($"Replace \"C#\" with \"CSharp\": {str.Replace("C#", "CSharp")}"); // "C#"을 "CSharp"으로 변경 
            Console.WriteLine($"Length of str: {str.Length}"); // 문자열 길이
        }
    }
}