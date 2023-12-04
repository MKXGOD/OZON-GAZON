using UnityEngine;
[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public int Id => GetInstanceID();
    public int ItemCode { get; private set; }

    [field: SerializeField]
    [field: Range(1, 3)]
    public int Size { get; private set; }
    [field: SerializeField] public float Price { get; private set; }
    [field: SerializeField] public GameObject PrefabItem { get; private set; }
    [field: SerializeField] public Sprite ItemImage { get; private set; }
}
