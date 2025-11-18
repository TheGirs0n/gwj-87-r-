using Godot;
using System;

public partial class CoreShield : Node2D
{
	[Export] private int _shieldCapacity = 1;

	public void ClickOnShield()
	{
		_shieldCapacity--;
		QueueFree();
	}
}
