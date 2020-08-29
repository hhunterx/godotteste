using Godot;
using System;

public class Player : Actor
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	[Export]
	public float stomp_impulse = 700;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public void _on_StompDetector_area_entered(Area2D body)
	{
		velocity = CalculateStompVelocity(velocity, stomp_impulse);
	}

	public void _on_EnemyDetector_body_entered(PhysicsBody2D body)
	{
		Die();
	}

	private void Die()
	{
		QueueFree();
		var playerData = (PlayerData)GetNode("/root/PlayerData");
		playerData.AddDeath();
	}

	public override void _PhysicsProcess(float delta)
	{
		//base._PhysicsProcess(delta);
		var direction = GetDirection();
		var isJumpInterrupted = Input.IsActionJustReleased("jump") && velocity.y < 0;

		velocity = CalculateMoveVelocity(velocity, direction, speed, isJumpInterrupted);
		velocity = MoveAndSlide(velocity, FLOOR_NORMAL);
	}

	public Vector2 GetDirection()
	{
		return new Vector2(
			Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left"),
			Input.IsActionJustPressed("jump") && IsOnFloor() ? -1 : 1);
	}

	public Vector2 CalculateMoveVelocity(Vector2 linerVelocity, Vector2 direction, Vector2 speed, bool isJumpInterrupted)
	{
		var result = linerVelocity;
		result.x = speed.x * direction.x;
		result.y += gravity * this.GetPhysicsProcessDeltaTime();
		if (direction.y == -1)
		{
			result.y = speed.y * direction.y;
		}

		if (isJumpInterrupted)
		{
			result.y = 0;
		}
		return result;
	}

	public Vector2 CalculateStompVelocity(Vector2 linerVelocity, float impulse)
	{
		var reuslt = linerVelocity;
		reuslt.y = -impulse;
		return reuslt;
	}
}
