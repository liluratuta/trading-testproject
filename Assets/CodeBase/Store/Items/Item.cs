namespace CodeBase.Store.Items
{
    public class Item
    {
        public ItemId Id { get; }
        public float Cost { get; }

        public Item(ItemId id, float cost)
        {
            Id = id;
            Cost = cost;
        }
    }
}
