using Godot;
using System;

public class PauseScreen : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private bool pause = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("pause"))
		{
			SetPause(!pause);
			GetTree().SetInputAsHandled();
		}
	}

	private void SetPause(bool value)
	{
		pause = value;
		GetTree().Paused = pause;
		var n = GetNode<ColorRect>("overlay");
		n.Visible = pause;
	}

}
