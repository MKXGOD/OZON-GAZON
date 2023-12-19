using UnityEngine;
public class DeliveryPackage : MonoBehaviour
{
    [SerializeField] private ItemSO _smallPackage;
    [SerializeField] private ItemSO _middlePackage;
    [SerializeField] private ItemSO _bigPackage;

    public delegate void DeliveryHandler(int packageDelivered);
    public event DeliveryHandler NotifyOnDelivered;

    public Item CreateItem()
    { 
        Item item = new Item 
        { 
            ItemSO = _smallPackage,
            ItemCode = "2281"
        };
        NotifyOnDelivered?.Invoke(1);
        return item;
    }
    public void SpawnClient()
    { 
        
    }
}
