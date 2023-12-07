using NAudio.SoundFont;
using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using mon_premier_jeu;
using System.Diagnostics;
//nom: kim-pahud
//date: 2023-9-05
//description: mon premier jeu

namespace ProjetNarratif
{
    internal class Jeutext
    {


        static async Task Main(string[] args)
        {
            // déclarer les bool des succès ici pour qu'ils soyent sauvegardés entre les parties

            //FINS
            int nbdefintotale = 4;//******************** modifier à chaque fin rajoutées ****************************************************
            int nbdefindécouvertes = 0;
            bool finpont = false;
            bool finpontf = false;
            bool finpieux = false;
            bool finpieuxf = false;
            bool finkarma = false;
            bool finkarmaf = false;
            bool finsoleil = false;
            bool finsoleilf = false;
            bool fin_casu = false;

            //SUCCÈS
            int nbdetropdécouverts = 0;
            int nbdetroptotale = 10;
            bool âme_sensible = false;
            bool nostalgie = false;
            bool repas_mignon = false;
            bool mort_avec_classe = false;
            bool la_véritée = false;
            bool devenir_fou = false;
            bool paix_aux_familles = false;
            bool si_prêt_du_but = false;
            bool la_prévention_avant_tout = false;
            bool brochette_de_folie = false;
            bool merci_gros_fou = false;
        //futur ajout de différents mode de difficultée pour les QTE
        //idées de succès: - suicide réussi(se suicider, pas tué femme et enfant, dire aurevoir à la famille et laisser une note aux enfants ?? ne pas tué de collègues ou ne pas aller au travail??)
        //                 - suicide raté(se suicider, ne pas dire aurevoir, ne pas laisser de note)
        //                 - la survie à quel prix?(ne pas se suicider)
        //                 - famille(découvrez le nom de toute votre famille)
        //                 - merci d'avoir joué(faire toutes les fins au moins une fois)
        //                 - surhomme(avoir réussi le QTE final et sauver votre famille)
        //fin rentrer maison manger femme et enfants
        //si prendre repas midi dans la cuisine faim contenu à midi et collègue sauvé sinon assouvir faim avec collègue

        messdébut:;
            string messdébut = " ";
            SoundPlayer ostmenu = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"\ostmenu.wav"));
            bruit.Bruitostmenu();
            ostmenu.Play();
            Console.WriteLine("ATTENTION");
            Console.ReadKey(true);
            Console.WriteLine("ce jeu parle de sujets sensibles tel que la dépression et le suicide.");
            Console.ReadKey(true);
            Console.WriteLine("si vous n'etes pas à l'aise avec de tels sujets veuillez [quitter] l'application.");
            Console.ReadKey(true);
            Console.WriteLine("sinon vous êtes libre de [continuer].\n");
            Console.Write("choix : ");
            messdébut = Convert.ToString(Console.ReadLine());
            if (messdébut == "continuer")
            {
                goto messgore;
            }
            if (messdébut == "quitter")
            {
                goto fin;
            }
            else
            {
                Console.WriteLine("\ndésoler ce n'est pas une option\n");
                Console.ReadKey();
                goto messdébut;
            }


        messgore:;
            //gore activé ou pas
            bool gore = true;
            string choixgore = " ";
            Console.WriteLine("ce jeu contient des descriptions gore qui peuvent s'avérer choquantes pour un certain public.");
            Console.ReadKey(true);
            Console.WriteLine("si vous souhaitez désactiver le gore dans les descriptions entrez [non]");
            Console.WriteLine("si vous êtes à l'aise avec ce genre  de description entrez [oui]\n");
            choixgore = Convert.ToString(Console.ReadLine());
            if (choixgore == "oui")
            {
                Console.WriteLine("scène gore activé\n\n");
                Console.ReadKey(true);
                goto start;
            }
            if (choixgore == "non")
            {
                gore = false;
                Console.WriteLine("scène gore désactivé\n\n");
                Console.ReadKey(true);
                goto start;
            }
            else
            {
                Console.WriteLine("\ndésoler ce n'est pas une option\n");
                Console.ReadKey(true);
                goto messgore;
            }

        start:;
            //COMPTEUR AUTRES
            int contvoit = 1;

            //COMPTEUR POUR EASTER EGG
            int contras = 0;//suicidaire rasoir
            int contportm = 0;//destin famille

            //CONAISSANCES
            string votre_femme = "votre femme";
            string votre_fils = "votre fils";
            string votre_fille = "votre fille";
            bool découvrirvéritée = false;

            //ACTIONS
            bool rasoir = false;
            bool bain = false;
            bool note = false;
            bool bon_mat_f = false;
            bool bon_mat_e = false;
            bool tutoQTE = false;
            bool revientafAM = false;
            bool revientafPM = false;
            bool visiterét1 = false;
            bool visiterét2 = false;
            bool visiterét3 = false;//si tout étage false succès arrivé a l'heure et dialogue positif avec patron //si tout étage true succès déja-vu et dialogue négatif avec patron
            bool visiterét4 = false;
            bool mangerlapin = false;
            bool suicide = false;
            bool enterrer = false;
            bool trajet = false;
            bool folie = false;
            bool dévoilervéritée = false;

            //OBJETS
            bool sac_à_lunch = false;
            bool habits = false;//variable qui vérifie la sortie de la chambre

            //QTE réussi ou non
            bool QTEfamd = true;//QTE avec la famille avant d'aller au travail
            bool QTEascen = true;//QTE pour ne pas manger les collègues devant l'assenceur

            //QTE fait ou non et suite branches
            bool QTEfamdf = false;
            bool QTEascenf = false;
            bool branche_parking = false;


