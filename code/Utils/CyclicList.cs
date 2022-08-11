namespace carreath
{
	public class CyclicList<T> : List<T>
	{
		private int _index = 0;

		public int Index { 
			get
			{
				if ( _index >= this.Count ) _index = 0;
				return _index;
			}
			set => _index = value; 
		}

		public T Next()
		{
			if ( Count == 0 ) return default( T );
			return this[Index++];
		}

		public T Current()
		{
			if ( Count == 0 ) return default( T );
			return this[Index];
		}
	}
}
