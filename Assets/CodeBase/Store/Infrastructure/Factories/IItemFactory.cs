using CodeBase.Store.Infrastructure.Services;
using CodeBase.Store.Items;

namespace CodeBase.Store.Infrastructure.Factories
{
    public interface IItemFactory : IService
    {
        Item Create(ItemId itemId);
    }
}