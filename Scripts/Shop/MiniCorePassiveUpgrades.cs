using Godot;
using Godot.Collections;

public partial class MiniCorePassiveUpgrades : Node
{
    [Export] private int _positiveUpgradeValue;
    [Export] private int _negativeUpgradeValue;
    
    [Export] private Array<int> _positiveUpgradeCosts;
    [Export] private Array<int> _negativeUpgradeCosts;

    public int ShowPositiveCost(int index)
    {
        return _positiveUpgradeCosts[index];
    }

    public int ShowNegativeCost(int index)
    {
        return _negativeUpgradeCosts[index];
    }
}