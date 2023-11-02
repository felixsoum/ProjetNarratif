namespace ProjetNarratif.Rooms
{
    internal class Bathroom : Room
    {
        internal static bool bathtaken;
        internal override string CreateDescription() =>
@"Dans la toilette, le [bain] est rempli d'eau chaude.
Le [miroir] devant toi affiche ton visage déprimé.
Tu peux revenir dans ta [chambre].
";

        internal override void ReceiveChoice(string choice)
        {

            switch (choice)
            {
                case "bain":
                    Console.WriteLine("Tu te laisses relaxer dans le bain bain chaud, tu regardes la brume se répendre dans la pièce.");
                    bathtaken = true;
                    break;
                case "miroir":
                    
                    if (!Bathroom.bathtaken)
                    {
                        Console.WriteLine("Tu te vois dans le miroir, triste");
                    }
                    else
                    {
                        Console.WriteLine("Tu aperçois les chiffres 5872 écrits sur la brume sur le miroir.");
                        
                    }
                    break;
                case "chambre":
                    Console.WriteLine("Tu retournes dans ta chambre.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
