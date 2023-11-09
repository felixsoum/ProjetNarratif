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
                    if (!BedroomBedChoice.book)
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
                    Console.WriteLine("Ton tiroir s'ouvre et tu y trouves une note : ");
                    Console.WriteLine("\tMa cachette préféré :");
                    Console.WriteLine("\nIgnoré, c'est comme ça que je me sens quand tocson ne me répond plus. Ne t'en fais pas,\nje suis toujours ton ami malgré tout." +
                        "Veux-tu que je te chante une berçeuse pour que \ntu t'endorme? Imagine que nous somme tous les deux superman!Superman!Imagine!\nBattre les villains et sauver" +
                        "les innocents! Le rêve c'est clair! En me réveillant je serais superman, cette fois-ci, c'est sûr...");


                    break;
                case "livres":
                    Console.WriteLine("Tu prends la pile de livres, ils te serviront!");
                    book = true;
                    break;

                case "affiche":
                    Console.WriteLine("Tu te déplace vers l'affiche.");
                    Console.WriteLine("Dessus, tu contemple ton héro préféré, Superman. ");
                    Console.WriteLine("Dans son constume bleu, rouge et jaune, Superman t'a toujours inspiré.");

                    break;

                default:
                    Console.WriteLine("Commande invalide.");
                    break;

            }
        }
    }
}
