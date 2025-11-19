using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ModifierDifficulty : Node
{
	[Export] private Godot.Collections.Dictionary<string, float> _modifierDifficulty = new Godot.Collections.Dictionary<string, float>();

	private Random random = new Random();
	
	public void ApplyRandomModifierDifficulty()
	{
		var number = random.Next(1, _modifierDifficulty.Count);
		KeyValuePair<string, float> pair = _modifierDifficulty.ElementAt(number);

		switch (number)
		{
			case 0: // minus positive
				//GlobalContext.
				break;
			case 1: // plus negative
				break;
			case 2: // spawn time
				break;
			case 3: // speed multiplayer
				break;
		}
	}
}
