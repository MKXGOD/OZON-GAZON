using System;
[Serializable]
public struct Item
{
    public string ItemCode;
    public ItemSO ItemSO;
    public bool isEmpty => ItemSO == null;

    public static Item GetEmptyItem() => new Item
    {
        ItemSO = null,
        ItemCode = 0.ToString(),
    };
}
