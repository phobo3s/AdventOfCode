using System;
using System.Collections.Generic;
using System.Collections;
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
            List<int> totalSnack = new List<int>();
            foreach (string aDwarf in DataText)
            {
                int totalLoad = 0;
                foreach (string aLoad in aDwarf.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                {
                    totalLoad = totalLoad + int.Parse(aLoad);
                }
                totalSnack.Add(totalLoad);
            };
            for(int i=0; i < totalSnack.Count -2 ; i++)
            {
                for(int j = i+1; j < totalSnack.Count -0 ; j++)
                {
                    if (totalSnack[i] < totalSnack[j] )
                    {
                        int temp = totalSnack[j];
                        totalSnack[j] = totalSnack[i];
                        totalSnack[i] = temp;
                    }
                }
            }
            Console.WriteLine(totalSnack[0]+totalSnack[1]+totalSnack[2]);
        }
    }
}
