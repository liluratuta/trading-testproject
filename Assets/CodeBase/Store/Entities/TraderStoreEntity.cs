using CodeBase.Store.Inventories;
using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.Items;

namespace CodeBase.Store.Entities
{
    public class TraderStoreEntity : IEntity
    {
        public IInventory Inventory => _inventory;
    
        private readonly IInventory _inventory;
        private readonly float _costMultiplier;

        public TraderStoreEntity(IInventory inventory, float costMultiplier)
        {
            _inventory = inventory;
            _costMultiplier = costMultiplier;
        }

        public bool IsEmptySlot(InventorySlot slot) => 
            _inventory.IsEmptySlot(slot);

        public bool CanSpend(float moneyAmount) => 
            true;

        public void Buy(InventorySlot slot, Item item, float moneyAmount) => 
            _inventory.SetItem(slot, item);

        public bool CanSell(InventorySlot slot) => 
            !_inventory.IsEmptySlot(slot);

        public Item Sell(InventorySlot slot)
        {
            var item = _inventory.GetItem(slot);
            _inventory.Remove(slot);
            return item;
        }

        public float ItemCost(InventorySlot slot)
        {
            var item = _inventory.GetItem(slot);
            return item.Cost * _costMultiplier;
        }
    }
}