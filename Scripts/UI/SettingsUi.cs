using System.Reflection.Metadata;
using Godot;

public partial class SettingsUi : Control
{
    [Export] private SettingsBarUi SettingsBar;

    public void LoadUserSettings()
    {
        SettingsBar.LoadAllUserSettings();
    }

    public void HideSettings()
    {
        if (GlobalContext.MainMenuInstance != null)
        {
            GlobalContext.MainMenuInstance.SetUntransperentMenu();
        }
        else if (GlobalContext.MainGameInstance != null)
        {
            GlobalContext.GlobalUIInstance.CloseSettings();
        }
        
        this.QueueFree();
    }
}
