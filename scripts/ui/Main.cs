using System;
using Godot;

public partial class Main : Control
{
    private CombatLog _combatLog;
    private CombatManager _combat;
    private string[] _defaultHeroNames = ["Warrior", "Mage", "Rogue", "Cleric", "Paladin"];

    private string[] _defaultEnemyNames = ["Goblin", "Orc", "Skeleton", "Bandit", "Slime"];
    private AddCharacter _addHero;
    private AddCharacter _addEnemy;

    private VBoxContainer _heroesContainer;
    private VBoxContainer _enemiesContainer;

    private readonly PackedScene _characterRowScene = GD.Load<PackedScene>(
        "res://scenes/ui/CharacterRow.tscn"
    );

    private Party _heroes = new();
    private Party _enemies = new();

    public override void _Ready()
    {
        _combat = new CombatManager(_heroes, _enemies);

        _combatLog = GetNode<CombatLog>("Top/TopLayout/CombatLog");

        _addHero = GetNode<AddCharacter>("Top/TopLayout/HPanel/Heroes/AddCharacter");
        _addEnemy = GetNode<AddCharacter>("Top/TopLayout/EPanel/Enemies/AddCharacter");

        _heroesContainer = GetNode<VBoxContainer>("Top/TopLayout/HPanel/Heroes/HeroesContainer");
        _enemiesContainer = GetNode<VBoxContainer>("Top/TopLayout/EPanel/Enemies/EnemiesContainer");

        _addHero.CharacterSubmitted += OnHeroAdded;
        _addEnemy.CharacterSubmitted += OnEnemyAdded;
    }

    private void OnHeroAdded(string name)
    {
        if (_heroes.IsFull())
            return;

        if (string.IsNullOrWhiteSpace(name))
        {
            name = _defaultHeroNames[_heroes.Members.Count];
        }

        var character = new Character(name, 100, 10, 5);

        _heroes.AddMember(character);

        AddCharacterRow(_heroesContainer, character);
        Check_Party_Limit();
    }

    private void OnEnemyAdded(string name)
    {
        if (_enemies.IsFull())
            return;

        if (string.IsNullOrWhiteSpace(name))
        {
            name = _defaultEnemyNames[_enemies.Members.Count];
        }

        var character = new Character(name, 100, 10, 5);

        _enemies.AddMember(character);

        AddCharacterRow(_enemiesContainer, character);
        Check_Party_Limit();
    }

    private void AddCharacterRow(VBoxContainer container, Character character)
    {
        var row = _characterRowScene.Instantiate<CharacterRow>();
        container.AddChild(row);
        row.SetCharacter(character);
    }

    private void Check_Party_Limit()
    // This method should be called after a char is added to check if the party is full.
    // If it is, should disable the AddCharacter component and show a message to the user.
    // In this state it checkes both parties, so it can be called after adding a hero or an enemy.
    {
        if (_heroes.IsFull())
        {
            _addHero.Visible = false;
            GD.Print("Heroes party is full!");
        }
        else
        {
            _addHero.Visible = true;
        }

        if (_enemies.IsFull())
        {
            _addEnemy.Visible = false;
            GD.Print("Enemies party is full!");
        }
        else
        {
            _addEnemy.Visible = true;
        }
    }
}
