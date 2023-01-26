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
            string[] splittedData = fileText.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
            string[] dataPart1 = splittedData[0].Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] stackNames = dataPart1.Last().Trim().Split(new string[] { "   " }, StringSplitOptions.None);
            Dictionary<string, List<string>> stackList = new Dictionary<string, List<string>>();
            foreach (string stackName in stackNames)
            {
                stackList.Add(stackName, new List<string>());
            }
            for (int i = 0; i<(dataPart1.Length-1); i++)
            {
                for (int j=2; j < dataPart1[i].Length; j = j + 3)
                {
                    Console.WriteLine(dataPart1[i][j]);
                    stackList(((j-2)/3)+1).Add(dataPart1[i][j]);
                }
            
            }


            //resolve Part-2


            //resolve Part-1




            Console.WriteLine("the end");

        }
    }
}
