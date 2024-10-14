using Godot;
using System;

public partial class RandomisedValue : ComplexValue
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	bool Randomised = true;
	[Export]
	float RandomUpperBound = 10;
	[Export]
	float RandomLowerBound = 0;
	[Export]
	bool RandomiseNegativePositive = false;
	RandomNumberGenerator rng;
	public override void _EnterTree()
	{
		if (Randomised)
		{
			rng = new RandomNumberGenerator();
			_Value = (double)rng.RandfRange(RandomLowerBound, RandomUpperBound);
			if (RandomiseNegativePositive)
			{
				if ((double)rng.RandiRange(0, 1) == 1)
				{
					_Value = -_Value;
				}
			}
		}
		else
		{
			_Value = RandomUpperBound;
		}
	}

}
