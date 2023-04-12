namespace MoneyControl
{
    public class GeneralStatistics
    {
        StatisticsBase Income;
        StatisticsBase Outlay;
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
