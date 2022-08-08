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
        
        public void Begin(ItemId itemId) => 
            _itemView.Show(itemId);

        public void UpdatePosition(Vector2 position) => 
            _itemView.SetPosition(position);

        public void End() => 
            _itemView.Hide();
    }
}