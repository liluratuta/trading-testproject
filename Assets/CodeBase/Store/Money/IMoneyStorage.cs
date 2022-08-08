using System;

namespace CodeBase.Store.Money
{
    public interface IMoneyStorage
    {
        event Action<float> AmountChanged;
        float Amount { get; }
        void Spend(float spendAmount);
        void Take(float amount);
    }
}