using Godot;
using System;

public class Enemy : Actor
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SetPhysicsProcess(false);
        velocity.x = -speed.x;
    }

    public void _on_StompDetector_body_entered(PhysicsBody2D body)
    {
        if (body.GlobalPosition.y > GetNode<Area2D>("StompDetector").GlobalPosition.y) {
            return;
        }
        GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
        QueueFree();
    }

    public override void _PhysicsProcess(float delta)
    {
        velocity.y += gravity * delta;
        // velocity.y = Math.Max(velocity.y, speed.y);
        // velocity = this.MoveAndSlide(velocity);
        if (IsOnWall())
        {
            velocity.x *= -1;
        }

        velocity.y = MoveAndSlide(velocity, FLOOR_NORMAL).y;
    }
}
