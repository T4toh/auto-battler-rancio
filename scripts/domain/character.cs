public class Character
{
    public string Name { get; set; }

    public int MaxHp { get; set; }
    public int CurrentHp { get; set; }

    public int Attack { get; set; }
    public int Defense { get; set; }

    public Character(string name, int maxHp, int attack, int defense)
    {
        Name = name;
        MaxHp = maxHp;
        CurrentHp = maxHp;
        Attack = attack;
        Defense = defense;
    }

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