using CodeBase.Store.Infrastructure.Services;
using CodeBase.Store.Inventories;
using CodeBase.Store.Inventories.Slot;
using CodeBase.Store.ItemDragger;
using CodeBase.Store.Money;
using UnityEngine;

namespace CodeBase.Store.Infrastructure.Factories
{
    public interface IViewFactory : IService
    {
        InventoryView CreatePlayerInventory();
        InventoryView CreateTraderInventory();
        InventorySlotView CreateSlot(Transform container);
        ItemDraggerView CreateItemDragger();
        MoneyStorageView CreateMoneyView();
    }
}