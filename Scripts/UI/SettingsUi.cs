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
    }
}
