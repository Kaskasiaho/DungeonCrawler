﻿using System.Diagnostics;

namespace DungeonCrawler;

public class Pawn : Actor
{
    public int Speed { get; init; } = 1;
    public PawnMovement PawnMovement { get; init; }
    public bool IsDead { get; private set; }
    public bool Moved { get; set; }
    public string Name { get; init; }

    public float HP { get; private set; } = 100;
    private bool _hpChanged = true;
    
    public Pawn(string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Graphics = new Graphics('@', ConsoleColor.Gray);
        Name = name;
    }

    public Pawn(int x, int y, string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(x, y);
        Graphics = new Graphics('@', ConsoleColor.Gray);
        Name = name;
    }

    public Pawn(Vector2 position, Graphics graphics, string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(position.X, position.Y);
        Graphics = graphics;
        Name = name;
    }
    
    public Pawn(int x, int y,  Graphics graphics, string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(x, y);
        Graphics = graphics;
        Name = name;
    }

    public Pawn(Vector2 position, string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(position.X, position.Y);
        Graphics = new Graphics('@', ConsoleColor.Gray);
        Name = name;
    }
    
    public Pawn(Graphics graphics, string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Graphics = graphics;
        Name = name;
    }

    public bool Slap(Pawn pawn, out float damage)
    {
        damage = Random.Shared.Next(10, 20) + Random.Shared.NextSingle();
        string damageStr = damage.ToString("0.00");
        damage = float.Parse(damageStr);

        double roll = Random.Shared.NextDouble();
        Debug.WriteLine(roll);
        if (roll > 0.5)
        {
            pawn.Damage(damage);
            return true;
        }
        return false;
    }

    public void Heal(float amount)
    {
        if (HP < 100) HP += amount;

        _hpChanged = true;
    }

    public void Damage(float amount)
    {
        if (HP - amount <= 0) Kill();
        else if (HP > 0) HP -= amount;

        _hpChanged = true;
    }

    public bool HpChanged()
    {
        if (_hpChanged)
        {
            _hpChanged = false;
            return true;
        }

        return false;
    }

    public void Kill()
    {
        HP = 0;
        IsDead = true;
    }
}