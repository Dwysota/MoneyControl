namespace MoneyControl
{
    public class GeneralStatistics
    {
        public StatisticsBase Income { get; private set; }
        public StatisticsBase Outlay { get; private set; }
        public int ProcentIncome
        {
            get
            {
                return (int)Income.Sum * 100 / this.Sum;
            }
        }
        public int ProcentOutlay
        {
            get
            {
                return (int)(Outlay.Sum * 100 / this.Sum);
            }
        }
        public int Sum
        {
            get
            {
                return (int)(Income.Sum + Outlay.Sum);
            }

        }
        public double Balance
        {
            get
            {
                return Income.Sum - Outlay.Sum;
            }
        }
        public GeneralStatistics(StatisticsBase income, StatisticsBase outlay)
        {
            Income = income;
            Outlay = outlay;
        }
        public void Update(StatisticsBase income, StatisticsBase outlay)
        {
            Income = income;
            Outlay = outlay;
        }



    }
}
