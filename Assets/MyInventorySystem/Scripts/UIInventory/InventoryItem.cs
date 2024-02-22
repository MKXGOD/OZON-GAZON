using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemCodeText;

    public event Action<InventoryItem> OnItemClicked;

    private bool _isEmpty = true;

    private void Awake()
    {
        ResetData();
    }
    public void ResetData()
    {
        _itemImage.gameObject.SetActive(false);
        _itemCodeText.gameObject.SetActive(false);
        _isEmpty = true;
    }
    public void SetData(Sprite itemImage, int itemCode)
    {
        _itemImage.gameObject.SetActive(true);
        _itemCodeText.gameObject.SetActive(true);
        _itemImage.sprite = itemImage;
        _itemCodeText.text = itemCode.ToString();
        _isEmpty = false;
    }
    public void OnPointerClick(PointerEventData pointerData)
    {
        if (pointerData.button == PointerEventData.InputButton.Left)
            OnItemClicked?.Invoke(this);
    }
}
