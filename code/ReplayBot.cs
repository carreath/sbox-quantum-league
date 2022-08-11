using Sandbox;

namespace carreath;

public class ReplayBot : Bot
{
	public RecordablePawn Pawn { get; set; }

	public ReplayBot() { }

	public ReplayBot( Client cl ) : base( ) {
		Client.Pawn = cl.Pawn; 
		Pawn = Client.Pawn as RecordablePawn;
		Pawn.PlayerController = new PathController();
		cl.Pawn = new RecordablePawn( cl );
		cl.Pawn.Position = Vector3.Up * -12288;
		var cloneCount = cl.GetValue( "CloneCount", 1 );
		if ( cloneCount >= MyGame.MAX_CLONES )
		{
			(cl.Pawn as RecordablePawn).Record = false;
		} 
		else
		{
			cl.SetValue( "CloneCount", cloneCount + 1 );
		}
	}

	public static void SpawnCustomBot()
	{
		Host.AssertServer();

		// Create an instance of your custom bot.
		_ = new ReplayBot();
	}

	public override void BuildInput( InputBuilder input )
	{
		base.BuildInput( input );
	}

	public override void Tick() { }
}
