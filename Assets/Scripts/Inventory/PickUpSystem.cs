using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField] private InventorySO _playerInventory;
    private InventorySO _shelfInventory;

    private void OnTriggerEnter(Collider other)
    {
        _shelfInventory = GetComponent<InventorySO>();
    }
}
