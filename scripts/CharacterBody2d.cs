using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public float Speed = 300.0f;
	public float JumpVelocity = -400.0f;
	public float Gravity = 980.0f; // adjust to match your project

	private AnimatedSprite2D animatedSprite;

	public override void _Ready()
	{
		// Adjust path to match your scene
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Apply gravity if not on the floor
		if (!IsOnFloor())
			velocity.Y += Gravity * (float)delta;

		// Handle jump
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get movement direction
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			animatedSprite.Play("walk");

			// Flip sprite
			Vector2 scale = Scale;
			scale.X = MathF.Sign(direction.X) * MathF.Abs(scale.X);
			Scale = scale;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			animatedSprite.Play("Idle");
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
