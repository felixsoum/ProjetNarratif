﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mon_premier_jeu
{
    internal class Program
    {


        static void Main(string[] args)
        {
        //idées de succès: - suicide réussi(se suicider, pas tué femme et enfant, dire aurevoir à la famille et laisser une note aux enfants ?? ne pas tué de collègues ou ne pas aller au travail??)
        //                 - mort avec classe(se suicider, prendre un bain et se raser)
        //                 - suicide raté(se suicider, ne pas dire aurevoir, ne pas laisser de note)
        //                 - la survie à quel prix?(ne pas se suicider)
        //                 - la fin?(se suicider)
        //                 - famille(découvrez le nom de toute votre famille)
        //                 - merci d'avoir joué(faire toutes les fins au moins une fois)
        //                 - surhomme(avoir réussi le QTE final et sauvé votre famille)
        //fin rentrer maison manger femme et enfants
        //fin forêt aller suicide
        //fin forêt retour suicide ? + collègues tués?
        //si prendre repas midi dans la cuisine faim contenu à midi et collègue sauvé sinon assouvir faim avec collègue
        start:;
            int habitsok = 0;//variable qui vérifie la sortie de la chambre
            int cont = 0;//variable message suicidaire rasoir
            string votre_femme = "votre femme";
            string votre_fils = "votre fils";
            string votre_fille = "votre fille";
            bool bon_mat_f = false;
            bool bon_mat_e = false;
            bool sac_à_lunch = false;

            string choixchamb = " ";
            Console.WriteLine("vous vous réveillez dans votre lit, votre femme est déja levée.");
            Console.ReadKey();
            Console.WriteLine("vous vous levez de votre lit et observez autour de vous.");
            Console.ReadKey();
        chambre:;
            Console.WriteLine("dans votre chambre vous voyez la porte des [toilettes], la porte qui mène au [couloir] d'ou vous sentez une bonne odeur.");
            Console.ReadKey();
            Console.WriteLine("il y a la [fenetre] devant vous et sur votre commode des [habits].");
            Console.ReadKey();
            Console.Write("où voulez vous aller?");
            Console.Write(" : ");
            choixchamb = Convert.ToString(Console.ReadLine());
            switch (choixchamb)
            {
                case "habits": //obligatoire
                    {
                        if (habitsok == 0)
                        {
                            Console.WriteLine("\nvous enfilez pour la cinquième fois cette semaine un costume 3 pièce gris");
                            Console.ReadKey();
                            Console.WriteLine("vous mettez votre cravate bleue.");
                            Console.ReadKey();
                            Console.WriteLine("puis vous déposez votre pyjama sur la commode\n");
                            habitsok = habitsok + 1;
                            Console.ReadKey();
                            goto chambre;
                        }
                        else
                        {
                            Console.WriteLine("vous ne voyez que votre pyjama sur la commode.");
                            Console.ReadKey();
                            Console.WriteLine("vous êtes prêt pour aller travailler.");
                            Console.ReadKey();
                            goto chambre;
                        }
                    }
                    break;

                case "toilettes"://optionnel
                    {
                        string choixbain = " ";
                        Console.WriteLine("\nvous entrez dans votre salle de bain et vous sentez un frisson vous parcourir le corps.");
                        Console.ReadKey();
                    salledebain:;
                        Console.WriteLine("vous retrouvez votre [bain] devant vous, votre lavabo avec un [miroir] au dessus à votre gauche.");
                        Console.ReadKey();
                        Console.WriteLine("votre [rasoir] est posé sur le lavabo et les [toilettes] sont à votre droite.");
                        Console.ReadKey();
                        Console.WriteLine("il y a aussi la [porte] qui mène à votre chambre derrière vous.");
                        Console.ReadKey();
                        Console.Write("que voulez vous faire : ");
                        choixbain = Convert.ToString(Console.ReadLine());
                        switch (choixbain)
                        {
                            case "porte"://retour
                                {
                                    Console.WriteLine("\nvous soupirez, puis vous sortez de la salle de bain en refermant la porte derrière vous.\n");
                                    Console.ReadKey();
                                    goto chambre;
                                }
                                break;

                            case "miroir":
                                {
                                    Console.WriteLine("\nvous tournez la tête à gauche et regardez dans votre miroir.");
                                    Console.ReadKey();
                                    Console.WriteLine("vous soupirez.");
                                    Console.ReadKey();
                                    Console.WriteLine("vous ne vous reconnaissez toujours pas.");
                                    Console.ReadKey();
                                    Console.WriteLine("vous regardez autour de vous.");
                                    Console.ReadKey();
                                    goto salledebain;
                                }
                                break;

                            case "rasoir":
                                {

                                    if (cont == 0)
                                    {
                                        Console.WriteLine("\nvous vous approchez du lavabo.");
                                        Console.ReadKey();
                                        Console.WriteLine("vous prenez votre rasoir et commencez à vous raser.");
                                        Console.ReadKey();
                                        Console.WriteLine("vous vous coupez en vous rasant et en levant les yeux vers le mirroir vous voyez qu'ils ont changés");//indice sur l'histoire
                                        Console.ReadKey();
                                        Console.WriteLine("vous essuyez difficilement le sang sur votre joue.");
                                        Console.ReadKey();
                                        Console.WriteLine("vous finissez de vous raser et observez le rasoir pendant quelques secondes avant de le reposer.\n");
                                        Console.ReadKey();
                                        cont = cont + 1;
                                        goto salledebain;
                                    }
                                    if (cont == 3) //easter egg teaser
                                    {
                                        Console.WriteLine("\nvous : je ne suis pas encore sur d'en être capable.\n");
                                        cont = cont + 1;
                                        Console.ReadKey();
                                        goto salledebain;
                                    }
                                    else
                                    {
                                        Console.WriteLine("je me suis déja rasé.\n");
                                        cont = cont + 1;
                                        Console.ReadKey();
                                        goto salledebain;
                                    }
                                }
                                break;

                            case "toilettes":
                                {
                                    Console.WriteLine("\nvous tournez la tête à droite vers votre toilette.");
                                    Console.ReadKey();
                                    Console.WriteLine("je n'ai pas envie d'aller au toilette\n");
                                    Console.ReadKey();
                                    goto salledebain;
                                }
                                break;

                            case "bain":
                                {
                                    Console.WriteLine("\nvous faites couler de l'eau brulante dans le bain.");
                                    Console.ReadKey();
                                    Console.WriteLine("une fois qu'il est rempli vous entrez dedans.");
                                    Console.ReadKey();
                                    Console.WriteLine("vous vous rappelez l'époque lointaine où la chaleur de l'eau vous réconfortait");
                                    Console.ReadKey();
                                    Console.WriteLine("cela fait longtemps qu'elle ne vous fait plus rien.\n");
                                    Console.ReadKey();
                                    goto salledebain;
                                }
                                break;

                            default:
                                {
                                    Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                    Console.ReadKey();
                                    goto salledebain;
                                }
                                break;
                        }
                    }
                    break;

                case "fenetre"://optionnel
                    {
                    fenetre:;
                        Console.WriteLine("\nvous vous approchez de la fenêtre, ouvrez les rideaux et regardez dehors.");
                        Console.ReadKey();
                        Console.WriteLine("le soleil est caché par une épaisse couche de nuages et les gens courent pour arriver au travail à temps.");
                        Console.ReadKey();
                        Console.WriteLine("vous souriez légèrement puis vous faite demi-tour.\n");
                        Console.ReadKey();
                        goto chambre;
                    }
                    break;

                case "couloir"://obligatoire
                    {
                        if (habitsok != 1)
                        {
                            Console.WriteLine("\nvous : je ferais mieux de m'habiller pour le travail tant que je suis dans ma chambre.\n");
                            Console.ReadKey();
                            goto chambre;
                        }
                        else
                        {
                            string choixcoul = " ";
                            Console.WriteLine("\nvous ouvrez la porte de votre chambre et suivez la bonne odeur jusqu'au couloir.");
                            Console.ReadKey();
                        couloir:;
                            Console.WriteLine("la porte de la chambre des [enfants] est ouverte.");
                            Console.ReadKey();
                            Console.WriteLine("vous avez la [porte] d'entrée derrière vous ainsi que celle de votre [chambre].");
                            Console.ReadKey();
                            Console.WriteLine("vous entendez des rires d'enfant depuis la [cuisine].");
                            Console.ReadKey();
                            Console.Write("où voulez vous aller? : ");
                            choixcoul = Convert.ToString(Console.ReadLine());

                            switch (choixcoul)
                            {
                                case "chambre": //retour
                                    {
                                        Console.WriteLine("\nvous faites demi-tour et vous retournez dans votre chambre.\n");
                                        Console.ReadKey();
                                        goto chambre;
                                    }
                                    break;

                                case "enfants": //optionnel
                                    {
                                        string chambenf = " ";
                                        Console.WriteLine("\nvous entrez dans la chambre de vos enfants.");
                                        Console.ReadKey();
                                    chambre_enfants:;
                                        Console.WriteLine("vous voyez les lits de votre fille et de votre fils avec une [photo] de famille au dessus.");
                                        Console.ReadKey();
                                        Console.WriteLine("il y a divers [travaux] manuels sur les murs.");
                                        Console.ReadKey();
                                        Console.WriteLine("il y a aussi du [papier] et un crayon sur leur bureau.");
                                        Console.ReadKey();
                                        Console.WriteLine("il y a la [porte] du couloir derrière vous.");
                                        Console.ReadKey();
                                        Console.Write("que voulez vous faire? : ");
                                        chambenf = Convert.ToString(Console.ReadLine());

                                        switch (chambenf)
                                        {
                                            case "porte":// retour
                                                {
                                                    Console.WriteLine("\nvous soupirez.");
                                                    Console.ReadKey();
                                                    Console.WriteLine("vous fermez la porte de la chambre de vos enfants derrière vous.");
                                                    Console.ReadKey();
                                                    goto couloir;
                                                }
                                                break;

                                            case "photo":
                                                {
                                                    Console.WriteLine("\nvous vous approchez des lit de vos enfant.");
                                                    Console.ReadKey();
                                                    Console.WriteLine("vous regardez la photo au dessus du lit de votre fille.");
                                                    Console.ReadKey();
                                                    Console.WriteLine("vous avez toujours préféré votre fille mais personne ne le sait.");
                                                    Console.ReadKey();
                                                    Console.WriteLine("ce n'est pas la seul chose que les autres ne savent pas.");
                                                    Console.ReadKey();
                                                    Console.WriteLine("vous avez vraiments de beaux enfants avec Béatrice\n");
                                                    Console.ReadKey();
                                                    votre_femme = "Béatrice";
                                                    goto chambre_enfants;
                                                }
                                                break;

                                            case "papier":
                                                {
                                                    Console.WriteLine("\nvous vous approchez du bureau de vos enfants");
                                                    Console.ReadKey();
                                                    Console.WriteLine("vous prenez le crayon et écrivez une note chaleureuse pour vous enfants.");
                                                    Console.ReadKey();
                                                    Console.WriteLine("ce sont de bons enfants ils le méritent.\n");
                                                    Console.ReadKey();
                                                    goto chambre_enfants;
                                                }
                                                break;

                                            case "travaux":
                                                {
                                                    Console.WriteLine("\nvous vous approchez du mur.");
                                                    Console.ReadKey();
                                                    Console.WriteLine("dessus il y a des dessins et des collages fait par votre fille.");
                                                    Console.ReadKey();
                                                    Console.WriteLine("elle a toujours été plus créative que Pierre");
                                                    Console.ReadKey();
                                                    Console.WriteLine("vous soupirez.\n");
                                                    Console.ReadKey();
                                                    votre_fils = "Pierre";
                                                    goto chambre_enfants;
                                                }
                                                break;

                                            default:
                                                {
                                                    Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                    Console.ReadKey();
                                                    goto chambre_enfants;
                                                }
                                                break;
                                        }

                                    }
                                    break;

                                case "cuisine": //optionnel
                                    {
                                        string choixcui = " ";
                                        Console.WriteLine("\nvous vous dirigez vers la cuisine où l'odeur agréable du couloir s'intensifie");
                                        Console.ReadKey();
                                    cuisine:;
                                        Console.WriteLine("vous voyez " + votre_fils + " et " + votre_fille + " jouer à la [table] à manger en mageant leur céréales.");
                                        Console.ReadKey();
                                        Console.WriteLine("vous voyez " + votre_femme + " devant le [comptoir] qui prépare les dîners des enfants.");
                                        Console.ReadKey();
                                        Console.WriteLine("sur le comptoir à coté de " + votre_femme + " il y a un [sac].");
                                        Console.ReadKey();
                                        Console.WriteLine("il y a le [couloir] derrière vous.");
                                        Console.ReadKey();
                                        Console.WriteLine("vous avez chaud.");
                                        Console.ReadKey();
                                        Console.Write("que voulez vous faire? : ");
                                        Console.ReadKey();
                                        choixcui = Convert.ToString(Console.ReadLine());

                                        switch (choixcui)
                                        {
                                            case "ouloir": //retour
                                                {
                                                    Console.WriteLine("\nvous rassemblez vos forces et faites demi-tour en ignorant la délicieuse odeur.\n");
                                                    Console.ReadKey();
                                                    goto couloir;
                                                }
                                                break;

                                            case "able":
                                                {
                                                    if (bon_mat_e == false)
                                                    {
                                                        Console.WriteLine("\nvous vous approchez de vos enfants.");
                                                        Console.ReadKey();
                                                        Console.WriteLine("vous sentez une goutte de sueur perler sur votre font");
                                                        Console.ReadKey();
                                                        Console.WriteLine("vous embrassez sur le front " + votre_fille + ", puis " + votre_fils + ".");
                                                        Console.ReadKey();
                                                        Console.WriteLine("vous leur souhaitez une bonne journée et leur dites que vous le aimez.");
                                                        Console.ReadKey();
                                                        Console.WriteLine("vous vous éloignez d'eux en soupirant.\n");
                                                        Console.ReadKey();
                                                        bon_mat_e = true;
                                                        goto cuisine;
                                                    }

                                                    if (bon_mat_e == true)
                                                    {
                                                        Console.WriteLine("\nvous : je devrais laisser les enfants finir de déjeuner ou ils risquent d'être en retard pour l'école.\n");
                                                        Console.ReadKey();
                                                        goto cuisine;
                                                    }

                                                }
                                                break;

                                            case "omptoir":
                                                {
                                                    if (bon_mat_f == false)
                                                    {
                                                        Console.WriteLine("\n" + votre_femme + " vous souhaite bon matin et vous embrasse sur la joue.");
                                                        Console.ReadKey();
                                                        Console.WriteLine("vous lui souhaitez aussi bon matin.");
                                                        Console.ReadKey();
                                                        Console.WriteLine("vous avez très chaud.");
                                                        Console.ReadKey();
                                                        Console.WriteLine("ca ne vous arrive pas normalement");
                                                        Console.ReadKey();
                                                        Console.Write("...");
                                                        Console.ReadKey();
                                                        Console.Write("...");
                                                        Console.ReadKey();
                                                        Console.Write("...");
                                                        Console.ReadKey();
                                                        Console.WriteLine("pas avec eux.");
                                                        Console.ReadKey();
                                                        Console.WriteLine("vous voyez " + votre_femme + " écrire un mot pour le mettre dans la boîte à lunch de Agnès");
                                                        Console.ReadKey();
                                                        Console.WriteLine("vous prenez " + votre_femme + " dans vos bras, lui dites que vous l'aime et lui souhaitez de passer une bonne journée");
                                                        Console.ReadKey();
                                                        Console.WriteLine("vous laissez " + votre_femme + " finir les lunch des enfants\n");
                                                        Console.ReadKey();
                                                        votre_fille = "Agnès";
                                                        bon_mat_f = true;
                                                        goto cuisine;
                                                    }

                                                    if (bon_mat_f == true)
                                                    {
                                                        Console.WriteLine("\nvous avez trop chaud pour lui reparler.\n");
                                                        Console.ReadKey();
                                                        goto cuisine;
                                                    }

                                                }
                                                break;

                                            case "ac":
                                                {
                                                    if (sac_à_lunch == false)
                                                    {
                                                        Console.WriteLine("\nvous vous avancez vers le conptoir.");
                                                        Console.ReadKey();
                                                        Console.WriteLine("vous prenez votre sac à lunch.");
                                                        Console.ReadKey();
                                                        Console.WriteLine("vous vous éloignez du contoir.\n");
                                                        Console.ReadKey();
                                                        sac_à_lunch = true;
                                                        goto cuisine;
                                                    }
                                                    if (sac_à_lunch == true)
                                                    {
                                                        Console.WriteLine("\nvous : j'ai déja pris mon lunch je n'est plus rien à faire là-bas.\n");
                                                        Console.ReadKey();
                                                        goto cuisine;
                                                    }
                                                }
                                                break;

                                            default:
                                                {
                                                    Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                    Console.ReadKey();
                                                    goto cuisine;
                                                }
                                                break;


                                        }

                                    }
                                    break;

                                case "porte": //obligatoire
                                    {
                                        Console.WriteLine("\nvous enfilez vos mocassins.");
                                        Console.ReadKey();
                                        Console.WriteLine("vous mettez votre veste.");
                                        Console.ReadKey();
                                        Console.WriteLine("vous vous retournez vers la cuisine attiré par la bonne odeur.");
                                        Console.ReadKey();
                                        Console.WriteLine("vous soupirez et faite demi-tour");
                                        Console.ReadKey();
                                        Console.WriteLine("vous sortez dehors en fermant la porte derrière vous.\n\n\n");
                                        Console.ReadKey();
                                        goto confin;
                                    }
                                    break;

                                default:
                                    {
                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                        Console.ReadKey();
                                        goto couloir;
                                    }
                                    break;
                            }

                        }
                    }
                    break;

                default:
                    {
                        Console.WriteLine("\nvous soupirez en étant confus car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                        Console.ReadKey();
                        goto chambre;
                    }
                    break;
            }

        confin:;
            string fin = " ";
            Console.WriteLine("Merci d'avoir joué à la démo de mon premier jeu!!!!");
            Console.ReadKey();
            Console.WriteLine("n'hésitez pas à me faire part de vos commentaires et à me demander la suite quand je l'aurai fini si vous avez appréciez cette démo.");
            Console.ReadKey();
            Console.WriteLine("si vous même vous sentez triste quotidiennement ou si vous avez des idées suicidaire vous n'hésitez pas à aller chercher de l'aide ou appeler les numéros du site ci-dessous.");
            Console.WriteLine("https://www.infosuicide.org/urgences-aide-ressources/lignes-decoute/");
            Console.ReadKey();
            Console.WriteLine("\nvoulez vous [rejouer] ou [quitter] le jeu?\n");
            Console.ReadKey();
            Console.Write("choix : ");
            fin = Convert.ToString(Console.ReadLine());
            if (fin == "rejouer")
            {
                goto start;
            }
            if (fin == "quitter")
            {
                Console.WriteLine("\nmerci encore d'avoir joué au jeu\n");
                goto fin;
            }
            else
            {
                Console.WriteLine("\ndésoler ce n'est pas une option\n");
                Console.ReadKey();
                goto confin;
            }
        fin:;
            Console.ReadKey();
        }
    }
}