using Godot;
using System;

public partial class ModifiersList : Node
{
	public override void _EnterTree()
	{
		GlobalContext.ModifiersListInstance = this;
	}

	public void GetRandomModifier()
	{
		
	}
}
