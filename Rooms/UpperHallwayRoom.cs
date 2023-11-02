using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class UpperHallwayRoom : Room
    {
        internal static bool thirddeath;
        internal override string CreateDescription() =>
@"Le couloir est sombre et tu ne vois pas bien.
Tu entends du bruit venir de ta chambre. Il se rapproche de la porte!
Vite, caches-toi :
Tu te rends jusqu'aux escaliers de l'autre côté du couloir. [escaliers]
Tic Tac Tic Tac... Tu te caches derrière l'horloge [horloge]
Tu cours vers la toilette. [toilette]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "escaliers":
                    Console.WriteLine("Tu tentes de te rendre jusqu'aux escaliers.");
                    Console.WriteLine("Une fois devant tu manques la première marche et déboules les escaliers");
                    Console.WriteLine("Fin 3 : Une mort abrupt");
                    thirddeath = true;
                    break;
                case "horloge":
                    Console.WriteLine("Tu te dirige rapidement vers l'horloge et te cache derrière");
                    Console.WriteLine("TIC TAC TIC TAC TIC TAC");
                    Console.WriteLine("Le bruit de l'horloge t'empêche de savoir où il est allé...");

                    break;
                case "toilette":
                    Console.WriteLine("Tu te précipite vers les toilettes");
                    Console.WriteLine("La lumière des toilettes clignottes, tu doit trouver un endroit pour te cacher vite!");
                    Console.WriteLine();

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
