using ProjetNarratif.Rooms;
using System.Diagnostics;

namespace ProjetNarratif
{
    internal class Game
    {
        List<Room> rooms = new();
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";
        internal static Stopwatch stopwatch = new Stopwatch();

     
        internal void Add(Room room)
        {
            rooms.Add(room);
            if (currentRoom == null)
            {
                currentRoom = room;
            }
        }

        internal string CurrentRoomDescription => currentRoom.CreateDescription();

        internal void ReceiveChoice(string choice)
        {
            currentRoom.ReceiveChoice(choice);
            CheckTransition();
        }

        internal static void Transition<T>() where T : Room
        {
            nextRoom = typeof(T).Name;
        }

        internal static int vie = 3;

        internal static int peur = 0;

        internal static bool tocs = false;
        internal static void Tocson()
        {
            int ch; 
            if (!Game.tocs)
            {
                Console.WriteLine("Ton niveau de peur augmente : ");
                Peur();
            } else
            {
                Console.WriteLine("Tocson peut t'aider");
                qst: Console.WriteLine("Veux-tu l'utiliser?");
                Console.Write("(1) oui " +
                    "\n(2) non" +
                    "\nTon choix : ");
                try
                {
                    ch = Convert.ToInt32(Console.ReadLine());
                } catch
                {
                    Console.WriteLine("Commande invalide : \n"); goto qst;
                }
                if (ch == 1)
                {
                    Console.WriteLine("Tu prends Tocson et le serres dans tes bras" +
                        "\nTu réussis à te calmer.");
                    Console.WriteLine("Tu égares Tocson");
                    Game.tocs = false;
                }
                if (ch == 2)
                {
                    Console.WriteLine("Ton niveau de peur augmente...");
                    Game.Peur();
                }
                if (ch < 1 || ch > 2) { Console.WriteLine("Commande invalide"); goto qst; }
            }
        }
        internal static void Peur()
        {
            //vie
            peur++;
            if (peur <= 2)
            {
                Console.WriteLine($"Niveau de peur : {peur}");
            }
            if (peur == 3)
            {
                Console.WriteLine($"Tu te perds dans la peur, niveau de peur : {peur}");
                Console.WriteLine("Fin du jeu");
                Game.Finish();
            }
        }

        internal static void UnPeur()
        {
            //vie
            peur--;
            Console.WriteLine($"Ton niveau de peur descend : ");
            if (peur < 0)
            {
                peur = 0;

                Console.WriteLine($"Niveau de peur : {peur} ");
            } else
            {
                Console.WriteLine($"Niveau de peur : {peur} ");
            }
           
           
        }
        internal static void Vie()
        {
            //vie
            vie = vie - 1;
            if (vie != 0)
            {
                Console.WriteLine($"Il te reste {vie} vies");
            }
            else
            {
                Console.WriteLine("Tu es mort :(");
                Game.Finish();
            }
        }
        internal static void Finish()
        {
            isFinished = true;
        }
        
        internal void CheckTransition()
        {
            foreach (var room in rooms)
            {
                if (room.GetType().Name == nextRoom)
                {
                    nextRoom = "";
                    currentRoom = room;
                    break;
                }
            }
        }
    }
}
