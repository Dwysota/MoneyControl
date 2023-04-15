namespace MoneyControl
{

    public interface IContainerTransaction
    {
        int CountItems { get; }
        string ShowList();
        string ShowListValues();
        bool AddNewName(string name);
        void AddValue(string value, string name);
        /// <summary>
        /// Parameter position must be greater than 0
        /// </summary>
        /// <param name="position"></param>
        void SetPosition(string position);
        /// <summary>
        /// Parameter position must be greater than -1
        /// </summary>
        /// <param name="position"></param>
        void SetPosition(int position);
        string GetActiveName();
        StatisticsBase GetContainerStatistics();
    }
}
