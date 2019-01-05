using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day3 : InputHandler
    {
        private List<string> inputs { get; }
        // Track if ids overlap
        // False is there is no overlap
        // True if there is
        private Dictionary<int, bool> ids { get; }
        private int[,] fabric;

        public Day3(string path)
        {
            inputs = new List<string>();
            ids = new Dictionary<int, bool>();
            fabric = new int[1000,1000];
            inputs.AddRange(BreakByEndLine(FileReader(path)));
        }

        private void FillFabricArray()
        {
            int id = 0;
            int startingCol = 0;
            int startingRow = 0;
            int amtAcross = 0;
            int amtDown = 0;
            foreach (string s in inputs)
            {
                id = GetID(s);
                startingCol = GetCol(s);
                startingRow = GetRow(s);
                amtAcross = GetAmountAcross(s);
                amtDown = GetAmountDown(s);

                ids.Add(id, false);
                
                for (int col = startingCol; col < startingCol+amtAcross; col++)
                {
                    for (int row = startingRow; row < startingRow+amtDown; row++)
                    {
                        if (fabric[col, row] == 1 || fabric[col, row] == 2)
                        {
                            fabric[col, row] = 2;
                            ids[id] = true;
                        }
                        else
                        {
                            fabric[col, row] = 1;
                        }
                    }
                }
            }

            // USED FOR PART 2
            // Rerun to go back and find the claimed ids that passed through on the first run
            // Not a great way to solve the problem IMO
            foreach (string s in inputs)
            {
                id = GetID(s);
                startingCol = GetCol(s);
                startingRow = GetRow(s);
                amtAcross = GetAmountAcross(s);
                amtDown = GetAmountDown(s);
                
                for (int col = startingCol; col < startingCol + amtAcross; col++)
                {
                    for (int row = startingRow; row < startingRow + amtDown; row++)
                    {
                        if ( fabric[col, row] == 2)
                        {
                            fabric[col, row] = 2;
                            ids[id] = true;
                        }
                    }
                }
            }
        }

        private int GetID(string input)
        {
            return StringToInt(input.Replace(" ", "").Split('#', '@')[1]);
        }

        private int GetCol(string input)
        {
            return StringToInt(input.Replace(" ", "").Split('@', ',')[1]);
        }

        private int GetRow(string input)
        {
            return StringToInt(input.Replace(" ", "").Split(',', ':')[1]);
        }

        private int GetAmountAcross(string input)
        {
            return StringToInt(input.Replace(" ", "").Split(',', ':', 'x')[2]);
        }

        private int GetAmountDown(string input)
        {
            return StringToInt(input.Replace(" ", "").Split(',', ':', 'x')[3]);
        }

        public int CalcSquareInchesMultiClaimed()
        {
            FillFabricArray();

            int answer = 0;

            for (int col = 0; col < fabric.GetLength(0); col++)
            {
                for (int row = 0; row < fabric.GetLength(1); row++)
                {
                    if (fabric[col, row] == 2)
                    {
                        answer++;
                    }
                }
            }

            return answer;
        }

        public int FindIDWithNoOverlap()
        {
            if (!ids.Any())
            {
                FillFabricArray();
            }
            return ids.FirstOrDefault(key => key.Value == false).Key;
        }

    }
}
