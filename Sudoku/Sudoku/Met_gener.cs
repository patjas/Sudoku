using System;

namespace Sudoku
{
	public static partial class Met_gener
	{
		public static void GenerujPodst ( int[,] area )
		{
			for (int i = 0; i < 9; i++) 
			{	for (int j = 0; j < 9; i++) 
				{
					if (i + j + 1 < 10)
						area [(int)Math.Floor (i /3d) + i % 3 * 3, j] = i + j + 1;
					else
						area [(int)Math.Floor (i /3d) + i % 3 * 3, j] = (i + j + 1)%9;
				}
			}
		}

		public static void ZamienWiersz(int [,] area, int start, int end)
		{
			
				for (int i = 0; i < 9; i++) 
				{
					int tmp;
					tmp = area [end * 3, i];
					area [end * 3, i] = area [start * 3, i];
					area [start * 3, i] = tmp;
					tmp = area [end * 3+1, i];
					area [end * 3+1, i] = area [start * 3+1, i];
					area [start * 3+1, i] = tmp;
					tmp = area [end * 3+2, i];
					area [end * 3+2, i] = area [start * 3+2, i];
					area [start * 3+2, i] = tmp;
				}

		}

		public static void ZamienKol(int [,] area, int box, int start, int end)
		{for(int i=0;i<9;i++)
			{
				int tmp;
				tmp = area [box * 3, end*3+i];
				area [box * 3, end * 3 + i] = area [box * 3, start * 3 + i];
				area [box * 3, start * 3 + i] = tmp;
				tmp = area [box * 3+1, end*3+i];
				area [box * 3+1, end * 3 + i] = area [box * 3+1, start * 3 + i];
				area [box * 3+1, start * 3 + i] = tmp;
				tmp = area [box * 3+2, end*3+i];
				area [box * 3+2, end * 3 + i] = area [box * 3+2, start * 3 + i];
				area [box * 3+2, start * 3 + i] = tmp;
			}
		}
	}
}

