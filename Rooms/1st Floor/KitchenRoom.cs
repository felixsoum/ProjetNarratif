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
                    if (!GuessRoom.light)
                    {
                            Console.WriteLine("Tu ouvres la porte. Il fait noir." +
                        "\ntu essais d'ouvrir la lumière, mais l'ampoule reste éteinte.");
                    } else
                    {
                        Console.WriteLine("Dans l'espace de rangement, " +
                            "\ntu trouves des planches de bois ainsi qu'une note : " +
                            "\nJ'ai déplacé la bouffe du chat, elle est dans la boite en bois dans la cour," +
                            "mais j'ai échapé la clef quelque part dans le jardin..." +
                            "\n\n\tMaman");

                        BackyardRoom.ladder = true;
                    }
                   
                    

                    break;

                case "frigo":

                    Console.WriteLine("Tu vois une note de ton père sur le frigo : " +
                        "\nJ'ai changé la cachette de la clef!" +
                        "\nElle est dans la boite aux [lettres]!");


                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
