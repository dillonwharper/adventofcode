using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day1 : InputHandler
    {
        private List<int> inputs;

        public Day1(string path)
        {
            inputs = new List<int>();

            ConvertInputToInts(FileReader(path));
        }

        // Part One
        public int CalculateFrequency()
        {
            return inputs.Sum();
        }

        // Part Two
        public int FindDuplicateFrequency()
        {
            List<int> FoundAnswers = new List<int>();
            bool duplicateFound = false;
            int loopedAnswer = 0;
            int answer = 0;

            while (duplicateFound == false)
            {
                for (int i = 0; i < inputs.Count; i++)
                {                    
                    loopedAnswer += inputs[i];
                    if (FoundAnswers.Any() && FoundAnswers.Contains(loopedAnswer))
                    {
                        answer = loopedAnswer;
                        duplicateFound = true;
                        i = inputs.Count;
                    }
                    FoundAnswers.Add(loopedAnswer);
                }
            }

            return answer;
        }

        private void ConvertInputToInts(string input)
        {
            foreach (string s in BreakByEndLine(input))
            {
                inputs.Add(StringToInt(s));
            }
        }

    }
}
