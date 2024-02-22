using MyInventory;
using UnityEngine;

public interface IInventoryCollect
{
    public BaseInventory Inventory { get; set; }

    public void ShareItem(int itemIndex);
}
