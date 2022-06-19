using UnityEngine;

/// <summary>
/// アイテムの種類．
/// </summary>
public enum ItemType : int
{
    Pencil,
    Camera,
    Telephone,
    GamePad,
    Wallet,
    PC,
    Watch,
    Book,
    Desk,
}


[System.Serializable]
public class ItemData
{
    [SerializeField]
    ItemType _ItemType;

    public ItemType ItemType => _ItemType;


    [SerializeField]
    private string _ItemName;

    public string ItemName => _ItemName;

    public ItemData(ItemType type, string name)
    {
        _ItemType = type;
        _ItemName = name;
    }

    public ItemData(ItemUserData userData)
    {
        _ItemType = userData.Data.ItemType;
        _ItemName = userData.Data.ItemName;
    }
}


[CreateAssetMenu(menuName = "OneO/ItemUserData")]
public class ItemUserData : ScriptableObject
{
    [SerializeField]
    private ItemData _Data;

    public ItemData Data => _Data;
}
