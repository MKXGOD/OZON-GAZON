using MyInventory;
public class PlayerInventory : BaseInventory
{
    private ShelfInventory _shelfInventory;
    public override void ShareItem(Item item)
    {
        if (_shelfInventory != null)
        {
            _shelfInventory.AddItem(item);
            
        }
    }
    public void GetShelfInventory(ShelfInventory shelfInventory)
    {
        _shelfInventory = shelfInventory;
    }
    public Item GetItem()
    { 
        return _items[0];
    }
}
