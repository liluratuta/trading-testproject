using CodeBase.Store.Infrastructure.Providers;
using CodeBase.Store.Inventories;
using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.ItemDragger;
using CodeBase.Store.Money;
using UnityEngine;

namespace CodeBase.Store.Infrastructure.Factories
{
    public class ViewFactory : IViewFactory
    {
        private readonly RectTransform _canvas;
        private readonly IAssetProvider _assetProvider;

        public ViewFactory(RectTransform canvas, IAssetProvider assetProvider)
        {
            _canvas = canvas;
            _assetProvider = assetProvider;
        }

        public InventoryView CreatePlayerInventory() => 
            Object.Instantiate(_assetProvider.PlayerInventoryPrefab.GetComponent<InventoryView>(), _canvas);

        public InventoryView CreateTraderInventory() => 
            Object.Instantiate(_assetProvider.TraderInventoryPrefab.GetComponent<InventoryView>(), _canvas);

        public InventorySlotView CreateSlot(Transform container) => 
            Object.Instantiate(_assetProvider.InventorySlotPrefab.GetComponent<InventorySlotView>(), container);

        public ItemDraggerView CreateItemDragger() => 
            Object.Instantiate(_assetProvider.ItemDraggerPrefab.GetComponent<ItemDraggerView>(), _canvas);

        public MoneyStorageView CreateMoneyView() => 
            Object.Instantiate(_assetProvider.MoneyViewPrefab.GetComponent<MoneyStorageView>(), _canvas);
    }
}