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
            if (Game.peur >= 1)
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

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "cuisine":
                    Console.WriteLine("Une fois devant la télévision le grésillement arrête. Tu te sens hypnotiser par ce que tu vois puis... Rien...");
                    Game.Finish();
                    break;

                case "chambre":
                    Console.WriteLine("Le bruis de la télévision s'intensifie, tu n'entends que ça...");

                    break;

                case "peinture":
                    Console.WriteLine("Le bruis de la télévision s'intensifie, tu n'entends que ça...");

                    break;

                case "porte":
                    Console.WriteLine("Le bruis de la télévision s'intensifie, tu n'entends que ça...");

                    break;

                case "entree":
                    Console.WriteLine("Le bruis de la télévision s'intensifie, tu n'entends que ça...");

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
