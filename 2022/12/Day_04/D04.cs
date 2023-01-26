using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileText = File.ReadAllText("..\\..\\Resources\\ProblemData.txt");
            string[] teamData = fileText.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            //resolve Part-2
            int errorCount = 0;
            foreach (string aTeamPair in teamData)
            {
                string[] teams = aTeamPair.Split(',');
                int xi = int.Parse(teams[0].Split('-')[0]);
                int xj = int.Parse(teams[0].Split('-')[1]);
                int yi = int.Parse(teams[1].Split('-')[0]);
                int yj = int.Parse(teams[1].Split('-')[1]);
                if ((xj<yi)||(xi>yj))
                {
                    //
                }
                else
                {
                    errorCount++;
                }
            }

            //resolve Part-1
            errorCount = 0;
            foreach (string aTeamPair in teamData)
            {
                string[] teams = aTeamPair.Split(',');
                int xi = int.Parse(teams[0].Split('-')[0]);
                int xj = int.Parse(teams[0].Split('-')[1]);
                int yi = int.Parse(teams[1].Split('-')[0]);
                int yj = int.Parse(teams[1].Split('-')[1]);
                if ((xi<=yi && xj>=yj)||(xi>=yi && xj<=yj))
                {
                    errorCount++;
                }
            }
            Console.WriteLine("the end");

        }
    }
}
