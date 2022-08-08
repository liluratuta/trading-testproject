using UnityEngine;

namespace CodeBase.Store.Infrastructure.Providers
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject InventorySlotPrefab => _contentProvider.InventorySlotPrefab;
        public GameObject TraderInventoryPrefab => _contentProvider.TraderInventoryPrefab;
        public GameObject PlayerInventoryPrefab => _contentProvider.PlayerInventoryPrefab;
        public GameObject ItemDraggerPrefab => _contentProvider.ItemDraggerPrefab;
        public GameObject MoneyViewPrefab => _contentProvider.MoneyStoragePrefab;

        private readonly ContentProvider _contentProvider;

        public AssetProvider(ContentProvider contentProvider)
        {
            _contentProvider = contentProvider;
        }
    }
}