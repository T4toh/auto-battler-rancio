using System;

public class Character(string name, int maxHp, int attack, int defense)
{
    public string Name { get; set; } = name;
    public int MaxHp { get; set; } = maxHp;
    public int CurrentHp { get; set; } = maxHp;
    public int Attack { get; set; } = attack;
    public int Defense { get; set; } = defense;

    public int TakeDamage(int amount)
    {
        int damage = Math.Max(1, amount - Defense);
        CurrentHp = Math.Max(0, CurrentHp - damage);
        return damage;
    }

    public bool IsAlive()
    {
        return CurrentHp > 0;
    }
}
