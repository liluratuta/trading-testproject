using CodeBase.Store.Configs;
using CodeBase.Store.Entities;
using CodeBase.Store.Infrastructure.Factories;
using CodeBase.Store.Infrastructure.Providers;
using CodeBase.Store.Infrastructure.Services;
using CodeBase.Store.Inventories;
using CodeBase.Store.ItemDragger;
using CodeBase.Store.Items;
using CodeBase.Store.Money;
using UnityEngine;

namespace CodeBase.Store.Infrastructure
{
    public class StoreEntryPoint : MonoBehaviour
    {
        [SerializeField] private ContentProvider _contentProvider;
        [SerializeField] private StoreConfig _storeConfig;
        [SerializeField] private RectTransform _canvasTransform;
        
        private AllServices _services;
        
        private void Awake()
        {
            _services = AllServices.Container;
        }

        private void Start()
        {
            RegisterServices();
            InitializeGame();
        }

        private void InitializeGame()
        {
            var itemDragger = _services.Single<IViewFactory>().CreateItemDragger();
            itemDragger.Construct(_services.Single<ISpriteProvider>());
            
            InitializePlayer(itemDragger);
            InitializeTrader(itemDragger);
            
            itemDragger.transform.SetAsLastSibling();
        }

        private void InitializeTrader(IItemDragger itemDragger)
        {
            var inventory = new Inventory(_storeConfig.TraderInventorySize, _services.Single<IItemFactory>());
            
            _storeConfig.TraderStartItems.ForEach(x => inventory.SetItem(x.Id, x.InventoryIndex));
            
            var trader = new TraderStoreEntity(inventory, _storeConfig.TraderCostMultiplier);
            
            var inventoryView = _services.Single<IViewFactory>().CreateTraderInventory();
            
            inventoryView.Construct(trader,
                _services.Single<ISpriteProvider>(),
                _services.Single<IViewFactory>(),
                _services.Single<IStoreService>(),
                itemDragger);
        }

        private void InitializePlayer(IItemDragger itemDragger)
        {
            var inventory = new Inventory(_storeConfig.PlayerInventorySize, _services.Single<IItemFactory>());
            
            _storeConfig.PlayerStartItems.ForEach(x => inventory.SetItem(x.Id, x.InventoryIndex));
            
            var moneyStorage = new MoneyStorage(_storeConfig.PlayerStartMoneyAmount);
            var player = new PlayerStoreEntity(inventory, moneyStorage);

            var inventoryView = _services.Single<IViewFactory>().CreatePlayerInventory();
            
            inventoryView.Construct(player,
                _services.Single<ISpriteProvider>(),
                _services.Single<IViewFactory>(),
                _services.Single<IStoreService>(),
                itemDragger);

            var moneyView = _services.Single<IViewFactory>().CreateMoneyView();

            moneyView.Construct(moneyStorage);
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IItemFactory>(new ItemFactory(_storeConfig));
            _services.RegisterSingle<IAssetProvider>(new AssetProvider(_contentProvider));
            _services.RegisterSingle<ISpriteProvider>(new SpriteProvider(_contentProvider));
            _services.RegisterSingle<IPurchaseService>(new PurchaseService());
            _services.RegisterSingle<IStoreService>(new StoreService(_services.Single<IPurchaseService>()));
            _services.RegisterSingle<IViewFactory>(new ViewFactory(_canvasTransform, _services.Single<IAssetProvider>()));
        }
    }
}