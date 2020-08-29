using Godot;
using System;

public class PlayerData : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export]
	public int score = 0;
	[Export]
	public int deaths = 0;

	[Signal]
	public delegate void OnScoreUpdate();
	[Signal]
	public delegate void OnPlayerDied();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public void AddScore(int value)
	{
		score += value;
		EmitSignal("OnScoreUpdate", score);
	}

	public void AddDeath()
	{
		deaths += 1;
		EmitSignal("OnPlayerDied", deaths);
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}
