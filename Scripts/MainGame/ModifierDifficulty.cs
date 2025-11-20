using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class ModifierDifficulty : Node
{
	[Export] private Godot.Collections.Dictionary<string, float> _modifierDifficulty;

	private Random random = new Random();
	
	public void ApplyRandomModifierDifficulty()
	{
		var number = random.Next(1, _modifierDifficulty.Count);
		KeyValuePair<string, float> pair = _modifierDifficulty.ElementAt(number);
	
		switch (number)
		{
			case 0: // minus positive
				var miniCorePositiveInitialValue = GlobalContext.SpawnMiniCoresInstance.MiniCorePositiveScore;
				GlobalContext.SpawnMiniCoresInstance.UpdatePositiveScore(miniCorePositiveInitialValue - pair.Value);
				
				var miniCorePositiveNewValue = GlobalContext.SpawnMiniCoresInstance.MiniCorePositiveScore;
				var positiveText = Tr("UI_SWITCHER_MOD_TEXT_1");
				
				GlobalContext.GlobalUIInstance.AfterGameSwitcher.SetupModifierScene(positiveText, pair.Value, miniCorePositiveNewValue);
				break;
			case 1: // plus negative
				var miniCoreNegativeScore = GlobalContext.SpawnMiniCoresInstance.MiniCoreNegativeScore;
				GlobalContext.SpawnMiniCoresInstance.UpdateNegativeScore(miniCoreNegativeScore + pair.Value);
				
				var miniCoreNegativeNewScore = GlobalContext.SpawnMiniCoresInstance.MiniCoreNegativeScore;
				var negativeText = Tr("UI_SWITCHER_MOD_TEXT_2");

				GlobalContext.GlobalUIInstance.AfterGameSwitcher.SetupModifierScene(negativeText, pair.Value, miniCoreNegativeNewScore);
				break;
			case 2: // spawn time
				var waitTime = GlobalContext.SpawnMiniCoresInstance.SpawnTimer.WaitTime;
				GlobalContext.SpawnMiniCoresInstance.UpdateSpawnTimer((float)(waitTime + pair.Value));
				
				var newWaitTime = GlobalContext.SpawnMiniCoresInstance.SpawnTimer.WaitTime;
				var waitTimeText = Tr("UI_SWITCHER_MOD_TEXT_3");

				GlobalContext.GlobalUIInstance.AfterGameSwitcher.SetupModifierScene(waitTimeText, pair.Value, (float)newWaitTime);
				break;
			case 3: // speed multiplayer
				var miniCoreSpeedMultiplier = GlobalContext.SpawnMiniCoresInstance.MiniCoreSpeedMultiplier;
				GlobalContext.SpawnMiniCoresInstance.UpdateSpeedMultiplier(miniCoreSpeedMultiplier + pair.Value);
				
				var miniCoreNewSpeedMultiplier = GlobalContext.SpawnMiniCoresInstance.MiniCoreSpeedMultiplier;
				var speedMultiplayerText = Tr("UI_SWITCHER_MOD_TEXT_4");
				
				GlobalContext.GlobalUIInstance.AfterGameSwitcher.SetupModifierScene(speedMultiplayerText, pair.Value, miniCoreNewSpeedMultiplier);
				break;
		}
	}
}
