
using Godot;

public partial class GlobalUI : Node
{
    [Export] public MainGameUI MainGameUi;
    [Export] public AfterGameSwitcher AfterGameSwitcher;
    [Export] public PauseMenu PauseMenuUi;
    [Export] public GameOverScene GameOverUI;
    
    public BackgroundLayer BackgroundLayer;
    
    public override void _EnterTree()
    {
        GlobalContext.GlobalUIInstance = this;
    }

    public void MainSceneUIOpen()
    {
        MainGameUi.Visible = true;
        BackgroundLayer.Visible = true;
        AfterGameSwitcher.Visible = false;
        PauseMenuUi.Visible = false;
    }

    public void TimeSwitcherUIOpen()
    {
        MainGameUi.Visible = false;
        BackgroundLayer.Visible = true;
        AfterGameSwitcher.Visible = true;
        PauseMenuUi.Visible = false;
    }

    public void SettingsSceneUIOpen()
    {
        MainGameUi.Visible = true;
        BackgroundLayer.Visible = true;
        AfterGameSwitcher.Visible = false;
        PauseMenuUi.Visible = false;
    }

    public void CloseSettings()
    {
        MainGameUi.Visible = true;
        BackgroundLayer.Visible = true;
        AfterGameSwitcher.Visible = false;
        PauseMenuUi.Visible = true;
    }

    public void OpenPause()
    {
        if (AfterGameSwitcher.Visible == false)
        {
            GlobalContext.MainGameInstance.ProcessMode = ProcessModeEnum.Disabled;
            MainGameUi.Visible = true;
            BackgroundLayer.Visible = true;
            AfterGameSwitcher.Visible = false;
            PauseMenuUi.Visible = true;
        }
    }
    
    public void OpenGameOverUI()
    {
        MainGameUi.Visible = false;
        BackgroundLayer.Visible = false;
        AfterGameSwitcher.Visible = false;
        PauseMenuUi.Visible = false;
        GameOverUI.Visible = true;
    }
}