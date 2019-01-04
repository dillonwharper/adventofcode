using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public abstract class InputHandler
    {

        public String FileReader(string path)
        {
            return File.ReadAllText(path);
        }

        public String[] BreakByEndLine(string input)
        {
            return input.Split('\n');
        }

        public int StringToInt(string input)
        {
            return Convert.ToInt32(input);
        }
    }
}
