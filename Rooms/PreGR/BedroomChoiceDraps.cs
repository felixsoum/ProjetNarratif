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
Ton tiroir, tu gardes caché des choses importantes pour toi, 
mais tu ne te souviens pas tu codes qui est caché dans la salle de jeu... [????]
Tes livres préférés. [livres]
Une affiche que ta mère t'avait offert pour ta fête [affiche] 
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
                    if (!BedroomChoiceDraps.book)
                    {
                        Console.WriteLine("En te rapprochant de la porte de ta chambre, tu réalise que la poignée est plus haute que d'habitude.");
                    }
                    else
                    {
                        Console.WriteLine("Tu déposes le livres à tes pieds et grimpes dessus. Tu atteins finalement la poigné.");
                        Console.WriteLine("Tu ouvres la porte");
                        Game.Transition<PreGRHallway>();
                    }


                    break;
                case "3537":
                    if (!FfHallwayRoom.artkit)
                    {
                        Console.WriteLine("Ton tiroir s'ouvre et tu y trouves un dessin : ");
                        Console.WriteLine("Tu reconnais ta chambre. " +
                            "\nSur ton lit, il y a un garçon." +
                            "\nIl pleure... " +
                            "En bas du dessin, les initiales R.D sont inscrites");

                    }
                    else
                    {

                        Console.WriteLine("Ton tiroir s'ouvre et tu y trouves un dessin : ");
                        Console.WriteLine("Tu reconnais ta chambre. " +
                            "\nSur ton lit, il y a un garçon." +
                            "\nIl pleure... " +
                            "En bas du dessin, les initiales R.D sont inscrites");
                    }

                    break;
                case "livres":
                    Console.WriteLine("Tu prends la pile de livres, ils te serviront!");
                    book = true;
                    break;

                case "affiche":
                    Console.WriteLine("Tu te déplace vers l'affiche.");
                    Console.WriteLine("Dessus, tu contemple ton héro préféré, Sentry. ");
                    Console.WriteLine("Dans son constume jaune, bleu et noir," +
                        "\nSentry à toujours été une source d'inspiration pour toi.");

                    break;

                default:
                    Console.WriteLine("Commande invalide.");
                    break;

            }
        }
    }
}
