using Godot;
using System;

public class EndScreen : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var pd = GetNode<PlayerData>("/root/PlayerData");
		var l = GetNode<Label>("Label");
		
		l.Text = $"Your score is {pd.score}\nYou died {pd.deaths} times!";
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
