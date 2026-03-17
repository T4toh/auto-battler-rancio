using Godot;

public partial class CombatLog : VBoxContainer
{
    public void AddEntry(string text)
    {
        var label = new Label();
        label.Text = text;

        AddChild(label);
    }

    public void ClearLog()
    {
        foreach (Node child in GetChildren())
        {
            child.QueueFree();
        }
    }
}
