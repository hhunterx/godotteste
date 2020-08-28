using Godot;
using System;

public class Coin : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private AnimationPlayer animation;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animation = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }

	private async void _on_body_entered(object body)
	{
		animation.Play("fadeout");
		await ToSignal(animation, "animation_finished");
	}
}


