using Godot;
using System;

public partial class Component : Node2D
{
	protected Node2D ComponentController;
    public override void _EnterTree()
    {
		ComponentController = GetParent<Node2D>();
		if (ComponentController == null)
		{
			throw new Exception("Component does not have suitable parent!");
		}
	}
    public override void _Process(double delta)
	{
	}
}
