using System.ComponentModel.Design;

namespace ProjetNarratif.Rooms
{
    internal class AtticRoom : Room
    {
        internal static bool isKeyCollected;

        internal override string CreateDescription()
        {
            if (Game.stopwatch.Elapsed.TotalSeconds < 30)
            {
                return

                       @"Il fait noir
";
            }
            if (Bathroom.bathtaken)
            {
                return
 @"Il fait supra mega noir
";
            } else
            {
      return
@"Dans le grenier, il y fait noir et froid.
Un coffre est verrouillé avec un code [????].
Tu peux revenir dans ta [chambre].
[couteau]
";
            }
      
        }


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
                case "couteau":
                   Console.WriteLine("Tu prends le couteau mais tu te coupes avec");

                    Game.Vie();
                   
                    break;

                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
