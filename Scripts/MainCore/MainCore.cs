
using System.Linq;
using Godot;

public partial class MainCore : Node2D
{
    [ExportGroup("Sub parameters")]
    [Export] private Node _mainCoreTurretPool;
    [Export] private RichTextLabel _scoreLabel;
    [Export] public int _score;

    [ExportGroup("SpriteSetting")]
    [Export] public Sprite2D MainCoreSprite;
    [Export] public CompressedTexture2D MainCoreDaySprite;
    [Export] public CompressedTexture2D MainCoreNightSprite;
    
    public override void _Ready()
    {
        GlobalContext.MainCoreInstance = this;
    }

    public void AddScore(int score)
    {
        _score += score;    
    }

    public void DecreaseScore(int score)
    {
        _score -= score;
    }

    public void AddTurretFromPool()
    {
        _mainCoreTurretPool.GetChildren().First(x => x.ProcessMode == ProcessModeEnum.Disabled).ProcessMode = ProcessModeEnum.Inherit;
    }

    public void RebuildForDay()
    {
        MainCoreSprite.Texture = MainCoreDaySprite;
    }
    
    public void RebuildForNight()
    {
        MainCoreSprite.Texture = MainCoreNightSprite;
    }
}