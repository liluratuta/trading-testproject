using CodeBase.Store.Entities;
using CodeBase.Store.Inventories.Slot;
using UnityEngine;

namespace CodeBase.Store.ItemDragger
{
    public interface IItemDragger
    {
        void Begin(InventorySlot slot, ISeller seller);
        void UpdatePosition(Vector2 position);
        void End();
    }
}