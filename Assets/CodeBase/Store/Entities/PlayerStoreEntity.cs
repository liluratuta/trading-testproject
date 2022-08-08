using CodeBase.Store.Inventories;
using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.Items;
using CodeBase.Store.Money;

namespace CodeBase.Store.Entities
{
    public class PlayerStoreEntity : IEntity
    {
        public IInventory Inventory => _inventory;
        
        private readonly IInventory _inventory;
        private readonly IMoneyStorage _moneyStorage;

        public PlayerStoreEntity(IInventory inventory, IMoneyStorage moneyStorage)
        {
            _inventory = inventory;
            _moneyStorage = moneyStorage;
        }

        public bool IsEmptySlot(InventorySlot slot) => 
            _inventory.IsEmptySlot(slot);

        public bool CanSpend(float moneyAmount) => 
            _moneyStorage.Amount >= moneyAmount;

        public void Buy(InventorySlot slot, Item item, float moneyAmount)
        {
            _moneyStorage.Spend(moneyAmount);
            _inventory.SetItem(slot, item);
        }

        public bool CanSell(InventorySlot slot) => 
            !_inventory.IsEmptySlot(slot);

        public Item Sell(InventorySlot slot)
        {
            var item = _inventory.GetItem(slot);
            _moneyStorage.Take(ItemCost(slot));
            _inventory.Remove(slot);
            return item;
        }

        public float ItemCost(InventorySlot slot) => 
            _inventory.GetItem(slot).Cost;
    }
}