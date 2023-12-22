using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class FfHallwayRoom : Room
    {
        internal override string CreateDescription()
        {
            if (Game.peur == 2)
            {
              
                return
  @"Le couloir est mal éclairé, quelque chose est différent de d'habitude...
Te calmer pourrait surement t'aider à voir les choses différament.
Tu vas dans la cuisine [cuisine]
Tu te diriges vers la chambre d'invités [chambre]
Tu vas en direction de la porte d'entrée [porte]
";
            }
            else
            {
                return
                       @"Tu es dans le couloir de ta maison. 
Tu te souviens de tous les gens qui sont passés par là.
Leurs visages sont toutefois floux... 
Tu sembles te perdre petit à petit...  
Il y a une peinture sur le mur [peinture]
Tu vas vers la porte d'entrée [entree]
Tu entres dans la chambre d'invités [chambre]
Tu te diriges vers la cuisine [cuisine]
";
            }

    


        }
       internal static bool artkit = false;
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "cuisine":
                    Console.WriteLine("Tu vas dans la cuisine");
                    Game.Transition<KitchenRoom>();
                    break;

                case "chambre":
                    Console.WriteLine("Tu entres dans la chambre");
                    Game.Transition<GuessRoom>();
                    break;

                case "peinture":

                    int ch = 0;

                    if (!artkit)
                    {
                        Console.WriteLine("\n\tPaysage de printemps");
                        Console.WriteLine("\n C'est la peinture préféré de tes parents.\nDessus on y retrouve une montagne, une maison et un soleil qui se couche." +
                            "\nTu as toujours trouvé qu'il y avait quelque chose de malsaint dans cette toile,\nmais tu ne sais pas quoi...");
                    //} else
                    //{
                    //    Console.WriteLine("\n\tPaysage de printemps");
                    //    Console.Write("\n C'est la peinture préféré de tes parents.\nDessus on y retrouve une montagne, une maison et un soleil qui se couche." +
                    //        "\nTu as toujours trouvé qu'il y avait quelque chose de malsaint dans cette toile,\nmais tu ne sais pas quoi...");

                    //   qst: Console.Write("\nAvec le kit de peinture, tu peux investiguer d'avantage cette toile :\n(1) oui\n(2) non\nTon choix : ");
                    //    try
                    //    {
                    //        ch = Convert.ToInt32(Console.ReadLine());
                    //    } catch { Console.WriteLine("Option non valide"); goto qst; }
                    //   if (ch == 1)
                    //    {
                    //        Console.WriteLine("Tu te sens transporté, tu entres dans la peinture...");
                    //        Game.Transition<PeintureCouloirRoom>();
                    //    }
                    //    if (ch == 2)
                    //    {
                    //        Console.WriteLine("Tu décides de ne pas investiguer...");
                    //    }


                    }
                    

                    break;

                case "porte":
                    Console.WriteLine("Lorsque tu te tournes vers la porte d'entrée, elle te parait loin." +
                        "\nTu avances vers celle-ci, mais tu sembles incapable de l'atteindre");

                    break;

                case "entree":
                    Console.WriteLine("Tu arrives devant la porte d'entrée,\nTu l'ouvres et sors de ta maison.");
                    Game.Transition<OutsideRoom>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
