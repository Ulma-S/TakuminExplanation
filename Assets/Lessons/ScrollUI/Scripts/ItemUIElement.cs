using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIElement : MonoBehaviour
{
    public ItemData Data { get; private set; }
    public int Count { get; private set; }

    private ItemType _ItemType;

    [SerializeField]
    private Text _NameText;

    [SerializeField]
    private Text _CountText;

    private void Update()
    {
        var name = Data.ItemName;
        _NameText.text = name;

        var count = ItemDataProvider.Instance.GetItemCount(_ItemType);
        _CountText.text = count.ToString();
    }

    public void Initialize(ItemData data, int count)
    {
        Data = data;
        Count = count;
        _ItemType = data.ItemType;
    }
}
