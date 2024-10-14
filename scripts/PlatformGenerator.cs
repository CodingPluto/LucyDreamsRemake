
using Godot;
using System;
[Tool]
public partial class PlatformGenerator : Marker2D
{
	[ExportSubgroup("Platforms")]
	[Export]
	PackedScene[] _platformScenes { get; set; }
	[Export]
	int _platformCountLowerBound = 0;
	[Export]
	int _platformCountUpperBound = 0;
	bool _gameRunning = false;
	[Export]
	bool _canGenerate = true;
	public override void _Ready()
	{
		UpdateConfigurationWarnings();
		GD.Print("Platform Scenes: ", _platformScenes);
	}
	override public string[] _GetConfigurationWarnings()
	{
		if (!(_platformScenes.Length > 0))
		{
			String[] ErrorMessage= new string[]{"There is no attached platform scene."};
			return ErrorMessage;
		}
		NotifyPropertyListChanged();
		return base._GetConfigurationWarnings();
	}
	public override void _Process(double delta)
	{
		_gameRunning = !Engine.IsEditorHint();
		if (_gameRunning)
		{
			if (_platformScenes.Length > 0 && _canGenerate)
			{
				GeneratePlatforms(Globals.Instance.rng.RandiRange(_platformCountLowerBound,_platformCountUpperBound));
				_canGenerate = false;
			}
		}
	}
	private void GeneratePlatforms(int Count)
    {
        for (int Index = 0; Index < Count; ++Index)
        {
			int PlatformType = Globals.Instance.rng.RandiRange(0,_platformScenes.GetLength(0) - 1);
			Node Instance = _platformScenes[PlatformType].Instantiate();
			AddChild(Instance);	
        }
    }
}
