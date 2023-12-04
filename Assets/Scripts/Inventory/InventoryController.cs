using System;
using System.Collections.Generic;
using InventoryUI;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventoryPage _inventoryPage;
    [SerializeField] private InventorySO _inventoryData;

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
        Debug.Log("ChooseItem");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_inventoryPage.isActiveAndEnabled == false)
            {
                _inventoryPage.ShowHideInventory(true);
                foreach (var item in _inventoryData.GetCurrentInventoryState())
                {
                    _inventoryPage.UpdateData(item.Key, item.Value.Item.ItemImage, item.Value.ItemCode);
                }
            }
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
