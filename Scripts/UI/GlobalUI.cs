
using Godot;

public partial class GlobalUI : Node
{
    [Export] public MainGameUI MainGameUi;
    [Export] public PackedScene GameOverScene;
    
    public override void _EnterTree()
    {
        GlobalContext.GlobalUIInstance = this;
    }

    public void MainSceneUIOpen()
    {
        MainGameUi.Visible = true;
    }

    public void ShopUIOpen()
    {
        MainGameUi.Visible = false;
    }
}