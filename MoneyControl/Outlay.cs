using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl
{
    public class Outlay : Transaction
    {
        public Outlay(string name) : base(name)
        {
        }

        public override void AddTransactionValue(double value)
        {
            base.AddTransactionValue(value);
        }
        public override void AddTransactionValue(string value)
        {
            if (double.TryParse(value, out double tmpValue))
            {
                this.AddTransactionValue(tmpValue);
            }
            else
            {
                throw new Exception("Value is not valid.");
            }
        }
        public override void AddTransactionValue(float value)
        {
            this.AddTransactionValue((double)value);
        }
        public override void AddTransactionValue(int value)
        {
            this.AddTransactionValue((double)value);
        }
    }
}
