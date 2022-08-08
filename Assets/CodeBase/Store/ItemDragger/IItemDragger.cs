using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.Items;
using UnityEngine;

namespace CodeBase.Store.ItemDragger
{
    public interface IItemDragger
    {
        void Begin(ItemId itemId);
        void UpdatePosition(Vector2 position);
        void End();
    }
}