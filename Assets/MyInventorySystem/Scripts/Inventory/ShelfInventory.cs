using UnityEngine;
using MyInventory;

public class ShelfInventory : BaseInventory
{
    [SerializeField] private DeliveryPackage _deliveryPackage;
    private PlayerInventory _playerInventory;

    public override void ShareItem(Item item)
    {
        if (_playerInventory != null)
        { 
            _playerInventory.AddItem(item);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerInventory = other.GetComponent<PlayerInventory>();
            _playerInventory.GetShelfInventory(this);
            _inventoryPage.ShowHideInventory(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerInventory.GetShelfInventory(null);
            _playerInventory = null;
            _inventoryPage.ShowHideInventory(false);
        }
    }
}
