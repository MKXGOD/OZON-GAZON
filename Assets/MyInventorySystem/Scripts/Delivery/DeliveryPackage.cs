using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class DeliveryPackage : MonoBehaviour
{
    System.Random _rnd = new System.Random();
    [SerializeField] private List<ItemSO> _packagesType;
    [SerializeField] private ShelfInventory[] _shelfs;

    public delegate void DeliveryHandler(int itemCode);
    public event DeliveryHandler NotifyOnDelivered;

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.P)) Delive();
    }
    public Item CreateItem()
    { 
        Item item = new Item 
        { 
            ItemSO = GenerateItem(),
            ItemCode = GenerateCode()
        };
        NotifyOnDelivered?.Invoke(item.ItemCode);
        return item;
    }
    private ItemSO GenerateItem()
    {
        int totalSize =  _packagesType.Sum(x => x.Size);
        int randomNum = _rnd.Next(0, totalSize);

        ItemSO package = null;
        foreach (var packageType in _packagesType)
        {
            if (randomNum < packageType.Size)
            { 
                package = packageType;
                break;
            }
            randomNum -= packageType.Size;
        }
        return package;
    }

    private int GenerateCode()
    {
        int code = _rnd.Next(100, 999);
        return code;
    }

    private void Delive()
    {
            for (int k = 0; k <= _shelfs.Length - 1; )
            {
                if (_shelfs[k].InventoryIsFull())
                    k++;
     
                _shelfs[k].AddItem(CreateItem());
                return;
            }
    }
}   
