using Godot;
using System;

public partial class PositionInitalComponent : Component
{
	[Export]
	ComplexValue VerticalStartingPosition;
	[Export]
	ComplexValue HoriziontalStartingPosition;
	public override void _Ready()
	{
		Godot.Vector2 Position = new Godot.Vector2((float)HoriziontalStartingPosition.Value(),(float)VerticalStartingPosition.Value());
		ComponentController.Position = Position;
	}
}
