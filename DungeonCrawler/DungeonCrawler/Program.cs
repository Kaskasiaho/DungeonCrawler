﻿namespace DungeonCrawler;

class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        GameManager gameManager = new GameManager();
        
        Pawn player = new Pawn(0, 0, new Graphics('*', ConsoleColor.White));

        Graphics objGraphics = new Graphics('/', ConsoleColor.Blue);
        Graphics objGraphics2 = new Graphics('!', ConsoleColor.Yellow);
        Graphics objGraphics3 = new Graphics('^', ConsoleColor.DarkGreen);
        
        Actor obj = new Actor(2, 6, 3, 4, objGraphics);
        Actor obj2 = new Actor(78, 6, 6, 2, objGraphics2);
        Actor obj3 = new Actor(50, 18, 4, 4, objGraphics3);
        Actor obj4 = new Actor(6, 9,3, 5,  objGraphics);
        
        Door doorBenDoor = new Door(97, 0, DoorOrientation.Horizontal, -1);
        
        Actor[] objects =
        {
            obj, obj2, obj3, obj4, doorBenDoor
        };

        Level level = Utilities.CreateLevel(new Vector2(20, 100), player, objects);
        Enemy[] enemies = Utilities.GenerateEnemies(1, new Vector2(20, 100), level.NavMesh);
        level.AddEnemies(enemies);
        
        gameManager.StartGame(level);
    }
}