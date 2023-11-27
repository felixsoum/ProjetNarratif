using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class KitchenRoom : Room
    {
        internal override string CreateDescription() =>
@"Tu es dans la cuisine.
Un faible lumière éclaire la pièce.
la cuisine semble si vide lorsque personne n'y est...
Au fond de la cuisine se trouve un porte qui mène à la cour [cour]
Le frigo, il y a quelque chose dessus [frigo]
Près du garde-manger, il y a un espace de rangement [espace]
Tu vas dans le salon [salon]
Tu vas vers le couloir [couloir]
";
        static bool SpaceKey = false;
        
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "cour":

                    if (!OutsideRoom.backdoorkey)
                    {
                        Console.WriteLine("Tu tires sur la porte arrière, mais elle est barrée");
                    } else
                    {
                        Console.WriteLine("Tu ouvres la porte arrière et sors dans ta cour");
                        Game.Transition<BackyardRoom>();
                    }

                    
                    
                    break;
                case "salon":
                    Console.WriteLine("Tu vas dans le salon.");
                    Game.Transition<FfLivingRoom>();

                    break;
                case "couloir":
                    Console.WriteLine("Tu vas dans le couloir.");

                    Game.Transition<FfHallwayRoom>();

                    break;

                case "espace":

                    Console.WriteLine("Tu ouvres la porte. Il fait noir." +
                        "\ntu essais d'ouvrir la lumière, mais l'ampoule reste éteinte.");
                    

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
