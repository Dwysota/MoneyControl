namespace MoneyControl
{

    public interface IContainerTransaction
    {
        void loadData();
        string ShowList();
        string ShowListValues();
        void AddNewName(string name);
        void AddValue(string value, string name);
        void SetPosition(string position);
        string getActiveName();
    }
}
