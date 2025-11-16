using Godot;


public partial class ShopManager : Node
{
    [Export] public MainCorePassiveUpgrades MainCorePassiveUpgrades;
    [Export] public MiniCorePassiveUpgrades MiniCorePassiveUpgrades;
    [Export] public ModifiersUpgrades ModifiersUpgrades;

    public override void _Ready()
    {
        GlobalContext.ShopManagerInstance = this;
    }
}