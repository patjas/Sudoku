﻿using System;
using Gtk;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public class PlanszaGra
	{
		public int [,]save = new int[9,9];	
		public bool gamestarted =false;
		public Plansza wybrany;	
		public List<PlanszBox> k_boxes = new List<PlanszBox> ();
		public PlanszaGra (Table p_table, uint row, uint col, uint rowspan, uint colspan)
		{	
			AspectFrame m_frame = new AspectFrame ("Sudoku", 0, 0, 1, false);
			Table localtable = new Table(9, 9, false);
			m_frame.Add (localtable);
			p_table.Attach (m_frame, col, col + colspan, row, row + rowspan);
			for (int i = 0; i < 9; i++) 
			{
				k_boxes.Add(new PlanszBox(this));
				localtable.Attach(k_boxes[i].m_ramka, (uint)i % 3, (uint)i % 3 + 1, (uint)Math.Floor ((double)i / 3d), (uint)Math.Floor ((double)i / 3d) + 1);
			}
		}

		public void ustaw_pole(int n)
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
			wybrany.aktualizuj ();
		}

		public void aktualizuj_wszystko(object obj, EventArgs args)
		{
			foreach(PlanszBox pb in k_boxes)
			{
				foreach(Plansza f in pb.lista)
				{
					f.aktualizuj ();
				}
			}
		}

		public void aktualizuj_wszystko()
		{
			foreach(PlanszBox pb in k_boxes)
			{
				foreach(Plansza f in pb.lista)
				{
					f.aktualizuj ();
				}
			}
		}
			
		public void generuj(int ukryte){
			int[,] area = new int[9, 9];
			Random rand = new Random ();
			Met_gener.GenerujPodst (area);
			for (int i = 0; i < 16; i++) 
			{
				int r = rand.Next (1, 3);
				switch (r) 
				{
				case 1:
					Met_gener.ZamienKol(area, rand.Next(0,3), rand.Next(0,3), rand.Next(0,3));
					break;
				case 2:
					Met_gener.ZamienWiersz(area, rand.Next(0,3), rand.Next(0,3));
					break;
				}

			}

			for (int i = 0; i < 9; i++)
				for (int j = 0; j < 9; j++) {
					this.k_boxes [i].lista [j].num = area [i, j];
					this.k_boxes [i].lista [j].set = true;
				}

			save = area;

			while (ukryte > 0) {
				int w = rand.Next (0, 9);
				int f = rand.Next (0, 9);
				if (this.k_boxes [w].lista [f].set == true) {
					this.k_boxes [w].lista [f].set = false;
					this.k_boxes [w].lista [f].num = 0;
					ukryte--;
				}
			}

			aktualizuj_wszystko ();

			foreach(PlanszBox pb in this.k_boxes)
				foreach(Plansza pl in pb.lista)
					if(pl.set == false)
						pl.ustalony.ModifyBg(StateType.Normal, stan.nieaktywny);
			gamestarted = true;
		}
	}
}

