using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyInventory
{
    public abstract class BaseInventory : MonoBehaviour
    {
        [SerializeField] protected InventoryPage _inventoryPage;
        [SerializeField] protected List<Item> _items;
        [field: SerializeField] public int Size { get; private set; }

        public event Action<Dictionary<int, Item>> OnInventoryUpdated;

        protected void Awake()
        {
            PrepareUI();
            PrepareInventoryData();
        }

        public void InitializeInventory()
        {
            _items = new List<Item>();

            for (int i = 0; i < Size; i++)
            {
                _items.Add(Item.GetEmptyItem());
            }
        }

        private void AddItem(ItemSO item, int itemCode)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].IsEmpty)
                {
                    _items[i] = new Item
                    {
                        ItemSO = item,
                        ItemCode = itemCode
                    };
                    return;
                }
            }
        }
        public bool InventoryIsFull()
        {
            return _items.All(s => s.IsEmpty == false);
        }
        public void SwapItem(Item item)
        {
            _items[0] = item;
        }
        public void AddItem(Item item)
        {
            AddItem(item.ItemSO, item.ItemCode);
            InformAboutChange();
        }
        public abstract void ShareItem(Item item);
        private Item GetItemAt(int index)
        {
            return _items[index];
        }
        public Dictionary<int, Item> GetCurrentInventoryState()
        {
            Dictionary<int, Item> returnValue = new Dictionary<int, Item>();

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].IsEmpty)
                    continue;

                returnValue[i] = _items[i];
            }
            return returnValue;
        }


        protected void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
        }
        private void PrepareUI()
        {
            _inventoryPage.InitializeInventoryUI(Size);
            _inventoryPage.OnItemActionRequested += HandleItemActionRequest;

        }
        private void PrepareInventoryData()
        {
            InitializeInventory();
            OnInventoryUpdated += UpdateInventoryUI;
        }
        private void UpdateInventoryUI(Dictionary<int, Item> inventoryState)
        {
            _inventoryPage.ResetAllItems();
            foreach (var item in inventoryState)
            {
                _inventoryPage.UpdateData(item.Key, item.Value.ItemSO.ItemImage, item.Value.ItemCode);
            }
        }
        private void HandleItemActionRequest(int itemIndex)
        {
            Item inventoryItem = GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
                return;
            ShareItem(inventoryItem);
            RemoveItem(itemIndex);

        }

        private void RemoveItem(int itemIndex)
        {
            _items[itemIndex] = Item.GetEmptyItem();
            InformAboutChange();
        }
    }
}
