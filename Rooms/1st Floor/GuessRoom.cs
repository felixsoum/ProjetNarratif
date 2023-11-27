using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class GuessRoom : Room 
    {
        internal override string CreateDescription() =>
@"Tu rentres dans la chambre d'invité.
Tout est bien rangé, comme si personne n'y était jamais rentré.
Au fond de la pièce se trouve une salle de bain [bain]
À gauche, il y a une fenêtre [fenêtre]
En face de toi, il y a un lit. [lit]
Au dessus se trouve une peinture [peinture]
À droite il y a des armoires murales [armoir]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "fenetre":
                    int ch = 0;
                    if (Game.peur >= 1)
                    {
                        Console.WriteLine("Tu t'approches de la fenêtre." +
                            "\nChaque pas que tu fais, tu peux ressentir ton coeur qui bat de plus en plus vite.\n" +
                            "Ton souffle accélère et des frissons traversent ton corps.\n" +
                            "Tu entends sa voix, son rire, ses cris...\n" +
                            "Tu les vois pleurer...\n" +
                            "Tu recules" +
                            "\nTu n'es pas capable de surmonter tes sentiments actuellement...");
                    } else
                    {
                        if(!FfHallwayRoom.artkit)
                        {
                            Console.WriteLine("Tu t'approches de la fenêtre." +
                          "\nChaque pas que tu fais, tu peux ressentir ton coeur qui bat de plus en plus vite.\n" +
                          "Ton souffle accélère et des frissons traversent ton corps.\n" +
                          "Tu entends sa voix, son rire, ses cris...\n" +
                          "Tu les vois pleurer...\n" +
                          "Tu continues d'avancer." +
                          "Tu es devant la fenêtre." +
                          "\nAu loin, à travers le brouillard, tu apperçois un arbre. " +
                          "\nUn post-it est collé sur la fenêtre." +
                          "\nTu peux y lire ARBRE MAUDIT" +
                          "\nPrès du post-it se trouve un dessin." +
                          "\nDessus tu vois un garçon et une fille jouer ensemble");

                        } else
                        {
                            Console.WriteLine("Tu t'approches de la fenêtre." +
                          "\nChaque pas que tu fais, tu peux ressentir ton coeur qui bat de plus en plus vite.\n" +
                          "Ton souffle accélère et des frissons traversent ton corps.\n" +
                          "Tu entends sa voix, son rire, ses cris...\n" +
                          "Tu les vois pleurer...\n" +
                          "Tu continues d'avancer." +
                          "Tu es devant la fenêtre." +
                          "\nAu loin, à travers le brouillard, tu apperçois un arbre. " +
                          "\nUn post-it est collé sur la fenêtre." +
                          "\nTu peux y lire ARBRE MAUDIT" +
                          "\nPrès du post-it se trouve un dessin." +
                          "\nDessus tu vois un garçon et une fille jouer ensemble");

                        qst: Console.Write("\nAvec le kit d'art, tu peux investiguer d'avantage ce dessin :\n(1) oui\n(2) non\nTon choix : ");
                            try
                            {
                                ch = Convert.ToInt32(Console.ReadLine());
                            }
                            catch { Console.WriteLine("Option non valide"); goto qst; }
                            if (ch == 1)
                            {
                                Console.WriteLine("Tu te sens transporté, tu entres dans la peinture...");
                                
                            }
                            if (ch == 2)
                            {
                                Console.WriteLine("Tu décides de ne pas investiguer...");
                            }
                        }
                       

                    }
                   
                    
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
