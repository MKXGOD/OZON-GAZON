using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryUI
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField] private UIInventoryItem _inventoryItemPrefab;
        [SerializeField] private RectTransform _rectTransform;

        private List<UIInventoryItem> _inventoryItemsList = new List<UIInventoryItem>();

        public event Action<int> OnItemActionRequested;

        private void Awake()
        {
            ShowHideInventory(false);
        }
        public void InitializeInventoryUI(int inventorySize)
        {
            for (int i = 0; i < 4; i++)
            {
                UIInventoryItem uiItem = Instantiate(_inventoryItemPrefab);
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
        private void HandleItemSelection(UIInventoryItem item)
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
}