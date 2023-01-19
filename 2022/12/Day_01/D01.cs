using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day01
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string fileText = File.ReadAllText("..\\..\\Resources\\ProblemData.txt");
            string[] DataText = fileText.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
            int maxLoad = 0;
            foreach (string aDwarf in DataText)
            {
                int totalLoad = 0;
                foreach (string aLoad in aDwarf.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                {
                    totalLoad = totalLoad + int.Parse(aLoad);
                }
                if (totalLoad > maxLoad)
                {
                    maxLoad = totalLoad;
                }
            };
            Console.WriteLine(maxLoad);
        }
    }
}
