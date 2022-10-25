using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darttavlan
{
    class Dartboard
    {
        private string minDarttavla;
        private int newIndexValue;
        private int[] numbersOnBoard = new int[20] { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5 };

        public int NewIndexValue
        {
            get { return newIndexValue; }
            set { newIndexValue = value; }
        }

        public string MinDarttavla
        {
            get { return minDarttavla; }
            set { minDarttavla = value; }
        }

        public int[] NumbersOnBoard
        {
            get { return numbersOnBoard; }
            set { numbersOnBoard = value; }
        }

        public int UserChoice()
        {
            Random randomerare = new Random();
            int siffra = randomerare.Next(0, 21);
            return siffra;
        }

        public int UserChoice(int siktet) //Metod som beräknar sannolikheten att träffa siffran användaren siktar på
        {
            int sikte = siktet;
            Random randomerare = new Random();
            int siffra = randomerare.Next(1, 101); //randomiserar fram en procentsats för att räkna ut resultatets sannolikhet
            if (siffra <= 15) //15% chans att träffa siffran bredvid
            {
                for (int i = 0; i < numbersOnBoard.Length; i++)
                {
                    if (numbersOnBoard[i] == siktet)
                    {
                        newIndexValue = i - 1;
                        siktet = numbersOnBoard[newIndexValue];
                    }
                }
                return siktet;
            }
            else if (siffra > 15 && siffra <= 30) //15% chans att träffa den andra siffran bredvid
            {
                for (int i = 0; i < numbersOnBoard.Length; i++)
                {
                    if (numbersOnBoard[i] == siktet)
                    {
                        try
                        {
                            newIndexValue = i + 1;
                        }
                        catch (IndexOutOfRangeException) //när det nya indexet översteg 20 blev det en indexvalue, här hanterar jag det
                        {
                            newIndexValue = 0;
                        }
                        siktet = numbersOnBoard[newIndexValue];
                    }
                }
                return siktet;
            }
            else if (siffra > 30 && siffra <= 35) //5% chans att siktet hamnar någon helt annanstans
            {
                siktet = UserChoice(); //använder random-metoden ovan istället för att skapa en ny random-konstruktor pga enklare kod
                return siktet;
            }
            else if (siffra > 35 && siffra <= 40) //5% chans att missa tavlan.
            {
                siktet = 0;
                return siktet;
            }
            else //resterande 41-101 innebär 60% chans att träffa det man siktade på
                return siktet;
        }

    }
}
