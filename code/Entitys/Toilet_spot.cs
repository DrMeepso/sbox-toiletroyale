using Sandbox;
using System.Linq;
using System;

[Library( "toilet_spot", Description = "Spawn a player here" )]
[Hammer.EditorModel( "models/toilet.vmdl" )]
[Hammer.EntityTool( "Player Shitpoint", "Toilet", "Defines a point where a player can shit" )]
public partial class toiletspot : Prop
{
	public Entity Claimer;
	public override void Spawn()
	{
		SetModel( "models/toilet.vmdl" );
		base.Spawn();
	}
}
