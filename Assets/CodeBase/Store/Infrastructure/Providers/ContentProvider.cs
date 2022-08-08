using UnityEngine;

namespace CodeBase.Store.Infrastructure.Providers
{
    [CreateAssetMenu(fileName = "Content Provider", menuName = "Content Provider")]
    public class ContentProvider : ScriptableObject
    {
        [Header("Prefabs")]
        public GameObject InventorySlotPrefab;
        public GameObject TraderInventoryPrefab;
        public GameObject PlayerInventoryPrefab;
        public GameObject ItemDraggerPrefab;
        public GameObject MoneyStoragePrefab;

        [Header("Sprites")]
        public Sprite NoneItemSprite;
        public Sprite RedBottleItemSprite;
        public Sprite BlueBottleItemSprite;
        public Sprite SwordItemSprite;
        public Sprite BookItemSprite;
    }
}