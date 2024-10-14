using Godot;
using System;

public partial class ComplexValue : Node
{
	[Export]
	protected double _Value = 0;
    public virtual double Value()
    {
        return _Value;
    }
}
