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
À gauche, il y a une fenêtre [fenetre]
En face de toi, il y a un lit. [lit]
Au dessus se trouve une peinture [peinture]
À droite il y a des armoires murales [armoire]
Tu retournes dans le couloir [couloir]
";
        internal static bool Guessbathkey = false;
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
                    if (!Guessbathkey)
                    {
                        Console.WriteLine("Tu t'approches de la porte de la salle de bain" +
                        "Elle est barrée.");
                    } else
                    {
                        Console.WriteLine("Tu ouvres la porte de la salle de bain.");
                        Console.WriteLine("Tu l'entends déscendre les escaliers...");
                        Console.WriteLine("Fin de la béta");
                        Game.Finish();

                    }
                   

                    break;
                case "armoire":
                    int code;
                    Console.WriteLine("Tu es en face de l'armoire." +
                        "\nIl y a un cadenas à 4 chiffres dessus : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                   qst1: Console.Write("\nCode : ");
                    Console.ForegroundColor= ConsoleColor.White;
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

                case "lit":
                    Console.WriteLine("Zone en cours de dévelopement :( ");
                    Console.WriteLine("Cadeau pour le moment : ");
                    Game.UnPeur();

                    break;

                case "peinture":
                    if (!FfHallwayRoom.artkit)
                    {
                        Console.WriteLine("Tu t'approches de la peinture.\n");
                        Console.WriteLine("\n\tLyla");
                        Console.WriteLine("\nSur cette peinture, tu vois un lyla.");
                        Console.WriteLine("Tu te sens triste..." +
                            "\nC'étais son arbre préféré");
                    } else
                    {
                        int choi = 0;
                        Console.WriteLine("Tu t'approches de la peinture.\n");
                        Console.WriteLine("\n\tLyla");
                        Console.WriteLine("\nSur cette peinture, tu vois un lyla.");
                        Console.WriteLine("Tu te sens triste..." +
                            "\nC'étais son arbre préféré\n");
                        Console.WriteLine("Avec le kit d'art, tu peux investiguer la toile d'avantage : ");
                       qst4: Console.Write("(1) Oui" +
                            "(2) Non" +
                            "Choix : ");
                        try
                        {
                            choi = Convert.ToInt32(Console.ReadLine());
                        } catch
                        {
                            Console.WriteLine("Commande invalide\n"); goto qst4;
                        }
                        if (choi == 1)
                        {
                            Console.WriteLine("Tu te sens transporté dans la toile.");
                            Console.WriteLine("Zone en dévelopement :( ");
                            Console.WriteLine("Tu trouves une clef");

                        }
                    }
                    
                    

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
