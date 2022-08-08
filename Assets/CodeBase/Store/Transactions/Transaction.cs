using CodeBase.Store.Entities;
using CodeBase.Store.Inventories;
using CodeBase.Store.Inventories.Slot;

namespace CodeBase.Store.Transactions
{
    public readonly struct Transaction
    {
        public readonly ISeller Seller;
        public readonly IBuyer Buyer;
        public readonly InventorySlot SellerInventorySlot;
        public readonly InventorySlot BuyerInventorySlot;

        public Transaction(InventorySlot sellerSlot, InventorySlot buyerSlot)
        {
            BuyerInventorySlot = buyerSlot;
            SellerInventorySlot = sellerSlot;
            Seller = sellerSlot.Entity;
            Buyer = buyerSlot.Entity;
        }
    }
}