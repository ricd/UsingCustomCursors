using Microsoft.UI.Input;
using Microsoft.UI.Xaml.Controls;

namespace UsingCustomCursors
{
	internal class Grid2 : Grid
	{
		public InputCursor Cursor
		{
			get => ProtectedCursor;

			set => ProtectedCursor = value;
		}
	}
}
