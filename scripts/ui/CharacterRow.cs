using Godot;

public partial class CharacterRow : HBoxContainer
{
    private Label nameLabel;
    private Label hpLabel;
    private Label atkLabel;
    private Label defLabel;

    public override void _Ready()
    {
        nameLabel = GetNode<Label>("NameLabel");
        hpLabel = GetNode<Label>("HpLabel");
        atkLabel = GetNode<Label>("AtkLabel");
        defLabel = GetNode<Label>("DefLabel");
    }

    public void SetCharacter(Character character)
    {
        nameLabel.Text = character.Name;
        hpLabel.Text = $"{character.CurrentHp} / {character.MaxHp}";
        atkLabel.Text = $"ATK {character.Attack}";
        defLabel.Text = $"DEF {character.Defense}";
    }
}
