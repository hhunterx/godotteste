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
		var playerData = GetNode<PlayerData>("/root/PlayerData");
		playerData.Connect("OnScoreUpdate", this, "OnScoreUpdate");
		playerData.Connect("OnPlayerDied", this, "OnPlayerDied");
		OnScoreUpdate(0);
	}

	private void OnScoreUpdate(int score)
	{
		var l = GetNode<Label>("score");
		l.Text = $"Score: {score}";
	}

	private void OnPlayerDied(int deaths)
	{
		var l = GetNode<Label>("overlay/Title");
		l.Text = "You died!";
		SetPause(true);
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
