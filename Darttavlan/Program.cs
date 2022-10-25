using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Darttavlan
{
    class Program
    {
        static void Main(string[] args)
        {
            Game my_game = new Game();
            Console.WriteLine("Hur många spelare vill du lägga till?");
            int antalSpelare;
            while (!int.TryParse(Console.ReadLine(), out antalSpelare))
            {
                Console.WriteLine("Du verkar ha skrivit i fel format! Försök skriva ett heltal.");
            }
            for (int i = 0; i < antalSpelare; i++)
            {
                int nummerFörLista = i + 1;
                Console.WriteLine("Skriv namnet på spelare {0}: ", nummerFörLista);
                string spelarensNamn = Console.ReadLine();
                Player laggTillSpelare = new Player(spelarensNamn);
                Console.WriteLine(my_game.Add_Player(spelarensNamn));
            }
            Console.WriteLine("Här är listan över spelare: ");
            foreach (var spelare in my_game._listOfPlayers)
            {
                Console.WriteLine(spelare);
            }

            my_game.PlayGame();

            Console.WriteLine("Hejdå! Nu är spelet slut!");
        }
    }
}
