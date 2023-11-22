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
@"Tu es sur le patio de ta maison.
Lorsque tu regardes vers l'horizon, tu ne vois presque rien.
Un épais brouillard bloque ton champs de vision
À tes pieds tu trouves un tapis de bienvenu [tapis]
À ta gauche se trouve une boite au lettre [boite]
Malgré le brouillard, tu arrives à percevoir un arbre au loin. [arbre]
Tu décides de rentrer à l'intérieur [rentre] 
";
        static bool backdoorkey = false;
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "tapis":
                    Console.WriteLine("Tu regardes en dessous du tapis, mais tu ne trouves rien");
                    
                    break;
                case "boite":
                    Console.WriteLine("Tu regardes dans la boite au lettre, elle est vide...");

                    break;
                case "arbre":
                    Console.WriteLine("Une fois devant la télévision le grésillement arrête. Tu te sens hypnotiser par ce que tu vois puis... Rien...");

                    break;
                case "rentre":
                    Console.WriteLine("Le bruis de la télévision s'intensifie, tu n'entends que ça...");

                    break;
                case "clef":
                    Console.WriteLine("Tu plonge ta mains dans la boite au lettre et tâtes les rebords du bout des doigts." +
                        "\nTu trouves la clef que ton père avait caché");
                             backdoorkey = true;
                    break;

                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
