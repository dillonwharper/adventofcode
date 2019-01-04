using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day2 : InputHandler
    {
        private List<string> inputs { get; }
        private List<string> possibleBoxes { get; }

        public Day2(string path)
        {
            inputs = new List<string>();
            possibleBoxes = new List<string>();
            inputs.AddRange(BreakByEndLine(FileReader(path)));
        }

        private string FindDuplicateLetter(string input)
        {
            // Alphabetize
            input = String.Concat(input.OrderBy(c => c));
            int count = 0;
            char currentChar = ' ';

            string answer = "";

            foreach (char c in input)
            {
                if (currentChar == ' ')
                {
                    currentChar = c;
                    count++;
                }
                else if (currentChar != c)
                {
                    if (count == 2)
                    {
                        answer += "Two ";
                    }
                    if (count == 3)
                    {
                        answer += "Three ";
                    }
                    currentChar = c;
                    count = 1;
                }
                else
                {
                    count++;
                }
            }
            if (count == 2)
            {
                answer += "Two ";
            }
            if (count == 3)
            {
                answer += "Three ";
            }

            return answer;
        }
        
        // Part One
        public int CalculateCheckSum()
        {

            List<string> answer = new List<string>();
            int twoCount = 0;
            int threeCount = 0;

            string tempAnswer = "";

            foreach (string s in inputs)
            {
                tempAnswer = FindDuplicateLetter(s);
                if (tempAnswer.Contains("Two"))
                {
                    possibleBoxes.Add(s);
                    twoCount++;
                }
                if (tempAnswer.Contains("Three"))
                {
                    possibleBoxes.Add(s);
                    threeCount++;
                }
            }

            return twoCount*threeCount;
        }
        
        // Part Two
        public string FindCorrectBoxes()
        {
            // If possibleBoxes isn't populated populate it using CalculateCheckSum
            if (!possibleBoxes.Any())
            {
                CalculateCheckSum();
            }

            int wrong = 0;

            List<string> correctBoxes = new List<string>();

            for (int i = 0; i < possibleBoxes.Count; i++)
            {
                for (int j = i+1; j < possibleBoxes.Count; j++)
                {
                    for(int x = 0; x < possibleBoxes[i].Count()-1; x++)
                    {                        
                        if (possibleBoxes[i][x] != possibleBoxes[j][x])
                        {
                            wrong++;
                        }    
                    }
                    if (wrong == 1)
                    {
                        correctBoxes.Add(possibleBoxes[i]);
                        correctBoxes.Add(possibleBoxes[j]);
                    }
                    wrong = 0;
                }
            }

            string answer = "";

            for (int i = 0; i < correctBoxes[0].Count() - 1; i++)
            {
                if (correctBoxes[0][i] == correctBoxes[1][i])
                {
                    answer += correctBoxes[0][i];
                }
            }

            return answer;
        }



    }
}
