using Godot;
using System;

public partial class ModifiersSlotUi : TextureRect
{
	private ModifieTemplate _modifieTemplate;

	public void SetModifierInSlot(ModifieTemplate modifier)
	{
		_modifieTemplate = modifier;
	}

	public void ShowModifierInSlot()
	{
		
	}
}
