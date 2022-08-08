using System.Collections.Generic;
using CodeBase.Store.Entities;
using CodeBase.Store.Infrastructure.Factories;
using CodeBase.Store.Infrastructure.Providers;
using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.ItemDragger;
using UnityEngine;

namespace CodeBase.Store.Inventories
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform _slotsContainer;
        
        private readonly List<InventorySlotView> _slotViews = new List<InventorySlotView>();

        private IInventory _inventory;
        private ISpriteProvider _spriteProvider;
        private IStoreService _storeService;
        private IViewFactory _viewFactory;
        private IEntity _entity;
        private IItemDragger _itemDragger;

        public void Construct(IEntity entity, ISpriteProvider spriteProvider, IViewFactory viewFactory,
            IStoreService storeService, IItemDragger itemDragger)
        {
            _entity = entity;
            _inventory = entity.Inventory;
            _spriteProvider = spriteProvider;
            _storeService = storeService;
            _viewFactory = viewFactory;
            _itemDragger = itemDragger;
            
            Fill(_inventory.Slots());
            
            _inventory.SlotChanged += ChangeSlot;
        }

        private void Fill(IEnumerable<InventorySlot> slots)
        {
            foreach (var slot in slots)
            {
                var slotView = _viewFactory.CreateSlot(container: _slotsContainer);
                slotView.Construct(slot, _spriteProvider, OnAttached, OnDragging, _entity, _inventory);
                _slotViews.Add(slotView);
            }
        }

        private void OnDragging(InventorySlot slot, DragState state, Vector2 position)
        {
            if (state == DragState.End)
            {
                _itemDragger.End();
                _slotViews[slot.Index].SetGray(isGray: false);
                return;
            }

            if (state == DragState.Begin)
            {
                _itemDragger.Begin(_inventory.GetId(slot));
                _slotViews[slot.Index].SetGray(isGray: true);
            }

            _itemDragger.UpdatePosition(position);
        }

        private void OnAttached(InventorySlot pointer, InventorySlot target)
        {
            if (pointer.Entity == target.Entity)
            {
                _storeService.Swap(pointer, target);
                return;
            }

            _storeService.PerformBuying(pointer, target);
        }

        private void OnDestroy()
        {
            _inventory.SlotChanged -= ChangeSlot;
        }

        private void ChangeSlot(InventorySlot slot) => 
            _slotViews[slot.Index].ChangeSlot(slot);
    }
}