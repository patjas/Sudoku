using System;
using Gtk;

namespace Sudoku
{
	public partial class Plansza : Gtk.Window
	{
		public Plansza () :
			base (Gtk.WindowType.Toplevel)
		{

			this.Build ();
		}
	}
}

