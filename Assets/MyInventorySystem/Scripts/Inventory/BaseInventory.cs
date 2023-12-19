using UnityEngine;
using System;
using System.Collections.Generic;

namespace MyInventory
{
    public abstract class BaseInventory : MonoBehaviour
    {
        [SerializeField] protected InventoryPage _inventoryPage;
        [SerializeField] protected List<Item> _items;
        public List<Item> Items => _items;
        [field: SerializeField] public int Size { get; private set; }

        public event Action<Dictionary<int, Item>> OnInventoryUpdated;
        public List<Item> InitialItems = new List<Item>();

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

        private void AddItem(ItemSO item, string itemCode)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].isEmpty)
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
        public void SwapItem(Item item)
        {
            _items[0] = item;
        }
        public void AddItem(Item item)
        {
            AddItem(item.ItemSO, item.ItemCode);
            InformAboutChange();
        }
        public void RemoveItem(int index)
        {
            _items.RemoveAt(index); 
        }
        public Item GetItemAt(int index)
        {
            return _items[index];
        }
        public void SwapItems(int index1, int index2)
        {
            Item item1 = _items[index1];
            _items[index1] = _items[index2];
            _items[index2] = item1;
            InformAboutChange();
        }
        public Dictionary<int, Item> GetCurrentInventoryState()
        {
            Dictionary<int, Item> returnValue = new Dictionary<int, Item>();

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].isEmpty)
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
            foreach (Item item in InitialItems)
            {
                if (item.isEmpty)
                    continue;
                AddItem(item);
            }
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
            if (inventoryItem.isEmpty)
                return;
            ShareItem(itemIndex);
            
        }
        public abstract void ShareItem(int itemIndex);
    }
}
