using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algo_2022_WinterVacation
{
    class Program
    {
        static Stack<int> specialStack = new Stack<int>();

        static Dictionary<char, int> specialDict = new Dictionary<char, int>()
        {
            { '(', 1 },
            { '{', 2 },
            { '[', 3 },
            { ')', -1 },
            { '}', -2 },
            { ']', -3 },
        };

        static string stringForCheck = "{ A [(i+1)]=0;}";
        
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("수식을 입력해주세요");
                stringForCheck = Console.ReadLine();
                SetDataToStack(specialStack, stringForCheck);
                Console.WriteLine();
            }
        }

        static void SetDataToStack(Stack<int> stack, string str)
        {
            int curInt = 0;

            foreach (var item in str)
            {
                curInt = SpecialCharToInt(item);

                if (curInt == 0) // 괄호 아니면 스킵
                {
                    continue;
                }
                else
                {
                    if(curInt < 0)
                    {
                        if (stack.Count < 1)
                        {
                            Console.WriteLine("ERROR : 괄호에 문제가 있습니다"); // 2 ( 닫는 괄호 먼저 )
                            return;
                        }

                        if (stack.Pop() + curInt != 0)
                        {
                            Console.WriteLine("ERROR : 괄호에 문제가 있습니다"); // 2 아니면 3 ( 앞의 괄호랑 더한 수가 0이 아님 )
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                stack.Push(curInt);
            }

            if(stack.Count > 0)
            {
                Console.WriteLine("ERROR : 괄호에 문제가 있습니다"); // 1번 오류 ( 짝이 다 안지어져 있음 )
                return;
            }

            Console.WriteLine("괄호에 문제가 없습니다.");
        }

        static int SpecialCharToInt(char value)
        {
            int result = specialDict.TryGetValue(value, out result) ? result : 0;

            return result;
        }

    }
}
