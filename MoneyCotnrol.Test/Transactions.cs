using MoneyControl;

namespace MoneyCotnrol.Test
{
    public class Transactions
    {

        [Test]
        public void WhenWeAddedNewIncomeWithValues_ShouldReturnNameSumMaxMin()
        {
            // arrange
            TransactionIncome transactionIncome1 = new TransactionIncome("Wyplata");
            TransactionIncome transactionIncome2 = new TransactionIncome("Premia");

            // act
            transactionIncome1.AddTransactionValue(500);
            transactionIncome1.AddTransactionValue(1000);
            transactionIncome2.AddTransactionValue(500);
            transactionIncome2.AddTransactionValue(1000);

            // assert
            Assert.AreEqual("Wyplata", transactionIncome1.Name);
            Assert.AreEqual(1500, transactionIncome1.getStatistic().Sum);
            Assert.AreEqual(1000, transactionIncome1.getStatistic().Max);
            Assert.AreEqual(500, transactionIncome1.getStatistic().Min);

            Assert.AreEqual("Premia", transactionIncome2.Name);
            Assert.AreEqual(1500, transactionIncome2.getStatistic().Sum);
            Assert.AreEqual(1000, transactionIncome2.getStatistic().Max);
            Assert.AreEqual(500, transactionIncome2.getStatistic().Min);
        }

        [Test]
        public void WhenWeAddedTwoTransaction_SchuldReturnSumMinMax()
        {
            // arrange
            ContainerIncome containerIncome = new ContainerIncome();
            // act
            if (containerIncome.CountItems == 0)
            {
                containerIncome.AddNewName("Wyplata");
                containerIncome.SetPosition(0);
                containerIncome.AddValue("1000", "Wyplata");
                containerIncome.AddValue("2000", "Wyplata");
                containerIncome.AddNewName("Premia");
                containerIncome.SetPosition(1);
                containerIncome.AddValue("500", "Premia");
                containerIncome.AddValue("1000", "Premia");
            }
            // assert
            Assert.AreEqual(4500, containerIncome.GetContainerStatistics().Sum);
            Assert.AreEqual(500, containerIncome.GetContainerStatistics().Min);
            Assert.AreEqual(2000, containerIncome.GetContainerStatistics().Max);


        }
    }

}