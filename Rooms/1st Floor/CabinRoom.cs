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
À ta droite, tu remarques une petite valise [valise]
Tu sors de la cabane. [sors]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "sors":
                    Console.WriteLine("Tu te retournes et descends l'échelle.");
                    Game.Transition<BackyardRoom>();
                    
                    break;
                case "valise":
                    Console.WriteLine("Tu t'approches de la valise et tu l'ouvres");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tu trouves tes crayons et tes pinceaux");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Tu as découvert un nouveau moyen de voir l'art.");
                    FfHallwayRoom.artkit = true;
                    break;
                case "dessin":
                    Console.WriteLine("Tu t'approches du dessin.");
                    Console.WriteLine("En le regardant, tu ne peux t'empêcher de pleurer." +
                        "\nTu y vois ta cabane ainsi qu'une silhouette familière." +
                        "\nElle sourit." +
                        "\nEn bas du dessin, les initiales L.D sont inscrites.");
                    if (FfHallwayRoom.artkit == true)
                    {
                        Console.WriteLine("Tu utilise ton kit d'art.");
                        Console.WriteLine("Nouvelle mémoire débloquée");

                        Console.WriteLine("\nMémoire 1 :\n ");

                        Console.ForegroundColor= ConsoleColor.Magenta;
                        Console.WriteLine("Regarde regarde! Papa à finit!");
                        Console.WriteLine("Viens! Je veux voir ! ");
                        Console.WriteLine("Waa! Regard tout l'espace qu'on a, on va pouvoir peinturer ici !");
                        Console.WriteLine("C'est notre maison à nous, notre fort !");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nLes enfants! On mange!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nFin de la mémoire\n");
                        Console.WriteLine("Tu reprends t'es esprits." +
                            "Tu essuies tes larmes et esquisses un sourire.");

                        Game.UnPeur();
                    }
                    

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
