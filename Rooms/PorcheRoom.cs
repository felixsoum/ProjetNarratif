using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    
    internal class PorcheRoom : Room
    {
        internal static bool seconddeath;
        internal override string CreateDescription() =>
@"Sur le toit du porche, l'air et fraîche et l'atmosphère est menacante.
Tu entends du bruit dans les escaliers, il les monte...
Dépêches-toi à rejoindre la fenêtre qui mène à la salle de jeu. [cours]
Prends le risque d'être vu en te déplaçant plus lentement. [lent]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "cours":
                    Console.WriteLine("Tu te dépèche et cours vers la fenêtre, mais glisse sur le côté et chutes en bas tu porche.");
                    Console.WriteLine("Fin 2 : Une chute mortelle");
                    seconddeath = true;
                    Console.Write("Appuyez sur une touche pour recommencer : ");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "lent":
                    Console.WriteLine("Tu prends ton temps et te diriges lentement vers la fenêtre. ");
                    Console.WriteLine("Tu l'ouvres et rentre dans la salle de jeux. ");
                    Game.Transition<GameRoom>();

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
