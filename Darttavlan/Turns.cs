using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darttavlan
{
    class Turns
    {
        private int turnOne;
        private int turnTwo;
        private int turnThree;

        public Turns(int TurnOne, int TurnTwo, int TurnThree)
        {
            turnOne = TurnOne;
            turnTwo = TurnTwo;
            turnThree = TurnThree;
        }

        public int TurnOne
        {
            get { return turnOne; }
            set { turnOne = value; }
        }

        public int TurnTwo
        {
            get { return turnTwo; }
            set { turnTwo = value; }
        }

        public int TurnThree
        {
            get { return turnThree; }
            set { turnThree = value; }
        }

        public int Get_score()
        {
            int totalScoreAllThreeTurns = turnOne + turnTwo + turnThree;
            return totalScoreAllThreeTurns;
        }

        public override string ToString()
        {
            return string.Format("Kast 1: {0} || Kast 2: {1} || Kast 3: {2}", turnOne, turnTwo, turnThree);
        }
    }
}
