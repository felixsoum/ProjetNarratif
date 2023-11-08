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
                        Console.WriteLine("Ton niveau de peur augmente...");
                        if (Bedroom.Scared1)
                        {
                            Console.WriteLine("Niveau de peur : 2 ");
                            Bedroom.Scared2 = true;
                        } else
                        {
                            Console.WriteLine("Ton niveau de peur augmente...");
                            Console.WriteLine("Niveau de peur : 1 ");
                            Bedroom.Scared1 = true;
                        }
                    } else
                    {
                        string ch = "";
                        Console.WriteLine("M.Tocson peut t'aider. ");
                       ch1: Console.Write("Écris oui pour utiliser son aide, \n ou non pour conserver son effet pour plus tard : ");
                        try
                        {
                            ch = Convert.ToString(Console.ReadLine());
                        } catch { Console.WriteLine("Commande invalide : "); goto ch1; }
                       

                        if (ch == "oui" ||  ch == "Oui")
                        {
                            Console.WriteLine("Tu regardes ton meilleur ami et il te réconforte.");
                            Console.WriteLine("Tu réussis à te calmer.");
                        }
                        if (ch == "non" || ch == "Non")
                        {
                            if (Bedroom.Scared1)
                            {
                                Console.WriteLine("Ton niveau de peur augmente...");
                                Console.WriteLine("Niveau de peur : 2 ");
                                Bedroom.Scared2 = true;
                            }
                            else
                            {
                                Console.WriteLine("Ton niveau de peur augmente...");
                                Console.WriteLine("Niveau de peur : 1 ");
                                Bedroom.Scared1 = true;
                            }
                        } else { Console.WriteLine("Commande invalide : "); goto ch1; }
                    }

                    Game.Transition<Bedroom>();
                    break;
                case "attendre":
                    Console.WriteLine("Le coffre s'ouvre et tu obiens une clé.");
                    
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
