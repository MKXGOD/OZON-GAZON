using System.Collections.Generic;
using UnityEngine;

public class DeliveryPackage : MonoBehaviour
{
    [SerializeField] private ItemSO _smallPackage;
    [SerializeField] private ItemSO _middlePackage;
    [SerializeField] private ItemSO _bigPackage;

    public Item CreateItem()
    { 
        Item item = new Item 
        { 
            ItemSO = _smallPackage,
            ItemCode = "2281"
        };

        return item;
    }
}
