using Sandbox;
using System.Linq;
using System.Collections.Generic;

namespace ToiletRoyale
{
	public class Toilet
	{
		public Transform Transform;
		public Entity Claimer;
	}

	[Library( "toiletroyale", Title = "Toilet Royale" )]
	public partial class ToiletRoyaleGame : Game
	{
		public static new ToiletRoyaleGame Current { get; protected set; }

		public List<Toilet> Toilets = new();

		public ToiletRoyaleGame()
		{

			Log.Info("Game Started");

			if ( IsServer )
			{
				_ = new ToiletRoyaleHud();
			}
			Current = this;
		}


		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new ToiletRoyalePlayer();
			client.Pawn = player;

			player.Respawn();
		}

		public virtual void MoveToEmptyToilet( Entity pawn )
		{
			var toilets = All.OfType<toiletspot>().Where( x => x.Claimer is null );

			var targetToilet = toilets.FirstOrDefault();
			pawn.Transform = targetToilet.Transform;
			pawn.ResetInterpolation();
			targetToilet.Claimer = pawn;
		}

		public override void ClientDisconnect( Client cl, NetworkDisconnectionReason reason )
		{
			if ( cl.Pawn != null )
			{
				//Toilets.Find( toilet => toilet.Claimer == cl.Pawn ).Claimer = null;
				Sound.FromWorld( "toilet-flush", cl.Pawn.Position );
				var curtoilet = All.OfType<toiletspot>().Where( x => x.Claimer == cl.Pawn );
				curtoilet.Single().Claimer = null;

			}

			base.ClientDisconnect( cl, reason );
		}

		public override void DoPlayerNoclip( Client player ) { }
		public override void DoPlayerSuicide( Client cl ) { }
	}
}
