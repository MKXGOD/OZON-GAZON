using System.Collections.Generic;
using OldInventoryUI;
using UnityEngine;


namespace OldInventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private UIInventoryPage _inventoryPage;
        [SerializeField] private InventorySO _inventoryData;

        private PickUpSystem _pickupSystem;

        public List<InventoryItem> InitialItems = new List<InventoryItem>();

        private void Start()
        {
            PrepareUI();
            PrepareInventoryData();


        }

        private void PrepareInventoryData()
        {
            _inventoryData.Initialize();
            _inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach (InventoryItem item in InitialItems)
            {
                if (item.isEmpty)
                    continue;
                _inventoryData.AddItem(item);
            }
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            _inventoryPage.ResetAllItems();
            foreach (var item in inventoryState)
            {
                _inventoryPage.UpdateData(item.Key, item.Value.Item.ItemImage, item.Value.ItemCode);
            }
        }

        private void PrepareUI()
        {
            _inventoryPage.InitializeInventoryUI(_inventoryData.Size);
            _inventoryPage.OnItemActionRequested += HandleItemActionRequest;

        }
        private void HandleItemActionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.isEmpty)
                return;
            //_pickupSystem.TakeItem(inventoryItem);
            //Debug.Log(inventoryItem.ItemCode);


        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {

                //_pickupSystem = other.gameObject.GetComponent<PickUpSystem>();
                //_pickupSystem.InitialPickupSystem(_inventoryData);
                if (_inventoryPage.isActiveAndEnabled == false)
                {
                    foreach (var item in _inventoryData.GetCurrentInventoryState())
                    {
                        _inventoryPage.UpdateData(item.Key, item.Value.Item.ItemImage, item.Value.ItemCode);
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
}
