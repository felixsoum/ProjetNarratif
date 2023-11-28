using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class PostBathHall : Room
    {
        internal override string CreateDescription() =>
@"Dans le couloir, un gros bruit retenti. 
L'horloge sonne, il est minuit.
Tu te diriges vers la salle de jeu [jeu]
Tu retourne dans ta chambre [chambre]
Tu descends les escaliers [escaliers]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "chambre":
                    Console.WriteLine("Tu te diriges rapidement vers ta chambre et tu y entre. ");
                    Game.Transition<BedroomPostGR>();
                    break;

                case "jeu":
                    Console.WriteLine("Tu avance face à la porte de la salle de jeu");
                    Console.WriteLine("C'est en ouvrant la porte que tu te rends compte de quelque chose...");
                    Console.WriteLine("Il est dans cette pièce...");
                    Console.WriteLine("Tu ne peux plus bouger...");
                    Console.WriteLine("Il se jette sur toi...");
                    Console.WriteLine("C'est la fin...");
                    Console.WriteLine("\n FIN 3 : Mourir de rire");
                    Bedroom.thirddeath = true;
                    Console.Write("Appuyez sur une touche pour recommencer : ");
                    Console.ReadKey();
                    Console.Clear();
                    Game.Transition<Bedroom>();

                    break;

                case "escaliers":
                    Console.WriteLine("Silencieusement, tu descends les escaliers");
                    Game.Transition<FfLivingRoom>();
                    
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
