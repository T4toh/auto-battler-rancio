using System.Linq;

public enum Team
{
    Heroes,
    Enemies,
}

public class CombatManager(Party heroes, Party enemies)
{
    private readonly Party _heroes = heroes;
    private readonly Party _enemies = enemies;

    public string AttackRandom(bool heroesAttacking)
    {
        Party attackers = heroesAttacking ? _heroes : _enemies;
        Party defenders = heroesAttacking ? _enemies : _heroes;

        var attacker = attackers.GetRandomAliveMember();
        var target = defenders.GetRandomAliveMember();

        if (attacker == null || target == null)
            return "No valid targets.";

        int damage = target.TakeDamage(attacker.Attack);

        return $"{attacker.Name} hits {target.Name} for {damage} damage!";
    }

    public bool IsCombatOver()
    {
        return !_heroes.HasAliveMembers() || !_enemies.HasAliveMembers();
    }

    public string GetWinner()
    {
        if (!_heroes.HasAliveMembers())
            return "Enemies";

        if (!_enemies.HasAliveMembers())
            return "Heroes";

        return null;
    }
}
