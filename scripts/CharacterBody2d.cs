using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	public const float Gravity = 980.0f; // adjust to match your project

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
			velocity.X = direction.X * Speed;
		else
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);

		// Flip character based on direction
		if (direction.X != 0)
		{
			Vector2 scale = Scale;
			scale.X = MathF.Sign(direction.X) * MathF.Abs(scale.X);
			Scale = scale;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
