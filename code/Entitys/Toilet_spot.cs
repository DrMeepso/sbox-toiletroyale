using Sandbox;
using System.Linq;
using System;

[Library( "toilet_spot", Description = "Spawn a player here" )]
[Hammer.EditorModel( "models/toilet.vmdl" )]
[Hammer.EntityTool( "Player Spawnpoint", "Death", "Defines a point where a player can spawn" )]
public partial class toiletspot : Prop
{
	public Entity Claimer;
	public override void Spawn()
	{
		Log.Info( "Spawned Toilet" );
		SetModel( "models/toilet.vmdl" );
		base.Spawn();
	}
}
