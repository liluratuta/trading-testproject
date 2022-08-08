using System;
using System.Collections.Generic;
using CodeBase.Store.Items;
using UnityEngine;

namespace CodeBase.Store.Configs
{
    [CreateAssetMenu(fileName = "Store Config", menuName = "Store Config")]
    public class StoreConfig : ScriptableObject
    {
        public int PlayerInventorySize;
        public int PlayerStartMoneyAmount;
        public int TraderInventorySize;
        public float TraderCostMultiplier;
        
        [Header("Item Costs")]
        public float RedBottleCost;
        public float BlueBottleCost;
        public float SwordCost;
        public float BookCost;

        [Header("Start Inventory Items")]
        public List<ItemInfo> PlayerStartItems;
        public List<ItemInfo> TraderStartItems;

        public float ItemCost(ItemId itemId)
        {
            return itemId switch
            {
                ItemId.None => 0,
                ItemId.RedBottle => RedBottleCost,
                ItemId.BlueBottle => BlueBottleCost,
                ItemId.Sword => SwordCost,
                ItemId.Book => BookCost,
                _ => throw new ArgumentOutOfRangeException(nameof(itemId), itemId, null)
            };
        }
    }
    
    [Serializable]
    public struct ItemInfo
    {
        public ItemId Id;
        public int InventoryIndex;
    }
}