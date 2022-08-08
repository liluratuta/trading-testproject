using System;
using CodeBase.Store.Entities;
using CodeBase.Store.Infrastructure.Providers;
using CodeBase.Store.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.Store.Inventories.Slot
{
    public class InventorySlotView : MonoBehaviour, IDropHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public InventorySlot Slot => _slot;
        
        [SerializeField] private Image _itemIcon;
        [SerializeField] private TMP_Text _costField;

        private ISpriteProvider _spriteProvider;
        private Action<InventorySlot, InventorySlot> _onAttached;
        private Action<InventorySlot, DragState, Vector2> _onDragging;
        private InventorySlot _slot;
        private IEntity _entity;
        private IInventory _inventory;
        private bool _isDraggable;

        public void Construct(InventorySlot slot, ISpriteProvider spriteProvider,
            Action<InventorySlot, InventorySlot> onAttached,
            Action<InventorySlot, DragState, Vector2> onDragging, IEntity entity, IInventory inventory)
        {
            _entity = entity;
            _spriteProvider = spriteProvider;
            _onAttached = onAttached;
            _onDragging = onDragging;
            _inventory = inventory;
            ChangeSlot(slot);
        }

        public void ChangeSlot(InventorySlot slot)
        {
            _slot = new InventorySlot(_entity, slot.Index);
            var itemId = _inventory.GetId(slot);
            _itemIcon.sprite = _spriteProvider.ForItem(itemId);
            _isDraggable = itemId != ItemId.None;

            _costField.text = itemId != ItemId.None ? 
                _entity.ItemCost(slot).ToString("F2") : "";
        }

        public void SetGray(bool isGray) => 
            _itemIcon.color = isGray ? Color.gray : Color.white;

        public void OnDrop(PointerEventData eventData) => 
            _onAttached.Invoke(eventData.pointerDrag.GetComponent<InventorySlotView>().Slot, _slot);

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_isDraggable)
                _onDragging.Invoke(_slot, DragState.Begin, eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isDraggable)
                _onDragging.Invoke(_slot, DragState.InProcess, eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _onDragging.Invoke(_slot, DragState.End, eventData.position);
        }
    }
}