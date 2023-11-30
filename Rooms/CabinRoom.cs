using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class CabinRoom : Room
    {
        internal override string CreateDescription() =>
@"Te voilà dans la cabane.
L'endroit qui était autrefois une place de confort pour toi
semble bien plus sinistre maintenant qu'elle est partie...
À ta gauche se trouve un dessin accroché au mur [dessin]
Devant toi, il y a un petit lit et une petite table [lit]
À ta droite, tu remarques une petite valise [valise]
Tu sors de la cabane. [sors]
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
