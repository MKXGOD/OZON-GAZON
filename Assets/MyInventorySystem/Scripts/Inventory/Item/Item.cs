using System;

[Serializable]
public struct Item
{
    public int ItemCode;
    public ItemSO ItemSO;
    public bool IsEmpty => ItemSO == null;

    public static Item GetEmptyItem() => new Item
    {
        ItemSO = null,
        ItemCode = 0,
    };
}
