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
			if ( IsServer )
			{
				foreach(toiletspot toilet in All.OfType<toiletspot>() ) 
				{
					Toilets.Add(
					new Toilet()
					{
						Transform = new Transform()
						{
							Position = toilet.Position,
							Rotation = toilet.Rotation,
							Scale = 1.2f
						}
					} ); ;
				}

				_ = new ToiletRoyaleHud();
			}

			Current = this;
		}


		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			Log.Info(Toilets.Count);

			var player = new ToiletRoyalePlayer();
			client.Pawn = player;

			player.Respawn();
		}

		public virtual void MoveToEmptyToilet( Entity pawn )
		{
			List<Toilet> EmptyToilets = Toilets.FindAll( toilet => toilet.Claimer == null );

			if ( EmptyToilets != null && EmptyToilets.Count > 0 )
			{
				int RandomToiletIndex = Rand.Int( 0, EmptyToilets.Count - 1 );

				pawn.Transform = EmptyToilets[RandomToiletIndex].Transform;
				EmptyToilets[RandomToiletIndex].Claimer = pawn;
			}
			else
			{
				Log.Info( "Can't find empty toilet!" );
			}
		}

		public override void ClientDisconnect( Client cl, NetworkDisconnectionReason reason )
		{
			if ( cl.Pawn != null )
			{
				Toilets.Find( toilet => toilet.Claimer == cl.Pawn ).Claimer = null;
				Sound.FromWorld( "toilet-flush", cl.Pawn.Position );
			}

			base.ClientDisconnect( cl, reason );
		}

		public override void DoPlayerNoclip( Client player ) { }
		public override void DoPlayerSuicide( Client cl ) { }
	}
}
