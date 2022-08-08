using CodeBase.Store.Transactions;

namespace CodeBase.Store
{
    public class PurchaseService : IPurchaseService
    {
        public void PerformTransaction(Transaction transaction)
        {
            var sellerSlot = transaction.SellerInventorySlot;
            var buyerSlot = transaction.BuyerInventorySlot;
            var seller = transaction.Seller;
            var buyer = transaction.Buyer;

            if (!seller.CanSell(sellerSlot))
                return;

            if (!buyer.IsEmptySlot(buyerSlot))
                return;

            var itemCost = seller.ItemCost(sellerSlot);

            if (!buyer.CanSpend(itemCost))
                return;

            var item = seller.Sell(sellerSlot);
            buyer.Buy(buyerSlot, item, itemCost);

            return;
        }
    }
}