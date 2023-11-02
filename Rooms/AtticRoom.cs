namespace ProjetNarratif.Rooms
{
    internal class AtticRoom : Room
    {
        internal static bool isKeyCollected;

        internal override string CreateDescription() =>
@"Dans le grenier, il y fait noir et froid.
Un coffre est verrouillé avec un code [????].
Tu peux revenir dans ta [chambre].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "chambre":
                    Console.WriteLine("Tu retournes dans ta chambre.");
                    Game.Transition<Bedroom>();
                    break;
                case "5872":
                    Console.WriteLine("Le coffre s'ouvre et tu obiens une clé.");
                    isKeyCollected = true;
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
