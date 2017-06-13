using Gtk;
using System;
using System.Collections.Generic;
using Pango;

namespace Sudoku
{
	public class Plansza
	{
		public EventBox ustalony;
		public int num = 0;
		public Frame s_ramka = new Frame();
		PlanszaGra p_gra;
		public bool set = true;
		private Table tab = new Table(9,9,false);
		private Label etykieta = new Label(" ");
		public Plansza (PlanszaGra rodzic)
		{
			p_gra = rodzic;
			ustalony = new EventBox();
			ustalony.ModifyBg (StateType.Normal, stan.nieaktywny);
			this.ustalony.Events |= Gdk.EventMask.ButtonPressMask;
			this.ustalony.ButtonPressEvent += fClicked;
			this.ustalony.BorderWidth = 0;
			this.ustalony.Add (s_ramka);
			this.s_ramka.Add (this.tab);
			this.aktualizuj ();
		}

		private void fClicked(System.Object obj, EventArgs args)
		{
			foreach (PlanszBox pb in p_gra.k_boxes) 
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
				this.ustalony.ModifyBg (StateType.Normal, stan.zabl_aktyw);
			p_gra.wybrany= this;
			foreach (PlanszBox pb in p_gra.k_boxes) 
			{
				foreach (Plansza pl in pb.lista) 
				{
					if (pl == this)
						continue;
					if (pl.num == this.num && num != 0)
						pl.ustalony.ModifyBg (StateType.Normal, stan.samenum);
				}
			}
		}

		public void aktualizuj()
		{
			if (this.set == false) 
			{
				
				this.etykieta.Text = this.num.ToString ();
				if (num == 0) 
				{
					this.etykieta.Text = " ";
				}
			} 
			else 
			{
				this.tab.SetSizeRequest (0, 0);

				this.ustalony.ModifyBg (StateType.Normal, stan.zablokowany);
				this.etykieta.Text = this.num.ToString ();
				if (num == 0)
					this.etykieta.Text = " ";
			}
			this.tab.Attach (this.etykieta, 1, 2, 1, 2);
		}
	}
}