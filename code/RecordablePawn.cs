using Sandbox;

namespace carreath;

public partial class RecordablePawn : Player
{
	public bool Record { get; set; } = true;

	public CyclicList<TickData> Recording { get; } = new CyclicList<TickData>();

	public TickData TickData
	{
		get => Recording.Next();
		set => Recording.Add( value );
	}

	public RecordablePawn( ) { }

	public RecordablePawn(Client cl) : base(cl) { }

	public override void Spawn()
	{
		base.Spawn();
	}

	public override void Simulate( Client cl )
	{
		base.Simulate( cl );
	}

	public override void FrameSimulate( Client cl )
	{
		base.FrameSimulate( cl );
	}

	public void NewRound()
	{
		Recording.Index = 0;
	}
}
