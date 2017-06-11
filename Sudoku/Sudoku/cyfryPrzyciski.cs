using System;
using Gtk;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public class cyfryPrzyciski
	{
		List<Button> przyciski = new List<Button> ();
		public cyfryPrzyciski (Table rodzic_t, PlanszaGra pgf, string name="", uint row = 0 , uint col = 0, uint rowspan = 0, uint colspan = 0)
		{
			Frame ramka;
			Box kont;
			Table localtab_b = new Table(9, 1, false);

			ramka = new Frame ();
			ramka.Label = name;
			ramka.ShadowType = (ShadowType)4;
			kont = new HBox (false, 0);

			for (int i = 0; i < 9; i++) {
				przyciski.Add (new Button ((i+1).ToString()));
				var aktualnie = i+1;
				przyciski[i].Clicked += (sender, EventArgs) => ObslugaWejscia.ustaw_liczba (sender, EventArgs, aktualnie);
				localtab_b.Attach (przyciski[i], 0, 1, (uint)i, (uint)i+1);
			}

			ramka.Add (localtab_b);
			kont.PackStart (ramka, true, true, 5);
			localtab_b.Show ();
			rodzic_t.Attach (kont, col, colspan+col, row, rowspan+row);
		}
	}
}

