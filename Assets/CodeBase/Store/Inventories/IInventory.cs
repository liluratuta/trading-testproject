using System;
using System.Collections.Generic;
using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.Items;

namespace CodeBase.Store.Inventories
{
    public interface IInventory
    {
        event Action<InventorySlot> SlotChanged;
        IEnumerable<InventorySlot> Slots();
        void SetItem(InventorySlot slot, Item item);
        Item GetItem(InventorySlot slot);
        bool IsEmptySlot(InventorySlot slot);
        void Remove(InventorySlot slot);
        void Swap(InventorySlot firstSlot, InventorySlot secondSlot);
    }
}