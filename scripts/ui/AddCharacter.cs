using System;
using Godot;

public partial class AddCharacter : HBoxContainer
{
    [Signal]
    public delegate void CharacterSubmittedEventHandler(string name);

    private LineEdit _input;
    private Button _button;

    public override void _Ready()
    {
        _input = GetNode<LineEdit>("NameInput");
        _button = GetNode<Button>("AddButton");

        _button.Pressed += OnSubmit;
        _input.TextSubmitted += OnTextSubmitted;
    }

    private void OnSubmit()
    {
        Submit();
    }

    private void OnTextSubmitted(string text)
    {
        Submit();
    }

    private void Submit()
    {
        string name = _input.Text.Trim();

        EmitSignal(SignalName.CharacterSubmitted, name);

        _input.Text = "";
    }
}
