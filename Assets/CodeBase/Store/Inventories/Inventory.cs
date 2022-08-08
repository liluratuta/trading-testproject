using System;
using System.Collections.Generic;
using CodeBase.Store.Infrastructure.Factories;
using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.Items;

namespace CodeBase.Store.Inventories
{
    public class Inventory : IInventory
    {
        public event Action<InventorySlot> SlotChanged;
        
        private readonly IItemFactory _itemFactory;
        private readonly List<Item> _items;
        private int Size => _items.Count;

        public Inventory(int size, IItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
            _items = new List<Item>(size);

            for (var i = 0; i < size; i++) 
                _items.Add(_itemFactory.Create(ItemId.None));
        }

        public IEnumerable<InventorySlot> Slots()
        {
            var slots = new List<InventorySlot>(Size);

            for (var i = 0; i < Size; i++)
                slots.Add(MakeInventorySlot(_items[i], i));

            return slots;
        }

        public void SetItem(ItemId id, int index)
        {
            _items[index] = _itemFactory.Create(id);
            var newSlot = new InventorySlot(index);
            SlotChanged?.Invoke(newSlot);
        }
        
        public void SetItem(InventorySlot slot, Item item)
        {
            _items[slot.Index] = item;
            var newSlot = new InventorySlot(slot.Index);
            SlotChanged?.Invoke(newSlot);
        }

        public Item GetItem(InventorySlot slot) => 
            _items[slot.Index];

        public bool IsEmptySlot(InventorySlot slot) =>
            GetId(slot) == ItemId.None;

        public ItemId GetId(InventorySlot slot) => 
            _items[slot.Index].Id;

        public void Remove(InventorySlot slot)
        {
            _items[slot.Index] = _itemFactory.Create(ItemId.None);
            var newSlot = new InventorySlot(slot.Index);
            SlotChanged?.Invoke(newSlot);
        }

        public void Swap(InventorySlot firstSlot, InventorySlot secondSlot)
        {
            var firstItem = _items[firstSlot.Index];
            var secondItem = _items[secondSlot.Index];

            _items[secondSlot.Index] = firstItem;
            SlotChanged?.Invoke(new InventorySlot(secondSlot.Index));

            _items[firstSlot.Index] = secondItem;
            SlotChanged?.Invoke(new InventorySlot(firstSlot.Index));
        }

        private static InventorySlot MakeInventorySlot(Item item, int index) => 
            new InventorySlot(index);
    }
}