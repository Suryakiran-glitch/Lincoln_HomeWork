using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SwEngHomework.DescriptiveStatistics
{
    public class StatsCalculator : IStatsCalculator
    {
        public Stats Calculate(string semicolonDelimitedContributions)
        {
            var stats = new Stats();
            string res;

            string str = semicolonDelimitedContributions.Replace(" ", "");
            Regex reg = new Regex("[$]");
            res = reg.Replace(str, string.Empty);

            if (!string.IsNullOrEmpty(semicolonDelimitedContributions))
            {
               
                List<string> dec1 = res.Split(';').ToList();
                double n1;
                List<double> dec = new List<double>();
                foreach (var item in dec1)
                {
                   
                    bool isNumeric = double.TryParse(item, out n1);
                    if (isNumeric) dec.Add(Convert.ToDouble(item));
                }
               
                int n = dec.Count;

                if (n > 0)
                {
                    stats.Average = Math.Round(dec.Average(), 2);

                    stats.Median = Math.Round(GetMedian(dec.ToArray()), 2);
                    double max = getMaxValue(dec, n);
                    double min = getMinValue(dec, n);
                    double range = max - min;
                    stats.Range = Math.Round(range, 2);
                }
                else
                {
                    stats.Average = 0;
                    stats.Median = 0;
                    stats.Range = 0;
                }
            }
            else
            {
                stats.Average = 0;
                stats.Median = 0;
                stats.Range = 0;
            }
            return stats;

        }
       
        public static double GetMedian(double[] arr)
        {
           
            double[] arrSorted = (double[])arr.Clone();
            Array.Sort(arrSorted);

            int size = arrSorted.Length;
            int mid = size / 2;

            if (size % 2 != 0)
                return (double)arrSorted[mid];

            dynamic value1 = arrSorted[mid];
            dynamic value2 = arrSorted[mid - 1];
            return (double)(value1 + value2) / 2;
        }
        
        static double getMinValue(List<double> arr, int n)
        {
            double res = arr[0];
            for (int i = 1; i < n; i++)
                res = Math.Min(res, arr[i]);
            return res;
        }

        static double getMaxValue(List<double> arr, int n)
        {
            double res = arr[0];
            for (int i = 1; i < n; i++)
                res = Math.Max(res, arr[i]);
            return res;
        }
    }
}
