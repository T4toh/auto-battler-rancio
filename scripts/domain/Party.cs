using System;
using System.Collections.Generic;
using System.Linq;

public class Party
{
    public List<Character> Members { get; private set; } = [];

    public void AddMember(Character character)
    {
        Members.Add(character);
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

        var rng = new Random();
        return alive[rng.Next(alive.Count)];
    }

    public void Clear()
    {
        Members.Clear();
    }
}
