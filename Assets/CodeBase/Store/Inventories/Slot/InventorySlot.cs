using CodeBase.Store.Entities;

namespace CodeBase.Store.Inventories.Slot
{
    public readonly struct InventorySlot
    {
        public readonly int Index;
        public readonly IEntity Entity; 

        public InventorySlot(int index)
        {
            Index = index;
            Entity = null;
        }

        public InventorySlot(IEntity entity, int index)
        {
            Index = index;
            Entity = entity;
        }
    }
}