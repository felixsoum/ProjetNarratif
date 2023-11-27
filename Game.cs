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
