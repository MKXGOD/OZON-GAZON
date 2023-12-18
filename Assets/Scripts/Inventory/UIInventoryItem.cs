using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace OldInventoryUI
{
    public class UIInventoryItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private TextMeshProUGUI _itemCodeText;

        public event Action<UIInventoryItem> OnItemClicked;

        private bool _isEmpty = true;

        private void Awake()
        {
            ResetData();
        }
        public void ResetData()
        {
            _itemImage.gameObject.SetActive(false);
            _isEmpty = true;
        }
        public void SetData(Sprite itemImage, string itemCode)
        {
            _itemImage.gameObject.SetActive(true);
            _itemImage.sprite = itemImage;
            _itemCodeText.text = itemCode;
            _isEmpty = false;
        }
        public void OnPointerClick(PointerEventData pointerData)
        {
            if (pointerData.button == PointerEventData.InputButton.Left)
                OnItemClicked?.Invoke(this);
        }
    }
}