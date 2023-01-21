using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileText = File.ReadAllText("..\\..\\Resources\\ProblemData.txt");
            string[] DataText = fileText.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
        }
    }
}
