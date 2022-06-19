using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OneO/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    [SerializeField]
    private List<ItemUserData> _ItemDataList;

    public IReadOnlyList<ItemUserData> ItemDataList => _ItemDataList;
}
