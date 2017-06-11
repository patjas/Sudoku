using System;

namespace Sudoku
{
	public static  class Met_gener
	{
		public static void GenerujPodst(int [,] area)
		{
			for (int i = 0; i < 9; i++) 
			{
				for (int j = 0; j < 9; j++) 
				{
					if (j + i + 1<= 9)
						area [(int)Math.Floor(i/3d)+ i % 3 * 3, j] = j + 1 + i;
					else
						area [(int)Math.Floor(i/3d)+ i % 3 * 3, j] = j + 1 + i - 9;
				}
			}
		}
		public static void ZamienWiersz(int [,] area, int start, int koniec){
			for (int i = 0; i < 9; i++) 
			{
				int tmp;
				tmp = area [koniec * 3, i];
				area [koniec * 3, i] = area [start * 3, i];
				area [start * 3, i] = tmp;
				tmp = area [koniec * 3+1, i];
				area [koniec* 3+1, i] = area [start * 3+1, i];
				area [start * 3+1, i] = tmp;
				tmp = area [koniec * 3+2, i];
				area [koniec * 3+2, i] = area [start * 3+2, i];
				area [start * 3+2, i] = tmp;
			}
		}

		public static void ZamienKol(int [,] area, int blok, int start, int koniec)
		{
			for (int i = 0; i < 3; i++) 
			{
				int tmp;
				tmp = area [blok * 3, koniec* 3+i];
				area [blok * 3, koniec * 3+i] = area [blok * 3, start * 3+i];
				area [blok * 3, start * 3+i] = tmp;
				tmp = area [blok * 3 + 1, koniec * 3+i];
				area [blok * 3 + 1, koniec * 3+i] = area [blok * 3 + 1, start * 3+i];
				area [blok * 3 + 1, start * 3+i] = tmp;
				tmp = area [blok * 3 + 2, koniec * 3+i];
				area [blok * 3 + 2, koniec * 3+i] = area [blok * 3 + 2, start * 3+i];
				area [blok * 3 + 2, start * 3+i] = tmp;
			}
		}
	}
}