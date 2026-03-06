using System;
using Godot;

public partial class Main : Control
{
    private AddCharacter _addHero;
    private AddCharacter _addEnemy;

    private VBoxContainer _heroesContainer;
    private VBoxContainer _enemiesContainer;

    [Export]
    public PackedScene CharacterRowScene;

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
        var character = new Character(name, 100, 10, 5);
        _heroes.AddMember(character);

        AddCharacterRow(_heroesContainer, character);
    }

    private void OnEnemyAdded(string name)
    {
        var character = new Character(name, 100, 10, 5);
        _enemies.AddMember(character);

        AddCharacterRow(_enemiesContainer, character);
    }

    private void AddCharacterRow(VBoxContainer container, Character character)
    {
        var row = CharacterRowScene.Instantiate<CharacterRow>();
        container.AddChild(row);
        row.SetCharacter(character);
    }
}
