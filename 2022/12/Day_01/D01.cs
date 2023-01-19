using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day16
{
    class Program
    {
       
        static void Main(string[] args)
        {
            GetValveData();
            
        }

        
        private static void GetValveData()
        {
            Dictionary<string, string>  valveData = new Dictionary<string, string>();
            string fileText = File.ReadAllText("..\\..\\Resources\\ProblemData.txt");
            var valveDataText = fileText.Split('\n').Select(line => line.Split(';'));
            foreach (var valve in valveDataText)
            {
               
            };
        }

    }
}