            string choixchamb = " ";
            Console.Clear();
            ostmenu.Stop();
            Console.WriteLine("vous vous réveillez dans votre lit, votre femme est déja levée.");
            Console.ReadKey(true);
            Console.WriteLine("vous vous levez de votre lit et observez autour de vous.");
            Console.ReadKey(true);
        chambre:;
            Console.WriteLine("dans votre chambre vous voyez la porte des [toilettes] et la porte qui mène au [couloir] d'où vous sentez une bonne odeur.");
            Console.ReadKey(true);
            Console.WriteLine("il y a la [fenetre] devant vous et sur votre commode des [habits].");
            Console.ReadKey(true);
            Console.Write("où voulez vous aller?");
            Console.Write(" : ");
            choixchamb = Convert.ToString(Console.ReadLine());
            switch (choixchamb)
            {
                case "habits": //obligatoire
                    {
                        if (habits == false)
                        {
                            Console.WriteLine("\nvous enfilez pour la cinquième fois cette semaine un costume 3 pièce gris");
                            Console.ReadKey(true);
                            Console.WriteLine("vous mettez votre cravate bleue.");
                            Console.ReadKey(true);
                            Console.WriteLine("puis vous déposez votre pyjama sur la commode\n");
                            Console.ReadKey(true);
                            habits = true;
                            goto chambre;
                        }
                        if (habits == true)
                        {
                            Console.WriteLine("\nvous ne voyez que votre pyjama sur la commode.");
                            Console.ReadKey(true);
                            Console.WriteLine("vous êtes prêt pour aller travailler.\n");
                            Console.ReadKey(true);
                            goto chambre;
                        }
                    }
                    break;

                case "toilettes"://optionnel
                    {
                        string choixbain = " ";
                        Console.WriteLine("\nvous entrez dans votre salle de bain et vous sentez un frisson vous parcourir le corps.");
                        Console.ReadKey(true);
                    salledebain:;
                        Console.WriteLine("vous retrouvez votre [bain] devant vous, votre lavabo avec un [miroir] au dessus à votre gauche.");
                        Console.ReadKey(true);
                        Console.WriteLine("votre [rasoir] est posé sur le lavabo et les [toilettes] sont à votre droite.");
                        Console.ReadKey(true);
                        Console.WriteLine("il y a aussi la [porte] qui mène à votre chambre derrière vous.");
                        Console.ReadKey(true);
                        Console.Write("que voulez vous faire : ");
                        choixbain = Convert.ToString(Console.ReadLine());
                        switch (choixbain)
                        {
                            case "porte"://retour
                                {
                                    Console.WriteLine("\nvous soupirez, puis vous sortez de la salle de bain en refermant la porte derrière vous.\n");
                                    Console.ReadKey(true);
                                    goto chambre;
                                }
                                break;

                            case "miroir":
                                {
                                    Console.WriteLine("\nvous tournez la tête à gauche et regardez dans votre miroir.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("vous soupirez.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("vous ne vous reconnaissez toujours pas.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("vous regardez autour de vous.\n");
                                    Console.ReadKey(true);
                                    goto salledebain;
                                }
                                break;

                            case "rasoir":
                                {

                                    if (contras == 0)
                                    {
                                        Console.WriteLine("\nvous vous approchez du lavabo.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("vous prenez votre rasoir et commencez à vous raser.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("vous vous coupez en vous rasant et en levant les yeux vers le miroir vous voyez qu'ils ont changés");//indice sur l'histoire
                                        Console.ReadKey(true);
                                        Console.WriteLine("vous essuyez difficilement le sang sur votre joue.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("vous finissez de vous raser et observez le rasoir pendant quelques secondes avant de le reposer.\n");
                                        Console.ReadKey(true);
                                        contras = contras + 1;
                                        rasoir = true;
                                        goto salledebain;
                                    }
                                    if (contras == 3) //easter egg teaser
                                    {
                                        Console.WriteLine("\nvous : je ne suis pas encore sur d'en être capable.\n");
                                        contras = contras + 1;
                                        Console.ReadKey();
                                        goto salledebain;
                                    }
                                    else
                                    {
                                        Console.WriteLine("je me suis déja rasé.\n");
                                        contras = contras + 1;
                                        Console.ReadKey(true);
                                        goto salledebain;
                                    }
                                }
                                break;

                            case "toilettes":
                                {
                                    Console.WriteLine("\nvous tournez la tête à droite vers votre toilette.");
                                    Console.ReadKey(true);
                                    Console.WriteLine("je n'ai pas envie d'aller au toilette\n");
                                    Console.ReadKey(true);
                                    goto salledebain;
                                }
                                break;

                            case "bain":
                                {
                                    if (bain == false)
                                    {
                                        Console.WriteLine("\nvous faites couler de l'eau brulante dans le bain.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("une fois qu'il est rempli vous entrez dedans.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("vous vous rappelez l'époque lointaine où la chaleur de l'eau vous réconfortait");
                                        Console.ReadKey(true);
                                        Console.WriteLine("cela fait longtemps qu'elle ne vous fait plus rien.\n");
                                        Console.ReadKey(true);
                                        bain = true;
                                        goto salledebain;
                                    }
                                    if (bain == true)
                                    {
                                        Console.WriteLine("vous vous êtes déja lavé.");
                                        Console.ReadKey(true);
                                        goto salledebain;
                                    }
                                }
                                break;

                            default:
                                {
                                    Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                    Console.ReadKey(true);
                                    goto salledebain;
                                }
                                break;
                        }
                    }
                    break;

                case "fenetre"://optionnel
                    {
                        Console.WriteLine("\nvous vous approchez de la fenêtre, ouvrez les rideaux et regardez dehors.");
                        Console.ReadKey(true);
                        Console.WriteLine("le soleil est caché par une épaisse couche de nuages et les gens courent vers leur voiture pour arriver au travail à temps.");
                        Console.ReadKey(true);
                        Console.WriteLine("vous souriez légèrement puis vous faite demi-tour.\n");
                        Console.ReadKey(true);
                        goto chambre;
                    }
                    break;

                case "couloir"://obligatoire
                    {
                        if (habits == false)
                        {
                            Console.WriteLine("\nvous : je ferais mieux de m'habiller pour le travail tant que je suis dans ma chambre.\n");
                            Console.ReadKey(true);
                            goto chambre;
                        }
                        else
                        {
                            string choixcoul = " ";
                            Console.WriteLine("\nvous ouvrez la porte de votre chambre et suivez la bonne odeur jusqu'au couloir.");
                            Console.ReadKey(true);
                        couloir:;
                            Console.WriteLine("la porte de la chambre des [enfants] est ouverte.");
                            Console.ReadKey(true);
                            Console.WriteLine("vous avez la [porte] d'entrée derrière vous ainsi que celle de votre [chambre].");
                            Console.ReadKey(true);
                            if (QTEfamd == false)
                            {
                                Console.WriteLine("il y a la [cuisine].");
                                Console.ReadKey(true);
                            }
                            else
                            {
                                Console.WriteLine("vous entendez des rires d'enfant depuis la [cuisine].");
                                Console.ReadKey(true);
                            }
                            Console.Write("où voulez vous aller? : ");
                            choixcoul = Convert.ToString(Console.ReadLine());

                            switch (choixcoul)
                            {
                                case "chambre": //retour
                                    {
                                        Console.WriteLine("\nvous faites demi-tour et vous retournez dans votre chambre.\n");
                                        Console.ReadKey(true);
                                        goto chambre;
                                    }
                                    break;

                                case "enfants": //optionnel
                                    {
                                        string chambenf = " ";
                                        Console.WriteLine("\nvous entrez dans la chambre de vos enfants.");
                                        Console.ReadKey(true);
                                    chambre_enfants:;
                                        Console.WriteLine("vous voyez les lits de votre fille et de votre fils avec une [photo] de famille au dessus.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("il y a divers [travaux] manuels sur les murs.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("il y a aussi du [papier] et un crayon sur leur bureau.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("il y a la [porte] du couloir derrière vous.");
                                        Console.ReadKey(true);
                                        Console.Write("que voulez vous faire? : ");
                                        chambenf = Convert.ToString(Console.ReadLine());

                                        switch (chambenf)
                                        {
                                            case "porte":// retour
                                                {
                                                    Console.WriteLine("\nvous soupirez.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous quittez la chambre de vos enfants.\n");
                                                    Console.ReadKey(true);
                                                    goto couloir;
                                                }
                                                break;

                                            case "photo":
                                                {
                                                    Console.WriteLine("\nvous vous approchez des lit de vos enfant.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous regardez la photo au dessus du lit de votre fille.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous avez toujours préféré votre fille mais personne ne le sait.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("ce n'est pas la seul chose que les autres ne savent pas.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous avez vraiments de beaux enfants avec Béatrice\n");
                                                    Console.ReadKey(true);
                                                    votre_femme = "Béatrice";
                                                    goto chambre_enfants;
                                                }
                                                break;

                                            case "papier":
                                                {
                                                    if (note == false)
                                                    {
                                                        Console.WriteLine("\nvous vous approchez du bureau de vos enfants");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("vous prenez le crayon et écrivez une note chaleureuse pour vous enfants.");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("ce sont de bons enfants ils le méritent.\n");
                                                        Console.ReadKey(true);
                                                        note = true;
                                                        goto chambre_enfants;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\nvous n'avez plus rien à faire ici.\n");
                                                        Console.ReadKey(true);
                                                        goto chambre_enfants;
                                                    }
                                                }
                                                break;

                                            case "travaux":
                                                {
                                                    Console.WriteLine("\nvous vous approchez du mur.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("dessus il y a des dessins et des collages fait par votre fille.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("elle a toujours été plus créative que Pierre");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous soupirez.\n");
                                                    Console.ReadKey(true);
                                                    votre_fils = "Pierre";
                                                    goto chambre_enfants;
                                                }
                                                break;

                                            default:
                                                {
                                                    Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                    Console.ReadKey(true);
                                                    goto chambre_enfants;
                                                }
                                                break;
                                        }

                                    }
                                    break;

                                case "cuisine": //optionnel
                                    {
                                        if (QTEfamd == true)
                                        {
                                            string choixcui = " ";
                                            Console.WriteLine("\nvous vous dirigez vers la cuisine où l'odeur agréable s'intensifie");
                                            Console.ReadKey(true);
                                        cuisine:;
                                            Console.WriteLine("vous voyez " + votre_fils + " et " + votre_fille + " jouer à la [table] à manger en mangeant leur céréales.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("vous voyez " + votre_femme + " devant le [comptoir] qui prépare les dîners des enfants.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("sur le comptoir à coté de " + votre_femme + " il y a un [sac].");
                                            Console.ReadKey(true);
                                            Console.WriteLine("il y a le [couloir] derrière vous.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("vous avez chaud.");
                                            Console.ReadKey(true);
                                            Console.Write("que voulez vous faire? : ");
                                            choixcui = Convert.ToString(Console.ReadLine());

                                            switch (choixcui)
                                            {
                                                case "couloir": //retour
                                                    {
                                                        Console.WriteLine("\nvous rassemblez vos forces et faites demi-tour en ignorant la délicieuse odeur.\n");
                                                        Console.ReadKey(true);
                                                        goto couloir;
                                                    }
                                                    break;

                                                case "table":
                                                    {

                                                        if (bon_mat_e == false)
                                                        {
                                                            Console.WriteLine("\nvous vous approchez de vos enfants.");
                                                            Console.ReadKey(true);
                                                            Console.WriteLine("vous sentez une goutte de sueur perler sur votre font");
                                                            Console.ReadKey(true);
                                                            int i = 0;
                                                            if (tutoQTE == false)
                                                            {
                                                                Console.WriteLine("\nACTION DE RÉSISTER : Lorsque [RÉSISTEZ] s'affiche à l'écran vous pouvez perdre le controle de votre corps dans certaines situations.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("pour garder le controle appuyer 10 fois de suite rapidement sur votre touche entrée dans le temps imparti.\n");
                                                                Console.ReadKey(true);
                                                                tutoQTE = true;
                                                            }
                                                            Console.WriteLine("3");
                                                            Thread.Sleep(1000);
                                                            Console.WriteLine("2");
                                                            Thread.Sleep(1000);
                                                            Console.WriteLine("1");
                                                            Thread.Sleep(1000);
                                                            Console.WriteLine("[RÉSISTEZ]");
                                                            DateTime datea = DateTime.Now;//enregistre l'heur avant le QTE
                                                            do
                                                            {
                                                                Console.ReadKey(true); i++;
                                                            } while (i < 10);//nombre de fois que l'utilisateur dois appuyer
                                                            DateTime dateb = DateTime.Now;//enregistre l'heur apres le QTE
                                                            Console.WriteLine("QTE terminé");
                                                            Thread.Sleep(3000);//délai pour ne pas passer la suite de l'histoire
                                                            TimeSpan res = dateb.Subtract(datea);//soustrait l'heur du début à l'heur de fin
                                                            double resu = res.TotalSeconds;//converti le résultat en double en secondes
                                                            Console.ReadKey(true);
                                                            if (resu < 2.2)
                                                            {
                                                                Console.WriteLine("\nréussi\n");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous embrassez sur le front " + votre_fille + ", puis " + votre_fils + ".");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous leur souhaitez une bonne journée et leur dites que vous les aimez.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous vous éloignez d'eux en soupirant.\n");
                                                                Console.ReadKey(true);
                                                                QTEfamdf = true;
                                                                bon_mat_e = true;
                                                                goto cuisine;
                                                            }

                                                            else
                                                            {
                                                                Console.WriteLine("\nraté\n");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous sentez une énorme chaleur envahir votre corps.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("...");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("...");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous oubliez ce qui c'est passé.\n");
                                                                Console.ReadKey(true);
                                                                QTEfamdf = true;
                                                                QTEfamd = false;
                                                                goto couloir;
                                                            }
                                                        }

                                                        if (bon_mat_e == true)
                                                        {
                                                            Console.WriteLine("\nvous : je devrais laisser les enfants finir de déjeuner ou ils risquent d'être en retard pour l'école.\n");
                                                            Console.ReadKey(true);
                                                            goto cuisine;
                                                        }

                                                    }
                                                    break;

                                                case "comptoir":
                                                    {

                                                        if (bon_mat_f == false)
                                                        {
                                                            Console.WriteLine("\n" + votre_femme + " vous souhaite bon matin et vous embrasse sur la joue.");
                                                            Console.ReadKey(true);
                                                            Console.WriteLine("vous lui souhaitez aussi bon matin.");
                                                            Console.ReadKey(true);
                                                            Console.WriteLine("vous avez très chaud.");
                                                            Console.ReadKey(true);
                                                            Console.WriteLine("ca ne vous arrive pas normalement");
                                                            Console.ReadKey(true);
                                                            Console.Write("...");
                                                            Console.ReadKey(true);
                                                            Console.Write("...");
                                                            Console.ReadKey(true);
                                                            Console.Write("...");
                                                            Console.ReadKey(true);
                                                            Console.WriteLine("pas avec eux.");
                                                            Console.ReadKey(true);
                                                            int i = 0;
                                                            if (tutoQTE == false)
                                                            {
                                                                Console.WriteLine("\nACTION DE RÉSISTER : Lorsque [RÉSISTEZ] s'affiche à l'écran vous pouvez perdre le controle de votre corps dans certaines situations.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("pour garder le controle appuyer 10 fois de suite rapidement sur votre touche entrée dans le temps imparti.\n");
                                                                Console.ReadKey(true);
                                                                tutoQTE = true;
                                                            }
                                                            Console.WriteLine("3");
                                                            Thread.Sleep(1000);
                                                            Console.WriteLine("2");
                                                            Thread.Sleep(1000);
                                                            Console.WriteLine("1");
                                                            Thread.Sleep(1000);
                                                            Console.WriteLine("[RÉSISTEZ]");
                                                            DateTime datea = DateTime.Now;//enregistre l'heur avant le QTE
                                                            do
                                                            {
                                                                Console.ReadKey(true); i++;
                                                            } while (i < 10);//nombre de fois que l'utilisateur dois appuyer
                                                            DateTime dateb = DateTime.Now;//enregistre l'heur apres le QTE
                                                            Console.WriteLine("QTE terminé");
                                                            Thread.Sleep(3000);//délai pour ne pas passer la suite de l'histoire
                                                            TimeSpan res = dateb.Subtract(datea);//soustrait l'heur du début à l'heur de fin
                                                            double resu = res.TotalSeconds;//converti le résultat en double en secondes
                                                            Console.ReadKey(true);
                                                            if (resu < 2.2)
                                                            {
                                                                Console.WriteLine("\nréussi\n");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous voyez " + votre_femme + " écrire un mot pour le mettre dans la boîte à lunch de Agnès");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous prenez " + votre_femme + " dans vos bras, lui dites que vous l'aimez et lui souhaitez de passer une bonne journée");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous laissez " + votre_femme + " finir les lunch des enfants\n");
                                                                Console.ReadKey(true);
                                                                votre_fille = "Agnès";
                                                                QTEfamdf = true;
                                                                bon_mat_f = true;
                                                                goto cuisine;
                                                            }

                                                            else
                                                            {
                                                                Console.WriteLine("\nraté\n");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous sentez une énorme chaleur envahir votre corps.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("...");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("...");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous oubliez ce qui c'est passé.\n");
                                                                Console.ReadKey(true);
                                                                QTEfamdf = true;
                                                                QTEfamd = false;
                                                                goto couloir;
                                                            }
                                                        }

                                                        if (bon_mat_f == true)
                                                        {
                                                            Console.WriteLine("\nvous avez trop chaud pour lui reparler.\n");
                                                            Console.ReadKey(true);
                                                            goto cuisine;
                                                        }

                                                    }
                                                    break;

                                                case "sac":
                                                    {
                                                        if (sac_à_lunch == false)
                                                        {
                                                            Console.WriteLine("\nvous vous avancez vers le comptoir.");
                                                            Console.ReadKey(true);
                                                            Console.WriteLine("vous prenez votre sac à lunch.");
                                                            Console.ReadKey(true);
                                                            Console.WriteLine("vous vous éloignez du comptoir.\n");
                                                            Console.ReadKey(true);
                                                            sac_à_lunch = true;
                                                            goto cuisine;
                                                        }
                                                        if (sac_à_lunch == true)
                                                        {
                                                            Console.WriteLine("\nvous : j'ai déja pris mon lunch je n'est plus rien à faire là-bas.\n");
                                                            Console.ReadKey(true);
                                                            goto cuisine;
                                                        }
                                                    }
                                                    break;

                                                default:
                                                    {
                                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                        Console.ReadKey(true);
                                                        goto cuisine;
                                                    }
                                                    break;
                                            }

                                        }
                                        if (QTEfamd == false)
                                        {
                                            Console.WriteLine("\nil est temps d'aller au travail.\n");
                                            Console.ReadKey(true);
                                            goto couloir;
                                        }

                                    }
                                    break;

                                case "porte": //obligatoire
                                    {
                                        string choixalltrav;
                                        Console.WriteLine("\nvous enfilez vos mocassins.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("vous mettez votre veste grise.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("vous mettez un large chapeau noir.");
                                        Console.ReadKey();
                                        if (QTEfamd == true)
                                        {
                                            Console.WriteLine("vous vous retournez vers la cuisine attiré par la bonne odeur.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("vous soupirez et faite demi-tour");
                                            Console.ReadKey(true);
                                        }
                                        if (QTEfamd == false)
                                        {
                                            Console.WriteLine("vous sentez que la bonne odeur de la cuisine a complètement disparue.");
                                            Console.ReadKey(true);
                                            Console.WriteLine("cela vous angoisse fortement.");
                                            Console.ReadKey(true);
                                        }
                                        Console.WriteLine("vous sortez dehors en fermant la [porte] derrière vous.");
                                        Console.ReadKey(true);
                                        Console.WriteLine("vous regardez votre montre.");
                                        Console.ReadKey(true);
                                    allerautaf:;//fait disparaitre l'option porte pour cacher l'easter egg
                                        Console.WriteLine("il est l'heure d'aller au travail");
                                        Console.ReadKey(true);
                                        Console.WriteLine("votre [voiture] est devant la maison.");
                                        Console.ReadKey(true);
                                        Console.Write("où voulez vous aller? : ");
                                        choixalltrav = Convert.ToString(Console.ReadLine());

                                        switch (choixalltrav)
                                        {
                                            case "porte":
                                                {
                                                    if (QTEfamd == false)
                                                    {
                                                        if (contportm == 3)//easter egg et indice
                                                        {
                                                            Console.WriteLine("\nvous vous doutez mais ne voulez savoir.\n");
                                                            Console.ReadKey(true);
                                                            contportm = contportm + 1;
                                                            goto allerautaf;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("\nvous ne pouvez pas retourner chez vous.\n");
                                                            Console.ReadKey(true);
                                                            contportm = contportm + 1;
                                                            goto allerautaf;
                                                        }
                                                    }
                                                    if (QTEfamd == true)
                                                    {
                                                        Console.WriteLine("\nvous ne pouvez pas retourner chez vous.\n");
                                                        Console.ReadKey(true);
                                                        goto allerautaf;
                                                    }
                                                }
                                                break;

                                            case "voiture":
                                                {
                                                    Console.WriteLine("\nvous entrez dans votre voiture.");
                                                    Console.ReadKey(true);
                                                    if (sac_à_lunch == true)
                                                    {
                                                        Console.WriteLine("vous déposez votre lunch sur la banquette arrière.");
                                                        Console.ReadKey(true);
                                                    }
                                                    Console.WriteLine("vous démarrez le contact et reculez la voiture dans l'allée.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous soupirez.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous : une nouvelle journée de travail commence.\n");
                                                    Console.ReadKey(true);
                                                    //********************** FIN DÉMO DÉBUT JEU COMPLET retirez le goto confin; pour tester contenu *************************************
                                                    Console.WriteLine("vous commencez à rouler vers la ville.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous profitez d'être en avance pour prendre votre temps sur le trajet.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous sortez du quartier résidentiel.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous passez devant une forêt.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous êtes pensif.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("vous passez devant une station service.");
                                                    Console.ReadKey(true);
                                                    if (QTEfamdf == true)
                                                    {
                                                        Console.WriteLine("vous : je le fait tous les jours normalement.");
                                                        Console.ReadKey(true);
                                                    }
                                                    Console.WriteLine("vous passez sur le pont qui mène à la ville.");
                                                    Console.ReadKey(true);
                                                    if (QTEfamdf == true)
                                                    {
                                                        Console.WriteLine("vous : ce n'est pas si dur normalement.");
                                                        Console.ReadKey(true);
                                                    }
                                                    Console.WriteLine("vous arrivez en ville.");
                                                    Console.ReadKey(true);
                                                    if (QTEfamdf == true)
                                                    {
                                                        Console.WriteLine("vous êtes inquiet.");
                                                        Console.ReadKey(true);
                                                    }
                                                    Console.WriteLine("vous vous dirigez vers le bâtiment dans lequel vous travaillez.");
                                                    Console.ReadKey(true);
                                                    Console.WriteLine("une fois arrivé vous allez garer votre voiture dans le parking.\n");
                                                    Console.ReadKey(true);
                                                forêt:;//************************************************************************************************************************************************
                                                    if (branche_parking == true)
                                                    {
                                                        if (revientafAM == true)
                                                        {
                                                            if (trajet == true)
                                                            {
                                                                if (QTEfamd == true)
                                                                {
                                                                    Console.WriteLine("vous vous dirigez vers la sortie de la ville.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("???? : nous savons que c'est la seul option.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("???? : le moment est venu.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("???? : il faut les protéger.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous arrivez au milieu du pont pour sortir de la ville.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous vous arrêtez devant la forêt que vous avez vu ce matin.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous : l'heure est venue.\n");
                                                                    Console.ReadKey(true);
                                                                }
                                                                if (QTEfamd == false)
                                                                {
                                                                    Console.WriteLine("vous vous dirigez vers la forêt que vous avez vu plus tôt.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("une fois arrivé vous garez votre voiture devant.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous sortez de la voiture.");
                                                                    Console.ReadKey(true);
                                                                }
                                                            forêtstart:;
                                                                string choixforêtstart = " ";
                                                                Console.WriteLine("devant vous il y a un [sentier].");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("derrière vous il y a votre [voiture]");
                                                                Console.ReadKey(true);
                                                                Console.Write("où voulez vous aller? : ");
                                                                choixforêtstart = Convert.ToString(Console.ReadLine());

                                                                switch (choixforêtstart)
                                                                {
                                                                    case "voiture":
                                                                        {
                                                                            Console.WriteLine("\nvous : je suis allé trop loin cette fois.");
                                                                            Console.ReadKey(true);
                                                                            Console.WriteLine("vous : je ne peux plus revenir en arrière.\n");
                                                                            Console.ReadKey(true);
                                                                            goto forêtstart;
                                                                        }
                                                                        break;

                                                                    case "sentier":
                                                                        {
                                                                            Console.WriteLine("\nvous entrez dans la forêt.");
                                                                            Console.ReadKey(true);
                                                                            Console.WriteLine("les arbres sont tellement épais que vous ne voyez plus le ciel.");
                                                                            Console.ReadKey(true);
                                                                        sentier1:;
                                                                            string choixsentier1 = " ";
                                                                            Console.WriteLine("devant vous il y a la suite du [sentier].");
                                                                            Console.ReadKey(true);
                                                                            if (mangerlapin == false)
                                                                            {
                                                                                Console.WriteLine("vous avez faim et vous sentez une bonne [odeur] à votre droite.");
                                                                                Console.ReadKey(true);
                                                                            }
                                                                            Console.Write("où voulez vous aller? : ");
                                                                            choixsentier1 = Convert.ToString(Console.ReadLine());

                                                                            switch (choixsentier1)
                                                                            {
                                                                                case "odeur":
                                                                                    {
                                                                                        Console.WriteLine("\nvous suivez l'odeur.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("elle vous mène jusqu'a un lapin qui est prit dans un piège et qui a une coupure à la patte.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("vous vous approchez du lapin.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("vous lui sautez dessus et lui mordez le coup pour lui sucer le sang.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("???? : tu n'arrive plus à contrôler ta faim il faut en finir vite.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("vous retournez sur le sentier paniqué.\n");
                                                                                        Console.ReadKey(true);
                                                                                        mangerlapin = true;
                                                                                        goto sentier1;
                                                                                    }
                                                                                    break;

                                                                                case "sentier":
                                                                                    {
                                                                                        string choixsentier2 = " ";
                                                                                        Console.WriteLine("\nvous avancez sur le chemin durant une quinzaine de minutes.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("après cette longue marche vous arrivez à un endroit du sentier que vous ne connaissez que trop bien.");
                                                                                        Console.ReadKey(true);
                                                                                    sentier2:;
                                                                                        if (QTEascen == false)
                                                                                        {
                                                                                            Console.WriteLine("voulez vous [continuer] ou voulez vous [dévier]");
                                                                                            Console.ReadKey(true);
                                                                                            Console.Write("que voulez vous faire ? : ");
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("voulez vous [continuer] ou voulez vous [dévier] de votre trajet pour affrontez la véritée");
                                                                                            Console.ReadKey(true);
                                                                                            Console.Write("que voulez vous faire? : ");
                                                                                        }
                                                                                        choixsentier2 = Convert.ToString(Console.ReadLine());
                                                                                        switch (choixsentier2)
                                                                                        {
                                                                                            case "continuer":
                                                                                                {
                                                                                                    Console.WriteLine("\nvous continuez à marcher jusqu'a la fin du sentier.");
                                                                                                    Console.ReadKey(true);
                                                                                                    Console.WriteLine("à la fin de celui-ci il y a une toute petite clairière.");
                                                                                                    Console.ReadKey(true);
                                                                                                    Console.WriteLine("il y a plein de fleurs au partout sur le sol de la clairière.");
                                                                                                    Console.ReadKey(true);
                                                                                                clairière:;
                                                                                                    string choixclair = " ";
                                                                                                    Console.WriteLine("en plein milieu il y a un gros [rocher] éclairé par un rayon de soleil");
                                                                                                    Console.ReadKey(true);
                                                                                                    Console.WriteLine("il y a aussi un [baton] à quelques pas du rocher.");
                                                                                                    Console.ReadKey(true);
                                                                                                    Console.WriteLine("le [sentier] est derrière vous mais la clairière vous attire.");
                                                                                                    Console.ReadKey(true);
                                                                                                    Console.Write("ou voulez vous aller? : ");
                                                                                                    choixclair = Convert.ToString(Console.ReadLine());

                                                                                                    switch (choixclair)
                                                                                                    {
                                                                                                        case "sentier":
                                                                                                            {
                                                                                                                Console.WriteLine("\n???? : mais qu'est ce que tu fait?");
                                                                                                                Console.ReadKey(true);
                                                                                                                Console.WriteLine("vous : il me reste des choses à régler");
                                                                                                                Console.ReadKey(true);
                                                                                                                Console.WriteLine("vous retournez en arrière.\n");
                                                                                                                Console.ReadKey(true);
                                                                                                                goto sentier2;
                                                                                                            }
                                                                                                            break;

                                                                                                        case "rocher": //**************************************************************** fin clairière ****************************************************************************************
                                                                                                            {
                                                                                                                if (QTEascen == true && QTEfamd == true)
                                                                                                                {
                                                                                                                    Console.WriteLine("\nvous vous approchez du rocher prêt à en finir.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("???? : tu sais que c'est la meilleur option pour eux.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("vous : je sais et nous devons les protéger de moi.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("vous escaladez le rocher.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("vous faites entrez votre main dans le rayon de soleil et elle se met directement à brûler.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("vous entrez dans le rayon complètement et vous prenez feu.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("malgré la douleur vous vous agenouillez.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    if (gore == true)
                                                                                                                    {
                                                                                                                        Console.WriteLine("vous sentez votre peau et votre chair partir en cendre mais ça n'a pas d'importance car vous êtes en paix.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                    }
                                                                                                                    Console.WriteLine("votre dernière pensée sera pour votre famille qui sont la meilleur chose que vous ayez eu la chance d'avoir.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    suicide = true;
                                                                                                                    finsoleil = true;
                                                                                                                    if (finsoleil == true && finsoleilf == false)
                                                                                                                    {
                                                                                                                        nbdefindécouvertes = nbdefindécouvertes + 1;
                                                                                                                        finsoleilf = true;
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    Console.WriteLine("\nvous vous approchez du rocher prêt à en finir.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("mais alors que vous vous aprêtiez à monter dessus les nuages reviennent cacher le soleil et il commence à pleuvoir.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("???? : le karma t'as finalement rattraper.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("???? : tu aurais du résister.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("vous vous énervez et vous fracassez le rocher en un coup de poing.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("vous prenez le baton et vous vous l'enfoncez dans le torse en riant.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    if (gore == true)
                                                                                                                    {
                                                                                                                        Console.WriteLine("vous ressentez une énorme douleur au niveau du torse et crachez du sang mais vous ne sentez pas vos forces vous quitter.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("???? : tu as raté ton coeur idiot personne ne peux déjouer le karma même pas nous.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("malgré l'énorme douleur vous retirez le baton de votre torse en recrachant du sang.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous vous le plantez pour la deuxième fois dans le torse.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous sentez votre poumon gauche se remplir de sang et avez de la difficultée à respirer.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("???? : trop à gauche cette fois-ci.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("???? : cette souffrance c'est tout ce que nous méritons pour ce que nous avons fait");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("la douleur devient insuportable alors que vous retirez le baton pour la deuxième fois.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous vous le plantez une dernière fois de toute vos forces dans le coeur cette fois.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("le baton vous transperce de pars en pars alors que vous sentez vos forces vous quitter.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                    }
                                                                                                                    Console.WriteLine("vous vous effondrez.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    suicide = true;
                                                                                                                    finkarma = true;
                                                                                                                    if (finkarma == true && finkarmaf == false)
                                                                                                                    {
                                                                                                                        nbdefindécouvertes = nbdefindécouvertes + 1;
                                                                                                                        finkarmaf = true;
                                                                                                                    }
                                                                                                                }
                                                                                                                Console.WriteLine("\n\n2 jours plus tard.");
                                                                                                                Console.ReadKey(true);
                                                                                                                Console.WriteLine("...");
                                                                                                                bruit.bruitteljour();
                                                                                                                Console.WriteLine("\nprésentateur : Bonjours chère téléspectateurs et bienvenu au journal de 18h.");
                                                                                                                Console.ReadKey(true);
                                                                                                                if (QTEfamd == false)
                                                                                                                {
                                                                                                                    Console.WriteLine("présentateur : Le corps d'une mère, de son fils et de ça fille ont été retrouvés sans vie ce matin à leur domicile.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("présentateur : Les trois corps découverts par leur voisine, présentent deux marques circulaires au niveau de la carotide et on été vidés de leur sang.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("présentateur : Le mari de la famille reste introuvable et les forces de l'ordre l'ont pris comme suspect principal dans cette affaire.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                }
                                                                                                                if (finkarma == true)
                                                                                                                {
                                                                                                                    Console.WriteLine("présentateur : Un autre drame morbide est survenu aujourd'hui dans une forêt à quelques kilomètres de notre ville");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("présentateur : Alors qu'une joggeuse courrait dans la forêt ce midi, elle est tombée sur un corps avec des canines anormalement longues qui est transpercé par un baton.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("présentateur : Lors de l'inspection des lieux par la police ceux-ci sont tombés sur une centaine de tombes non loin du corps.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    if (dévoilervéritée == true)
                                                                                                                    {
                                                                                                                        Console.WriteLine("présentateur : Les policiers ont rapidement fait le lien entre les tombes et le corps retrouvé et ont découverts qu'il serai le meurtrier comme l'indique le message qu'il a laissé à côté de son corps.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("présentateur : Le tueur en série se serai suicider à cause de ça culpabilitée.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("présentateur : Ça mort aurais été lente et douloureuse ce qui apportera, espéront le, la paix aux familles des victimes.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                    }
                                                                                                                    if (dévoilervéritée == false)
                                                                                                                    {
                                                                                                                        Console.WriteLine("présentateur : Faute de preuve liant les deux événements il n'y aurais aucun lien entre les deux incidents plongeant ducoup les familles des victimes dans le doute.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("présentateur : La police analyse les macabés des deux incidents pour identifier toutes les victimes.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                    }
                                                                                                                }

                                                                                                                if (finsoleil == true)
                                                                                                                {
                                                                                                                    Console.WriteLine("présentateur : Un autre drame morbide est survenu aujourd'hui dans une forêt à quelques kilomètres de notre ville");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("présentateur : Alors qu'une joggeuse courrait dans la forêt ce midi, elle est tombée sur un tas d'os et de cendres dans la clairière.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("présentateur : Lors de l'inspection des lieux par la police ceux-ci sont tombés sur une centaine de tombes non loin du corps.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    if (dévoilervéritée == true)
                                                                                                                    {
                                                                                                                        Console.WriteLine("présentateur : Les policiers ont rapidement fait le lien entre les tombes et les os retrouvé et ont découverts qu'il appartiendraient aux meurtrier comme l'indique le message qu'il a laissé à côté de son corps.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("présentateur : Le tueur en série se serai suicider à cause de ça culpabilitée.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("présentateur : Ça mort aurais été lente et douloureuse ce qui apportera, espéront le, la paix aux familles des victimes.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                    }
                                                                                                                    if (dévoilervéritée == false)
                                                                                                                    {
                                                                                                                        Console.WriteLine("présentateur : Faute de preuve liant les deux événements il n'y aurais aucun lien entre les deux incidents plongeant ducoup les familles des victimes dans le doute.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("présentateur : La police analyse les macabés des deux incidents pour identifier toutes les victimes.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                    }
                                                                                                                }

                                                                                                                if (QTEascen == false)
                                                                                                                {
                                                                                                                    Console.WriteLine("présentateur : Si vous vous souvenez bien il y a deux jours 5 employés d'une firme de comptabilitée on été portés disparus.");
                                                                                                                    Console.ReadKey();
                                                                                                                    if (dévoilervéritée == false)
                                                                                                                    {
                                                                                                                        Console.WriteLine("présentateur : Les forces de l'ordes ont retrouvés les 5 corps parmis la centaine d'autre du cimetière macabre de la forêt.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("présentateur : Bien que les familles puissent enterrer leurs morts comme la police n'a aucune pistes concernant leur meurtrier celles-ci n'auront probablement jamais justice.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                    }
                                                                                                                    if (dévoilervéritée == true)
                                                                                                                    {
                                                                                                                        Console.WriteLine("présentateur : Les forces de l'ordre ont donc associées ces meurtres au tueur en série qui a enterrer ces victimes dans cette forêt.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("présentateur : justice a donc été rendu aux familles qui pourront enterrer leurs morts paisiblement.");
                                                                                                                        Console.ReadKey(true);

                                                                                                                    }

                                                                                                                }
                                                                                                                if (QTEfamd == true)
                                                                                                                {
                                                                                                                    Console.WriteLine("présentateur : Une des disparitions de ces derniers jours a été résolue grâce au drame de la forêt.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("présentateur : En effet, il y a deux jours une mère de famille à contacter la police pour la disparition de son mari.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    if (note == true)
                                                                                                                    {
                                                                                                                        Console.WriteLine("présentateur : Madame aurait trouvée une lettre de suicide de son mari qui explique les raisons de son actes.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                    }
                                                                                                                    Console.WriteLine("présentateur : Ça voiture à été retrouvée devant la forêt en même temps que le corps de la calairière ce qui laisse supposé que ce corps est en fait le mari de Madame.");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    Console.WriteLine("présentateur : Nous attendons toute fois l'analyse de la police pour confirmer cette théorie et clore l'enquête.");
                                                                                                                    Console.ReadKey(true);

                                                                                                                }
                                                                                                                Console.WriteLine("présentateur : Sur ce se sera tout pour le journal de 18h, nous nous retrouvons demain avec espéront le des nouvelles plus réjouissantes.\n");
                                                                                                                Console.ReadKey(true);
                                                                                                                goto confin;
                                                                                                            }
                                                                                                            break;//**************************************************************** fin clairière ****************************************************************************************

                                                                                                        case "baton":
                                                                                                            {
                                                                                                                if (découvrirvéritée == true)
                                                                                                                {
                                                                                                                    if (dévoilervéritée == false)
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous : je dois me dénoncer pour dissiper les doutes sur mes meurtres.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous prenez le baton et vous approchez du rocher.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous marquez je suis un meurtrier dans le sol avec le baton.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("???? : c'est très humain de ta pars.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous : je suis peut-être un monstre mais tu n'est pas la seul partie de nous qui a un coeur.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        dévoilervéritée = true;
                                                                                                                        goto clairière;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous : j'ai déja fait ce qu'il fallai.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto clairière;
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    Console.WriteLine("\nvous : je ne vois pas quoi en faire.\n");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    goto clairière;
                                                                                                                }
                                                                                                            }
                                                                                                            break;

                                                                                                        default:
                                                                                                            {
                                                                                                                Console.WriteLine("\nvous soupirez en étant confus car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                                Console.ReadKey(true);
                                                                                                                goto clairière;
                                                                                                            }
                                                                                                            break;
                                                                                                    }
                                                                                                }
                                                                                                break;

                                                                                            case "dévier":
                                                                                                {

                                                                                                    Console.WriteLine("\nvous déviez du sentier pour vous enfoncer dans la forêt.");
                                                                                                    Console.ReadKey(true);
                                                                                                    Console.WriteLine("vous vous arrêtez apres quelques minutes de marche.");
                                                                                                    Console.ReadKey(true);
                                                                                                    if (QTEascen == false && QTEfamd == false)
                                                                                                    {
                                                                                                    véritée:;
                                                                                                        string choixdévier = " ";
                                                                                                        Console.WriteLine("devant vous il y a plein de [monticules] de terre.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("un peu plus loin à gauche vous voyez les [corps] de vos collègues de l'ascenseur.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous pouvez [revenir] sur vos pas.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.Write("où voulez vous aller ? : ");
                                                                                                        choixdévier = Convert.ToString(Console.ReadLine());

                                                                                                        switch (choixdévier)
                                                                                                        {
                                                                                                            case "revenir":
                                                                                                                {
                                                                                                                    if (découvrirvéritée == false)
                                                                                                                    {
                                                                                                                        if (enterrer == false)
                                                                                                                        {
                                                                                                                            Console.WriteLine("\nvous refusez de voir pleinement la véritée et retournez sur vos pas.\n");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            goto sentier2;
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            Console.WriteLine("\nvous retournez sur vos pas.\n");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            goto sentier2;
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous êtes maintenant convaincu que vous ne serais qu'une nuisance.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous retournez sur le sentier encore plus convaincu que vous devez payer pour ce que vous avez fait.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto sentier2;

                                                                                                                    }
                                                                                                                }
                                                                                                                break;

                                                                                                            case "corps":
                                                                                                                {
                                                                                                                    if (enterrer == false)
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous vous approchez de la pile de cadavre la boule au ventre.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("???? : regarde ce que tu as fait.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous fixez les cadavres horrifié par ce que vous avez fait.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        int i = 0;
                                                                                                                        double resu = 0;
                                                                                                                        if (tutoQTE == false)
                                                                                                                        {
                                                                                                                            Console.WriteLine("\nACTION DE RÉSISTER : Lorsque [RÉSISTEZ] s'affiche à l'écran vous pouvez perdre le controle de votre corps dans certaines situations.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("pour garder le controle appuyer 10 fois de suite rapidement sur votre touche entrée dans le temps imparti.\n");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            tutoQTE = true;
                                                                                                                        }
                                                                                                                        Console.WriteLine("3");
                                                                                                                        Thread.Sleep(1000);
                                                                                                                        Console.WriteLine("2");
                                                                                                                        Thread.Sleep(1000);
                                                                                                                        Console.WriteLine("1");
                                                                                                                        Thread.Sleep(1000);
                                                                                                                        Console.WriteLine("[RÉSISTEZ]");
                                                                                                                        DateTime datea = DateTime.Now;//enregistre l'heur avant le QTE
                                                                                                                        do
                                                                                                                        {
                                                                                                                            Console.ReadKey(true); i++;
                                                                                                                        } while (i < 10);//nombre de fois que l'utilisateur dois appuyer
                                                                                                                        DateTime dateb = DateTime.Now;//enregistre l'heur apres le QTE
                                                                                                                        Console.WriteLine("QTE terminé");
                                                                                                                        Thread.Sleep(3000);//délai pour ne pas passer la suite de l'histoire
                                                                                                                        TimeSpan res = dateb.Subtract(datea);//soustrait l'heur du début à l'heur de fin
                                                                                                                        resu = res.TotalSeconds;//converti le résultat en double en secondes
                                                                                                                        Console.ReadKey(true);
                                                                                                                        if (resu < 1.5)
                                                                                                                        {
                                                                                                                            enterrer = true;
                                                                                                                            Console.WriteLine("\nréussi\n");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous retournez sur le sentier détruit mentalement mais encore plus convincu de votre décision.\n");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            goto sentier2;
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            enterrer = true;
                                                                                                                            Console.WriteLine("\nraté\n");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous vous rendez compte d'à quel point vous êtes un monstre.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous devenez fou face à ce constat.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous vous éloignez des corps en tremblant.\n");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            folie = true;
                                                                                                                            goto véritée;
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous êtes trop fragile mentalement pour revoir ça.\n");
                                                                                                                        goto véritée;
                                                                                                                    }
                                                                                                                }
                                                                                                                break;

                                                                                                            case "monticules":
                                                                                                                {
                                                                                                                    if (découvrirvéritée == false)
                                                                                                                    {
                                                                                                                        if (enterrer == false)
                                                                                                                        {
                                                                                                                            Console.WriteLine("\nvous approcher d'un monticule de terre avec un panneau dessus.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous regardez le panneau de bois sur lequel vous voyez un nom et deux date.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous : c'est ici que j'ai enterrer tous les corps qui m'ont servit de nourriture ces 3 derniers siècles.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous levez les yeux et voyez une centaines d'autre monticules.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous serrez le poing et versez une larme.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous : je n'avais jamais réalisé qu'il y en avais autant.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            découvrirvéritée = true;
                                                                                                                            Console.WriteLine("vous revenez sur vos pas.\n");
                                                                                                                            Console.ReadKey();
                                                                                                                            goto véritée;
                                                                                                                        }
                                                                                                                        else //**************************************************************** fin pieux ****************************************************************************************
                                                                                                                        {
                                                                                                                            Console.WriteLine("\nvous approcher d'un monticule de terre avec un panneau dessus.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous regardez le panneau de bois sur lequel vous voyez un nom et deux dates");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous levez les yeux et voyez des centaines d'autres monticules.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous : c'est ici que j'ai enterrer tous les corps qui m'ont servit de nourriture ces 3 derniers siècles.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            découvrirvéritée = true;
                                                                                                                            Console.WriteLine("vous sentez la folie s'emparé de vous.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous n'aviez jamais réaliser que vous aviez tué autant de personnes.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("c'était la goutte de trop.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous ne pouvez plus attendre.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous prenez le panneau de la tombe et le cassez en deux.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("vous prenez le morceaux le plus pointu et vous vous le plantez directement dans le coeur.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            if (gore == true)
                                                                                                                            {
                                                                                                                                Console.WriteLine("vous crachez du sang et tombez à genoux.");
                                                                                                                                Console.ReadKey(true);
                                                                                                                                Console.WriteLine("vous pensez aux familles de tous ceux que vous avez tués en espérant que votre mort leur apporte la paix tout en vous vidant de votre sang.");
                                                                                                                                Console.ReadKey(true);
                                                                                                                                Console.WriteLine("vous utilisez vos dernières forces pour enfoncez le morceaux de bois jusqu'a ce qu'il vous traverse.");
                                                                                                                                Console.ReadKey(true);
                                                                                                                            }
                                                                                                                            Console.WriteLine("vous vous effondez.");
                                                                                                                            Console.ReadKey(true);

                                                                                                                            Console.WriteLine("\n\n2 jours plus tard.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("...");
                                                                                                                            bruit.bruitteljour();
                                                                                                                            Console.WriteLine("\nprésentateur : Bonjours chère téléspectateur et bienvenu au journal de 18h.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("présentateur : Le corps d'une mère, de son fils et de ça fille ont été retrouvés sans vie ce matin à leur domicile.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("présentateur : Les trois corps présentent deux marques circulaires au niveau de la carotide et on été vidés de leur sang.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("présentateur : Le mari de la famille reste introuvable et les forces de l'ordre l'ont pris comme suspect principal dans cette affaire.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("présentateur : Si vous vous souvenez bien il y a deux jours 5 employés d'une firme de comptabilitée on été portés disparus.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("présentateur : Les forces de l'ordes n'ont toujours aucune piste pour retrouvé les victimes qui ont maitenant peu de chances d'etre retrouvés.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("présentateur : Nous finissons ce journal par une pensée pour les familles des disparus qui sont elles mortes d'inquiétudes.");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            Console.WriteLine("présentateur : Sur ce se sera tout pour le journal de 18h, nous nous retrouvons demain avec espéront le des nouvelles plus réjouissantes.\n");
                                                                                                                            Console.ReadKey(true);
                                                                                                                            suicide = true;
                                                                                                                            finpieux = true;
                                                                                                                            if (finpieux == true && finpieuxf == false)
                                                                                                                            {
                                                                                                                                nbdefindécouvertes = nbdefindécouvertes + 1;
                                                                                                                                finpieuxf = true;
                                                                                                                            }
                                                                                                                            goto confin; //**************************************************************** fin pieux ****************************************************************************************
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous : je n'est plus rien à faire ici.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("???? : aller... il est temps d'en finir.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto sentier2;
                                                                                                                    }
                                                                                                                }
                                                                                                                break;

                                                                                                            default:
                                                                                                                {
                                                                                                                    Console.WriteLine("\nvous soupirez en étant confus car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    goto véritée;
                                                                                                                }
                                                                                                                break;
                                                                                                        }

                                                                                                    }
                                                                                                    if (QTEascen == false && QTEfamd == true)
                                                                                                    {
                                                                                                        string choixdévier = " ";
                                                                                                        Console.WriteLine("\nvous déviez du sentier pour vous enfoncer dans la forêt.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous vous arrêtez apres quelques minutes de marche.");
                                                                                                        Console.ReadKey(true);
                                                                                                    véritée:;
                                                                                                        Console.WriteLine("devant vous il y a plein de [monticules] de terre.");
                                                                                                        Console.ReadKey(true);
                                                                                                        if (enterrer == false)
                                                                                                        {
                                                                                                            Console.WriteLine("un peu plus loin à gauche vous voyez les [corps] de vos collègues de l'ascenseur.");
                                                                                                            Console.ReadKey(true);
                                                                                                        }
                                                                                                        if (enterrer == true)
                                                                                                        {
                                                                                                            Console.WriteLine("un peu plus loin à gauche vous voyez l'endroit où vous avez enterré les [corps] de vos collègues.");
                                                                                                            Console.ReadKey(true);
                                                                                                        }
                                                                                                        Console.WriteLine("vous pouvez [revenir] sur vos pas.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("où voulez vous aller ? : ");
                                                                                                        choixdévier = Convert.ToString(Console.ReadLine());

                                                                                                        switch (choixdévier)
                                                                                                        {
                                                                                                            case "revenir":
                                                                                                                {
                                                                                                                    if (découvrirvéritée == false)
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous refusez de voir pleinement la véritée et retournez sur vos pas.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto sentier2;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous êtes maintenant convaincu que vous ne serais qu'une nuisance pour votre famille.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous retournez sur le sentier encore plus convaincu que vous devez payer pour ce que vous avez fait.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto sentier2;
                                                                                                                    }
                                                                                                                }
                                                                                                                break;

                                                                                                            case "corps":
                                                                                                                {
                                                                                                                    if (enterrer == false)
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous vous approchez du corps de vos collèges.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous vous agenouillez devant eux et vous excusez de ne pas avoir pu contrôler votre faim.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous décidez de les enterrer à côté des autres victimes de vos dernières années.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        enterrer = true;
                                                                                                                        Console.WriteLine("vous retournez sur le sentier encore plus convincu de votre décision.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto sentier2;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous : je suis désolé pour eux et leurs familles.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto véritée;
                                                                                                                    }
                                                                                                                }
                                                                                                                break;

                                                                                                            case "monticules":
                                                                                                                {
                                                                                                                    if (découvrirvéritée == false)
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous approcher d'un monticule de terre avec un panneau dessus.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous regardez le panneau de bois sur lequel vous voyez un nom et deux date.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous : c'est ici que j'ai enterrer tous les corps qui m'ont servit de nourriture ces 3 derniers siècles.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous levez les yeux et voyez une centaines d'autre monticules.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous serrez le poing et versez une larme.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous : je n'avais jamais réalisé qu'il y en avais autant.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        découvrirvéritée = true;
                                                                                                                        Console.WriteLine("vous revenez sur vos pas.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto véritée;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous : je n'est plus rien à faire ici.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("???? : aller... il est temps d'en finir.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto sentier2;
                                                                                                                    }

                                                                                                                }
                                                                                                                break;

                                                                                                            default:
                                                                                                                {
                                                                                                                    Console.WriteLine("\nvous soupirez en étant confus car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    goto véritée;
                                                                                                                }
                                                                                                                break;
                                                                                                        }
                                                                                                    }
                                                                                                    if (QTEascen == true)
                                                                                                    {
                                                                                                    véritée:;
                                                                                                        string choixdévier = " ";
                                                                                                        Console.WriteLine("\nvous déviez du sentier pour vous enfoncer dans la forêt.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous vous arrêtez apres quelques minutes de marche à un endroit avec plein de [monticules] de terre.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous pouvez [revenir] sur vos pas");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("où voulez vous aller ? : ");
                                                                                                        choixdévier = Convert.ToString(Console.ReadLine());

                                                                                                        switch (choixdévier)
                                                                                                        {
                                                                                                            case "revenir":
                                                                                                                {
                                                                                                                    if (découvrirvéritée == false)
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous refusez de voir pleinement la véritée et retournez sur vos pas.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto sentier2;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous êtes maintenant convaincu que vous ne serais qu'une nuisance.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous retournez sur le sentier encore plus convaincu que vous devez payer pour ce que vous avez fait.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto sentier2;
                                                                                                                    }
                                                                                                                }
                                                                                                                break;

                                                                                                            case "monticules":
                                                                                                                {
                                                                                                                    if (découvrirvéritée == false)
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous approcher d'un monticule de terre avec un panneau dessus.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous regardez le panneau de bois sur lequel vous voyez un nom et deux date.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous : c'est ici que j'ai enterrer tous les corps qui m'ont servit de nourriture ces 3 derniers siècles.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous levez les yeux et voyez une centaines d'autre monticules.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous serrez le poing et versez une larme.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("vous : je n'avais jamais réalisé qu'il y en avais autant.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        découvrirvéritée = true;
                                                                                                                        Console.WriteLine("vous revenez sur vos pas.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto véritée;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        Console.WriteLine("\nvous : je n'est plus rien à faire ici.");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        Console.WriteLine("???? : aller... il est temps d'en finir.\n");
                                                                                                                        Console.ReadKey(true);
                                                                                                                        goto sentier2;
                                                                                                                    }
                                                                                                                }
                                                                                                                break;

                                                                                                            default:
                                                                                                                {
                                                                                                                    Console.WriteLine("\nvous soupirez en étant confus car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                                    Console.ReadKey(true);
                                                                                                                    goto véritée;
                                                                                                                }
                                                                                                                break;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                break;

                                                                                            default:
                                                                                                {
                                                                                                    Console.WriteLine("\nvous soupirez en étant confus car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                    Console.ReadKey(true);
                                                                                                    goto sentier2;
                                                                                                }
                                                                                                break;
                                                                                        }
                                                                                    }
                                                                                    break;

                                                                                default:
                                                                                    {
                                                                                        Console.WriteLine("\nvous soupirez en étant confus car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                        Console.ReadKey(true);
                                                                                        goto sentier1;
                                                                                    }
                                                                                    break;
                                                                            }
                                                                        }
                                                                        break;

                                                                    default:
                                                                        {
                                                                            Console.WriteLine("\nvous soupirez en étant confus car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                            Console.ReadKey(true);
                                                                            goto forêtstart;
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                            if (QTEfamd == false)
                                                            {
                                                                Console.WriteLine("vous vous dirigez vers la sortie de la ville.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("???? : nous savons que c'est la seul option.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("???? : nous ne pouvons plus le nier.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("???? : pas pour eux.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous : pas pour eux.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous arrivez au milieu du pont pour sortir de la ville.\n");
                                                                Console.ReadKey(true);
                                                                int i = 0;
                                                                Console.WriteLine("3");
                                                                Thread.Sleep(1000);
                                                                Console.WriteLine("2");
                                                                Thread.Sleep(1000);
                                                                Console.WriteLine("1");
                                                                Thread.Sleep(1000);
                                                                Console.WriteLine("[RÉSISTEZ]");
                                                                DateTime datea = DateTime.Now;//enregistre l'heur avant le QTE
                                                                do
                                                                {
                                                                    Console.ReadKey(true); i++;
                                                                } while (i < 10);//nombre de fois que l'utilisateur dois appuyer
                                                                DateTime dateb = DateTime.Now;//enregistre l'heur apres le QTE
                                                                Console.WriteLine("QTE terminé");
                                                                Thread.Sleep(3000);//délai pour ne pas passer la suite de l'histoire
                                                                TimeSpan res = dateb.Subtract(datea);//soustrait l'heur du début à l'heur de fin
                                                                double resu = res.TotalSeconds;//converti le résultat en double en secondes
                                                                Console.ReadKey(true);
                                                                if (resu > 3.5)//*********************************************** fin pont ******************************************************************************************
                                                                {
                                                                    Console.WriteLine("\nraté\n");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous sortez du déni.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous prenez pleinement conscience de ce que vous avez fait.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous vous êtes nourrit de votre famille.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous arrêtez votre voiture au millieu du pont.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine(votre_femme);
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine(votre_fils);
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine(votre_fille);
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous n'avez pas su contrôler votre faim et vous les avez tués.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("la nouvelle vous dévaste.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous arrachez violament la portière avant de votre voiture en bondissant hors de celle-ci.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous attérissez sur le rebord du pont.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous sautez.");
                                                                    Console.ReadKey(true);
                                                                    if (gore == true)
                                                                    {
                                                                        Console.WriteLine("vous vous sentez tomber.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("en dessous de vous il y a une rivière avec un fort courrant qui mène à une cascade.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("à mesure que la rivière se rapproche vous sentez vos pied passez devant.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous vous écraser sur l'eau pied devant avec un bruit de craquement d'os.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous ne sentez plus vos jambes.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous criez mais vos poumons se remplissent d'eau.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous êtes attiré vers la chute d'eau.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous heurtez un rocher.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("l'eau autour de vous devient rouge alors que vous ne sentez plus votre bras gauche.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous êtes réconfortez par la pensée que votre famille était vos dernières victimes.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous êtes arrivez à la chute d'eau.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("???? : c'était la meilleur option.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous avez à peine le temps de sentir que vous tomber que votre tête touche un rocher en bas.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous sentez pendant quelques brève millisecondes l'énorme douleur de votre tête qui explose au contact du rocher.");
                                                                        Console.ReadKey(true);
                                                                    }
                                                                    Console.WriteLine("\n\n2 jours plus tard.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("...");
                                                                    bruit.bruitteljour();
                                                                    Console.WriteLine("\nprésentateur : Bonjours chère téléspectateur et bienvenu au journal de 18h.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("présentateur : Le corps d'une mère, de son fils et de ça fille ont été retrouvés sans vie ce matin à leur domicile.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("présentateur : Les trois corps présentent deux marques circulaires au niveau de la carotide et on été vidés de leur sang.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("présentateur : Le mari de la famille reste introuvable et les forces de l'ordre l'ont pris comme suspect principal dans cette affaire.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("présentateur : Dans la continuité de l'ambiance morbide de ce journal nous avons enfin une bonne nouvelle concernant l'affaire de l'homme qui a sauté du pont sud de la ville il y a deux jours.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("présentateur : Ce matin les équipes de recherches ont retrouvé un morceau de bras dans la rivière.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("présentateur : Il est actuellement en analyse pour découvrir l'identitée de l'homme qui à sauté.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("présentateur : Les équipes n'ont malheureusement pas retrouvé le reste du corps qui à selon eux chuter en bas de la cascade et est donc introuvable.");
                                                                    Console.ReadKey(true);
                                                                    if (QTEascenf == true && QTEascen == false)
                                                                    {
                                                                        Console.WriteLine("présentateur : Si vous vous souvenez bien il y a deux jours 5 employés d'une firme de comptabilitée on été portés disparus.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("présentateur : Les forces de l'ordes n'ont toujours aucune piste pour retrouvé les victimes qui ont maitenant peu de chances d'etre retrouvés.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("présentateur : Nous finissons ce journal par une pensée pour les familles des disparus qui sont elles mortes d'inquiétudes.");
                                                                        Console.ReadKey(true);
                                                                    }
                                                                    Console.WriteLine("présentateur : Ce sera tout pour ce journal de 18h nous nous retrouvons demain avec espéront le des nouvelles plus réjouissantes.\n");
                                                                    Console.ReadKey(true);
                                                                    suicide = true;
                                                                    finpont = true;
                                                                    if (finpont == true && finpontf == false)
                                                                    {
                                                                        nbdefindécouvertes = nbdefindécouvertes + 1;
                                                                        finpontf = true;
                                                                    }
                                                                    goto confin;//*********************************************** fin pont ******************************************************************************************

                                                                }
                                                                Console.WriteLine("\nréussi\n");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous sortez du déni.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous prenez pleinement conscience de ce que vous avez fait.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous vous êtes nourrit de votre famille.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous êtes horrifié par ce que vous avez fait et votre santée mentale prend un gros coup.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous : je dois en finir.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("vous : je suis une nuisance pour les personnes qu'on aime.");
                                                                Console.ReadKey(true);
                                                                Console.WriteLine("???? : tu dois d'abord apporter la paix aux familles de nos victimes.");
                                                                Console.ReadKey(true);
                                                                trajet = true;
                                                                goto forêt;

                                                            }
                                                        }

                                                        if (revientafPM == true)
                                                        {
                                                            if (QTEfamd == true)
                                                            {
                                                                //******************************************************** coder suite fin après travail *****************************************
                                                                goto confin;
                                                                Console.WriteLine("");
                                                                Console.ReadKey(true);
                                                            }
                                                            if (QTEfamd == false)
                                                            {
                                                                //******************************************************** coder suite fin après travail *****************************************
                                                                goto confin;
                                                                Console.WriteLine("");
                                                                Console.ReadKey(true);
                                                            }
                                                        }
                                                        Console.WriteLine("vous sortez de votre voiture à l'entrée d'une épaisse forêt.");
                                                        Console.ReadKey(true);

                                                    }
                                                    else
                                                    {
                                                    pbureau:;
                                                        if (branche_parking == true) //suite au bureau
                                                        {
                                                            Console.WriteLine("vous regardez autour de vous.");
                                                            Console.ReadKey(true);
                                                            fin_casu = true;
                                                            goto confin;
                                                        }
                                                        if (QTEascenf == true)
                                                            Console.WriteLine("\nvous garez votre voiture dans le parking du bâtiment.");//début séquence parking
                                                        Console.ReadKey(true);
                                                        if (sac_à_lunch == true)
                                                        {
                                                            string lunch = "";
                                                        lunch:;
                                                            Console.WriteLine("votre lunch est sur la banquette arrière.");
                                                            Console.ReadKey(true);
                                                            Console.Write("voulez vous le prendre? [oui] [non] : ");
                                                            lunch = Convert.ToString(Console.ReadLine());
                                                            switch (lunch)
                                                            {
                                                                case "oui":
                                                                    {
                                                                        Console.WriteLine("\nvous ramasser votre lunch.\n");
                                                                        Console.ReadKey(true);
                                                                    }
                                                                    break;

                                                                case "non":
                                                                    {
                                                                        sac_à_lunch = false;
                                                                    }
                                                                    break;

                                                                default:
                                                                    {
                                                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                        Console.ReadKey(true);
                                                                        goto lunch;
                                                                    }
                                                                    break;
                                                            }
                                                        }
                                                        string parking = " ";
                                                        Console.WriteLine("vous sortez de la voiture et la fermez à clef.");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("vous êtes à l'heure.");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("il est 8h00.");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("vous vous dirigez vers la sortie du parking");
                                                        Console.ReadKey(true);
                                                    parking:;
                                                        Console.WriteLine("vous êtes devant une porte d'[ascenseur].");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("à coté il y a un [escalier]");
                                                        Console.ReadKey(true);
                                                        Console.WriteLine("votre [voiture] est à quelques mètres derrière vous.");
                                                        Console.ReadKey(true);
                                                        Console.Write("où voulez vous aller? : ");
                                                        parking = Convert.ToString(Console.ReadLine());

                                                        switch (parking)
                                                        {
                                                            case "ascenseur":
                                                                {
                                                                    if (QTEascen == true && QTEascenf == true)
                                                                    {
                                                                        Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                        Console.ReadKey(true);
                                                                    }
                                                                ascenceurfail:;
                                                                    if (QTEascen == false)
                                                                    {
                                                                        string étageacctu = "RC";
                                                                        string choixétage = " ";
                                                                        if (QTEascenf == false)
                                                                        {
                                                                            Console.WriteLine("\nvous appuyez sur le boutton pour appeler l'ascenseur.");
                                                                            Console.ReadKey(true);
                                                                            Console.WriteLine("il est au 5ièm étage.");
                                                                            Thread.Sleep(1000);
                                                                            Console.WriteLine("il est au 4ièm étage.");
                                                                            Thread.Sleep(1000);
                                                                            Console.WriteLine("il est au 3ièm étage.");
                                                                            Thread.Sleep(1000);
                                                                            Console.WriteLine("il est au 2ièm étage.");
                                                                            Thread.Sleep(1000);
                                                                            Console.WriteLine("il est au 1er étage.");
                                                                            Thread.Sleep(1000);
                                                                            Console.WriteLine("il est au rez-de-chaussé.");
                                                                            Console.ReadKey(true);
                                                                        }
                                                                        Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous entrez dans l'assenseur.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("les portes se referment.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("il est 9h00.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous êtes en retard.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous avez mal aux gencives.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vos mocassins sont plein de boue et de feuilles.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("vous savez pourquoi.");
                                                                        Console.ReadKey(true);
                                                                    ascenseurRC:;
                                                                        Console.WriteLine("il y a 6 bouttons dans l'ascenseur.");
                                                                        Console.ReadKey(true);
                                                                        Console.WriteLine("[RC],[1],[2],[3],[4] et [5].");
                                                                        Console.ReadKey(true);
                                                                        Console.Write("sur quel bouton appuyez vous? : ");
                                                                        choixétage = Convert.ToString(Console.ReadLine());

                                                                        switch (choixétage)
                                                                        {
                                                                            case "RC":
                                                                                {
                                                                                    Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                    Console.ReadKey(true);
                                                                                    étageacctu = "RC";
                                                                                    goto parking;
                                                                                }
                                                                                break;

                                                                            case "1":
                                                                                {
                                                                                    if (étageacctu == "1")
                                                                                    {
                                                                                        Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("il ne se passe rien.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("vous : je suis déja au 1er étage.\n");
                                                                                        goto ascenseurRC;
                                                                                    }

                                                                                    Console.WriteLine("\nvous : je suis déja assez en retard. je devrais aller travailler\n");
                                                                                    Console.ReadKey(true);
                                                                                    étageacctu = "RC";
                                                                                    goto ascenseurRC;
                                                                                }
                                                                                break;

                                                                            case "2":
                                                                                {
                                                                                    if (étageacctu == "2")
                                                                                    {
                                                                                        Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("il ne se passe rien.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("vous : je suis déja au 2ièm étage.\n");
                                                                                        goto ascenseurRC;
                                                                                    }

                                                                                    Console.WriteLine("\nvous : je suis déja assez en retard. je devrais aller travailler\n");
                                                                                    Console.ReadKey(true);
                                                                                    étageacctu = "RC";
                                                                                    goto ascenseurRC;
                                                                                }
                                                                                break;

                                                                            case "3":
                                                                                {
                                                                                    if (étageacctu == "3")
                                                                                    {
                                                                                        Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("il ne se passe rien.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("vous : je suis déja au 3ièm étage.\n");
                                                                                        goto ascenseurRC;
                                                                                    }

                                                                                    Console.WriteLine("\nvous : je suis déja assez en retard. je devrais aller travailler\n");
                                                                                    Console.ReadKey(true);
                                                                                    étageacctu = "RC";
                                                                                    goto ascenseurRC;

                                                                                }
                                                                                break;

                                                                            case "4":
                                                                                {
                                                                                    if (étageacctu == "4")
                                                                                    {
                                                                                        Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("il ne se passe rien.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("vous : je suis déja au 4ièm étage.\n");
                                                                                        goto ascenseurRC;
                                                                                    }

                                                                                    Console.WriteLine("\nvous : je suis déja assez en retard. je devrais aller travailler\n");
                                                                                    Console.ReadKey(true);
                                                                                    étageacctu = "RC";
                                                                                    goto ascenseurRC;

                                                                                }
                                                                                break;

                                                                            case "5":
                                                                                {
                                                                                    if (étageacctu == "5")
                                                                                    {
                                                                                        Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("il ne se passe rien.");
                                                                                        Console.ReadKey(true);
                                                                                        Console.WriteLine("vous : je suis déja au 5ièm étage.\n");
                                                                                        goto ascenseurRC;
                                                                                    }

                                                                                    Console.WriteLine("\nvous sentez l'ascenseur monter.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("l'ascenseur s'arrête au 5ièm étage.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                    Console.ReadKey(true);
                                                                                    étageacctu = "5";
                                                                                    branche_parking = true;
                                                                                    goto pbureau;
                                                                                }
                                                                                break;

                                                                            default:
                                                                                {
                                                                                    Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                    Console.ReadKey(true);
                                                                                    goto ascenceurfail;
                                                                                }
                                                                                break;

                                                                        }

                                                                    }
                                                                    double resu = 0;
                                                                    if (QTEascen == true)
                                                                    {
                                                                        if (QTEascenf == false)
                                                                        {
                                                                            Console.WriteLine("\nvous appuyez sur le boutton pour appeler l'ascenseur.");
                                                                            Console.ReadKey(true);
                                                                            Console.WriteLine("il est au 5ièm étage.");
                                                                            Thread.Sleep(2500);
                                                                            Console.WriteLine("vous sentez une bonne odeur.");
                                                                            Thread.Sleep(2250);
                                                                            Console.WriteLine("il est au 4ièm étage.");
                                                                            Thread.Sleep(2000);
                                                                            Console.WriteLine("l'odeur s'intensifie.");
                                                                            Thread.Sleep(1750);
                                                                            Console.WriteLine("il est au 3ièm étage.");
                                                                            Thread.Sleep(1500);
                                                                            Console.WriteLine("l'odeur s'intensifie.");
                                                                            Thread.Sleep(1250);
                                                                            Console.WriteLine("il est au 2ièm étage.");
                                                                            Thread.Sleep(1000);
                                                                            Console.WriteLine("l'odeur s'intensifie.");
                                                                            Thread.Sleep(975);
                                                                            Console.WriteLine("il est au 1er étage.");
                                                                            Thread.Sleep(1000);
                                                                            Console.Write("L'ODEUR! ");
                                                                            Thread.Sleep(2000);
                                                                            Console.WriteLine("S'INTENSIFIE!");
                                                                            Thread.Sleep(1000);
                                                                            Console.WriteLine("il est au rez-de-chaussée.\n");
                                                                            Console.ReadKey(true);
                                                                            int i = 0;
                                                                            if (tutoQTE == false)
                                                                            {
                                                                                Console.WriteLine("\nACTION DE RÉSISTER : Lorsque [RÉSISTEZ] s'affiche à l'écran vous pouvez perdre le controle de votre corps dans certaines situations.");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("pour garder le controle appuyer 10 fois de suite rapidement sur votre touche entrée dans le temps imparti.\n");
                                                                                Console.ReadKey(true);
                                                                                tutoQTE = true;
                                                                            }
                                                                            Console.WriteLine("3");
                                                                            Thread.Sleep(1000);
                                                                            Console.WriteLine("2");
                                                                            Thread.Sleep(1000);
                                                                            Console.WriteLine("1");
                                                                            Thread.Sleep(1000);
                                                                            Console.WriteLine("[RÉSISTEZ]");
                                                                            DateTime datea = DateTime.Now;//enregistre l'heur avant le QTE
                                                                            do
                                                                            {
                                                                                Console.ReadKey(true); i++;
                                                                            } while (i < 10);//nombre de fois que l'utilisateur dois appuyer
                                                                            DateTime dateb = DateTime.Now;//enregistre l'heur apres le QTE
                                                                            Console.WriteLine("QTE terminé");
                                                                            Thread.Sleep(3000);//délai pour ne pas passer la suite de l'histoire
                                                                            TimeSpan res = dateb.Subtract(datea);//soustrait l'heur du début à l'heur de fin
                                                                            resu = res.TotalSeconds;//converti le résultat en double en secondes
                                                                            Console.ReadKey(true);
                                                                        }
                                                                        if (sac_à_lunch == true)
                                                                        {
                                                                            if (resu < 3)
                                                                            {
                                                                                if (QTEascenf == false)
                                                                                {
                                                                                    Console.WriteLine("\nréussi\n");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous vous concentrez sur l'odeur de votre lunch.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous voyez 5 de vos collègues en sortir et elles se referment.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("ils sont restés au bureau toute la nuit pour finir de remplir les papier de la comptabilitée.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("ils ont l'air d'épaves vides.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous les saluez mais ils sont trop fatigués pour faire de même.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous soupirez.");
                                                                                    Console.ReadKey(true);
                                                                                }
                                                                                QTEascen = true;
                                                                                QTEascenf = true;
                                                                                branche_parking = true;
                                                                                string étageacctu = "RC";
                                                                                string choixétage = " ";
                                                                            ascenseur:;
                                                                                Console.WriteLine("\nvous entrez dans l'ascenseur.");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("les portes se referment");
                                                                                Console.ReadKey(true);
                                                                            étageacctu:;
                                                                                Console.WriteLine("il y a 6 bouttons dans l'ascenseur.");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("[RC],[1],[2],[3],[4] et [5].");
                                                                                Console.ReadKey(true);
                                                                                Console.Write("sur quel bouton appuyez vous? : ");
                                                                                choixétage = Convert.ToString(Console.ReadLine());

                                                                                switch (choixétage)
                                                                                {
                                                                                    case "RC":
                                                                                        {
                                                                                            if (étageacctu == "RC" || étageacctu == "rc")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au rez-de-chaussée.\n");
                                                                                                goto étageacctu;
                                                                                            }
                                                                                            Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur descendre.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au rez-de-chaussé.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "RC";
                                                                                            goto parking;
                                                                                        }
                                                                                        break;

                                                                                    case "1":
                                                                                        {
                                                                                            if (étageacctu == "1")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au 1er étage.\n");
                                                                                                goto étageacctu;
                                                                                            }

                                                                                            Console.WriteLine("\nvous appuyez sur le bouton 1.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur monter.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au 1er étage.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "1";

                                                                                            string choixresto = " ";
                                                                                            Console.WriteLine("vous êtes dans l'entrée d'un restaurant.");
                                                                                            Console.ReadKey(true);
                                                                                        resto:;
                                                                                            Console.WriteLine("devant vous il y a des [portes] sur lesquelles il y a un [écriteau].");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'entrée est sombre et le resto semble vide.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("derrière vous il y a l'[ascenseur]");
                                                                                            Console.ReadKey(true);
                                                                                            Console.Write("que voulez vous faire? : ");
                                                                                            choixresto = Convert.ToString(Console.ReadLine());

                                                                                            switch (choixresto)
                                                                                            {
                                                                                                case "ascenseur":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous appuyez sur le bouton de l'ascenseur.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les portes de l'ascenseur s'ouvrent\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto ascenseur;
                                                                                                    }
                                                                                                    break;

                                                                                                case "portes":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous vous approchez des portes du restaurant et essayez de les ouvrir.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les portes sont fermées.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous entreaperçevez un homme et une femme à une table.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vou : ils ont dû réserver tout le resto.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous soupirez en vous remémorant votre rencontre avec " + votre_femme + ".\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        visiterét1 = true;
                                                                                                        goto resto;
                                                                                                    }
                                                                                                    break;

                                                                                                case "écriteau":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous vous approchez des portes pour lire l'écriteau.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("il est écrit Fermé.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("en dessous il y a les horraires d'ouverture du restaurant");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous soupirez");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous : il n'ouvre au public qu'après mes heures de travail.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        visiterét1 = true;
                                                                                                        goto resto;
                                                                                                    }
                                                                                                    break;

                                                                                                default:
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto resto;
                                                                                                    }
                                                                                                    break;

                                                                                            }
                                                                                        }
                                                                                        break;

                                                                                    case "2":
                                                                                        {
                                                                                            if (étageacctu == "2")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton 2.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au 2ièm étage.\n");
                                                                                                goto étageacctu;
                                                                                            }

                                                                                            Console.WriteLine("\nvous appuyez sur le bouton 2.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur monter.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au 2ièm étage.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "2";
                                                                                        salledereception:;
                                                                                            string choixmarri = " ";
                                                                                            Console.WriteLine("vous êtes devant une [salle] de réception.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("il y a l'[ascenseur] derrière vous.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.Write("où voulez vous aller? : ");
                                                                                            choixmarri = Convert.ToString(Console.ReadLine());

                                                                                            switch (choixmarri)
                                                                                            {
                                                                                                case "ascenseur":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous appuyez sur le bouton de l'ascenseur.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les portes de l'ascenseur s'ouvrent\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto ascenseur;
                                                                                                    }
                                                                                                    break;

                                                                                                case "salle":
                                                                                                    {

                                                                                                        Console.WriteLine("\nvous vous approchez de la salle.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les tables et la décorations sont toutes blanches.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("la salle est pleine de gens.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("ils ont l'air de célébrer un marriage.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous soupirez avec nostalgie et tristesse.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        visiterét2 = true;
                                                                                                        goto salledereception;
                                                                                                    }
                                                                                                    break;

                                                                                                default:
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto salledereception;
                                                                                                    }
                                                                                                    break;
                                                                                            }
                                                                                        }
                                                                                        break;

                                                                                    case "3":
                                                                                        {
                                                                                            if (étageacctu == "3")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton 3.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au 3ièm étage.\n");
                                                                                                goto étageacctu;
                                                                                            }

                                                                                            Console.WriteLine("\nvous appuyez sur le bouton 3.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur monter.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au 3ièm étage.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "3";

                                                                                            string choixclinique = " ";
                                                                                            bool porte = false;
                                                                                            Console.WriteLine("vous êtes dans une clinique de naissances privée.");
                                                                                            Console.ReadKey(true);
                                                                                        clinique:;
                                                                                            Console.WriteLine("devant vous il y a les [portes] de la salle d'attente.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("un peu plus loing vous voyez une [vitre].");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous entendez des cries depuis une des [salles].");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("derrière vous il y a l'[ascenseur].");
                                                                                            Console.ReadKey(true);
                                                                                            Console.Write("où voulez vous allez? : ");
                                                                                            choixclinique = Convert.ToString(Console.ReadLine());

                                                                                            switch (choixclinique)
                                                                                            {
                                                                                                case "ascenseur":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous appuyez sur le bouton de l'ascenseur.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les portes de l'ascenseur s'ouvrent\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto ascenseur;
                                                                                                    }
                                                                                                    break;

                                                                                                case "salles":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous entrez dans la salle d'attente.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("elle est remplie de femmes enceintes qui attendent une consultation.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("votre attention est attiré par une femme qui attend sans son mari pour l'accompagner.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous sentez une pression sur votre torse.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous sortez de la salle d'attente\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        visiterét3 = true;
                                                                                                        goto clinique;
                                                                                                    }
                                                                                                    break;

                                                                                                case "vitre":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous vous approcher de la grande vitre rectangulaire.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("de l'autre côté il y a la garderie de la clinique.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("tout les berceaux ont au moins un bébé et certains en ont deux.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous vous éloignez de la vitre.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        visiterét3 = true;
                                                                                                        goto clinique;
                                                                                                    }
                                                                                                    break;

                                                                                                case "portes":
                                                                                                    {
                                                                                                        if (porte == false)
                                                                                                        {
                                                                                                            Console.WriteLine("\nvous vous apprrochez de la salle d'où proviennent les cris.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("quand vous arrivez devant la porte de la salle vous voyez une femme qui acouche.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("un médecin vous voit et ferme la porte de la salle");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("vous entendez le médecin dire qu'il doit procéder à une césarienne.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("un frisson vous parcours le dos.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("vous retournez d'où vous venez.\n");
                                                                                                            Console.ReadKey(true);
                                                                                                            visiterét3 = true;
                                                                                                            porte = true;
                                                                                                            goto clinique;
                                                                                                        }

                                                                                                        else
                                                                                                        {
                                                                                                            Console.WriteLine("\nvous ne voyez pas d'intérêt à retourner là bas.\n");
                                                                                                            Console.ReadKey(true);
                                                                                                            goto clinique;
                                                                                                        }
                                                                                                    }
                                                                                                    break;

                                                                                                default:
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto clinique;
                                                                                                    }
                                                                                                    break;
                                                                                            }

                                                                                        }
                                                                                        break;

                                                                                    case "4":
                                                                                        {
                                                                                            if (étageacctu == "4")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton 4.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au 4ièm étage.\n");
                                                                                                goto étageacctu;
                                                                                            }

                                                                                            Console.WriteLine("\nvous appuyez sur le bouton 4.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur monter.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au 4ièm étage.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "4";

                                                                                            string choixretraite = " ";
                                                                                            bool parlersecr = false;
                                                                                            Console.WriteLine("vous êtes dans une maison de retraite.");
                                                                                            Console.ReadKey(true);
                                                                                        retraite:;
                                                                                            Console.WriteLine("vous voyez la [secrétaire] devant vous derrière sont bureau.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous avez l'[ascenseur] derrière vous.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.Write("où voulez vous aller? : ");
                                                                                            choixretraite = Convert.ToString(Console.ReadLine());

                                                                                            switch (choixretraite)
                                                                                            {
                                                                                                case "ascenseur":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous appuyez sur le bouton de l'ascenseur.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les portes de l'ascenseur s'ouvrent\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto ascenseur;

                                                                                                    }
                                                                                                    break;

                                                                                                case "secrétaire":
                                                                                                    {
                                                                                                        if (parlersecr == false)
                                                                                                        {
                                                                                                            Console.WriteLine("\nvous vous approchez du bureau de la secrétaire.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("elle vous dit bonjour et commence à vous décrire l'endroit.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("vous éccoutez à peine car vous êtes dans vos pensées.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("vous soupirez.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("vous éprouvez du regret en vous éloignant du bureau de la secrétaire.\n");
                                                                                                            Console.ReadKey(true);
                                                                                                            visiterét4 = true;
                                                                                                            goto retraite;
                                                                                                        }

                                                                                                        else
                                                                                                        {
                                                                                                            Console.WriteLine("\nvous ne voyez pas l'intérêt de reparler à la secrétaire.\n");
                                                                                                            Console.ReadKey(true);
                                                                                                            goto retraite;
                                                                                                        }
                                                                                                    }
                                                                                                    break;

                                                                                                default:
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto retraite;
                                                                                                    }
                                                                                                    break;
                                                                                            }
                                                                                        }
                                                                                        break;

                                                                                    case "5":
                                                                                        {
                                                                                            if (étageacctu == "5")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton 5.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au 5ièm étage.\n");
                                                                                                goto étageacctu;
                                                                                            }

                                                                                            Console.WriteLine("\nvous appuyez sur le bouton 5.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur monter.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au 5ièm étage.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "5";
                                                                                            branche_parking = true;
                                                                                            goto pbureau;
                                                                                        }
                                                                                        break;

                                                                                    default:
                                                                                        {
                                                                                            Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                            Console.ReadKey(true);
                                                                                            goto ascenseur;
                                                                                        }
                                                                                        break;

                                                                                }
                                                                            }

                                                                            else
                                                                            {
                                                                                Console.WriteLine("\nraté\n");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("...");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("...");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("...");
                                                                                Console.ReadKey(true);
                                                                                QTEascen = false;
                                                                                QTEascenf = true;
                                                                                branche_parking = true;
                                                                                goto ascenceurfail;
                                                                            }
                                                                        }
                                                                        if (sac_à_lunch == false)
                                                                        {
                                                                            if (resu < 2)
                                                                            {
                                                                                if (QTEascenf == true)
                                                                                {
                                                                                    Console.WriteLine("\nréussi\n");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous voyez 5 de vos collègues en sortir et elles se referment.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("ils sont restés au bureau toutes la nuit pour finir de remplir les papier de la comptabilitée.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("ils ont l'air d'épaves vides.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous les saluez mais ils sont trop fatigués pour faire de même.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous soupirez.");
                                                                                    Console.ReadKey(true);
                                                                                }
                                                                                QTEascen = true;
                                                                                QTEascenf = true;
                                                                                branche_parking = true;
                                                                                string étageacctu = "RC";
                                                                                string choixétage = " ";
                                                                            ascenseur:;
                                                                                Console.WriteLine("\nvous entrez dans l'ascenseur.");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("les portes se referment");
                                                                                Console.ReadKey(true);
                                                                            ascenseurRC:;
                                                                                Console.WriteLine("il y a 6 bouttons dans l'ascenseur.");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("[RC],[1],[2],[3],[4] et [5].");
                                                                                Console.ReadKey(true);
                                                                                Console.Write("sur quel bouton appuyez vous? : ");
                                                                                choixétage = Convert.ToString(Console.ReadLine());

                                                                                switch (choixétage)
                                                                                {
                                                                                    case "RC":
                                                                                        {
                                                                                            if (étageacctu == "RC")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au rez-de-chaussée.\n");
                                                                                                goto ascenseurRC;
                                                                                            }

                                                                                            Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur descendre.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au rez-de-chaussé.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "RC";
                                                                                            goto parking;
                                                                                        }
                                                                                        break;

                                                                                    case "1":
                                                                                        {
                                                                                            if (étageacctu == "1")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton RC.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au 1er étage.\n");
                                                                                                goto ascenseurRC;
                                                                                            }

                                                                                            Console.WriteLine("\nvous appuyez sur le bouton 1.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur monter.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au 1er étage.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "1";

                                                                                            string choixresto = " ";
                                                                                            Console.WriteLine("vous êtes dans l'entrée d'un restaurant.");
                                                                                            Console.ReadKey(true);
                                                                                        resto:;
                                                                                            Console.WriteLine("devant vous il y a des [portes] sur lesquelles il y a un [écriteau].");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'entrée est sombre et le resto semble vide.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("derrière vous il y a l'[ascenseur]");
                                                                                            Console.ReadKey(true);
                                                                                            Console.Write("que voulez vous faire? : ");
                                                                                            choixresto = Convert.ToString(Console.ReadLine());

                                                                                            switch (choixresto)
                                                                                            {
                                                                                                case "ascenseur":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous appuyez sur le bouton de l'ascenseur.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les portes de l'ascenseur s'ouvrent\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto ascenseur;
                                                                                                    }
                                                                                                    break;

                                                                                                case "portes":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous vous approchez des portes du restaurant et essayez de les ouvrir.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les portes sont fermées.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous entreaperçevez un homme et une femme à une table.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vou : ils ont dû réserver tout le resto.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous soupirez en vous remémorant votre rencontre avec " + votre_femme + ".\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        visiterét1 = true;
                                                                                                        goto resto;
                                                                                                    }
                                                                                                    break;

                                                                                                case "écriteau":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous vous approchez des portes pour lire l'écriteau.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("il est écrit Fermé.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("en dessous il y a les horraires d'ouverture du restaurant");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous soupirez");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous : il n'ouvre au public qu'après mes heures de travail.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        visiterét1 = true;
                                                                                                        goto resto;
                                                                                                    }
                                                                                                    break;

                                                                                                default:
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto resto;
                                                                                                    }
                                                                                                    break;

                                                                                            }
                                                                                        }
                                                                                        break;

                                                                                    case "2":
                                                                                        {
                                                                                            if (étageacctu == "2")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton 2.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au 2ièm étage.\n");
                                                                                                goto ascenseurRC;
                                                                                            }

                                                                                            Console.WriteLine("\nvous appuyez sur le bouton 2.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur monter.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au 2ièm étage.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "2";
                                                                                        salledereception:;
                                                                                            string choixmarri = " ";
                                                                                            Console.WriteLine("vous êtes devant une [salle] de réception.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("il y a l'[ascenseur] derrière vous.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.Write("où voulez vous aller? : ");
                                                                                            choixmarri = Convert.ToString(Console.ReadLine());

                                                                                            switch (choixmarri)
                                                                                            {
                                                                                                case "ascenseur":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous appuyez sur le bouton de l'ascenseur.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les portes de l'ascenseur s'ouvrent\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto ascenseur;
                                                                                                    }
                                                                                                    break;

                                                                                                case "salle":
                                                                                                    {

                                                                                                        Console.WriteLine("\nvous vous approchez de la salle.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les tables et la décorations sont toutes blanches.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("la salle est pleine de gens.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("ils ont l'air de célébrer un marriage.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous soupirez avec nostalgie et tristesse.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        visiterét2 = true;
                                                                                                        goto salledereception;
                                                                                                    }
                                                                                                    break;

                                                                                                default:
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto salledereception;
                                                                                                    }
                                                                                                    break;
                                                                                            }
                                                                                        }
                                                                                        break;

                                                                                    case "3":
                                                                                        {
                                                                                            if (étageacctu == "3")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton 3.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au 3ièm étage.\n");
                                                                                                goto ascenseurRC;
                                                                                            }

                                                                                            Console.WriteLine("\nvous appuyez sur le bouton 3.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur monter.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au 3ièm étage.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "3";

                                                                                            string choixclinique = " ";
                                                                                            bool porte = false;
                                                                                            Console.WriteLine("vous êtes dans une clinique de naissances privée.");
                                                                                            Console.ReadKey(true);
                                                                                        clinique:;
                                                                                            Console.WriteLine("devant vous il y a les [portes] de la salle d'attente.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("un peu plus loing vous voyez une [vitre].");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous entendez des cries depuis une des [salles].");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("derrière vous il y a l'[ascenseur].");
                                                                                            Console.ReadKey(true);
                                                                                            Console.Write("où voulez vous allez? : ");
                                                                                            choixclinique = Convert.ToString(Console.ReadLine());

                                                                                            switch (choixclinique)
                                                                                            {
                                                                                                case "ascenseur":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous appuyez sur le bouton de l'ascenseur.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les portes de l'ascenseur s'ouvrent\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto ascenseur;
                                                                                                    }
                                                                                                    break;

                                                                                                case "salles":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous entrez dans la salle d'attente.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("elle est remplie de femmes enceintes qui attendent une consultation.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("votre attention est attiré par une femme qui attend sans son mari pour l'accompagner.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous sentez une pression sur votre torse.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous sortez de la salle d'attente\n");
                                                                                                        Console.ReadKey();
                                                                                                        visiterét3 = true;
                                                                                                        goto clinique;
                                                                                                    }
                                                                                                    break;

                                                                                                case "vitre":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous vous approcher de la grande vitre rectangulaire.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("de l'autre côté il y a la garderie de la clinique.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("tout les berceaux ont au moins un bébé et certains en ont deux.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("vous vous éloignez de la vitre.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        visiterét3 = true;
                                                                                                        goto clinique;
                                                                                                    }
                                                                                                    break;

                                                                                                case "portes":
                                                                                                    {
                                                                                                        if (porte == false)
                                                                                                        {
                                                                                                            Console.WriteLine("\nvous vous apprrochez de la salle d'où proviennent les cris.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("quand vous arrivez devant la porte de la salle vous voyez une femme qui acouche.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("un médecin vous voit et ferme la porte de la salle");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("vous entendez le médecin dire qu'il doit procéder à une césarienne.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("un frisson vous parcours le dos.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("vous retournez d'où vous venez.\n");
                                                                                                            Console.ReadKey(true);
                                                                                                            visiterét3 = true;
                                                                                                            porte = true;
                                                                                                            goto clinique;
                                                                                                        }

                                                                                                        else
                                                                                                        {
                                                                                                            Console.WriteLine("\nvous ne voyez pas d'intérêt à retourner là bas.\n");
                                                                                                            Console.ReadKey(true);
                                                                                                            goto clinique;
                                                                                                        }
                                                                                                    }
                                                                                                    break;

                                                                                                default:
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto clinique;
                                                                                                    }
                                                                                                    break;
                                                                                            }

                                                                                        }
                                                                                        break;

                                                                                    case "4":
                                                                                        {
                                                                                            if (étageacctu == "4")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton 4.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au 4ièm étage.\n");
                                                                                                goto ascenseurRC;
                                                                                            }

                                                                                            Console.WriteLine("\nvous appuyez sur le bouton 4.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur monter.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au 4ièm étage.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "4";

                                                                                            string choixretraite = " ";
                                                                                            bool parlersecr = false;
                                                                                            Console.WriteLine("vous êtes dans une maison de retraite.");
                                                                                            Console.ReadKey(true);
                                                                                        retraite:;
                                                                                            Console.WriteLine("vous voyez la [secrétaire] devant vous derrière sont bureau.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous avez l'[ascenseur] derrière vous.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.Write("où voulez vous aller? : ");
                                                                                            choixretraite = Convert.ToString(Console.ReadLine());

                                                                                            switch (choixretraite)
                                                                                            {
                                                                                                case "ascenseur":
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous appuyez sur le bouton de l'ascenseur.");
                                                                                                        Console.ReadKey(true);
                                                                                                        Console.WriteLine("les portes de l'ascenseur s'ouvrent\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto ascenseur;

                                                                                                    }
                                                                                                    break;

                                                                                                case "secrétaire":
                                                                                                    {
                                                                                                        if (parlersecr == false)
                                                                                                        {
                                                                                                            Console.WriteLine("\nvous vous approchez du bureau de la secrétaire.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("elle vous dit bonjour et commence à vous décrire l'endroit.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("vous éccoutez à peine car vous êtes dans vos pensées.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("vous soupirez.");
                                                                                                            Console.ReadKey(true);
                                                                                                            Console.WriteLine("vous éprouvez du regret en vous éloignant du bureau de la secrétaire.\n");
                                                                                                            Console.ReadKey(true);
                                                                                                            visiterét4 = true;
                                                                                                            goto retraite;
                                                                                                        }

                                                                                                        else
                                                                                                        {
                                                                                                            Console.WriteLine("\nvous ne voyez pas l'intérêt de reparler à la secrétaire.\n");
                                                                                                            Console.ReadKey(true);
                                                                                                            goto retraite;
                                                                                                        }
                                                                                                    }
                                                                                                    break;

                                                                                                default:
                                                                                                    {
                                                                                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                                        Console.ReadKey(true);
                                                                                                        goto retraite;
                                                                                                    }
                                                                                                    break;
                                                                                            }
                                                                                        }
                                                                                        break;

                                                                                    case "5":
                                                                                        {
                                                                                            if (étageacctu == "5")
                                                                                            {
                                                                                                Console.WriteLine("\nvous appuyez sur le bouton 5.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("il ne se passe rien.");
                                                                                                Console.ReadKey(true);
                                                                                                Console.WriteLine("vous : je suis déja au 5ièm étage.\n");
                                                                                                goto ascenseurRC;
                                                                                            }

                                                                                            Console.WriteLine("\nvous appuyez sur le bouton 5.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sentez l'ascenseur monter.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("l'ascenseur s'arrête au 5ièm étage.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("les portes de l'ascenseur s'ouvrent.");
                                                                                            Console.ReadKey(true);
                                                                                            Console.WriteLine("vous sortez de l'ascenseur et les portes se referment derrière vous.\n");
                                                                                            Console.ReadKey(true);
                                                                                            étageacctu = "5";
                                                                                            branche_parking = true;
                                                                                            goto pbureau;
                                                                                        }
                                                                                        break;

                                                                                    default:
                                                                                        {
                                                                                            Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                                            Console.ReadKey(true);
                                                                                            goto ascenseur;
                                                                                        }
                                                                                        break;

                                                                                }
                                                                            }

                                                                            else
                                                                            {
                                                                                Console.WriteLine("\nraté\n");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("...");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("...");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("...");
                                                                                Console.ReadKey(true);
                                                                                QTEascen = false;
                                                                                QTEascenf = true;
                                                                                branche_parking = true;
                                                                                goto ascenceurfail;
                                                                            }
                                                                        }

                                                                    }

                                                                }
                                                                break;

                                                            case "escalier":
                                                                {
                                                                    Console.WriteLine("vous ouvrez la porte des escaliers.");
                                                                    Console.ReadKey(true);
                                                                    Console.WriteLine("vous montez jusqu'au 5ièm étage où se trouve les bureaux de l'entreprise pour laquelle vous travaillez.");
                                                                    Console.ReadKey(true);
                                                                    branche_parking = true;
                                                                    goto pbureau;
                                                                }
                                                                break;

                                                            case "voiture":
                                                                {
                                                                    if (QTEfamdf == true)
                                                                    {
                                                                        if (QTEfamd == false)
                                                                        {
                                                                            if (contvoit == 3)
                                                                            {
                                                                                Console.Write("\nvous : JE ");
                                                                                Thread.Sleep(1500);
                                                                                Console.Write("DOIS ");
                                                                                Thread.Sleep(1500);
                                                                                Console.Write("ALLER ");
                                                                                Thread.Sleep(1500);
                                                                                Console.Write("TRAVAILLER!\n");
                                                                                Thread.Sleep(500);
                                                                                contvoit = contvoit + 1;
                                                                                goto parking;
                                                                            }

                                                                            if (contvoit == 5)
                                                                            {
                                                                                Console.WriteLine("\n???? : tu sais que c'est la seul option.");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("vous : non.");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("???? : tu sais ce que nous leur avons fait.\n");
                                                                                Console.ReadKey(true);
                                                                                contvoit = contvoit + 1;
                                                                                goto parking;
                                                                            }

                                                                            if (contvoit == 10)
                                                                            {
                                                                                int i = 0;
                                                                                Console.WriteLine("3");
                                                                                Thread.Sleep(1000);
                                                                                Console.WriteLine("2");
                                                                                Thread.Sleep(1000);
                                                                                Console.WriteLine("1");
                                                                                Thread.Sleep(1000);
                                                                                Console.WriteLine("[RÉSISTEZ]");
                                                                                DateTime datea = DateTime.Now;//enregistre l'heur avant le QTE
                                                                                do
                                                                                {
                                                                                    Console.ReadKey(); i++;
                                                                                } while (i < 10);//nombre de fois que l'utilisateur dois appuyer
                                                                                DateTime dateb = DateTime.Now;//enregistre l'heur apres le QTE
                                                                                Console.WriteLine("QTE terminé");
                                                                                Thread.Sleep(3000);//délai pour ne pas passer la suite de l'histoire
                                                                                TimeSpan res = dateb.Subtract(datea);//soustrait l'heur du début à l'heur de fin
                                                                                double resu = res.TotalSeconds;//converti le résultat en double en secondes
                                                                                Console.ReadKey();
                                                                                if (resu < 4)
                                                                                {
                                                                                    Console.WriteLine("\nréussi\n");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous reprenez vos esprits.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous : il est vraiment temps d'aller travailler maintenant.\n");
                                                                                    Console.ReadKey(true);
                                                                                    goto parking;
                                                                                }
                                                                                else
                                                                                {
                                                                                    revientafAM = true;
                                                                                    Console.WriteLine("\nraté\n");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous craquez.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous rentrez dans votre voiture.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous démarrez la voiture, sortez du parking et rejoignez la route.\n");
                                                                                    branche_parking = true;
                                                                                    goto forêt;
                                                                                }
                                                                            }

                                                                            else
                                                                            {
                                                                                Console.WriteLine("\nvous : je dois aller travailler.\n");
                                                                                Console.ReadKey(true);
                                                                                contvoit = contvoit + 1;
                                                                                goto parking;
                                                                            }
                                                                        }

                                                                        if (QTEfamd == true)
                                                                        {
                                                                            if (contvoit == 3)
                                                                            {
                                                                                Console.Write("\nvous : JE ");
                                                                                Thread.Sleep(1500);
                                                                                Console.Write("DOIS ");
                                                                                Thread.Sleep(1500);
                                                                                Console.Write("ALLER ");
                                                                                Thread.Sleep(1500);
                                                                                Console.Write("TRAVAILLER!\n");
                                                                                Thread.Sleep(500);
                                                                                contvoit = contvoit + 1;
                                                                                goto parking;
                                                                            }

                                                                            if (contvoit == 5)
                                                                            {
                                                                                Console.WriteLine("\n???? : tu savais que un jour ça allai arriver.");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("vous : arrêt.");
                                                                                Console.ReadKey(true);
                                                                                Console.WriteLine("???? : tu sais ce que nous allions leur faire.\n");
                                                                                Console.ReadKey(true);
                                                                                contvoit = contvoit + 1;
                                                                                goto parking;
                                                                            }

                                                                            if (contvoit == 10)
                                                                            {
                                                                                int i = 0;
                                                                                Console.WriteLine("3");
                                                                                Thread.Sleep(1000);
                                                                                Console.WriteLine("2");
                                                                                Thread.Sleep(1000);
                                                                                Console.WriteLine("1");
                                                                                Thread.Sleep(1000);
                                                                                Console.WriteLine("[RÉSISTEZ]");
                                                                                DateTime datea = DateTime.Now;//enregistre l'heur avant le QTE
                                                                                do
                                                                                {
                                                                                    Console.ReadKey(); i++;
                                                                                } while (i < 10);//nombre de fois que l'utilisateur dois appuyer
                                                                                DateTime dateb = DateTime.Now;//enregistre l'heur apres le QTE
                                                                                Console.WriteLine("QTE terminé");
                                                                                Thread.Sleep(3000);//délai pour ne pas passer la suite de l'histoire
                                                                                TimeSpan res = dateb.Subtract(datea);//soustrait l'heur du début à l'heur de fin
                                                                                double resu = res.TotalSeconds;//converti le résultat en double en secondes
                                                                                Console.ReadKey();
                                                                                if (resu < 5)
                                                                                {
                                                                                    Console.WriteLine("\nréussi\n");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous reprenez vos esprits.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous : il est vraiment temps d'aller travailler maintenant.\n");
                                                                                    Console.ReadKey(true);
                                                                                    goto parking;
                                                                                }
                                                                                else
                                                                                {
                                                                                    revientafAM = true;
                                                                                    Console.WriteLine("\nraté\n");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous craquez.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous rentrez dans votre voiture.");
                                                                                    Console.ReadKey(true);
                                                                                    Console.WriteLine("vous démarrez la voiture, sortez du parking et rejoignez la route.\n");
                                                                                    branche_parking = true;
                                                                                    trajet = true;
                                                                                    goto forêt;
                                                                                }
                                                                            }

                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("\nvous : je dois aller travailler.\n");
                                                                            Console.ReadKey(true);
                                                                            goto parking;
                                                                        }
                                                                    }
                                                                }
                                                                break;

                                                            default:
                                                                {
                                                                    Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                                    Console.ReadKey(true);
                                                                    goto parking;
                                                                }
                                                                break;
                                                        }
                                                    }

                                                }
                                                break;

                                            default:
                                                {
                                                    Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                                    Console.ReadKey(true);
                                                    goto allerautaf;
                                                }
                                                break;
                                        }

                                    }
                                    break;

                                default:
                                    {
                                        Console.WriteLine("\nvous soupirez en étant confus, car vous ne comprenez pas ce que votre cerveau essaye de vous faire faire.\n");
                                        Console.ReadKey(true);
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
                        Console.ReadKey(true);
                        goto chambre;
                    }
                    break;
            }

        confin:;

            string fin = " ";
            Console.WriteLine("\n\nFIN");
            Console.ReadKey(true);//*************************************************** affichage de succès ************************************************************
            Console.ForegroundColor = ConsoleColor.Green;
            if (visiterét1 == true && visiterét2 == true && visiterét3 == true && visiterét4 == true && nostalgie == false)
            { Console.WriteLine("\nsuccès débloqué (nostalgie) : avoir visité tout les étages du bâtiment au travail.\n"); nbdetropdécouverts = nbdetropdécouverts + 1; nostalgie = true; Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Red;
            if (visiterét1 == false || visiterét2 == false || visiterét3 == false || visiterét4 == false && nostalgie == false)
            { Console.WriteLine("\nsuccès manquant (nostalgie) : avoir visité tout les étages du bâtiment au travail.\n"); Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Green;
            if (bain == true && rasoir == true && suicide == true && mort_avec_classe == false)
            { Console.WriteLine("\nsuccès débloqué (mort avec classe) : se raser, prendre un bain, mourrir."); nbdetropdécouverts = nbdetropdécouverts + 1; mort_avec_classe = true; Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Red;
            if (bain == false || rasoir == false || suicide == false && mort_avec_classe == false)
            { Console.WriteLine("\nsuccès manquant (mort avec classe) : se raser, prendre un bain, mourrir."); Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Green;
            if (mangerlapin == true && repas_mignon == false)
            { Console.WriteLine("\nsuccès débloqué (repas mignon) : un lapin? sérieusement?"); nbdetropdécouverts = nbdetropdécouverts + 1; repas_mignon = true; Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Red;
            if (mangerlapin == false && repas_mignon == false)
            { Console.WriteLine("\nsuccès manquant (repas mignon) : un lapin? sérieusement?"); Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Green;
            if (découvrirvéritée == true && la_véritée == false)
            { Console.WriteLine("\nsuccès débloqué (la véritée) : découvrez la véritée sur les personnes disparue ces dernières années."); nbdetropdécouverts = nbdetropdécouverts + 1; la_véritée = true; Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Red;
            if (découvrirvéritée == false && la_véritée == false)
            { Console.WriteLine("\nsuccès manquant (la véritée) : découvrez la véritée sur les personnes disparue ces dernières années."); Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Green;
            if (folie == true && devenir_fou == false)
            { Console.WriteLine("\nsuccès débloqué (devenir fou) : vous n'avez pas supproté le poid de tous vos actes."); devenir_fou = true; nbdetropdécouverts = nbdetropdécouverts + 1; Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Red;
            if (folie == false && devenir_fou == false)
            { Console.WriteLine("\nsuccès manquant (devenir fou) : vous n'avez pas supproté le poid de tous vos actes."); Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Green;
            if (dévoilervéritée == true && paix_aux_familles == false)
            { Console.WriteLine("\nsuccès débloqué (paix aux victimes) : dévoilez clairement vos crimes."); nbdetropdécouverts = nbdetropdécouverts + 1; paix_aux_familles = true; Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Red;
            if (dévoilervéritée == false && paix_aux_familles == false)
            { Console.WriteLine("\nsuccès manquant (paix aux victimes) : dévoilez clairement vos crimes."); Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Green;
            if (finkarma == true && si_prêt_du_but == false)
            { Console.WriteLine("\nsuccès débloqué (si prêt du but) : débloquer la fin karma."); nbdetropdécouverts = nbdetropdécouverts + 1; si_prêt_du_but = true; Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Red;
            if (finkarma == false && si_prêt_du_but == false)
            { Console.WriteLine("\nsuccès manquant (si prêt du but) : débloquer la fin karma."); Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Green;
            if (finsoleil == true && la_prévention_avant_tout == false)
            { Console.WriteLine("\nsuccès débloqué (la prévention avant tout) : débloquer la meilleur fin."); nbdetropdécouverts = nbdetropdécouverts + 1; la_prévention_avant_tout = true; Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Red;
            if (finsoleil == false && la_prévention_avant_tout == false)
            { Console.WriteLine("\nsuccès manquant (la prévention avant tout) : débloquer la meilleur fin."); Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Green;
            if (finpont == true && âme_sensible == false)
            { Console.WriteLine("\nsuccès débloqué (âme sensible) : débloquer la fin du pont."); nbdetropdécouverts = nbdetropdécouverts + 1; âme_sensible = true; Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Red;
            if (finpont == false && âme_sensible == false)
            { Console.WriteLine("\nsuccès manquant (âme sensible) : débloquer la fin du pont."); Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Green;
            if (finpieux == true && brochette_de_folie == false)
            { Console.WriteLine("\nsuccès débloqué (brochette de folie)  : débloquer la fin du pieu."); nbdetropdécouverts = nbdetropdécouverts + 1; brochette_de_folie = true; Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Red;
            if (finpieux == false && brochette_de_folie == false)
            { Console.WriteLine("\nsuccès manquant (brochette de folie)  : débloquer la fin du pieu."); Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Green;
            if (nbdetropdécouverts == nbdetroptotale && merci_gros_fou == false)
            { Console.WriteLine("\nsuccès débloqué (merci gros fou) : finissez le jeu à 100% en débloquant toutes les fin et tous les succès."); merci_gros_fou = true; Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.Red;
            if (nbdetropdécouverts != nbdetroptotale && merci_gros_fou == false)
            { Console.WriteLine("\nsuccès manquant (merci gros fou) : finissez le jeu à 100% en débloquant toutes les fin et tous les succès."); Thread.Sleep(500); }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nVous avez découvert " + nbdefindécouvertes + " / " + nbdefintotale + " fins.");
            Thread.Sleep(500);
            Console.WriteLine("\nVous avez débloqué " + nbdetropdécouverts + " / " + nbdetroptotale + " succès.");
            Thread.Sleep(500);
            if (fin_casu == true) { Console.WriteLine("Pour débloquer les autres fins soyez très persistant avec votre voiture dans le parking et ne résistez pas à la voix."); }
            Console.ReadKey();//*************************************************** message de fin *****************************************************************
            Console.WriteLine("\n\n\n\nMerci d'avoir joué à la démo de mon premier jeu!!!!");// enlever et mettre les succès
            Console.ReadKey(true);
            if (merci_gros_fou == true)
            {
                Console.WriteLine("ATTENDS?!!!");
                Console.ReadKey(true);
                Console.WriteLine("QUOI?!!!");
                Console.ReadKey(true);
                Console.WriteLine("tu as fini le jeu à 100% ?!!!");
                Console.ReadKey(true);
                Console.WriteLine("WOW!");
                Console.ReadKey(true);
                Console.WriteLine("j'aurais vraiment pas cru que quelqu'un aurais eu la patience de faire ça.");
                Console.ReadKey(true);
                Console.WriteLine("ducoup désoler j'ai pas prévu d'easter egg des 100%.");
                Console.ReadKey(true);
                Console.WriteLine("mais bon à la place je peux te donner des idées que j'ai pour mes prochains jeux.");
                Console.ReadKey(true);
                Console.WriteLine("j'aimerais faire un jeu matrix, un jeu à la subnautica mais sur une planète volcanique ou encore un god of war dans la mythologie de lovecraft.");
                Console.ReadKey(true);
                Console.WriteLine("voila merci encore d'avoir fini le jeu au complet et j'espère que il t'as plus.");
                Console.ReadKey(true);
                Console.WriteLine("en dernier cadeau je te donne même mon gmail pour que tu m'envoi directement tes commentaires sur le jeu (Kphd64@gmail.com)");
                Console.ReadKey(true);
                goto fin;
            }
            Console.WriteLine("n'hésitez pas à me faire part de vos commentaires et à me demander la suite quand je l'aurai fini si vous avez appréciez cette démo.");//mettre un message d'accès anticipé.
            Console.ReadKey(true);
            Console.WriteLine("si vous même vous sentez triste quotidiennement ou si vous avez des idées suicidaire vous n'hésitez pas à aller chercher de l'aide ou appeler les numéros du site ci-dessous.");
            Console.WriteLine("https://www.infosuicide.org/urgences-aide-ressources/lignes-decoute/");
            Console.ReadKey(true);
            Console.WriteLine("\nvoulez vous [rejouer] ou [quitter] le jeu?\n");
            Console.Write("choix : ");
        menuf:;
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
                Console.ReadKey(true);
                goto menuf;
            }
        fin:;
            Console.ReadKey(true);
        }
    }
}