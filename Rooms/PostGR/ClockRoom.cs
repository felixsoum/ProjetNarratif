using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class ClockRoom : Room
    {
        internal override string CreateDescription() =>
@"??????????????????????????????????????????????
??????????????????????????????????????????????
????????????????????????
??????????????????????????? [escaliers]
????????????????????????? [jeu]
??????????????????????????????? [chambre]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "chambre":
                   if (Game.peur >= 1)
                    {
                        Console.WriteLine("Ton niveau de peur est trop élevé pour que tu puisses entrprendre cette action...");
                    } else 
                    { 
                        Console.WriteLine("Désorienté, tu cours vers ta chambre pour te réfugier!");
                        Game.Transition<BedroomPostGR>();
                    }
                    break;
                case "jeu":
                    Console.WriteLine("Pris de panique, tu cours te réfugier dans la salle de jeu!");
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
                    Console.WriteLine("Tu te diriges vers les escaliers d'un pas effrayé...");
                    Console.WriteLine("Tu les descends");
                    Game.Transition<FfLivingRoom>();

                    break;

                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
