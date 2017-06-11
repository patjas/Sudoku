using System;
using Gtk;
using System.Collections.Generic;

namespace Sudoku
{
	public class PlanszBox
	{
		public Frame m_ramka;
		public List<Plansza> lista = new List<Plansza>();
		PlanszaGra p_gra;
		public PlanszBox (PlanszaGra rodzic)
		{
			p_gra = rodzic;
			Table b_Tab = new Table (9, 9, false);
			for (int i = 0; i < 9; i++) {
				lista.Add(new Plansza(p_gra));
				b_Tab.Attach (lista [i].ustalony, (uint)i % 3, (uint)i % 3 + 1, (uint)Math.Floor ((double)i / 3d), (uint)Math.Floor ((double)i / 3d) + 1);
			}
			m_ramka= new Frame ();
			m_ramka.Add (b_Tab);
		}
	}
}

