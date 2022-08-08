using CodeBase.Store.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Store.Infrastructure.Providers
{
    public interface IAssetProvider : IService
    {
        GameObject InventorySlotPrefab { get; }
        GameObject TraderInventoryPrefab { get; }
        GameObject PlayerInventoryPrefab { get; }
        GameObject ItemDraggerPrefab { get; }
        GameObject MoneyViewPrefab { get; }
    }
}