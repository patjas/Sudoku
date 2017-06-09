using System;
using Gtk;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public class liczbaPrzyciski
	{
		List<Button> przyciski=new List<Button>();


		public liczbaPrzyciski (Table rodzic, PlanszaGra pg, string nazwa="",uint row=0,uint col=0, uint rowspan=0, 
			uint colspan=0)
		{
			Frame ramka=new Frame("s_ramka");
			Box kont;
			Table localtab=new Table(9,1,false);

			ramka.Label = nazwa;
			ramka.ShadowType = (ShadowType)5;
			kont = new HBox (false, 0);

			for (int i = 0; i < 9; i++) 
			{
				przyciski.Add (new Button ((i + 1).ToString()));
				var aktualnie = i + 1;
				przyciski [i].Clicked += (sender, EventArgs) => ObslugaWejscia.ustawLiczba (sender, EventArgs, aktualnie); 
				localtab.Attach (przyciski [i], 0, 1, (uint)i, (uint)i + 1);
			}

			ramka.Add (localtab);
			kont.PackStart (ramka, true, true, 1);
			localtab.Show ();

			rodzic.Attach (kont, col, colspan + col, row, rowspan + row);

		}
	}
}

