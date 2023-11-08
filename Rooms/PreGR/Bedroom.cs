using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using System;

namespace ProjetNarratif.Rooms
{
    internal class Bedroom : Room
    {
        
        internal static bool firstdeath;
        internal static bool WindowLock;
        internal static bool Scared1;
        internal static bool Scared2;
        internal static bool Scared3;

        
        internal override string CreateDescription() =>
            
@"Alors que tu dormais paisiblement... Un grincement te réveille...
Tes petits yeux ouverts tu ressens l'immense pression de son regard depuis ton garde-robe...
Tu entends les portes, de celui-ci, s'ouvrir lentement, tu dois agir vite...
Cours vers ta fenêtre il n'y a pas de temps a perdre [fenetre]
Tu es tétanisé, cache toi sous tes couverture [drap]
Roule hors de ton petit lit et cache toi en dessous [lit]
";
 
        internal override void  ReceiveChoice(string choice)
             
        {
            

            switch (choice)
            {
                case "fenetre":
                    if (!Bedroom.WindowLock)
                    {
                        Console.WriteLine("Tu cours vers ta fenêtre et tentes de l'ouvrir, mais celle-ci est coincée... ");
                        Console.WriteLine("Des bruits de pas lourds se font entendre derrière toi...");
                        Console.WriteLine("Tu endends sa respiration se rapprocher...");
                        Console.WriteLine("Tu cris pour que tes parents t'entendent, mais il est trop tard, il t'a trouvé...");
                        Console.WriteLine("\n FIN 1 : Mort prématurée");
                        firstdeath = true;
                        Console.Write("Appuyez sur une touche pour recommencer : ");
                        Console.ReadKey();
                        Console.Clear();
                    } else
                    {

                    }
                   

                    break;
                case "drap":
                    Game.Transition<BedroomChoiceDraps>();



                    break;
                case "lit":
                    Console.WriteLine("Tu te dépèches et te caches rapidement sous ton lit.");
                    Console.WriteLine("Tu regardes alors ton garde robe s'ouvrir...");
                    Console.WriteLine("Tu le vois se rapprocher tranquillement vers ton lit...");
                    Console.WriteLine("Ton petit coeurs accélère...");
                    
                    Console.WriteLine("Il se dirige vers la porte de ta chambre...");
                    Console.WriteLine("Il l'ouvre et la ferme derrière lui.");
                    Console.WriteLine("Tu cherches autour de toi pour le regard réconfortant de M.Tocson, mais tu l'as égaré...");
                    Console.WriteLine("Ton niveau de peur augmente...");
                
                    Scared1 = true;
                    if (Scared1 == true)
                    {
                        Console.WriteLine("Niveau de peur : 1...");
                    }
                    Game.Transition<BedroomBedChoice>();

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;

                    //Game.Finish();
            }
        }
    }
}
