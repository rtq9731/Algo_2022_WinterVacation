using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Algo_2022_WinterVacation
{
    class _03
    {
        struct WordStruct
        {
            public string word;
            public string mean;

            public WordStruct(string word, string mean)
            {
                this.word = word;
                this.mean = mean;
            }
        }

        static WordStruct[] words = new WordStruct[]
        {
            new WordStruct("native", "토종의"),
            new WordStruct("ASYNC", "비동기 통신, 정보를 일정한 속도로 보낼 것을 요구하지 않는 데이터 전송 방법이다."),
            new WordStruct("abstract", "추상적인"),
            new WordStruct("Cynic", "부정적인 사람"),
            new WordStruct("immortal", "불멸의"),
            new WordStruct("void", "…이 하나도[전혀] 없는"),
            new WordStruct("idle", "가동되지 않는, 놀고 있는"),
            new WordStruct("black tea", "홍차"),
            new WordStruct("double", "(똑같거나 비슷한 것이) 두 개[부분]로 된"),
            new WordStruct("chase", "뒤쫓다, 추적하다"),
        };


        static void Main(string[] args)
        {
            Array.Sort(words, (x, y) => x.word.CompareTo(y.word));

            foreach(var item in words)
            {
                Console.WriteLine($"{item.word} : {item.mean}");
            }
        }


    }
}
