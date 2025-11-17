
using Godot;

public partial class GlobalUI : Node
{
    [Export] public ShopUi ShopUi;
    [Export] public MainGameUI MainGameUi;

    public override void _Ready()
    {
        GlobalContext.GlobalUIInstance = this;
    }

    public void MainSceneUIOpen()
    {
        ShopUi.Visible = false;
        MainGameUi.Visible = true;
    }

    public void ShopUIOpen()
    {
        ShopUi.Visible = true;
        MainGameUi.Visible = false;
    }
}