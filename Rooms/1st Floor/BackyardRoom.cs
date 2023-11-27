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
        static bool ladder = false;
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "boite":
                    Console.WriteLine("Il y a un cadena sur la boite qui t'empêche de l'ouvrir");
                    
                    break;
                case "cabane":
                    if (!ladder)
                    {
                        Console.WriteLine("Tu t'avances dans la cour. Au pied de la cabane," +
                            "\ntu réalises que l'échelle pour y monter est brisée.");
                    } else
                    {
                        Console.WriteLine("Tu utilises les planches de bois que tu as trouvé, et grimpe dans la cabane.");
                        //Game.Transition<CabinRoom>();
                    }

                   

                    break;

                case "rentre":
                    Console.WriteLine("Tu retournes à l'intérieur.");
                    Game.Transition<KitchenRoom>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
