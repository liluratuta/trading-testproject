using CodeBase.Store.Configs;
using CodeBase.Store.Items;

namespace CodeBase.Store.Infrastructure.Factories
{
    public class ItemFactory : IItemFactory
    {
        private readonly StoreConfig _storeConfig;

        public ItemFactory(StoreConfig storeConfig)
        {
            _storeConfig = storeConfig;
        }

        public Item Create(ItemId itemId) => 
            new Item(itemId, _storeConfig.ItemCost(itemId));
    }
}