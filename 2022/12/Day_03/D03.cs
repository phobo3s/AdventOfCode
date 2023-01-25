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
            string[] sackData = fileText.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            //resolve Part-2
            for (int i=0, i < sackData.Length, i = i+3)
            {

            }





            //resolve Part-1
            int totalError = 0;
            HashSet<char> pocket1 = new HashSet<char>();
            HashSet<char> pocket2 = new HashSet<char>();
            foreach (string aSack in sackData)
            {
                
                pocket1 = aSack.Substring(0,aSack.Length/2).ToHashSet();
                pocket2 = aSack.Substring(aSack.Length/2).ToHashSet();
                
                foreach (char anItem in pocket1)
                {
                    if (pocket2.Contains(anItem)) 
                    {
                        totalError = totalError + ((anItem-38)%58);
                        break;
                    }
                }
                pocket1.Clear();
                pocket2.Clear();

            }
            Console.WriteLine("the end");


        }
    }
}
