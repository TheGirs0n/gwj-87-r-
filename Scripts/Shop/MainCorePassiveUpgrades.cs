using Godot;
using Godot.Collections;

public partial class MainCorePassiveUpgrades : Node
{
    [Export] private int _turretUpgradeValue;
  
    [Export] private Array<int> _turretUpgradeCosts;

    public int ShowTurretCost(int index)
    {
        return _turretUpgradeCosts[index];
    }
}