using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	[Export] public float Speed = 300.0f;
	[Export] public float JumpVelocity = -400.0f; 
	[Export] public float Gravity = 980.0f; // adjust to match your project
	
	float direction = 1;

	private AnimatedSprite2D animatedSprite;

	public override void _Ready()
	{
		// Adjust path to match your scene
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Velocity = velocity;

		// Apply gravity if not on the floor
		if (!IsOnFloor())
			velocity.Y += Gravity * (float)delta;

		// Handle jump
		if (Input.IsKeyPressed(Key.X) && IsOnFloor())
			velocity.Y = JumpVelocity;

		if (Input.IsKeyPressed(Key.Up))
		{
			
		}
		if (Input.IsKeyPressed(Key.Down))
		{
			
		}
		if (Input.IsKeyPressed(Key.Left))
		{
			direction = -1;
			Scale = new Vector2(direction, 0);
			animatedSprite.Play("walk");
			velocity.X = Speed * direction;
		}
		if (Input.IsKeyPressed(Key.Right))
		{
			direction = 1;
			Scale = new Vector2(direction, 0);
			animatedSprite.Play("walk");
			velocity.X = Speed * direction;
		}
	}
}