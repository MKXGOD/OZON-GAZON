using UnityEngine;

public class ItemObject : MonoBehaviour
{
  public ItemSO ItemData;
    public int GetCode()
    { 
        return ItemData.ItemCode;
    }
}
