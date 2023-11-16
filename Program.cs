using ProjetNarratif;
using ProjetNarratif.Rooms;

var game = new Game();
game.Add(new Bedroom());
game.Add(new BedroomChoiceDraps());
game.Add(new PostBathHall());
game.Add(new BedroomPostGR());
game.Add(new PreGRHallway());
game.Add(new ClockRoom());
game.Add(new BedroomBedChoice());
game.Add(new PorcheRoom());
game.Add(new GameRoom());
game.Add(new UpperHallwayRoom());
game.Add(new UpperBathRoom());
game.Add(new UpperBathRoomGood());
game.Add(new Bathroom());
game.Add(new AtticRoom());
game.Add(new LivingRoom());
game.Add(new KitchenRoom());
game.Add(new FfHallwayRoom());
game.Add(new GuessRoom());


Game.stopwatch.Start();

while (!game.IsGameOver())
{
    Console.WriteLine("--");
    Console.WriteLine(game.CurrentRoomDescription);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    Console.WriteLine("Min: " + Game.stopwatch.Elapsed.TotalHours);
  
   
    Console.WriteLine($"PV = {Game.vie}/3");
  Console.Clear();
     game.ReceiveChoice(choice);


}

Console.WriteLine("FIN");
Console.ReadLine();