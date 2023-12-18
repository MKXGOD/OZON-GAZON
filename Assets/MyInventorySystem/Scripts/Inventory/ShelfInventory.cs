using UnityEngine;
using MyInventory;

public class ShelfInventory : BaseInventory
{
    [SerializeField] private DeliveryPackage _deliveryPackage;
    [SerializeField] private PlayerInventory _playerInventory;

    private void Start()
    {
        Delivery();
    }
    private void Delivery()
    {
        AddItem(_deliveryPackage.CreateItem());
    }

    public override void ShareItem(int itemIndex)
    {
        Debug.Log(GetCurrentInventoryState());
        if (_playerInventory.ItemsQuantity > _playerInventory.Size)
            return;

        _playerInventory.AddItem(GetItemAt(itemIndex));
        RemoveItem(itemIndex);
        InformAboutChange();
        Debug.Log(GetCurrentInventoryState());
    }
}
