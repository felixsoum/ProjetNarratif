using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class GuessRoom : Room 
    {
        internal override string CreateDescription() =>
@"Tu rentres dans la chambre d'invité.
Tout est bien rangé, comme si personne n'y était jamais rentré.
Au fond de la pièce se trouve une salle de bain [bain]
À gauche, il y a une fenêtre [fenêtre]
En face de toi, il y a un lit. [lit]
Au dessus se trouve une peinture [peinture]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "television":
                    Console.WriteLine("Une fois devant la télévision le grésillement arrête. Tu te sens hypnotiser par ce que tu vois puis... Rien...");
                    Game.Finish();
                    break;
                case "sofa":
                    Console.WriteLine("Le bruis de la télévision s'intensifie, tu n'entends que ça...");

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
