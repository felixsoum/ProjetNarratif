using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class GameRoom : Room
    {
        internal static bool Tocson;
        internal override string CreateDescription() =>
@"Dans la salle de jeux, tu entends ses pas faire du bruit dans le couloir...
La porte de ta chambre s'ouvre et se ferme immédiatement. Tu peux l'entendre faire du bruit de l'autre côté du mur...
Tu vois une piscine à balles. [balles]
Tu peux aller ouvrir la porte de la salle de jeux [porte]
Tu ressents une présence réconfortante [????]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "balles":
                    int num1 = 0, num2 = 0, num3 = 0;

                  
                    
                    Console.WriteLine("Tu avances vers la piscines à balles.");
                    Console.WriteLine("Tu vois des balles : " +
                        "\n(1) noires, " +
                        "\n(2) vertes, " +
                        "\n(3) jaunes, " +
                        "\n(4) bleues " +
                        "\n(5) mauves");
                    Console.WriteLine("Entre 3 chiffres de 1 à 5 et trouves la combinaison : ");
                   qst1: Console.Write("Premier chiffre : ");
                    try { num1 = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst1; }
                    if (num1 <= 0 || num1 > 5)
                    {
                        Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst1;
                    }
                    if (num1 == 1) { Console.WriteLine("Noir!"); }
                    if (num1 == 2) { Console.WriteLine("Vert!"); }
                    if (num1 == 3) { Console.WriteLine("Jaune!"); }
                    if (num1 == 4) { Console.WriteLine("Bleu!"); }
                    if (num1 == 5) { Console.WriteLine("Mauve!"); }
                qst2: Console.Write("Deuxième chiffre : ");
                    try { num2 = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst2; }
                    if (num2 <= 0 || num2 > 5)
                    {
                        Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst1;
                    }
                    if (num2 == 1) { Console.WriteLine("Noir!"); }
                    if (num2 == 2) { Console.WriteLine("Vert!"); }
                    if (num2 == 3) { Console.WriteLine("Jaune!"); }
                    if (num2 == 4) { Console.WriteLine("Bleu!"); }
                    if (num2 == 5) { Console.WriteLine("Mauve!"); }
                qst3: Console.Write("Troisième chiffre : ");
                    try { num3 = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst3; }
                    if (num3 <= 0 || num3 > 5)
                    {
                        Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst1;
                    }
                    if (num3 == 1) { Console.WriteLine("Noir!"); }
                    if (num3 == 2) { Console.WriteLine("Vert!"); }
                    if (num3 == 3) { Console.WriteLine("Jaune!"); }
                    if (num3 == 4) { Console.WriteLine("Bleu!"); }
                    if (num3 == 5) { Console.WriteLine("Mauve!"); }

                    if (num1 == 3)
                    {
                        if (num2 == 4)
                        {
                            if (num3 == 1)
                            {
                                Console.WriteLine("Bonne combinaison!");
                                Console.WriteLine("En tassant les balles tu trouves un papier : ");
                                Console.WriteLine("\n\tFrançais exercice");
                                Console.WriteLine("Maman a 37 ans! Papa a 35 ans!");
                            }
                        }
                        
                    } else { 
                        Console.WriteLine("Mauvaise combinaison : ");
                        Console.WriteLine("Tu tasses les balles, mais tu ne trouves rien... ");
                    }
                    
                    break;

                case "porte":
                    Console.WriteLine("Tu ouvres la portes et entres dans le couloir...");
                    Game.Transition<UpperHallwayRoom>();
                    
                    break;

                case "tocson":
                    Console.WriteLine("\nTu trouves Tocson!");
                    Console.WriteLine("Il était là où tu l'avais laissé la dernière fois!");
                    Console.WriteLine("La prochaine fois que ton niveau de peur augmente, utilise M.Tocson pour nullifier l'effet. (Une seule utilisation)");
                    Tocson = true;

                    break;

              


              
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
