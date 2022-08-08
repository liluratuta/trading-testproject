using CodeBase.Store.Entities;
using CodeBase.Store.Infrastructure;
using CodeBase.Store.Infrastructure.Providers;
using CodeBase.Store.Inventories;
using CodeBase.Store.Inventories.Slot;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Store.Items
{
    public class DraggingItemView : MonoBehaviour
    {
        [SerializeField] private Image _itemIcon;
        
        private RectTransform _rectTransform;
        private ISpriteProvider _spriteProvider;

        public void Construct(ISpriteProvider spriteProvider)
        {
            _spriteProvider = spriteProvider;
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Show(InventorySlot inventorySlot, ISeller seller)
        {
            _itemIcon.sprite = _spriteProvider.ForItem(inventorySlot.Id);
            gameObject.SetActive(true);
        }

        public void Hide() =>
            gameObject.SetActive(false);

        public void SetPosition(Vector2 position)
        {
            _rectTransform.position = position;
        }
    }
}
