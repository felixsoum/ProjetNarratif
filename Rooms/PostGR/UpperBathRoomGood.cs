using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class UpperBathRoomGood : Room
    {
        internal override string CreateDescription() =>
@"Tu arrives à te cacher derrière la laveuse.
Tu l'entends entrer dans la salle de bain et se fâcher de ne pas t'y trouver...
tu entends ses pas s'éloigner en direction de la salle de jeu...
Tu sors de ta cachettes : 
Diriges-toi vers ta chambre [chambre]
Descends les escaliers [escaliers]

";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "chambre":
                    Console.WriteLine("Tu retournes dans ta chambre.");
                    Game.Transition<BedroomPostGR>();
                    break;
                case "escaliers":
                    Console.WriteLine("Silencieusement, tu descends les escaliers");
                    Console.WriteLine("Fin de la beta");

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
