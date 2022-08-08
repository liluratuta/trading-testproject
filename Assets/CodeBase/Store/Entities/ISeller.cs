using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.Items;

namespace CodeBase.Store.Entities
{
    public interface ISeller
    {
        bool CanSell(InventorySlot slot);
        Item Sell(InventorySlot slot);
        float ItemCost(InventorySlot slot);
    }
}