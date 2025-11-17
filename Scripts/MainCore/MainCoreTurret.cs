
using Godot;

public partial class MainCoreTurret : Node2D
{
    [ExportGroup("Sprite")] 
    [Export] private Sprite2D _turretSprite;
    [Export] private CompressedTexture2D _turretDaySprite;
    [Export] private CompressedTexture2D _turretNightSprite;
    
    private bool _canShoot = true;

    public void DestroyNegativeMiniCore(Node2D target)
    {
        //if()
    }

    public void RebuildForDay()
    {
        _turretSprite.Texture = _turretDaySprite;
    }
    
    public void RebuildForNight()
    {
        _turretSprite.Texture = _turretNightSprite;
    }
}