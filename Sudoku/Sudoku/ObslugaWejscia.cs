using System;

namespace Sudoku
{
	public class ObslugaWejscia
	{
		static PlanszaGra pl_akt;

		public static void ustaw_cel(PlanszaGra s)
		{
			pl_akt = s;
		}
		public static void ustaw_liczba(Object obj, EventArgs args, int liczba)
		{
			
			pl_akt.ustaw_pole (liczba);

			int a, b;

			for ( int i = 0; i < 9; i++)
			{	for ( int j = 0; j < 9; j++) 
				{	
					bool m=pl_akt.k_boxes[i].lista[j].Equals(pl_akt.wybrany.ustalony);
					if (m==false)
					{
						for(int k=0;k<9;k++)
						{
							if (pl_akt.wybrany.num == pl_akt.k_boxes [k].lista [i].num)
								pl_akt.wybrany.ustalony.ModifyBg (Gtk.StateType.Normal, stan.samenum);
						}
					}
				}
			}




			/*for (int i = 0; i < 9; i++)
			{	for (int j = 0; j < 9; j++) 
				{	string ciagWiersz = pl_akt.k_boxes[i].lista.ToString();
					
					for (int k=1; k < ciagWiersz.Length; k++)
					{
						if (ciagWiersz[i] <= ciagWiersz[i-1])
						{
							pl_akt.wybrany.ustalony.ModifyBg (Gtk.StateType.Normal, stan.samenum);
						}
					}

				}
			}*/
		}
	}
}