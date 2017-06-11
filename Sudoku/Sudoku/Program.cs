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
			Window okno = new Window ("Sudoku");
			okno.DeleteEvent += delegate {
				Application.Quit ();
			};

			okno.SetSizeRequest (ekr_szer, ekr_wys);
			okno.BorderWidth = 10;

			Table m_tab = new Table (5, 8, false);

			PlanszaGra pg_akt = new PlanszaGra (m_tab, 1, 1, 4, 6);
			ObslugaWejscia.ustawG_cel (pg_akt);
			new liczbaPrzyciski (m_tab, pg_akt, "Cyfry", 1, 0, 4, 1);

			m_tab.Show ();
			okno.Add (m_tab);

			pg_akt.generuj (50);

			Button zamknij_gra = new Button ("Wyjdź");
			zamknij_gra.Clicked += delegate {
				Application.Quit ();
			};
			m_tab.Add (zamknij_gra);

			okno.Resizable = false;
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
