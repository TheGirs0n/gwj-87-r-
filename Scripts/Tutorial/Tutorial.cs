using Godot;
using System;

public partial class Tutorial : Node
{
	[ExportGroup("Button")] 
	[Export] private Button Button;
	[Export] private Theme ButtonDayTheme;
	[Export] private Theme ButtonNightTheme;
}
