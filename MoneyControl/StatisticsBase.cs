using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MoneyControl
{
    public class StatisticsBase : IStatistics
    {
        public double Sum
        {
            get
            {
                if (values.Length == 0)
                {
                    return 0;
                }
                return values.Sum();
            }
        }
        public double Average
        {
            get
            {
                if (values.Length == 0)
                {
                    return 0;
                }
                return Math.Round(values.Average(),2);
            }
        }
        public double Min
        {
            get
            {
                if (values.Length == 0)
                {
                    return 0;
                }
                return values.Min();
            }
        }
        public double Max
        {
            get
            {
                if (values.Length == 0)
                {
                    return 0;
                }
                return values.Max();
            }
        }

        protected double[] values { get; private set; }
        public int count
        {
            get
            {
                return values.Length;
            }
        }
        public string Name { get; private set; }
        public StatisticsBase(string name, double[] values)
        {
            this.Name = name;
            this.values = values;
        }
        public StatisticsBase(double[] values)
        {
            this.values = values;
        }
        public StatisticsBase()
        {
            values = new double[0];
        }
        public StatisticsBase(double[] a, double[] b)
        {
            values = new double[a.Length + b.Length];
            Array.Copy(a, values, a.Length);
            Array.Copy(b, 0, values, a.Length, b.Length);
        }

        public static StatisticsBase operator +(StatisticsBase a, StatisticsBase b)
        {
            return new StatisticsBase(a.values, b.values);
        }
    }
}
