using Godot;

public abstract partial class ShopUpgradeSlotUi : Texture
{
    [Export] public int IndexSlot;
    protected bool _isActivated = false;

    public abstract void ShowUpgradeSlotPopUp();
}