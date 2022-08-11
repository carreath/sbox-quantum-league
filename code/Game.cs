using Sandbox;
using System;

namespace carreath;

public partial class MyGame : Sandbox.Game
{
	[Net]
	public float LastRound { get; set; } = 0;
	[Net]
	public bool NewRound { get; set; } = true;

	public static int MAX_CLONES = 4;
	public static float ROUND_TIME_LIMIT = 10f;

	public MyGame() { }

	public override void ClientJoined( Client client )
	{
		base.ClientJoined( client );

		if ( !client.IsBot )
		{ 
			var pawn = new RecordablePawn( client );
			client.Pawn = pawn;
			pawn.Position = Vector3.Up * -12288;
		}
	}
	public override void Simulate( Client cl )
	{
		base.Simulate( cl );

		if ( !cl.IsBot )
		{
			if ( IsServer )
			{
				DebugOverlay.ScreenText( $"Round Timer: {((int)(MyGame.ROUND_TIME_LIMIT - (RealTime.Now - LastRound)))}" );
				if ( NewRound )
				{
					LastRound = RealTime.Now;
					NewRound = false;
				}

				if ( LastRound - RealTime.Now < -MyGame.ROUND_TIME_LIMIT )
				{
					NewRound = true;

					if ( LastRound != 0 )
					{
						if ( (cl.Pawn as RecordablePawn).Record )
						_ = new ReplayBot( cl );
					}

				}
			}
		}
		else
		{
			if ( LastRound - RealTime.Now < -MyGame.ROUND_TIME_LIMIT )
			{
				(cl.Pawn as RecordablePawn).NewRound();
			}
		}
	}
}
