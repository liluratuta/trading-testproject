using CodeBase.Store.Inventories;
using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.Transactions;

namespace CodeBase.Store
{
    public class StoreService : IStoreService
    {
        private readonly IPurchaseService _purchaseService;

        public StoreService(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public void Swap(InventorySlot firstSlot, InventorySlot secondSlot) => 
            firstSlot.Entity.Inventory.Swap(firstSlot, secondSlot);

        public void PerformBuying(InventorySlot sellerSlot, InventorySlot buyerSlot)
        {
            var transaction = new Transaction(sellerSlot, buyerSlot);
            _purchaseService.PerformTransaction(transaction);
        }
    }
}