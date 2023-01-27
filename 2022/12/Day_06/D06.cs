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
            qRunner = new Queue<char>();
            foreach (char c in fileText) 
            {
                qAll.Enqueue(c);
            }
            for (int i = 1; i < 5; i++)
            {
                qRunner.Enqueue(qAll.Dequeue());
            }
            //resolve Part-2
            

            //resolve Part-1
            NoSameInQueue();


            Console.WriteLine("the end");

        }
    
        static void NoSameInQueue()
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
                    Enumerable.Range(0, 4-qRunner.Count()).ToList().ForEach(arg => qRunner.Enqueue(qAll.Dequeue()));
                }
                else
                {

                }
                NoSameInQueue();
            }
        }
    }
}
