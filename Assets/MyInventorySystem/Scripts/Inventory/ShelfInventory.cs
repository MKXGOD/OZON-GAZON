using UnityEngine;
using MyInventory;
using OldInventoryUI;

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
        var item = _playerInventory.GetItemAt(0);
        if (!item.isEmpty)
            return;

        Item item1 = _items[itemIndex];
        _playerInventory.AddItem(item1);
        _items[itemIndex] = Item.GetEmptyItem();

        InformAboutChange();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_inventoryPage.isActiveAndEnabled == false)
            {
                foreach (var item in GetCurrentInventoryState())
                {
                    _inventoryPage.UpdateData(item.Key, item.Value.ItemSO.ItemImage, item.Value.ItemCode);
                }
            }
            _inventoryPage.ShowHideInventory(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _inventoryPage.ShowHideInventory(false);
            _inventoryPage.ResetAllItems();
        }
    }
}
