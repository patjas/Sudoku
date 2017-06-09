using System;

namespace Sudoku
{
	public partial class OknoStart : Gtk.Window
	{	PlanszaGra pg_f;
		int am;
		public OknoStart () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}


		protected void OnButton1Clicked (object sender, EventArgs e)
		{
			am = 20;
			this.Destroy ();
			new sudoku ();
			pg_f.generuj(this.am);
			
		}

		protected void OnButton2Clicked (object sender, EventArgs e)
		{
			
		}

		protected void OnButton3Clicked (object sender, EventArgs e)
		{
			
		}
	}
}

