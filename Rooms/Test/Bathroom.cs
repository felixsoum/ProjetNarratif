﻿using System.ComponentModel.Design;

namespace ProjetNarratif.Rooms
{
    internal class Bathroom : Room
    {
       
        
        internal static bool bathtaken;
        internal override string CreateDescription()
        {
     

            return

@"Dans la toilette, le [bain] est rempli d'eau chaude.
Le [miroir] devant toi affiche ton visage déprimé.
il y a un couteau sur le bord du bain [couteau]
Tu peux revenir dans ta [chambre].
[attic]

Jette ta piece de monnaie dans les air [monnaie]
";
            
        }

        Random random = new Random();
        internal override void ReceiveChoice(string choice)
        {
            
            switch (choice)
            {
                case "bain":
                    Console.WriteLine("Tu te laisses relaxer dans le bain bain chaud, tu regardes la brume se répendre dans la pièce.");
                    

                    
                    break;
                case "miroir":
                    
                    if (!Bathroom.bathtaken)
                    {
                        Console.WriteLine("Tu te vois dans le miroir, triste");
                    }
                    else
                    {
                        Console.WriteLine("Tu aperçois les chiffres 5872 écrits sur la brume sur le miroir.");
                        //pour lier un site web (musique image etc)
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "https://www.youtube.com/watch?v=oavMtUWDBTM", UseShellExecute = true });
                    }
                    break;
                case "chambre":
                    Console.WriteLine("Tu retournes dans ta chambre.");
                    Game.Transition<Bedroom>();
                    break;

                case "couteau": 

                    Console.WriteLine("Tu le prend dans tes mains et tu te coupe avec...");

                    Game.Vie();

                   
                    
                    break;
                case "monnaie": 
                   double chance = random.Next();
                    if (chance < 0.5)
                    {
                        Console.WriteLine("Pile");
                    }
                    else
                    {
                        Console.WriteLine("Face");
                    }
                    break;
                case "attic":

                 Game.Transition<AtticRoom>();


                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
