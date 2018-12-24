using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitySelection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> start  = new List<int> { 8, 3, 0, 5, 1, 5 };
            List<int> finish = new List<int> { 9, 4, 6, 9, 2, 7 };

            List<List<int>> intervals = new List<List<int>> { };

            for (int i = 0; i < start.Count; i++)
            {
                intervals.Add(new List<int> { start[i], finish[i]});
            }

            List<List<int>> result = FindActivities(intervals);
        }

        static List<List<int>> FindActivities(List<List<int>> intervals)
        {
			List<List<int>> result = new List<List<int>> { };

            intervals.Sort((a, b) => (a[1].CompareTo(b[1])));
            result.Add(intervals[0]);

            for (int i = 1; i < intervals.Count; i++)
            {
                while (result.Last()[1] > intervals[i][0])
                {
                    i++;
                    if (i >= intervals.Count)
                        return result;
                }
                result.Add(intervals[i]);
            }

            return result;
        }
    }
}
