namespace MoneyControl
{
    public class ContainerStatistics : StatisticsBase
    {
        StatisticsBase[] statisticsTransactions;
        public ContainerStatistics(): base()
        {
            
        }

        public ContainerStatistics(List<TransactionIncome> transactions)
        {
            int i = 0;
            statisticsTransactions = new StatisticsBase[transactions.Count];
            foreach (var transaction in transactions)
            {
                statisticsTransactions[i] = new StatisticsBase(transaction.Name, transaction.values.ToArray());
                i++;
            }
        }
        public ContainerStatistics(List<TransactionOutlay> transactions)
        {
            int i = 0;
            statisticsTransactions = new StatisticsBase[transactions.Count];
            foreach (var transaction in transactions)
            {
                statisticsTransactions[i] = new StatisticsBase(transaction.Name, transaction.values.ToArray());
                i++;
            }
        }

        public StatisticsBase getContainerStatistics()
        {
            StatisticsBase containerStatistics = new StatisticsBase();
            for(int i = 0; i < statisticsTransactions.Length; i++) {
                containerStatistics = containerStatistics + statisticsTransactions[i]; 
            }
            return containerStatistics;
        }
    }
}
