using System;
using Gtk;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public partial class PlanszaGra
	{	
		private int [,] zapis = new int[9,9];
		private bool gra_wystart=false;
		private Plansza wybrany;
		public List<PlanszBox> k_boxes = new List<PlanszBox> ();


		public PlanszaGra (Table pTab, int row, int col, int rowspan, int colspan)
		{
			AspectFrame m_ramka=AspectFrame("Sudoku", int, int, int);
			Table localtab=new Table(9,9,false);

		}
			

	
	}
}

