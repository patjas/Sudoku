using System;
using Gtk;
using Pango;
using System.Collections.Generic;

namespace Sudoku
{
	public partial class Plansza
	{	public int num=0;
		private bool[] czysc=new bool[9];
		public EventBox ustalony;
		public Frame s_ramka=new Frame();
		PlanszaGra r_gra;
		public bool set=true;
		private Table tab = new Table(9,9,false);
		private Label G_Etykieta;

		public Plansza (PlanszaGra rodzic)
		{
			Array.Clear (czysc, 0, czysc.Length);
			r_gra = rodzic;
			ustalony = new EventBox ();
			this.ustalony.Events |= Gdk.EventMask.ButtonPressMask;
			this.ustalony.ButtonPressEvent += klikniete;
			this.ustalony.BorderWidth = 0;
			this.ustalony.Add (s_ramka);
			this.ustalony.Add (this.tab);

		}

		private void klikniete(System.Object obj, EventArgs args)
		{
			foreach (PlanszBox pb in r_gra.k_boxes) 
			{
				foreach (Plansza pl in pb.lista)
				{
					if (pl.set == false)
						pl.ustalony.ModifyBg (StateType.Normal, stan.nieaktywny);
					else
						pl.ustalony.ModifyBg (StateType.Normal, stan.zablokowany);
				}
			}
			if (this.set == false)
				this.ustalony.ModifyBg (StateType.Normal, stan.aktywny);
			else
				this.ustalony.ModifyBg (StateType.Normal, stan.aktyw_zabl);

			r_gra.wybrany = this;
			foreach (PlanszBox pb in r_gra.k_boxes) 
			{	
				foreach (Plansza p in pb.lista) 
				{
					if (p == this)
						continue;
					if (p.num == this.num && num != 0)
						p.ustalony.ModifyBg (StateType.Normal, stan.samenum);
				}
			}
		}


	}
}

