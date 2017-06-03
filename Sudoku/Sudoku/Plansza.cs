using System;
using Gtk;
using Pango;
using System.Collections.Generic;

namespace Sudoku
{
	public partial class Plansza : Gtk.Window
	{	private int num=0;
		private bool czysc=new bool[9];
		public EventBox ustalony;
		public Frame ramka=new Frame();
		PlanszaGra r_gra;
		public bool set=true;
		private Table tab = new Table(9,9,false);

		public Plansza (PlanszaGra rodzic)
		{
			Array.Clear (czysc, 0, czysc.length);
			p_gra = rodzic;
			ustalony = new EventBox ();
			this.ustalony.Events |= Gdk.EventMask.ButtonPressMask;
			this.ustalony.ButtonPressEvent += klikniete;
			this.ustalony.BorderWidth = 0;
			this.ustalony.Add (ramka);
			this.ustalony.Add (this.tab);
			this.aktualizuj ();
		}

		private void klikniete(System.Object obj, EventArgs args)
		{
			foreach (planszbox pb in p_gra.k_boxes) {
				foreach (Plansza pl in pb.lista) {
					if (f.set == false)
						f.ustalony.ModifyBg (StateType.Normal, Globals.nieaktywny);
					else
						f.ustalony.ModifyBg (StateType.Normal, Globals.zablokowany);
				}
			}
			if (this.set == false)
				this.ustalony.ModifyBg (StateType.Normal, Globals.aktywny);
			else
				this.ustalony.ModifyBg (StateType.Normal, Globals.aktyw_zabl);

			p_gra.wybrany = this;
			foreach (Planszbox pb in p_gra.k_boxes) {	
				foreach (Plansza p in pb.lista) {
					if (p == this)
						continue;
					if (p.num == this.num && num != 0)
						p.ustalony.ModifyBg (StateType.Normal, Globals.samenum);
				}
			}
		}
		private void aktualizuj()
		{
			int h=this.ramka.Allocation.Height;
			if (this.set = false) 
			{
				if (true) 
				{
					Pango.FontDescription fd = new FontDescription ();
					fd.Size = Convert.ToInt32 (h * 0.2 * Pango.Scale.PangoScale);
					this.tab.SetSizeRequest (0, 0);

				}
			}

		}
			
	}
}

