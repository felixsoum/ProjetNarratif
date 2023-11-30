using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class GuessRoom : Room 
    {
        internal static bool light = false;
        internal override string CreateDescription() =>
@"Tu rentres dans la chambre d'invité.
Tout est bien rangé, comme si personne n'y était jamais rentré.
Au fond de la pièce se trouve une salle de bain [bain]
À gauche, il y a une fenêtre [fenêtre]
En face de toi, il y a un lit. [lit]
Au dessus se trouve une peinture [peinture]
À droite il y a des armoires murales [armoire]
Tu retournes dans le couloir [couloir]
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
                                Console.WriteLine("");
                                
                            }
                            if (ch == 2)
                            {
                                Console.WriteLine("Tu t'éloignes de la fenêtre");
                            }
                        }
                       

                    }
                   
                    
                    break;
                case "bain":
                    Console.WriteLine("Tu t'approches de la porte de la salle de bain" +
                        "Elle est barrée de l'autre côté");

                    break;
                case "armoire":
                    int code;
                    Console.WriteLine("Tu es en face de l'armoire." +
                        "\nIl y a un cadenas dessus : ");
                   qst1: Console.Write("\nCode : ");
                    try
                    {
                        code = Convert.ToInt32(Console.ReadLine()); 

                    } catch { Console.WriteLine("Commande invalide"); goto qst1; }
                    if (code == 1158)
                    {
                        Console.WriteLine("Tu déverouille le cadenas et ouvres les portes." +
                            "\nIl y a un compteur électrique derrière");
                        int cui = 0, sal = 1, cou = 1, cha = 1, rslt = 0;
                        char choix = ' ';
                        Console.WriteLine("Il y a 4 interrupteur devant toi (1 - 4) " +
                               "\nou appuis sur 0 pour quitter : ");
                        Console.WriteLine($"\n\tCuisine : {cui}" +
                            $"\n\tSalon   : {sal}" +
                            $"\n\tCouloir : {cou}" +
                            $"\n\tChambre : {cha}\n");
                        do
                        {
                            
                           
                                qst2: Console.Write("Interrupteur choisi : ");
                                try
                            {
                                choix = Convert.ToChar(Console.ReadLine());
                            } catch
                            {
                                Console.WriteLine("Commande invalide : "); goto qst2;
                            }
                            switch( choix )
                            {
                                case '1': 
                                    cui = cui + 1;
                                    if (cui == 2)
                                    {
                                        cui = 0;
                                    }
                                    sal = sal + 0;
                                    if (sal == 2)
                                    {
                                        sal = 0;
                                    }
                                    cou = cou + 1;
                                    if (cou == 2)
                                    {
                                        cou = 0;
                                    }
                                    cha = cha + 0;
                                    if (cha == 2)
                                    {
                                        cha = 0;
                                    }

                               Console.WriteLine($"\n\tCuisine : {cui}" +
                               $"\n\tSalon   : {sal}" +
                               $"\n\tCouloir : {cou}" +
                               $"\n\tChambre : {cha}\n");

                                    rslt = cui + sal + cou + cha;
                                    if (rslt == 4)
                                    {
                                        Console.WriteLine("Tu entends un click");
                                        light = true;
                                            
                                    } else
                                    {
                                        Console.WriteLine("Rien ne se passe...");
                                    }
                                    break;

                                case '2':
                                    cui = cui + 1;
                                    if (cui == 2)
                                    {
                                        cui = 0;
                                    }
                                    sal = sal + 1;
                                    if (sal == 2)
                                    {
                                        sal = 0;
                                    }
                                    cou = cou + 1;
                                    if (cou == 2)
                                    {
                                        cou = 0;
                                    }
                                    cha = cha + 1;
                                    if (cha == 2)
                                    {
                                        cha = 0;
                                    }

                                    Console.WriteLine($"\n\tCuisine : {cui}" +
                                    $"\n\tSalon   : {sal}" +
                                    $"\n\tCouloir : {cou}" +
                                    $"\n\tChambre : {cha}\n");

                                    rslt = cui + sal + cou + cha;

                                    if (rslt == 4)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Tu entends un click");
                                        Console.ForegroundColor= ConsoleColor.White;
                                        light = true;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Rien ne se passe...");
                                    }
                                    break;
                                   
                                case '3':
                                    cui = cui + 1;
                                    if (cui == 2)
                                    {
                                        cui = 0;
                                    }
                                    sal = sal + 0;
                                    if (sal == 2)
                                    {
                                        sal = 0;
                                    }
                                    cou = cou + 1;
                                    if (cou == 2)
                                    {
                                        cou = 0;
                                    }
                                    cha = cha + 1;
                                    if (cha == 2)
                                    {
                                        cha = 0;
                                    }

                                    Console.WriteLine($"\n\tCuisine : {cui}" +
                                    $"\n\tSalon   : {sal}" +
                                    $"\n\tCouloir : {cou}" +
                                    $"\n\tChambre : {cha}\n");

                                    rslt = cui + sal + cou + cha;
                                    if (rslt == 4)
                                    {
                                        Console.WriteLine("Tu entends un click");
                                        light = true;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Rien ne se passe...");
                                    }
                                    break;

                                case '4':
                                    cui = cui + 0;
                                    if (cui == 2)
                                    {
                                        cui = 0;
                                    }
                                    sal = sal + 1;
                                    if (sal == 2)
                                    {
                                        sal = 0;
                                    }
                                    cou = cou + 1;
                                    if (cou == 2)
                                    {
                                        cou = 0;
                                    }
                                    cha = cha + 0;
                                    if (cha == 2)
                                    {
                                        cha = 0;
                                    }

                                    Console.WriteLine($"\n\tCuisine : {cui}" +
                                    $"\n\tSalon   : {sal}" +
                                    $"\n\tCouloir : {cou}" +
                                    $"\n\tChambre : {cha}");

                                    rslt = cui + sal + cou + cha;
                                    if (rslt == 4)
                                    {
                                        Console.WriteLine("Tu entends un click");
                                        light = true;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Rien ne se passe...");
                                    }
                                    break;
                                default: Console.WriteLine("Commande invalide : "); break;
                            }
                        } while (choix != '0');
                    }   

                    break;

                case "couloir":
                    Console.WriteLine("Tu retournes vers le couloir.");
                    Game.Transition<FfHallwayRoom>();

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
