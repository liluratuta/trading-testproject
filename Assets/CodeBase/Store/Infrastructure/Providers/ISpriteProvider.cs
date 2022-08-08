using CodeBase.Store.Infrastructure.Services;
using CodeBase.Store.Items;
using UnityEngine;

namespace CodeBase.Store.Infrastructure.Providers
{
    public interface ISpriteProvider : IService
    {
        Sprite ForItem(ItemId itemId);
    }
}