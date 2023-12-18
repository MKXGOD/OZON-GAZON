using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    [SerializeField] private InventoryItem _item;
    [SerializeField] private RectTransform _rectTransform;

    private List<InventoryItem> _inventoryItemsList = new List<InventoryItem>();

    public event Action<int> OnItemActionRequested;
    private void Awake()
    {
        //ShowHideInventory(false);
    }
    public void InitializeInventoryUI(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            InventoryItem uiItem = Instantiate(_item);
            uiItem.transform.SetParent(_rectTransform, false);
            _inventoryItemsList.Add(uiItem);

            uiItem.OnItemClicked += HandleItemSelection;
        }
    }

    public void UpdateData(int itemIndex, Sprite itemImage, string itemCode)
    {
        if (_inventoryItemsList.Count > itemIndex)
        {
            _inventoryItemsList[itemIndex].SetData(itemImage, itemCode);
        }
    }
    private void HandleItemSelection(InventoryItem item)
    {
        int index = _inventoryItemsList.IndexOf(item);

        if (index == -1)
            return;
        OnItemActionRequested?.Invoke(index);

    }

    public void ShowHideInventory(bool state)
    {
        this.gameObject.SetActive(state);
    }
    public void ResetAllItems()
    {
        foreach (var item in _inventoryItemsList)
        {
            item.ResetData();
        }
    }
}
