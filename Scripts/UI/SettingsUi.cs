using Godot;

public partial class SettingsUi : Control
{
    public override void _EnterTree()
    {
        GlobalContext.SettingsUiInstance = this;
    }

    public void HideSettings()
    {
        this.Visible = false;
    }
}
