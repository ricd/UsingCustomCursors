using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;

namespace UsingCustomCursors
{
	public sealed partial class MainWindow
	{
		private InputCursor _redCursor;
		private InputCursor _greenCursor;
		private InputCursor _blueCursor;

		private enum CustomCursor
		{
			None,
			Red,
			Green,
			Blue
		};

		public MainWindow() { InitializeComponent(); }

		private CustomCursor CurrentCursor { get; set; } = CustomCursor.None;

		private void OnGridLoaded(object sender, RoutedEventArgs e)
		{
			_redCursor = InputDesktopResourceCursor.CreateFromModule("UsingCustomCursors", 201);
			_greenCursor = InputDesktopResourceCursor.CreateFromModule("UsingCustomCursors", 202);
			_blueCursor = InputDesktopResourceCursor.CreateFromModule("UsingCustomCursors", 203);
		}

		private void OnGridPointerPressed(object sender, PointerRoutedEventArgs e)
		{
			switch (CurrentCursor)
			{
				case CustomCursor.None:
					_grid2.Cursor = _redCursor;
					CurrentCursor = CustomCursor.Red;
					break;

				case CustomCursor.Red:
					_grid2.Cursor = _greenCursor;
					CurrentCursor = CustomCursor.Green;
					break;

				case CustomCursor.Green:
					_grid2.Cursor = _blueCursor;
					CurrentCursor = CustomCursor.Blue;
					break;

				case CustomCursor.Blue:
					_grid2.Cursor = null;
					CurrentCursor = CustomCursor.None;
					break;
			}
		}

		private void OnWindowClosed(object sender, WindowEventArgs args)
		{
			// Since our custom cusors have the same lifetime as this window,
			// there is no real need to Dispose them. This is here simply as
			// a reminder that cursors can cause memory leaks if you leave
			// them sitting around.
			_redCursor?.Dispose();
			_redCursor = null;

			_greenCursor?.Dispose();
			_greenCursor = null;

			_blueCursor?.Dispose();
			_blueCursor = null;
		}
	}
}
