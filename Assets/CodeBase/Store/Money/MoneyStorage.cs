using System;

namespace CodeBase.Store.Money
{
    public class MoneyStorage : IMoneyStorage
    {
        public event Action<float> AmountChanged;

        public float Amount { get; private set; }

        public MoneyStorage(int startAmount)
        {
            Amount = startAmount;
        }

        public void Spend(float spendAmount)
        {
            Amount -= spendAmount;
            AmountChanged?.Invoke(Amount);
        }

        public void Take(float amount)
        {
            Amount += amount;
            AmountChanged?.Invoke(Amount);
        }
    }
}