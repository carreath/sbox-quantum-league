using Sandbox;
using System.Collections.Generic;

namespace carreath
{
	[Library]
	public partial class PathController : PawnController
	{
		public void RecordTick()
		{ 
			var tickData = new TickData
			{
				Position = Position, // 16B
				Rotation = (sbyte)(Rotation.Yaw() * 0.7f),
				Velocity = Velocity, // 16B
				EyeRotation = (sbyte)(EyeRotation.Yaw() * 0.7f),
				EyeLocalPosition = EyeLocalPosition, // 16B
				BaseVelocity = BaseVelocity, // 16B
				WishVelocity = WishVelocity // 16B
			};
			(Pawn as RecordablePawn).TickData = tickData;
		}

		public void UpdateFromRecording()
		{

			var tickData = (Pawn as RecordablePawn).TickData;

			if ( tickData == null ) return;

			Position = tickData.Position;
			Rotation = Rotation.FromYaw( tickData.Rotation / 0.7f );
			Velocity = tickData.Velocity;
			EyeRotation = Rotation.FromYaw( tickData.EyeRotation / 0.7f );
			EyeLocalPosition = tickData.EyeLocalPosition;
			BaseVelocity = tickData.BaseVelocity;
			WishVelocity = tickData.WishVelocity;
		}

		public override void Simulate()
		{
			this.SimulatePathRecorder();
		}

		public void SimulatePathRecorder()
		{
			if ( !Client.IsBot )
			{
				if ( !(Pawn as RecordablePawn).Record ) return;
				RecordTick();
			}
			else
			{
				UpdateFromRecording();
			}
		}
	}
}


