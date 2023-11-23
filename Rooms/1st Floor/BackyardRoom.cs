using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
   
    internal class BackyardRoom : Room
    {
        internal static bool PaintKit;
        internal override string CreateDescription() =>
@"Tu es dans la cour arrière. 
Il fait noir.
Tu rescents le vent frais sur ton visage.
Il y a un brouillard épais qui recouvre ta cour
À travers le brouillard, tu arrives à distinguer la cabane dans l'arbre
que ton père avait construit pour toi [cabane]
Directement à droite de la porte, il y a une grosse boite en bois [boite]
Tu rentres à l'intérieur [rentre]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "television":
                    Console.WriteLine("Une fois devant la télévision le grésillement arrête. Tu te sens hypnotiser par ce que tu vois puis... Rien...");
                    
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
