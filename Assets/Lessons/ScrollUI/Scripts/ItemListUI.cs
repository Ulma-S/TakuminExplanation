using System.Collections.Generic;
using UnityEngine;

public class ItemListUI : MonoBehaviour
{
    [SerializeField]
    private ItemUIElement _UIElement;

    private readonly Dictionary<int, ItemUIElement> _ItemUIMap = new Dictionary<int, ItemUIElement>();

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        var allItem = ItemDataProvider.Instance.GetAllItem();

        foreach(var itemData in allItem)
        {
            if(ItemDataProvider.Instance.GetItemCount(itemData.ItemType) <= 0)
            {
                _ItemUIMap[(int)itemData.ItemType].gameObject.SetActive(false);
            }
            else
            {
                _ItemUIMap[(int)itemData.ItemType].gameObject.SetActive(true);
            }
        }
    }

    private void Initialize()
    {
        var allItem = ItemDataProvider.Instance.GetAllItem();

        foreach(var itemData in allItem)
        {
            var element = Instantiate(_UIElement);
            var count = ItemDataProvider.Instance.GetItemCount(itemData.ItemType);
            element.Initialize(itemData, count);
            element.transform.parent = transform;
            _ItemUIMap.Add((int)itemData.ItemType, element);
        }
    }
}
