using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darttavlan
{
    class Game
    {
        private Player spelare = new Player(); //den här spelaren heter " "
        private List<Player> listOfPlayers = new List<Player>();
        private int variabelforpoints;
        private bool forTheLoop = true; //används för att om jag satte variabelforpoints som villkor i while-loopen så blev det fel

        public Player Spelare
        {
            get { return spelare; }
            set { spelare = value; }
        }

        public List<Player> _listOfPlayers
        {
            get { return listOfPlayers; }
            set { listOfPlayers = value; }
        }
        public int Variabelforpoints /*den här variabeln används aldrig utanför klassen
                                      men jag skapade propertyn ändå för att hålla vanan uppe*/
        {
            get { return variabelforpoints; }
            set { variabelforpoints = value; }
        }
        public bool ForTheLoop
        {
            get { return forTheLoop; }
            set { forTheLoop = value; }
        }
        public string Add_Player(string name) //denna skulle vara en void enligt planeringen, men ville returnera att spelaren lagts till
        {
            listOfPlayers.Add(new Player(name));
            return ("Spelaren " + name + " lades till");
        }
        public void PlayGame()
        {
            Dartboard dartBoard = new Dartboard();
            int whereYouHit = 0; //den klagade om jag inte gav whereYouHit & kasten värdet noll
            int kast1 = 0, kast2 = 0, kast3 = 0;

            Console.Clear();
            Console.WriteLine("Välkommen till dartspelet! Först att få exakt 301 poäng vinner.");
            Console.WriteLine("Här är dartbrädan:");

            for (int i = 0; i < dartBoard.NumbersOnBoard.Length; i++) //loop skriver ur alla siffror i tavlan
            {
                Console.Write("{0}, ", dartBoard.NumbersOnBoard[i]);
            }
            Console.WriteLine(" "); //byter rad efter listan, finns not en bättre funktion för detta

            do
            {
                foreach (var spelare in listOfPlayers) //LOOPEN GÅR IGENOM VARJE SPELARE I LISTAN
                {
                    Console.WriteLine("Nu spelar: {0}", spelare);
                    for (int y = 0; y <= 2; y++) //LOOP FÖR VARJE TUR I OMGÅNGEN
                    {
                        Console.WriteLine("Vill du 1. kasta på måfå, eller 2. sikta?");
                        int answer;
                        while (!int.TryParse(Console.ReadLine(), out answer))
                        {
                            Console.WriteLine("Du kan bara svara 1 eller 2.");
                        }
                        if (answer == 1) //Spelaren vill kasta på måfå.
                        {
                            whereYouHit = dartBoard.UserChoice();
                            if (whereYouHit == 0)
                            {
                                Console.WriteLine("Du missade tavlan!");
                            }
                            else
                                Console.WriteLine("Du träffade: {0}", whereYouHit);
                        }
                        else if (answer == 2) //Spelaren vill sikta
                        {
                            Console.WriteLine("Vilken siffra siktar du på ?");
                            int whereYouAim;
                            while (!int.TryParse(Console.ReadLine(), out whereYouAim))
                            {
                                Console.WriteLine("Du verkar ha skrivit i fel format! Försök skriva ett heltal.");
                            }
                            if (whereYouAim > 20)
                            {
                                whereYouHit = 0;
                                Console.WriteLine("Bra försök, men du måste välja en siffra mellan 1 och 20. 0 poäng till dig.");
                            }
                            else
                            {
                                whereYouHit = dartBoard.UserChoice(whereYouAim);
                                if (whereYouHit == 0)
                                    Console.WriteLine("Du missade tavlan!");
                                else
                                {
                                    Console.WriteLine("Du träffade: {0}", whereYouHit);
                                }
                            }
                        }
                        else
                        {
                            answer = 0;
                            Console.WriteLine("Jag förstår inte ditt svar. Noll poäng till dig. Lycka till med nästa kast.");
                        }
                        if (y == 0)
                        {
                            kast1 = whereYouHit;
                        }
                        else if (y == 1)
                        {
                            kast2 = whereYouHit;
                        }
                        else if (y == 2)
                        {
                            kast3 = whereYouHit;
                        }
                    }
                    spelare.Add_turn(kast1, kast2, kast3);
                    variabelforpoints = spelare.Calculatepoints();
                    if (variabelforpoints == 301)
                    {
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Grattis! {0} har vunnit spelet!", spelare.Name);
                        Console.ReadKey();
                        Console.Clear();
                        forTheLoop = false; //avslutar hela while-loopen
                        break;
                    }
                    else if (variabelforpoints > 301)
                    {
                        kast1 = 0;
                        kast2 = 0;
                        kast3 = 0;
                        Console.WriteLine("Din totala poäng översteg 301! Alla poäng denna runda nollställs.");
                    }
                    else
                        Console.WriteLine("{0} har {1} poäng!", spelare, variabelforpoints);
                }
            } while (forTheLoop);

            foreach (var spelare in listOfPlayers) //Här skrivs listan ut.
            {
                spelare.Print_turns();
            }
        }
    }
}
