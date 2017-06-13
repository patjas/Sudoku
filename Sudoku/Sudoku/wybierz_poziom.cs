using System;

namespace Sudoku
{
	public partial class wybierz_poziom : Gtk.Window
	{
		public wybierz_poziom () :
			base (Gtk.WindowType.Toplevel)
		{
			
			this.Build ();
		}

		protected void OnButton2Clicked (object sender, EventArgs e)
		{
			new sudoku (25);
		}

		protected void OnButton3Clicked (object sender, EventArgs e)
		{
			new sudoku (40);
		}

		protected void OnButton4Clicked (object sender, EventArgs e)
		{
			new sudoku (55);
		}
	}
}

