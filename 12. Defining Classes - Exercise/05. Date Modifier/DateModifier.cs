using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public static class DateModifier
    {
		public static int GetDifferenceInDays(string firstDate, string secondDate)
		{
			DateTime startDate = DateTime.Parse(firstDate);
			DateTime endDate = DateTime.Parse(secondDate);

			TimeSpan difference = endDate - startDate;

			return Math.Abs(difference.Days);
		}
	}
}