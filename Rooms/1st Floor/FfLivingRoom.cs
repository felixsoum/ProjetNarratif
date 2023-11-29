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
@"Te voilà dans ton salon. Tu te rappelle des bons souvenirs que tu as eu ici,
mais pourtant tu n'es pas heureux... 
Il ne semble pas t'avoir suivi, pour l'instant.....
Tu te déplace vers la cuisine [cuisine]
Tu vas vers le Couloir [couloir]
La porte du sous-sol tes parents s'y trouvent! [porte]
La télévision de ton salon [television]
Un sofa [sofa]
";

        bool remoteTv = false;
        internal override void ReceiveChoice(string choice)
        {
      

            switch (choice)
            {
                case "cuisine":
                    Console.WriteLine("Tu te diriges vers la cuisine");
                    Game.Transition<KitchenRoom>();

                    break;
                case "couloir":
                    Console.WriteLine("Tu te diriges vers le couloir.");
                    Game.Transition<FfHallwayRoom>();

                    break;
                case "porte": 
                    Console.WriteLine("Tu essaye d'ouvrir la porte, mais celle-ci est barrée.");
                    
                    break;

                case "sofa":
                    char couss1, couss2, couss3;
                    //Solution dans couloir
                    Console.WriteLine("Sur le sofa, il y a plusieurs coussins :\nCarré (1)\nRond (2)\nTriangle (3)\nRectangle (4)\nOval (5)");
                    Console.WriteLine("\nTu essaies de les repositionner : ");
                    Console.WriteLine("\nPremier coussin : ");

                    couss1 = Convert.ToChar(Console.ReadLine());

                    if (couss1 == '1')
                    {

                        Console.WriteLine("\nDeuxième coussin : ");
                        couss2 = Convert.ToChar(Console.ReadLine());

                        if(couss2 == '2')
                        {
                            Console.WriteLine("\nTroisième coussin : ");

                            couss3 = Convert.ToChar(Console.ReadLine());

                            if (couss3 == '3')
                            {
                                Console.WriteLine("En tassant les coussins, tu trouves la télécommande pour la télévision."); 
                                remoteTv = true;
                            } else
                            {
                                Console.WriteLine("Tu tasses le coussins, mais ne trouves rien.");
                            }
                        } else
                        {
                            Console.WriteLine("\nTroisième coussin : ");

                            couss3 = Convert.ToChar(Console.ReadLine());

                            Console.WriteLine("Tu tasses le coussins, mais ne trouves rien.");
                        }

                    } else
                    {
                        Console.WriteLine("\nDeuxième coussin : ");

                        couss2 = Convert.ToChar(Console.ReadLine());

                        Console.WriteLine("\nTroisième coussin : ");

                        couss3 = Convert.ToChar(Console.ReadLine());

                        Console.WriteLine("Tu tasses le coussins, mais ne trouves rien.");

                    }
                  
                    break;

                case "television":
                    if (!remoteTv)
                    {
                        Console.WriteLine("Tu t'approches de ta télévision,\nelle est éteinte.");
                    } else
                    {

                        Console.WriteLine("Tu ouvres la télévision, tu y vois un monsieur parler :"); 
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Un drame c'est produit dans le coins de Springfield qui choque la communauté. " +
                            "\nEn effet, c'est en soirée que le corps de la jeune...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nTu ne te sens plus bien...");
                        Console.WriteLine("Tu fixes l'écran de la télévision, ton coeur accélère");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nMarc Dumais fait face à quinze ans de prison au moins");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nTu vas être malade...");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nElle n'avait que huit ans...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nTu fermes la télévision..." +
                            "\nTa respiration tremble.");
                        if (Game.peur >= 1)
                        {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tu entends ses cris");
                        Console.ForegroundColor = ConsoleColor.White;
                        }
                        

                    }
                   

                    break;
                default:
                    Console.WriteLine("Commande invalide");
                    break;
            }
        }
    }
}
