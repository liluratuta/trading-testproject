using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.Items;

namespace CodeBase.Store.Entities
{
    public interface IBuyer
    {
        bool IsEmptySlot(InventorySlot slot);
        bool CanSpend(float moneyAmount);
        void Buy(InventorySlot slot, Item item, float moneyAmount);
    }
}