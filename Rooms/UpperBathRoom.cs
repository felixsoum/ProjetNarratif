using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class UpperBathRoom : Room
    {
        internal override string CreateDescription() =>
@"
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "chambre":
                    Console.WriteLine("Tu retournes dans ta chambre.");
                    Game.Transition<Bedroom>();
                    break;
                case "5872":
                    Console.WriteLine("Le coffre s'ouvre et tu obiens une clé.");
                    
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
