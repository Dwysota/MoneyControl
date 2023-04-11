namespace MoneyControl
{
    internal interface IStatistics
    {
        double Sum { get; }
        double Average { get; }
        double Min { get; }
        double Max { get; }

    }
}
