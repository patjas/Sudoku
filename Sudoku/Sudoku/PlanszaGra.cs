﻿using System;
using Gtk;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public partial class PlanszaGra: Met_gener 
	{	
		private int [,] zapis = new int[9,9];
		private bool gra_wystart=false;
		private Plansza wybrany;
		public List<PlanszBox> k_boxes = new List<PlanszBox> ();


		public PlanszaGra (Table pTab, int row, int col, int rowspan, int colspan)
		{
			AspectFrame m_ramka=AspectFrame("Sudoku",0,0,1,false);
			Table localtab=new Table(9,9,false);
			m_ramka.Add (localtab);
			localtab.Attach (m_ramka, col, col + colspan, row, row + rowspan);

			for (int i; i < 9; i++) 
			{	
				k_boxes.Add (new PlanszBox (this));
				localtab.Attach (k_boxes [i].p_ramka, (int)i % 3, (int)i % 3 + 1, (int)((double)i / 3d), 
					(int)((double)i / 3d) + 1);
				
			}
		}
			
		private void ustaw_pole (int n)
		{
			if (wybrany == null)
				return;
			if (wybrany.set == false) 
			{
				if (wybrany.num != n)
					wybrany.num = n;
				else
					wybrany.num = 0;
			}
		}

		private void aktualizuj_wszystko(object obj, EventArgs args)
		{
			foreach (PlanszBox pb in k_boxes) 
			{
				foreach (Plansza pl in pb.lista) {
					pl.update ();
				}
			}
		}

		private void aktualizuj_wszystko()
		{
			foreach (PlanszBox pb in k_boxes) 
			{
				foreach (Plansza pl in pb.lista) 
				{
					pl.update ();
				}
		
			}
		}

		private void generuj(int ukryte)
		{
			int[,] area = new int[9, 9];
			Random rand = new Random ();
			Met_gener.GenerujPodst (area);

			for (int i = 0; i < 50; i++) 
			{
				int r = rand.Next (1, 2);

				switch (r) {
				case 1:
					Met_gener.ZamienWiersz (area, rand.Next (0, 3), rand.Next (0, 3), rand.Next (0, 3));
				case 2:
					Met_gener.ZamienKol (area, rand.Next (0, 3), rand.Next (0, 3), rand.Next (0, 3));
				}
			}

			for (int i = 0; i < 9; i++) 
			{
				for (int j = 0; j < 9; j++) 
				{
					this.k_boxes [i].lista [j].num = area [i, j];
					this.k_boxes [i].lista [j].set = true;
				}
			}

			zapis = area;

			while (ukryte > 0) 
			{
				int w=rand.Next(0,9);
				int f=rand.Next(0,9);

				if(k_boxes[w].lista[f].set=true)
				{
						k_boxes[w].lista[f].set=false;
						k_boxes[w].lista[f].num=0;
						ukryte--;
				}
			}

			aktualizuj_wszystko ();

			foreach (PlanszBox pb in this.k_boxes)
				foreach (Plansza pl in pb.lista)
					if (pl.set = false)
						pl.ustalony.ModifyBg (StateType.Normal, stan.nieaktywny);
			gra_wystart = true;

		}
	}
}
