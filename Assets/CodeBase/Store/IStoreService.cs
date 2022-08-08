using CodeBase.Store.Infrastructure.Services;
using CodeBase.Store.Inventories;
using CodeBase.Store.Inventories.Slot;

namespace CodeBase.Store
{
    public interface IStoreService : IService
    {
        void Swap(InventorySlot firstSlot, InventorySlot secondSlot);
        void PerformBuying(InventorySlot sellerSlot, InventorySlot buyerSlot);
    }
}