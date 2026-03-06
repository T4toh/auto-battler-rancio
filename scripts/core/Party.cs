using System;
using System.Collections.Generic;
using System.Linq;

public class Party
{
    public int MaxMembers => 5;
    private static readonly Random Rng = new();

    public List<Character> Members { get; private set; } = [];

    public bool AddMember(Character character)
    {
        if (Members.Count >= MaxMembers)
            return false;

        Members.Add(character);
        return true;
    }

    public List<Character> GetAliveMembers()
    {
        return Members.Where(c => c.IsAlive()).ToList();
    }

    public Character GetRandomAliveMember()
    {
        var alive = GetAliveMembers();

        if (alive.Count == 0)
            return null;

        return alive[Rng.Next(alive.Count)];
    }

    public bool IsFull()
    {
        return Members.Count >= MaxMembers;
    }

    public void Clear()
    {
        Members.Clear();
    }
}
