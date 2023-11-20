using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class UpperBathRoom : Room
    {
        internal override string CreateDescription() =>
@" Tu te précipite dans le bain et te caches derrière les rideaux.
Tu l'entends te chercher dans la salle de bain.
Puis, frustré de ne pas te trouver, il quitte la pièce.
Tu entends ses griffes qui graffignent le plancher.
Tu est curieux et sors la tête de ta cachette pour regarder le monstre [regarde]
Le son des griffes te dérange trop, bouche toi les oreilles et attends qu'il s'éloigne d'avantage [attendre]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "regarde":
                    Console.WriteLine("La curiosité prend le dessus sur toi et tu ne peux t'empêcher de le regarder...");
                    Console.WriteLine("Tu le vois...");
                    Console.WriteLine("Il se dirige vers la salle de jeux...");
                    Console.WriteLine("Il est hideux...");
                    Console.WriteLine("Il rentre dans la pièce...");
                    Console.WriteLine("Boum boum boum");
                    Console.WriteLine("Tu ressents le rythme de ton coeur dans tes oreilles...");
                    Console.WriteLine("Il ferme la porte...");
                    Console.WriteLine("Ton souffle accélère...");
                    if (!GameRoom.Tocson)
                    {
                        Game.peur++;
                        Console.WriteLine("Ton niveau de peur augmente...");
                        Console.WriteLine($"Niveau de peur : {Game.peur} ");
                        //if (Bedroom.Scared1)
                        //{
                        //    Console.WriteLine("Ton niveau de peur augmente...");
                        //    Console.WriteLine("Niveau de peur : 2 ");
                        //    Bedroom.Scared2 = true;
                        //} else
                        //{
                        //    Console.WriteLine("Ton niveau de peur augmente...");
                        //    Console.WriteLine("Niveau de peur : 1 ");
                        //    Bedroom.Scared1 = true;
                        //}

                    } else
                    {
                        string ch;
                        Console.WriteLine("M.Tocson peut t'aider. ");
                    ch1: Console.Write("Écris oui pour utiliser son aide,\nou non pour conserver son effet pour plus tard : ");

                        ch = Convert.ToString(Console.ReadLine());
                       
                       if (ch == "oui" || ch == "Oui" || ch == "non" || ch == "Non")
                       {
                             if (ch == "oui" ||  ch == "Oui")
                             {
                            Console.WriteLine("Tu regardes ton meilleur ami et il te réconforte.");
                            Console.WriteLine("Tu réussis à te calmer.");
                            Game.Transition<PostBathHall>();
                          
                             }
                            if (ch == "non" || ch == "Non")
                            {
                                Game.peur++;
                                Console.WriteLine("Ton niveau de peur augmente...");
                                Console.WriteLine($"Niveau de peur : {Game.peur} ");
                                Game.Transition<PostBathHall>();
                                //if (Bedroom.Scared1)
                                //{
                                //    Console.WriteLine("Ton niveau de peur augmente...");
                                //    Console.WriteLine("Niveau de peur : 2 ");
                                //    Bedroom.Scared2 = true;
                                //    Game.Transition<PostBathHall>();
                                //}
                                //else
                                //{
                                //    Console.WriteLine("Ton niveau de peur augmente...");
                                //    Console.WriteLine("Niveau de peur : 1 ");
                                //    Bedroom.Scared1 = true;
                                //    Game.Transition<PostBathHall>();
                                //}
                            }
                       }
                        else { Console.WriteLine("Commande invalide"); goto ch1; }




                    }

                    Game.Transition<PostBathHall>();
                    break;
                case "attendre":
                    Console.WriteLine("Tu fermes tes yeux et bouches tes oreilles");
                    Console.WriteLine("Tu comptes jusqu'à 100 et tu sors de ta cachettes");
                    Console.WriteLine("Tu sors dans le couloir");
                    Game.Transition<PostBathHall>();

                    break;
                default:
                    Console.WriteLine("Salut");
                    break;
            }
        }
    }
}
