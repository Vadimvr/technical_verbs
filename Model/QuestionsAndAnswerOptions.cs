﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QuestionsAndAnswerOptions
    {
        public int LenghtList { get => data.Count;  }
        private string[] contentButton = new string[5];
        public string CorectAnswer { get; set; }
        public string Question { get; set; }
        public string[] ContentButton { get => contentButton; set => contentButton = value; }
       
        public void NewQuestionContext(int startIndex, int lastIndex)
        {
            if (lastIndex <= data.Count && startIndex >= 0 && lastIndex - startIndex >= 5)
            {
                int x = QuestionsAndAnswerOptions.data.Count;
                int[] randoms = new int[5];
                int temp = 0;
                Random rnd = new Random();
                randoms[0] = rnd.Next(startIndex, lastIndex);

                for (int i = 1; i < 5; i++)
                {
                    temp = rnd.Next(startIndex, lastIndex);

                    for (int j = 0; j <= i; j++)
                    {
                        if (j == i)
                        {
                            randoms[i] = temp;

                        }
                        else if (randoms[j] == temp)
                        {
                            i--; break;
                        }
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    ContentButton[i] = data[randoms[i]][0];

                }
                x = randoms[rnd.Next(0, 4)];
                CorectAnswer = data[x][0];
                Question = data[x][1];
            }

        }
        //// test
        static List<List<string>> data = new List<List<string>>
        {
            new List<string>{ "1", "нажми 1" },
            new List<string>{ "2", "нажми 2" },
            new List<string>{ "3", "нажми 3" },
            new List<string>{ "4", "нажми 4" },
            new List<string>{ "5", "нажми 5" },
            new List<string>{ "6", "нажми 6" },
            new List<string>{ "7", "нажми 7" },
            new List<string>{ "8", "нажми 8" },
            new List<string>{ "9", "нажми 9" },
            new List<string>{ "10", "нажми 10"}
        };

    }
}

