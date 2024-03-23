﻿namespace DungeonCrawler;

public class Door : Actor
{
    public DoorDirection Direction { get; private set; }
    public Vector2 Entry { get; private set; }
    public Vector2 PlayerSpawnPoint { get; private set; }
    public bool IsEntrance { get; private set; }
    public Level Destination { get; private set; }
    public Teleporter Teleporter { get; private set; }

    public Door(int x, int y, Level destination, bool isEntrance = false)
    {
        Destination = destination;
        IsEntrance = isEntrance;
        Transform.SetScale(4, 2);
        Transform.SetPosition(x, y);
        Graphics.Color = ConsoleColor.Red;
        SetEntry();
        Teleporter = new Teleporter(this);
        Interactable = true;
        
        if (IsEntrance) Renderer.OpenDoor(this);
    }

    public Door(int x, int y, DoorDirection direction, Level destination, bool isEntrance = false)
    {
        Graphics.Color = ConsoleColor.Red;
        Direction = direction;
        Destination = destination;
        IsEntrance = isEntrance;

        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(x, y);
        SetEntry();
        
        Teleporter = new Teleporter(this);
        Interactable = true;        
        
        if (IsEntrance) Renderer.OpenDoor(this);
    }
    
    public Door(int x, int y, DoorDirection direction, ConsoleColor color, Level destination, bool isEntrance = false)
    {
        Graphics.Color = color;
        Direction = direction;
        Destination = destination;
        IsEntrance = isEntrance;

        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(x, y);
        SetEntry();
        
        Teleporter = new Teleporter(this);
        Interactable = true;        
        
        if (IsEntrance) Renderer.OpenDoor(this);
    }

    public Door(Vector2 position, DoorDirection direction, ConsoleColor color, Level destination, bool isEntrance = false)
    {
        Graphics.Color = color;
        Direction = direction;
        Destination = destination;
        IsEntrance = isEntrance;

        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(position.X, position.Y);
        SetEntry();
        
        Teleporter = new Teleporter(this);
        Interactable = true;        
        
        if (IsEntrance) Renderer.OpenDoor(this);
    }
    
    public Door(Vector2 position, DoorDirection direction, Level destination, bool isEntrance = false)
    {
        Graphics.Color = ConsoleColor.Red;
        Direction = direction;
        Destination = destination;
        IsEntrance = isEntrance;

        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(position.X, position.Y);
        SetEntry();
        
        Teleporter = new Teleporter(this);
        Interactable = true;        
        
        if (IsEntrance) Renderer.OpenDoor(this);
    }
    
    public Door(int x, int y, bool isEntrance = false)
    {
        IsEntrance = isEntrance;
        Transform.SetScale(4, 2);
        Transform.SetPosition(x, y);
        Graphics.Color = ConsoleColor.Red;
        SetEntry();
        
        Teleporter = new Teleporter(this);
        Interactable = true;        
        
        if (IsEntrance) Renderer.OpenDoor(this);
    }

    public Door(int x, int y, DoorDirection direction, bool isEntrance = false)
    {
        Graphics.Color = ConsoleColor.Red;
        Direction = direction;
        IsEntrance = isEntrance;

        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(x, y);
        SetEntry();
        
        Teleporter = new Teleporter(this);
        Interactable = true;        
        
        if (IsEntrance) Renderer.OpenDoor(this);
    }
    
    public Door(int x, int y, DoorDirection direction, ConsoleColor color, bool isEntrance = false)
    {
        Graphics.Color = color;
        Direction = direction;
        IsEntrance = isEntrance;

        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(x, y);
        SetEntry();
        
        Teleporter = new Teleporter(this);
        Interactable = true;        
        
        if (IsEntrance) Renderer.OpenDoor(this);
    }

    public Door(Vector2 position, DoorDirection direction, ConsoleColor color, bool isEntrance = false)
    {
        Graphics.Color = color;
        Direction = direction;
        IsEntrance = isEntrance;

        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(position.X, position.Y);
        SetEntry();
        
        Teleporter = new Teleporter(this);
        Interactable = true;        
        
        if (IsEntrance) Renderer.OpenDoor(this);
    }
    
    public Door(Vector2 position, DoorDirection direction, bool isEntrance = false)
    {
        Graphics.Color = ConsoleColor.Red;
        Direction = direction;
        IsEntrance = isEntrance;

        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(position.X, position.Y);
        SetEntry();
        
        Teleporter = new Teleporter(this);
        Interactable = true;        
        
        if (IsEntrance) Renderer.OpenDoor(this);
    }

    public void SetEntry()
    {
        int xEntry = Transform.Position.X + 1;
        int yEntry = Transform.Position.Y + 1;

        if (Direction == DoorDirection.Left || Direction == DoorDirection.Right)
        {
            if (Direction == DoorDirection.Right)
            {
                xEntry = Transform.Position.X + 1;
                PlayerSpawnPoint = new Vector2(xEntry + 1, yEntry);
            }
            else
            {
                xEntry = Transform.Position.X;
                PlayerSpawnPoint = new Vector2(xEntry - 1, yEntry);
            }
        }

        if (Direction == DoorDirection.Up || Direction == DoorDirection.Down)
        {
            if (Direction == DoorDirection.Down)
            {
                yEntry = Transform.Position.Y + 1;
                PlayerSpawnPoint = new Vector2(xEntry, yEntry + 1);
            }
            else
            {
                yEntry = Transform.Position.Y;
                PlayerSpawnPoint = new Vector2(xEntry, yEntry - 1);
            }
        }

        Entry = new Vector2(xEntry, yEntry);
    }

    public void Open()
    {
        Teleporter.Trigger = true;
    }

    public void SetDestination(Level destination)
    {
        Destination = destination;
        Teleporter= new Teleporter(this);
    }
}