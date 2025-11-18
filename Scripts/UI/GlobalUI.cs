
using Godot;

public partial class GlobalUI : Node
{
    [Export] public MainGameUI MainGameUi;
    [Export] public ModifiersListUI ModifiersList;
    [Export] public AfterGameSwitcher AfterGameSwitcher;
    [Export] public PauseMenu PauseMenuUi;
    [Export] public PackedScene GameOverScene;
    
    public BackgroundLayer BackgroundLayer;
    
    public override void _EnterTree()
    {
        GlobalContext.GlobalUIInstance = this;
    }

    public void MainSceneUIOpen()
    {
        MainGameUi.Visible = true;
        ModifiersList.Visible = true;
        BackgroundLayer.Visible = true;
        AfterGameSwitcher.Visible = false;
    }

    public void TimeSwitcherUIOpen()
    {
        MainGameUi.Visible = false;
        ModifiersList.Visible = false;
        BackgroundLayer.Visible = false;
        AfterGameSwitcher.Visible = true;
    }

    public void ShowGameOverScreen()
    {
        
    }
}