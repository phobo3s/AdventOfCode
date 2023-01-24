using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_02
{
    class Program
    {
        private enum player1 {A=1,B=2,C=3};
        private enum player2 {X=1,Y=2,Z=3};
        static void Main(string[] args)
        {
            string fileText = File.ReadAllText("..\\..\\Resources\\ProblemData.txt");
            string[] gameData = fileText.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            int totalPoint = 0;
            
            //resolve
            foreach (string aGame in gameData)
            {
                string[] playerChoices = aGame.Split(' ');
                int player1Choice = (int)Enum.Parse(typeof(player1), playerChoices[0]);
                int player2Choice = (int)Enum.Parse(typeof(player2), playerChoices[1]);


                    if ((Math.Abs(player1Choice-player2Choice) % 2) == 0) //is the difference is even
                    {
                        if (player2Choice == player1Choice)
                        {
                            totalPoint = totalPoint + 3;
                        }
                        else
                        {
                            if (player2Choice == Math.Min(player1Choice,player2Choice))
                            {
                                totalPoint = totalPoint + 6;
                            }
                        }
                    }else //or odd    
                    {
                        if (player2Choice == Math.Max(player1Choice,player2Choice))
                        {
                            totalPoint = totalPoint + 6;
                        }
                    }
                    totalPoint = totalPoint + player2Choice;
            }
        }
    }
}
