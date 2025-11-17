using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class MainCoreTurretPool : Node
{
	[Export] private PackedScene _turretScene;
	private List<MainCoreTurret> _mainCoreTurrets = new List<MainCoreTurret>();

	public void RebuildTurrets(TimeType timeType)
	{
		foreach (var turret in _mainCoreTurrets)
		{
			turret.RebuildForCurrentTimeType(timeType);
		}
	}

	public void GetNewTurret()
	{
		var turret = _turretScene.Instantiate<MainCoreTurret>();
		_mainCoreTurrets.Add(turret);
		this.AddChild(turret);
	}
}
