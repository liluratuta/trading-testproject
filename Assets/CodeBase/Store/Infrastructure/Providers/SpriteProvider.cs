using System;
using CodeBase.Store.Items;
using UnityEngine;

namespace CodeBase.Store.Infrastructure.Providers
{
    public class SpriteProvider : ISpriteProvider
    {
        private readonly ContentProvider _contentProvider;

        public SpriteProvider(ContentProvider contentProvider)
        {
            _contentProvider = contentProvider;
        }

        public Sprite ForItem(ItemId itemId)
        {
            return itemId switch
            {
                ItemId.None => _contentProvider.NoneItemSprite,
                ItemId.RedBottle => _contentProvider.RedBottleItemSprite,
                ItemId.BlueBottle => _contentProvider.BlueBottleItemSprite,
                ItemId.Sword => _contentProvider.SwordItemSprite,
                ItemId.Book => _contentProvider.BookItemSprite,
                _ => throw new ArgumentOutOfRangeException(nameof(itemId), itemId, null)
            };
        }
    }
}