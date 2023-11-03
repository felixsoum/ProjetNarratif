using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Livingroom : Room
    {
        internal override string CreateDescription() =>
@"Une fois la porte du salon ouvert,dans le salon
il y a un [sofa] et un [tv].
Tu peux revenir dans ta [chambre].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {

                case "sofa":
                    Console.WriteLine("tu commences à dormir");
                    Game.Transition<Livingroom>();
                    break;
                case "tv":
                    Console.WriteLine("Tu t'approches de la télévision, et tu commences à toucher la tv, et un vortex interdimensionnel t'aspires dans un autre monde.");
                    Game.Finish();
                    break;
                case "chambre":
                    Console.WriteLine("Tu retournes dans ta chambre.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}