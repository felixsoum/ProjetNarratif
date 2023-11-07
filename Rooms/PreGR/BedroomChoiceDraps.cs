using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class BedroomChoiceDraps : Room
    {
        internal static bool book;
        internal override string CreateDescription() =>
@"Pris de peur ton petit corps ne te répond plus, tu te glisse immédiatement sous tes draps.
Tu l'entends courir vers ta fenetre et l'ouvrir...
Un lourd bruit se fait entendre, suivi du grincement de ta porte d'entrée au premier étage.
Tu retires tes draps, il n'est plus dans ta chambre.

Tu regardes autours de toi :

Ta fenetre est toujours ouverte elle mène surement vers quelque part... [fenetre]
La porte de ta chambre. [porte]
Ton tiroir, tu gardes caché des informations utiles sur ta maison... [tiroir]
Tes livres préférés. [livres]
";

        internal override void ReceiveChoice(string choice)
        {
          

            switch (choice)
            {
                case "fenetre":
                    Console.WriteLine("Tu te diriges vers ta fenêtre ouverte et tu décide de passer de l'autre côté.");
                    Console.WriteLine("Tu te retrouve sur le toit de ton porche.");
                    Game.Transition<PorcheRoom>();
                    break;
                   
                case "porte":
                    if (!BedroomBedChoice.book)
                    {
                        Console.WriteLine("En te rapprochant de la porte de ta chambre, tu réalise que la poignée est plus haute que d'habitude.");
                    }
                    else
                    {
                        Console.WriteLine("Tu déposes le livres à tes pieds et grimpes dessus. Tu atteins finalement la poigné.");

                    }


                    break;
                case "3537":
                    Console.WriteLine("Tu ouvres le tirroir et trouves le plan de ta maison que tu avais dessiné!");

                    break;
                case "livres":
                    Console.WriteLine("Tu prends la pile de livres, ils te serviront!");
                    book = true;
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;

            }
        }
    }
}
