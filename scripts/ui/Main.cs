using System;
using Godot;

public partial class Main : Control
{
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
    }

    private void AddCharacterRow(VBoxContainer container, Character character)
    {
        var row = _characterRowScene.Instantiate<CharacterRow>();
        container.AddChild(row);
        row.SetCharacter(character);
    }
}
