using System;

namespace Sudoku
{
	public class ObslugaWejscia
	{	
		static PlanszaGra G_aktual;

		private static void ustawG_cel (PlanszaGra s)
		{ 
			G_aktual=s;
		}

		public static void ustawLiczba(Object obj, EventArgs args, int wybr_lic, string typ)
		{
				G_aktual.ustaw_pole (wybr_lic);
		}

	}
}

