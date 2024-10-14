using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public partial class PositionModiferComponent : Component
{
	[Export]
	ComplexValue VerticalPositionModifer;
	[Export]
	ComplexValue HoriziontalPositionModifer;
	public override void _Process(double delta)
	{
		Godot.Vector2 Position = new Godot.Vector2();
		Position.X = (float)HoriziontalPositionModifer.Value();
		Position.Y = (float)VerticalPositionModifer.Value();
		ComponentController.Position = ComponentController.Position + Position;
	}
}
