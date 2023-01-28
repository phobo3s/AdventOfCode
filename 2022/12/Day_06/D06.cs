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
        static Queue<char> qAll;
        static Queue<char> qRunner;
        static void Main(string[] args)
        {
            string fileText = File.ReadAllText("..\\..\\Resources\\ProblemData.txt");
            qAll = new Queue<char>();
            
            foreach (char c in fileText) 
            {
                qAll.Enqueue(c);
            }
            
            //resolve Part-2
            qRunner = new Queue<char>();
            for (int i = 1; i < 15; i++)
            {
                qRunner.Enqueue(qAll.Dequeue());
            }
            NoSameInQueue(14);
            int result = fileText.Length - qAll.Count();

            //resolve Part-1
            qRunner = new Queue<char>();
            for (int i = 1; i < 5; i++)
            {
                qRunner.Enqueue(qAll.Dequeue());
            }
            NoSameInQueue(4);
            result = fileText.Length - qAll.Count();

            Console.WriteLine("the end");

        }
    
        static void NoSameInQueue(int codeLen)
        {
            if(qRunner.Count == 1)
            {
                return;
            }
            else
            {
                char subjectVal = qRunner.Dequeue();
                if (qRunner.Contains(subjectVal))
                {
                    Enumerable.Range(0, codeLen-qRunner.Count()).ToList().ForEach(arg => qRunner.Enqueue(qAll.Dequeue()));
                }
                else
                {

                }
                NoSameInQueue(codeLen);
            }
        }
    }
}
