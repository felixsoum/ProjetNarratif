﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class BedroomPostGR : Room
    {
        internal override string CreateDescription() =>
@"Tu te retrouves dans ta chambre, il l'a sacagé...
Tu ne te sens pas à l'aise ici, dépêche toi...
Ton tiroir, tu gardes caché des choses importantes pour toi, 
mais tu ne te souviens pas tu codes qui est caché dans la salle de jeu... [????]
Tes livres préférés. [livres]
Une affiche que ta mère t'avait offert pour ta fête [affiche] 
Tu retournes dans le couloir [couloir]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                //tiroir cache ta cachette prefere au premier etage . texte avec majuscule
                case "chambre":
                    Console.WriteLine("Tu retournes dans ta chambre.");
                    Game.Transition<Bedroom>();
                    break;

                case "3735":
                    
                    if(!FfHallwayRoom.artkit)
                    {
                        Console.WriteLine("Ton tiroir s'ouvre et tu y trouves un dessin : ");
                        Console.WriteLine("Tu reconnais ta chambre. " +
                            "\nSur ton lit, il y a un garçon." +
                            "\nIl pleure... " +
                            "En bas du dessin, les initiales R.D sont inscrites");
                 
                    } else
                    {

                        Console.WriteLine("Ton tiroir s'ouvre et tu y trouves un dessin : ");
                        Console.WriteLine("Tu reconnais ta chambre. " +
                            "\nSur ton lit, il y a un garçon." +
                            "\nIl pleure... " +
                            "En bas du dessin, les initiales R.D sont inscrites");
                    }
                   
                   
                    break;

                case "livres": 
                    if (BedroomBedChoice.book)
                    {
                        Console.WriteLine("Là où tes livres préférés se situaient...");
                        Console.WriteLine("Le temps où tout était normal te manque énormément...");
                    } else { Console.WriteLine("Une pile de livres qui contient tes livres préférés.");
                        Console.WriteLine("Ils ne te servirons probablement pas...");
                    }
                    break;

                case "affiche": 
                    Console.WriteLine("Ton affiche de Sentry, il l'a déchiré lorsqu'il était dans ta chambre...");
                    break;

                case "couloir": 
                    Console.WriteLine("En ouvrant la porte tu entends la porte de la salle de jeu s'ouvrir...");
                    Console.WriteLine("Tu n'a pas le choix, tu cours et descends les escaliers...");
                    Console.WriteLine("Fin de la beta");
                    Game.Finish();

                    break;

                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
