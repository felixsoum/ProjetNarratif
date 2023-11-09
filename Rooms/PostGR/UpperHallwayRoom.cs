using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class UpperHallwayRoom : Room
    {
        internal static bool thirddeath;
        internal override string CreateDescription() =>
@"Le couloir est sombre et tu ne vois pas bien.
Tu entends du bruit venir de ta chambre. Il se rapproche de la porte!
Vite, caches-toi :
Tu te rends jusqu'aux escaliers de l'autre côté du couloir. [escaliers]
Tic Tac Tic Tac... Tu te caches derrière l'horloge [horloge]
Tu cours vers la toilette. [toilette]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "escaliers":
                    Console.WriteLine("Tu tentes de te rendre jusqu'aux escaliers.");
                    Console.WriteLine("Une fois devant tu manques la première marche et déboules les escaliers");
                    Console.WriteLine("Fin 3 : Une mort abrupt");
                    thirddeath = true;
                    break;
                case "horloge":
                    Console.WriteLine("Tu te dirige rapidement vers l'horloge et te cache derrière");
                    Console.WriteLine("TIC TAC TIC TAC TIC TAC");
                    Console.WriteLine("Le bruit de l'horloge t'empêche de savoir où il est allé...");

                    break;
                case "toilette":
                    int in1 = 0, in2 = 0, in3 = 0, in4 = 0, in5 =0;
                    //34567
                    //43675
                    //33678
                    //99542
                    //12471

                    Console.WriteLine("Tu te précipite vers les toilettes");
                    Console.WriteLine("La lumière des toilettes clignottes, tu doit trouver un endroit pour te cacher vite!");
                    Console.WriteLine("Il y a 5 combinaisons, un seul chiffre par combinaison doit être utilisé : ");
                    Console.WriteLine("Trouve la combinaison correcte pour te cacher parfaitement : ");
                    Console.WriteLine("34567");
                    Console.ReadKey();
                  clear: Console.Clear();
                    try { in1 = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("Il faut entrer un chiffre positif entier : "); goto clear; }
                  if (in1 == 3) 
                    { 
                        Console.WriteLine("Bonne entrée : ");
                        Console.WriteLine("43675");
                        Console.ReadKey();
                    clear2: Console.Clear();
                        try { in2 = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("Il faut entrer un chiffre positif entier : "); goto clear2; }
                        if (in2 == 3)
                        {
                            Console.WriteLine("Bonne entrée : ");
                            Console.WriteLine("33678");
                            Console.ReadKey();
                        clear3: Console.Clear();
                            try { in3 = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("Il faut entrer un chiffre positif entier : "); goto clear3; }
                            if (in3 == 6)
                            {
                                Console.WriteLine("Bonne entrée : ");
                                Console.WriteLine("99542");
                                Console.ReadKey();
                            clear4: Console.Clear();
                                try { in4 = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("Il faut entrer un chiffre positif entier : "); goto clear4; }
                                if (in4 == 4)
                                {
                                    Console.WriteLine("Bonne entrée : ");
                                    Console.WriteLine("12471");
                                    Console.ReadKey();
                                clear5: Console.Clear();
                                    try { in5 = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("Il faut entrer un chiffre positif entier : "); goto clear5; }
                                    if (in5 == 1)
                                    {
                                        Console.WriteLine("Bonne combinaison!");

                                        Game.Transition<UpperBathRoomGood>();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Mauvaise combinaison");
                                        Game.Transition<UpperBathRoom>();
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Mauvaise combinaison");
                                    Game.Transition<UpperBathRoom>();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Mauvaise combinaison");
                                Game.Transition<UpperBathRoom>();
                            }

                        }
                        else
                        {
                            Console.WriteLine("Mauvaise combinaison");
                            Game.Transition<UpperBathRoom>();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Mauvaise combinaison");
                        Game.Transition<UpperBathRoom>();
                    }
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
