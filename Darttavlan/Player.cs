using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Darttavlan
{
    class Player
    {
        private string name;
        List<Turns> turns_list;

        public Player(string Name = " ")
        {
            name = Name;
            turns_list = new List<Turns>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Calculatepoints()
        {
            int points = 0;
            foreach (var turn in turns_list)
            {
                points = points+turn.Get_score();
            }
            return points;
        }

        public void Add_turn(int tal1, int tal2, int tal3)
        {
            turns_list.Add(new Turns(tal1, tal2, tal3));
        }

        public void Print_turns() //går det att lägga in datum för spelrundan någonstans? kanske i början?
        {
            string statistik = "statistik för " + name;
            Console.WriteLine(statistik);
            SaveDataInFile("Dartspel, spelomgångar", statistik);
            foreach (var turn in turns_list)
            {
                Console.WriteLine(turn);
                SaveDataInFile("Dartspel, spelomgångar", turn.ToString());
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", name);
        }

        public static void SaveDataInFile(string textfilName, string text)
        {
            try
            {
                using (StreamWriter _streamWriter = new StreamWriter(textfilName, true))
                {
                    _streamWriter.WriteLine(text);
                    _streamWriter.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
