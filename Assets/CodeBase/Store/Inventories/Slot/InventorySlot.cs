using CodeBase.Store.Entities;
using CodeBase.Store.Items;

namespace CodeBase.Store.Inventories.Slot
{
    public readonly struct InventorySlot
    {
        public readonly int Index;
        public readonly ItemId Id;
        public readonly IEntity Entity; 

        public InventorySlot(ItemId id, int index)
        {
            Id = id;
            Index = index;
            Entity = null;
        }

        public InventorySlot(IEntity entity, ItemId id, int index)
        {
            Id = id;
            Index = index;
            Entity = entity;
        }
    }
}