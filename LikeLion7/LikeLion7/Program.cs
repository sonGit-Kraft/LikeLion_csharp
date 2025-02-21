using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion7
{
    class Program
    {
        static void Main(string[] args)
        {
            // 숫자 데이터 형식: 정수와 실수를 다룰 때 사용하는 다양한 타입
            int integerNum = 10; // 정수 데이터
            float floatNum = 3.14f; // 단정밀도 실수 데이터
            double doubleNum = 3.141592; // 배정밀도 실수 데이터

            Console.WriteLine(integerNum); Console.WriteLine(floatNum); Console.WriteLine(doubleNum);

            // 정수 데이터 형식: 소수점이 없는 숫자를 표현
            int intValue = -100; // 4바이트 크기의 정수
            long longValue = 1234567890L; // 8바이트 크기의 정수

            Console.WriteLine(intValue); Console.WriteLine(longValue);

            // 부호 있는 정수: 음수와 양수를 모두 표현 가능
            sbyte signedByte = -50; // 1바이트 크기
            short signedShort = -32; // 2바이트 크기
            int signedInt = -20000000; // 4바이트 크기

            Console.WriteLine(signedByte);
            Console.WriteLine(signedShort);
            Console.WriteLine(signedInt);

            // 부호 없는 정수: 0 이상의 정수만 표현 가능
            byte unsignedByte = 225; // 1바이트 크기
            ushort unsignedShort = 65000; // 2바이트 크기
            uint unsignedInt = 40000000; // 4바이트 크기

            Console.WriteLine(unsignedByte);
            Console.WriteLine(unsignedShort);
            Console.WriteLine(unsignedInt);

            // 실수형 데이터 형식: 소수점을 포함한 숫자를 표현
            float singlePrecision = 3.14f; // 단정밀도 실수 (4바이트)
            double doublePrecision = 3.1415926535; // 배정밀도 실수 (8바이트)
            decimal highPrecision = 3.1415926535897932384626433833m; // 고정밀도 (16바이트)

            Console.WriteLine(singlePrecision);
            Console.WriteLine(doublePrecision);
            Console.WriteLine(highPrecision);

            // 접미사 사용: 숫자의 데이터 형식을 명시
            int IntegerValue = 100; // 기본 정수형 (int)
            long LongValue = 100L; // 정수형 (long)
            float FloatValue = 3.14f; // 실수형 (float)
            double DoubleValue = 3.14; // 기본 실수형 (double)
            decimal DecimalValue = 3.14m; // 고정밀도 실수형 (decimal)

            Console.WriteLine(IntegerValue);
            Console.WriteLine(LongValue);
            Console.WriteLine(FloatValue);
            Console.WriteLine(DoubleValue);
            Console.WriteLine(DecimalValue);
        }
    }
}