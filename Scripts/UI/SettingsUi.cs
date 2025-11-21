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
        this.QueueFree();

        if (GlobalContext.MainMenuInstance != null)
        {
            GlobalContext.MainMenuInstance.SetUntransperentMenu();
        }
        
        if (GlobalContext.MainGameInstance != null)
        {
            GlobalContext.MainGameInstance.SetUntransperentMenu();
            GlobalContext.GlobalUIInstance.CloseSettings();
        }
    }
}
