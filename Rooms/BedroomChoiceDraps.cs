using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class BedroomChoiceDraps : Room
    {
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
                    Console.WriteLine("Salut");
                    break;
                case "porte": break;
                case "tiroir": break;
                case "livres": break;
               
            }
        }
    }
}
