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

                    

                    Console.WriteLine("Pris de peur ton petit corps ne te répond plus, tu te glisse immédiatement sous tes draps. ");
                    Console.WriteLine("Tu l'entends courir vers ta fenetre et l'ouvrir...");
                    Console.WriteLine("Un lourd bruit se fait entendre, suivi du grincement de ta porte d'entrée au premier étage.");
                    Console.WriteLine("Tu retires tes draps, il n'est plus dans ta chambre.");

                    Console.WriteLine("Tu regardes autours de toi : ");
                    Console.WriteLine("Ta fenetre est toujours ouverte elle mène surement vers quelque part... [fenetre]");
                    Console.WriteLine("La porte de ta chambre. [porte]");
                    Console.WriteLine("Ton tiroir, tu gardes caché des informations utiles sur ta maison... [tiroir]");
                    Console.WriteLine("Tes livres préférés. [livres]");

                    switch (choice)
                    {
                        case "fenetre": 
                            Console.WriteLine("Salut");    
                            break;
                        case "porte": break;
                        case "tiroir": break;
                        case "livres": break;
                        default:
                            Console.WriteLine("Commande invalide.");
                            break;
                    }



                    break;
                case "lit":
                    Console.WriteLine("Tu montes dans le grenier.");
                    Game.Transition<AtticRoom>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;

                    //Game.Finish();
            }
        }
    }
}
