using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class PreGRHallway : Room
    {
        internal override string CreateDescription() =>
@" Tu ouvres la porte de ta chambre et te retrouves dans le couloir.
Tu vas jetter un coup d'oeil aux toilettes [toilettes]
Tu te déplace jusqu'à la salle de jeux [jeux]
Tu vas inspecter l'horloge familiale [horloge]
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "toilettes":
                    Console.WriteLine("Tu rentre dans les toilettes et remarque la lumière qui clignotte.");
                    Console.WriteLine("Tu te souviens de ce que ton père t'avait expliqué : ");
                    Console.WriteLine("\t28967\n1=2\n2=8\n3=9\n...");
                    Console.WriteLine("\nBien que cryptique, cette information de servira surement...");

                   
                    break;
                case "jeux":
                    Console.WriteLine("Tu rentres dans la salle de jeux");
                    Game.Transition<GameRoom>();
                    
                    break;

                case "horloge":
                    Console.WriteLine("Tu te rapproches lentement de l'horloge.");
                    Console.WriteLine("Tic tac tic tac...");
                    Console.WriteLine("Tu n'as jamais aimé le bruit de l'horloge, celui-ci te rends anxieux");
                    Console.WriteLine("Plus tu es près de l'horloge plus le tiquement des aiguilles s'intensifie");
                    Console.WriteLine("TIC TAC TIC TAC");
                    Console.WriteLine("Tu t'en éloigne...");

                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
