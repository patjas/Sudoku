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