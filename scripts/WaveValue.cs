using Godot;
using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

enum WaveType
{
	Sine,
	Cosine,
	Tangent,
	Cosec,
	SquareRoot,
	Log,
	Exponential,

}
enum Directionals
{
	Vertical = 1,
	Horiziontal = 0
}

public partial class WaveValue : ComplexValue
{
	[Export]
	ComplexValue Amplitiude;
	[Export]
	ComplexValue Speed;
	[Export]
	WaveType Type = 0;
	double _position = 0;
	public override void _Ready()
	{
		if (Amplitiude == null)
		{
			throw new Exception("Wave Amplitiude is null");
		}
		if (Speed == null)
		{
			throw new Exception("Wave Speed is null");
		}
	}

    public override double Value()
    {
		double value = UndergoWaveFunction(_position, Type) * Amplitiude.Value();
		_position += Speed.Value() * GetProcessDeltaTime();
		return value;
	}


    double UndergoWaveFunction(double Value, WaveType WaveType)
	{
		switch (WaveType)
		{
			case WaveType.Sine:
				return Math.Sin(Value);
			case WaveType.Cosine:
				return Math.Cos(Value);
			case WaveType.Tangent:
				return Math.Tan(Value);
			case WaveType.Cosec:
				return Math.Cos(Value);
			case WaveType.SquareRoot:
				return Math.Sqrt(Value);
			case WaveType.Log:
				return Math.Log(Value);
			case WaveType.Exponential:
				return Math.Exp(2);
			default:
				return 0;
		}
	}
}
/*
	public override void _Process(double delta)
	{
		Godot.Vector2 Offset = new Godot.Vector2(0,0);
		Offset[(int)directional] = (float)UndergoWaveFunction(_wavePosition,_waveType) * (float)_waveAmplitiude.Value();
		_wavePosition += _waveSpeed.Value() * delta;
		ComponentController.Position = ComponentController.Position + Offset;
	}
*/