using System;
using System.Collections.Generic;

namespace SueLordFromFamily
{
	// Token: 0x02000006 RID: 6
	internal class RandomUtils
	{
		// Token: 0x06000013 RID: 19 RVA: 0x000024C4 File Offset: 0x000006C4
		public static  List<int> RandomNumbers(int n, int min, int max, List<int> excludes)
		{
			List<int> list = new List<int>();
			long ticks = DateTime.Now.Ticks;
			Random random = new Random((int)(ticks & (long)((long)-1)) | (int)(ticks >> 32));
			while (list.Count != n)
			{
				int item = random.Next(min, max);
				bool flag = !list.Contains(item) && !excludes.Contains(item);
				if (flag)
				{
					list.Add(item);
				}
			}
			list.Sort();
			return list;
		}
	}
}
