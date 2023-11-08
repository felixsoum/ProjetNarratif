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
Tu aimerais que ton meilleur ami Monsieur Tocson soit avec toi pour te donner du courage.
Tu vois une piscine à balles. [balles]
Tu peux aller ouvrir la porte de la salle de jeux [porte]
Tu retournes à la fenêtre [fenetre]
Tu ressents une présence bienveillante [M.Tocson]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "balles":
                    int num1 = 0, num2 = 0, num3 = 0, rslt = 0;

                  
                    
                    Console.WriteLine("Tu avances vers la piscines à balles.");
                    Console.WriteLine("Tu vois des balles jaunes, vertes, bleues, rouges et mauves");
                    Console.WriteLine("Entre 3 chiffres de 1 à 5 et trouves la combinaison : ");
                   qst1: Console.Write("Premier chiffre : ");
                    try { num1 = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst1; }
                    if (num1 <= 0 || num1 > 5)
                    {
                        Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst1;
                    }
                    if (num1 == 1) { Console.WriteLine("Jaune!"); }
                    if (num1 == 2) { Console.WriteLine("Vert!"); }
                    if (num1 == 3) { Console.WriteLine("Bleu!"); }
                    if (num1 == 4) { Console.WriteLine("Rouge!"); }
                    if (num1 == 5) { Console.WriteLine("Mauve!"); }
                qst2: Console.Write("Premier chiffre : ");
                    try { num2 = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst2; }
                    if (num2 <= 0 || num2 > 5)
                    {
                        Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst1;
                    }
                    if (num2 == 1) { Console.WriteLine("Jaune!"); }
                    if (num2 == 2) { Console.WriteLine("Vert!"); }
                    if (num2 == 3) { Console.WriteLine("Bleu!"); }
                    if (num2 == 4) { Console.WriteLine("Rouge!"); }
                    if (num2 == 5) { Console.WriteLine("Mauve!"); }
                qst3: Console.Write("Troisième chiffre : ");
                    try { num3 = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst3; }
                    if (num3 <= 0 || num3 > 5)
                    {
                        Console.WriteLine("Il faut entrer un chiffre entre 1 et 5! "); goto qst1;
                    }
                    if (num3 == 1) { Console.WriteLine("Jaune!"); }
                    if (num3 == 2) { Console.WriteLine("Vert!"); }
                    if (num3 == 3) { Console.WriteLine("Bleu!"); }
                    if (num3 == 4) { Console.WriteLine("Rouge!"); }
                    if (num3 == 5) { Console.WriteLine("Mauve!"); }

                    if (num1 == 3)
                    {
                        if (num2 == 4)
                        {
                            if (num3 == 1)
                            {
                                Console.WriteLine("Bonne combinaison!");
                                Console.WriteLine("En tassant les balles tu trouves un papier : ");
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

                case "fenetre":

                    Console.WriteLine("En te retournant vers la fenêtre, tu remarque que celles-ci à disparue!");

                    break;


              
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
