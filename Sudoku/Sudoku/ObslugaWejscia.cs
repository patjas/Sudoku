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
		}
	}
}