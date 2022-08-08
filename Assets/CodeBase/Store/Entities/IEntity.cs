using CodeBase.Store.Inventories;

namespace CodeBase.Store.Entities
{
    public interface IEntity : IBuyer, ISeller
    {
        IInventory Inventory { get; }
    }
}