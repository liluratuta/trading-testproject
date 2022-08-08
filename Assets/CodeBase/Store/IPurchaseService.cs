using CodeBase.Store.Infrastructure.Services;
using CodeBase.Store.Transactions;

namespace CodeBase.Store
{
    public interface IPurchaseService : IService
    {
        void PerformTransaction(Transaction transaction);
    }
}