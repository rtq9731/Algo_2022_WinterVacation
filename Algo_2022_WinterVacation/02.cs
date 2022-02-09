using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Algo_2022_WinterVacation
{
    class C02
    {
        static List<string> strs = new List<string>();
        static Random rand = new Random();

        static string[] anyString = new string[]
        {
            "1학년은 내년에 2학년이 됩니다.",
            "고3은 이번 겨울방학이 마지막 겨울방학 입니다.",
            "학교는 3월에 개학합니다.",
            "휴지는 다 쓰면 휴지심이 남습니다.",
            "제로 콜라는 칼로리가 0입니다.",
            "암막커튼은 빛을 다 가리지 못합니다.",
            "중국은 동아시아에 있습니다.",
            "한복은 한국문화입니다.",
            "천안문은 베이징에 있습니다.",
            "1989년의 천안문에는 아무일도 없었습니다. 특히요",
            "피부적외선체온계는 의료기기입니다.",
            "초밥은 일식입니다.",
            "대부분의 큐브는 정육면체로 이루어져있습니다.",
            "삼각형의 내각의 합은 180도 입니다.",
            "워크래프트는 블리자드에서 만들었습니다.",
            "마인크래프트의 낚시대는 정확히 65번 사용 할 수 있습니다.",
            "마인크래프트에선 같은 장비 두 개가 합쳐졌을 때, 5%의 추가 내구도를 얻습니다."
        };
        /*
        1. 삽입
        2. 삭제
        3. 농담 적어주기
        4. 모두 출력하기
        5. 모두 지우기
         */

        static bool isOver = false;

        static void Main(string[] args)
        {
            while (!isOver)
            {
                Menu();
            }
        }

        static void Menu()
        {

            WriteLine();

            WriteLine("__________________________________________________________________");
            WriteLine("|----------------------------------------------------------------|");
            WriteLine("|--------☆★완벽한 텍스트 편집기 - from. 코코넛★☆-------------|");
            WriteLine("|----------------------------------------------------------------|");
            WriteLine("------------------------------------------------------------------");

            WriteLine();

            WriteLine("1 : 한 줄 삽입");
            WriteLine("2 : 한 줄 삭제");
            WriteLine("3 : 아무 말 적어주기 ( 맨 끝에 )");
            WriteLine("4 : 모두 출력하기");
            WriteLine("5 : 모두 지우기");
            WriteLine("6 : 해당 줄 확인하기");
            WriteLine("Q : 종료");

            string inputStr = ReadLine();

            if (int.TryParse(inputStr, out int input))
            {
                WriteLine();
                switch (input)
                {
                    case 1:
                        WriteStrLine();
                        break;
                    case 2:
                        RemoveStrLine();
                        break;
                    case 3:
                        InputRandomData();
                        break;
                    case 4:
                        PrintAll();
                        break;
                    case 5:
                        ClearStr();
                        break;
                    case 6:
                        PrintStr();
                        break;
                    default:
                        WriteLine("입력값이 잘못되었습니다!");
                        break;
                }
            }
            else if (inputStr == "Q" || inputStr == "q")
            {
                if (GetAnswer("종료하시겠습니까?"))
                {
                    isOver = true;
                    WriteLine("프로그램을 종료합니다..");
                }
                else
                {
                    WriteLine("프로그램 종료를 취소합니다.");
                }
            }
        }

        static void WriteStrLine()
        {
            int line = 0;

            Write($"몇번째 줄에 입력하시겠습니까? ( 입력 값은 0번부터 시작합니다 / 현재 줄 개수 {strs.Count}) : ");

            if (!int.TryParse(ReadLine(), out line))
            {
                WriteLine("숫자 값을 입력해주십시오.");
                WriteStrLine();
                return;
            }

            if(line < 0 || line > strs.Count)
            {
                WriteLine("숫자 값이 잘못되었습니다.");
                WriteStrLine();
                return;
            }

            Write($"{line}번째 줄에 입력 됩니다.\n문자열을 입력해주세요. : ");
            string input = ReadLine();
            InputDataToList(line, input, "문자열 입력이 완료되었습니다. 아무 키나 누르면 메뉴로 돌아갑니다..");
            ReadLine();
        }

        static void InputDataToList(int num, string input, string completeMsg)
        {
            List<string> result = new List<string>();
            if (num == 0)
            {
                result.Add(input);

                strs.ForEach(str => result.Add(str));
                strs = result;
                WriteLine(completeMsg);
            }
            else if (num == strs.Count)
            {
                result = strs;
                result.Add(input);
                WriteLine(completeMsg);
            }
            else
            {
                string[] temp = new string[num];
                List<string> front, back;

                strs.CopyTo(0, temp, 0, num); // 현재 리스트에 있는 것 중 num의 앞부분을 temp에 넣음

                front = temp.ToList(); 

                temp = new string[strs.Count - num];

                strs.CopyTo(num, temp, 0, strs.Count - num); // 현재 리스트에 있는 것 중 num의 뒷부분을 temp에 넣음

                back = temp.ToList();

                front.ForEach(str => result.Add(str));

                result.Add(input);

                back.ForEach(str => result.Add(str));

                WriteLine(completeMsg);
            }

            strs = result;
        }

        static void RemoveStrLine()
        {
            int line = 0;

            Write("몇번째 줄을 지우시겠습니까? ( 입력 값은 0번부터 시작합니다 ) : ");

            if (!int.TryParse(ReadLine(), out line))
            {
                WriteLine("숫자 값을 입력해주십시오.");
                RemoveStrLine();
                return;
            }

            if(strs.Count < line)
            {
                WriteLine("삭제하시려는 내용은 \n" + strs[line] + "입니다.");
                if (GetAnswer("삭제하시겠습니까?"))
                {
                    strs.RemoveAt(line);
                }
            }
            else
            {
                WriteLine("존재하지 않는 번호입니다.");
                return;
            }
        }

        static void InputRandomData()
        {
            InputDataToList(strs.Count, anyString[rand.Next(0, anyString.Length)], "랜덤 입력이 완료되었습니다.");
        }

        static void PrintAll()
        {
            if (GetAnswer("모두 출력하시겠습니까?"))
            {
                for (int i = 0; i < strs.Count; i++)
                {
                    WriteLine($"{i} {strs[i]}");
                }
                WriteLine("출력이 완료되었습니다.");
            }
        }

        static void ClearStr()
        {
            if (GetAnswer("모두 삭제하시겠습니까?"))
            {
                strs.Clear();
            }
        }

        static void PrintStr()
        {
            int line = 0;

            Write("몇번째 줄을 출력하시겠습니까? ( 입력 값은 0번부터 시작합니다 ) : "); 
            
            if(int.TryParse(ReadLine(), out line))
            {
                WriteLine("숫자 값을 입력해주십시오.");
                PrintStr();
                return;
            }

            WriteLine(strs[line]);
        }

        static bool GetAnswer(string msg)
        {
            Write($"{msg} < y / n > ");
            string answer = ReadLine();
            if (answer == "y")
            {
                WriteLine("입력이 확인되었습니다.");
                return true;
            }
            else if (answer == "n")
            {
                WriteLine("입력이 취소되었습니다.");
                return false;
            }
            else
            {
                WriteLine("다시 값을 입력해주세요.");
                return GetAnswer(msg);
            }
        }
    }
}
