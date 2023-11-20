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
La télévision de ton salon [television]
Un sofa [sofa]
";

        bool remoteTv = false;
        internal override void ReceiveChoice(string choice)
        {
      

            switch (choice)
            {
                case "cuisine":
                    Console.WriteLine("Une fois devant la télévision le grésillement arrête. Tu te sens hypnotiser par ce que tu vois puis... Rien...");
                    
                    break;
                case "couloir":
                    Console.WriteLine("Le bruis de la télévision s'intensifie, tu n'entends que ça...");

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
                        Console.WriteLine();
                    }
                   

                    break;
                default:
                    Console.WriteLine("Commande invalide");
                    break;
            }
        }
    }
}
