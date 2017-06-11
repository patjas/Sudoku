using System;
using Gtk;
using System.Drawing;
using System.Linq;

namespace Sudoku
{
	public class sudoku: Window
	{
		private const int ekr_wys=600;
		private const int ekr_szer = 600;

		public sudoku(): base("")
		{
			Window okno = new Window ("Gra Sudoku");
			okno.DeleteEvent += delegate 
			{ Application.Quit (); };
			okno.SetSizeRequest (ekr_szer, ekr_wys);
			okno.BorderWidth = 10;

			Table m_tab = new Table (5, 8, false);
			PlanszaGra pg_akt = new PlanszaGra (m_tab, 1, 1, 4, 6);
			ObslugaWejscia.ustaw_cel (pg_akt);
			new cyfryPrzyciski (m_tab, pg_akt, "Cyfry", 1, 0, 4, 1);
			m_tab.Show ();
			okno.Add (m_tab);

			MenuBar mb = new MenuBar ();
			MenuItem zamknij = new MenuItem ("Koniec");
			MenuItem nowa_gra = new MenuItem ("Nowa gra");
			zamknij.ButtonPressEvent += delegate {	Application.Quit(); };
			//nowa_gra.ButtonPressEvent += delegate {new poziom_wybor(pg_akt);};
			mb.Append (zamknij);
			//mb.Append (nowa_gra);

			m_tab.Attach (mb, 0, 9, 0, 1);
			okno.Resizable = false;
			pg_akt.generuj (40);
			okno.ShowAll ();
		}

		public static void Main(string[] args)
		{
			Application.Init ();
			new sudoku ();
			Application.Run ();
		}
	}
}
