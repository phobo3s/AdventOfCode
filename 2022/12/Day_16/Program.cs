using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day16
{
    class Program
    {
        private static Dictionary<string, Valve> valveData;
        private static Dictionary<string,string> allPaths;
        private static Dictionary<string, string> shortestPaths;
        private static int maxFlow;
        private static string bestPath;
        static void Main(string[] args)
        {
            GetValveData();
            allPaths = new Dictionary<string, string>();
            foreach (Valve aValve in valveData.Values)
            {
                FindAllPaths(aValve, aValve.Name);
            };

            shortestPaths = new Dictionary<string, string>();
            FindShortestPaths();

            var expectedPaths = valveData.Keys
                .SelectMany(from => valveData.Keys.Except(new[] { from }).Select(to => $"{from}-{to}"))
                .ToArray();
            var missingPaths = expectedPaths
                .Where(path => !shortestPaths.ContainsKey(path))
                .ToArray();


            System.Collections.ArrayList possibleValves = new System.Collections.ArrayList();
            foreach (Valve aValve in valveData.Values)
            {
                if(aValve.FlowRate != 0)
                {
                    possibleValves.Add(aValve.Name);
                }
            };
            RunValves("AA", "AA", possibleValves, 30, 0);

            Console.WriteLine(maxFlow);

            using (StreamWriter writer = new StreamWriter("..\\..\\Resources\\Result.txt",append:true))
            {
                writer.WriteLine(maxFlow);
                writer.WriteLine(bestPath);
            }

            Console.WriteLine("the end");

        }

        private static void RunValves(string xName, string tracePath, System.Collections.ArrayList possibleValves, int timeleft, int sumFlow) 
        {
            if (timeleft <= 0 | tracePath.ToCharArray().Count(c => c == '!') == possibleValves.Count)
            {
                //aBingo
                /*using (StreamWriter writer = new StreamWriter("C:\\Users\\berk.kilinc\\Desktop\\Result.txt",append:true))
                {
                    writer.WriteLine(tracePath + " // " + sumFlow + " // " + timeleft);
                }*/
                if (sumFlow > maxFlow)
                {
                    maxFlow = sumFlow;
                    bestPath = tracePath;
                }
            }
            else
            {
                for (int i = 0; i < possibleValves.Count; i++) 
                {
                    string y = (string)possibleValves[i];
                    if (tracePath.Contains(y + '!') == false)
                    {
                        int tl = timeleft - shortestPaths[xName + "-" + y].ToCharArray().Count(c => c == '-') - 1;
                        if (tl >= 0)
                        {
                            RunValves(y, tracePath + "-" + shortestPaths[xName + "-" + y].Substring(3) + "!", possibleValves, tl, sumFlow + (tl * valveData[y].FlowRate));
                        }
                        else
                        {
                            //time is not enough to complete this movement.
                        }
                    }
                    else
                    {
                        //we have turned this valve.
                    }
                }
                //all valves has routed.
                RunValves("", tracePath, possibleValves, 0, sumFlow);
            }
        }

        private static void FindShortestPaths() {
            foreach (string thePath in allPaths.Keys) {
                string x = thePath.Substring(0, 2) + "-" + thePath.Substring(thePath.Length-2,2);
                if (shortestPaths.ContainsKey(x))
                {
                    if (shortestPaths[x].Length <= thePath.Length)
                    {

                    }
                    else
                    {
                        shortestPaths.Remove(x);
                        shortestPaths.Add(x, thePath);
                    }
                }
                else {
                    shortestPaths.Add(x, thePath);
                };
            }
        }
        private static void FindAllPaths(Valve valveA, string P) 
        {
            foreach (string aTarget in valveA.LeadsTo) {
                //if (aTarget == "KD") { System.Diagnostics.Debugger.Break(); }
                if (P.Contains(aTarget) == false)
                {
                    string newP = P + "-" + aTarget;
                    allPaths.Add(newP, "");
                    FindAllPaths(valveData[aTarget], newP);
                };
            };
        }
        private static void GetValveData()
        {
            valveData = new Dictionary<string, Valve>();
            string fileText = File.ReadAllText("..\\..\\Resources\\ProblemData.txt");
            var valveDataText = fileText.Split('\n').Select(line => line.Split(';'));
            foreach (var valve in valveDataText)
            {
                Valve aValve = new Valve
                {
                    Name = valve[0].Substring(valve[0].IndexOf(' ') + 1, 2),
                    FlowRate = int.Parse(valve[0].Substring(valve[0].IndexOf('=') + 1)),
                    LeadsTo = valve[1].Substring(valve[1].IndexOf("valve") + 5).Replace("s", "").Replace(" ", "").Replace("\r", "").Split(',')
                };
                valveData.Add(aValve.Name, aValve);
            };
        }
        private struct Valve 
        {
            public string Name;
            public int FlowRate;
            public string[] LeadsTo;
        }
    }
}
