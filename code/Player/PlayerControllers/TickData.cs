using Sandbox;
using System.Collections.Generic;

namespace carreath
{
	[Library]
	public partial class TickData
	{
		public Vector3 Position { get; set; }
		public sbyte Rotation { get; set; }
		public Vector3 Velocity { get; set; }
		public sbyte EyeRotation { get; set; }
		public Vector3 EyeLocalPosition { get; set; }
		public Vector3 BaseVelocity { get; set; }
		public Vector3 WishVelocity { get; set; }
	}
}


