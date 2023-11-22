using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class OutsideRoom : Room
    {
        internal override string CreateDescription() =>
@"Dans le Salon, Malgré que l'atmosphère soie chaleureuse, quelque chose cloche...
Une télévision grésille [television].
S'assoir sur le sofa [sofa].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "television":
                    Console.WriteLine("Une fois devant la télévision le grésillement arrête. Tu te sens hypnotiser par ce que tu vois puis... Rien...");
                    Game.Finish();
                    break;
                case "sofa":
                    Console.WriteLine("Le bruis de la télévision s'intensifie, tu n'entends que ça...");

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
