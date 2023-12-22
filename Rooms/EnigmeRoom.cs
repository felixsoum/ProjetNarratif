using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class EnigmeRoom : Room
    {
        internal override string CreateDescription() =>
@"Tu parles au petit homme [homme]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "homme":
                    string ch = "";
                    Console.WriteLine("Bien le bonjour, voici une énigme pour toi : ");
                   qst: Console.WriteLine("\nQu'es ce qui disparait lorsque tu dis son nom?");
                    Console.Write("\nVotre réponse : ");
                    try
                    {
                        ch = Convert.ToString(Console.ReadLine());  

                    } catch { Console.WriteLine("Commande invalide."); goto qst; }
                    if (ch == "Le silence" || ch == "le silence" || ch == "silence" || ch == "Silence")
                    {
                        Console.WriteLine("\n\tBonne réponse!");
                        Game.vie = 3;
                    } else
                    {
                        Console.WriteLine("\n\tMauvaise réponse!");
                        Game.Essais();
                        Console.WriteLine("\nVoici un indice : ");
                        Console.WriteLine("\nCe n'est pas quelque chose que tu peux toucher! ");
                        qst1: Console.Write("Votre réponse : ");
                        try
                        {
                            ch = Convert.ToString(Console.ReadLine());

                        }
                        catch { Console.WriteLine("Commande invalide."); goto qst1; }
                        if (ch == "Le silence" || ch == "le silence" || ch == "silence" || ch == "Silence")
                        {
                            Console.WriteLine("\n\tBonne réponse!");
                            Game.vie = 3;
                        }
                        else
                        {
                            Console.WriteLine("\n\tMauvaise réponse!");
                            Game.Essais();
                            Console.WriteLine("\nVoici un indice : ");
                           qst2: Console.WriteLine("\nTu ne peux pas le voir non plus!");
                            Console.Write("Votre réponse : ");
                            try
                            {
                                ch = Convert.ToString(Console.ReadLine());

                            }
                            catch { Console.WriteLine("Commande invalide."); goto qst2; }
                            if (ch == "Le silence" || ch == "le silence" || ch == "silence" || ch == "Silence")
                            {
                                Console.WriteLine("\n\tBonne réponse!");
                                Game.vie = 3;
                            }
                            else
                            {
                                Console.WriteLine("\n\tMauvaise réponse!");
                                Game.Essais();
                                Console.WriteLine("\nVoici un indice : ");
                            qst3:    Console.WriteLine("\nLorsque tu cris tu brise le...");
                                Console.Write("Votre réponse : ");

                                try
                                {
                                    ch = Convert.ToString(Console.ReadLine());

                                }
                                catch { Console.WriteLine("Commande invalide."); goto qst3; }
                                if (ch == "Le silence" || ch == "le silence" || ch == "silence" || ch == "Silence")
                                {
                                    Console.WriteLine("\n\tBonne réponse!");
                                    Game.vie = 3;
                                }
                                else
                                {
                                   
                                    Console.WriteLine("\nC'est fini! la réponse était Le silence ! ");
                                     Game.Essais();
                                }
                            }
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
