using Godot;
using System;
using System.Diagnostics;


public partial class Globals : Node2D
{
    public static Globals Instance { get; private set; }
	public RandomNumberGenerator rng;
	public Vector2 ScreenDimensions;
    public override void _Ready()
    {
        Instance = this;
		rng = new RandomNumberGenerator();
		ScreenDimensions = GetViewportRect().Size;
		GD.Print("Screen Dimensions", Globals.Instance.ScreenDimensions);
		
    }
}
