using System;
using System.Collections.Generic;
using UnityEngine;

namespace OldInventory
{
    [CreateAssetMenu]
    public class InventorySO : ScriptableObject
    {
        [SerializeField] private List<InventoryItem> _inventoryItems;

        [field: SerializeField] public int Size { get; private set; } = 8;

        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

        public void Initialize()
        {
            _inventoryItems = new List<InventoryItem>();

            for (int i = 0; i < Size; i++)
            {
                _inventoryItems.Add(InventoryItem.GetEmptyItem());
            }
        }

        public void AddItem(ItemSO item, string itemCode)
        {
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].isEmpty)
                {
                    _inventoryItems[i] = new InventoryItem
                    {
                        Item = item,
                        ItemCode = itemCode
                    };
                    return;
                }
            }
        }
        public Dictionary<int, InventoryItem> GetCurrentInventoryState()
        {
            Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();

            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].isEmpty)
                    continue;

                returnValue[i] = _inventoryItems[i];
            }
            return returnValue;
        }

        public InventoryItem GetItemAt(int itemIndex)
        {
            return _inventoryItems[itemIndex];
        }

        public void AddItem(InventoryItem item)
        {
            AddItem(item.Item, item.ItemCode);
        }
    }
    [Serializable]
    public struct InventoryItem
    {
        public string ItemCode;
        public ItemSO Item;
        public bool isEmpty => Item == null;

        /*public InventoryItem ChangeQuantity(int newQuantity)
        {
            return new InventoryItem
            {
                Item = this.Item,
                Quantity = newQuantity
            };
        }*/
        public static InventoryItem GetEmptyItem() => new InventoryItem
        {
            Item = null,
            ItemCode = 0.ToString(),
        };
    }
}