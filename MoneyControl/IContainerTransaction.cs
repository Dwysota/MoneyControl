namespace MoneyControl
{

    public interface IContainerTransaction
    {
        string ShowList();
        string ShowListValues();
        void AddNewName(string name);
        void AddValue(string value, string name);
        void SetPosition(string position);
        string GetActiveName();
        StatisticsBase GetContainerStatistics();
    }
}
