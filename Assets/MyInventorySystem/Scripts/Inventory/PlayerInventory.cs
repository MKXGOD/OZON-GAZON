using MyInventory;
using UnityEngine;

public class PlayerInventory : BaseInventory
{
    [SerializeField] private ShelfInventory _shelfInventory;

    public override void ShareItem(int itemIndex)
    {
        Item item1 = _items[itemIndex];
        _items[itemIndex] = Item.GetEmptyItem();
        _shelfInventory.AddItem(item1);

        InformAboutChange();
    }
}
