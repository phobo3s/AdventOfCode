using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string[] datapart2 = splittedData[1].Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] stackNames = dataPart1.Last().Trim().Split(new string[] { "   " }, StringSplitOptions.None);
            Dictionary<char, List<string>> stackList = new Dictionary<char, List<string>>();
            foreach (string stackName in stackNames)
            {
                stackList.Add(char.Parse(stackName), new List<string>());
            }
            for (int i = 0; i<(dataPart1.Length-1); i++)
            {
                int stackColumnCounter = -1;
                for (int j=1; j < dataPart1[i].Length; j = j + 4)
                {
                    stackColumnCounter++;
                    if (!dataPart1[i][j].Equals(' '))
                    {
                        stackList[char.Parse(stackNames[stackColumnCounter])].Add(dataPart1[i][j].ToString());
                    }
                }
            }
            List<int[]> commandsList = new List<int[]>();
            string pattern = @"(\d+)";
            foreach (string aCommand in datapart2)
            {
                MatchCollection matches = Regex.Matches(aCommand,pattern);
                commandsList.Add(new int[] {int.Parse(matches[0].ToString()),int.Parse(matches[1].ToString()),int.Parse(matches[2].ToString())});
            }

            //resolve Part-2
            foreach(int[] aCommand in commandsList)
            {
                for (int repetitionNumber = 1; repetitionNumber <= aCommand[0]; repetitionNumber++)
                {
                    char from = char.Parse(aCommand[1].ToString());
                    char to = char.Parse(aCommand[2].ToString());
                    stackList[to].Insert(0,stackList[from][aCommand[0]-repetitionNumber]);
                    stackList[from].RemoveAt(aCommand[0]-repetitionNumber);
                }
            }
            string result = "";
            foreach(string stackName in stackNames)
            {
                result = result + stackList[char.Parse(stackName)][0];
            }


            //resolve Part-1
            result = "";
            foreach(int[] aCommand in commandsList)
            {
                for (int repetitionNumber = 1; repetitionNumber <= aCommand[0]; repetitionNumber++)
                {
                    char from = char.Parse(aCommand[1].ToString());
                    char to = char.Parse(aCommand[2].ToString());
                    stackList[to].Insert(0,stackList[from][0]);
                    stackList[from].RemoveAt(0);
                }
            }
            foreach(string stackName in stackNames)
            {
                result = result + stackList[char.Parse(stackName)][0];
            }
            



            Console.WriteLine("the end");

        }
    }
}
