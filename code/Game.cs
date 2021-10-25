using Sandbox;
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
				Toilets.Add(
					new Toilet()
					{
						Transform = new Transform()
						{
							Position = new Vector3( 95f, 0, 8.5f ),
							Rotation = Rotation.FromYaw( 180 ),
							Scale = 1.2f
						}
					} );

				Toilets.Add(
					new Toilet()
					{
						Transform = new Transform()
						{
							Position = new Vector3( 95f, 64.16f, 8.5f ),
							Rotation = Rotation.FromYaw( 180 ),
							Scale = 1.2f
						}
					} );

				Toilets.Add(
					new Toilet()
					{
						Transform = new Transform()
						{
							Position = new Vector3( 95f, 128.3f, 8.5f ),
							Rotation = Rotation.FromYaw( 180 ),
							Scale = 1.2f
						}
					} );

				Toilets.Add(
					new Toilet()
					{
						Transform = new Transform()
						{
							Position = new Vector3( 95f, 192.5f, 8.5f ),
							Rotation = Rotation.FromYaw( 180 ),
							Scale = 1.2f
						}
					} );

				Toilets.Add(
					new Toilet()
					{
						Transform = new Transform()
						{
							Position = new Vector3( -31f, 0, 8.5f ),
							Rotation = Rotation.FromYaw( 0 ),
							Scale = 1.2f
						}
					} );

				Toilets.Add(
					new Toilet()
					{
						Transform = new Transform()
						{
							Position = new Vector3( -31f, 64.16f, 8.5f ),
							Rotation = Rotation.FromYaw( 0 ),
							Scale = 1.2f
						}
					} );

				Toilets.Add(
					new Toilet()
					{
						Transform = new Transform()
						{
							Position = new Vector3( -31f, 128.3f, 8.5f ),
							Rotation = Rotation.FromYaw( 0 ),
							Scale = 1.2f
						}
					} );

				Toilets.Add(
					new Toilet()
					{
						Transform = new Transform()
						{
							Position = new Vector3( -31f, 192.5f, 8.5f ),
							Rotation = Rotation.FromYaw( 0 ),
							Scale = 1.2f
						}
					} );

				_ = new HudEntity();
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
			if ( cl.Pawn != null ) Toilets.Find( toilet => toilet.Claimer == cl.Pawn ).Claimer = null;

			base.ClientDisconnect( cl, reason );
		}

		public override void DoPlayerNoclip( Client player ) { }
		public override void DoPlayerSuicide( Client cl ) { }
	}
}
