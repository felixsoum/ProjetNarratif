using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
   
    internal class FfLivingRoom : Room 
    {
        internal override string CreateDescription() =>
@" En bas des escalier, te voilà dans ton salon. Tu te rappelle des bons souvenirs que tu à eu ici,
mais pourtant tu n'es pas heureux... Le peur commence à t'engloutir...
Il ne semble pas t'avoir suivi, pour l'instant.....
Tu te déplace vers la cuisine [cuisine]
Tu vas vers le Couloir [couloir]
La porte du sous-sol tes parents s'y trouvent! [porte]
";

        internal override void ReceiveChoice(string choice)
        {
      

            switch (choice)
            {
                case "cuisine":
                    Console.WriteLine("Une fois devant la télévision le grésillement arrête. Tu te sens hypnotiser par ce que tu vois puis... Rien...");
                    Game.Finish();
                    break;
                case "couloir":
                    Console.WriteLine("Le bruis de la télévision s'intensifie, tu n'entends que ça...");

                    break;
                case "porte": 
                    Console.WriteLine("Tu essaye d'ouvrir la porte, mais celle-ci est barrée.");
                    
                    break;
                default:
                    Console.WriteLine("Commande invalide");
                    break;
            }
        }
    }
}
