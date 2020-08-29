using Godot;
using System;

public class Actor : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public Vector2 velocity = Vector2.Zero;

	public Vector2 FLOOR_NORMAL = Vector2.Up;
	
	[Export]
	public Vector2 speed {get;set;} = new Vector2(300, 600);
	
	[Export]
	public float gravity { get; set; } = 3000;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		// velocity.y += gravity * delta;
		// velocity.y = Math.Max(velocity.y, speed.y);
		// velocity = this.MoveAndSlide(velocity);
	}
}
