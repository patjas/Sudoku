using System;
using Gtk;
using System.Collections.Generic;

namespace Sudoku
{
	public partial class PlanszBox
	{	private Frame pRamka;
		private List<Plansza> lista=new List<Plansza>();
		PlanszaGra p_gra;

		public PlanszBox (PlanszaGra rodzic)
		{
			p_gra = rodzic;
			Table fTab = new Table (9,9,false);
			for (int i = 0; i < 9; i++) 
			{
				lista.Add (new PlanszaGra(p_gra));
				fTab.Attach (lista [i].ustalony, (int)i % 3, (int)i % 3 + 1, (int)Math.Floor ((double)i / 3d),
					(int)Math.Floor ((double)i / 3d) + 1);
				pRamka = new Frame ();
				pRamka.Add (fTab);
			}
				


		}
	}
}

