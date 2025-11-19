using Godot;
using System;

public partial class CoreTurretBullet : Sprite2D
{
	[ExportGroup("BulletSprite")]
	[Export] private Sprite2D _bulletSprite;
	[Export] private CompressedTexture2D _bulletDayTexture;
	[Export] private CompressedTexture2D _bulletNightTexture;

	[ExportGroup("Particles")]
	[Export] private GpuParticles2D _bulletParticles;
	[Export] private ParticleProcessMaterial _bulletDayProcessMaterial;
	[Export] private ParticleProcessMaterial _bulletNightProcessMaterial;

	public void RebuildForCurrentTimeType(TimeType timeType)
	{
		switch (timeType)
		{
			case TimeType.DAY:
				_bulletSprite.Texture = _bulletDayTexture;
				_bulletParticles.ProcessMaterial = _bulletDayProcessMaterial;
				break;
			case TimeType.NIGHT:
				_bulletSprite.Texture = _bulletNightTexture;
				_bulletParticles.ProcessMaterial = _bulletNightProcessMaterial;
				break;
		}
	}
}
