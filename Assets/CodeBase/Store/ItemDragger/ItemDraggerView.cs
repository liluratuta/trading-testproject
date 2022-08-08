using CodeBase.Store.Entities;
using CodeBase.Store.Infrastructure.Providers;
using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.Items;
using UnityEngine;

namespace CodeBase.Store.ItemDragger
{
    public class ItemDraggerView : MonoBehaviour, IItemDragger
    {
        [SerializeField] private DraggingItemView _itemView;
        
        public void Construct(ISpriteProvider spriteProvider)
        {
            _itemView.Construct(spriteProvider);
        }
        
        public void Begin(InventorySlot slot, ISeller seller) => 
            _itemView.Show(slot, seller);

        public void UpdatePosition(Vector2 position) => 
            _itemView.SetPosition(position);

        public void End() => 
            _itemView.Hide();
    }
}