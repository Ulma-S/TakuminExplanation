using System.Collections.Generic;
using UnityEngine;


public class ItemDataProvider : MonoBehaviour
{
    private class ItemDataSet
    {
        public ItemData Data { get; private set; }
        public int Count { get; set; }

        public ItemDataSet(ItemData data, int count)
        {
            Data = data;
            Count = count;
        }
    }

    public static ItemDataProvider Instance { get; private set; }

    [SerializeField]
    private ItemDatabase _Database;

    private readonly Dictionary<int, ItemDataSet> _ItemDataMap = new Dictionary<int, ItemDataSet>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        Initialize();
    }


    public ItemData GetItemData(ItemType type)
    {
        var key = (int)type;
        if (!_ItemDataMap.ContainsKey(key))
        {
            throw new KeyNotFoundException();
        }
        return _ItemDataMap[key].Data;
    }


    public List<ItemData> GetAllItem()
    {
        List<ItemData> dataList = new List<ItemData>();
        
        foreach(var dataSet in _ItemDataMap.Values)
        {
            dataList.Add(dataSet.Data);
        }

        return dataList;
    }


    public int GetItemCount(ItemType type)
    {
        var key = (int)type;
        if (!_ItemDataMap.ContainsKey(key))
        {
            throw new KeyNotFoundException();
        }
        return _ItemDataMap[key].Count;
    }


    public void IncreaseItemCount(ItemType type, int count)
    {
        if(count < 0)
        {
            throw new System.ArgumentException();
        }

        var key = (int)type;
        if (!_ItemDataMap.ContainsKey(key))
        {
            throw new KeyNotFoundException();
        }
        _ItemDataMap[key].Count += count;
    }


    public void DecreaseItemCount(ItemType type, int count)
    {
        if(count < 0)
        {
            throw new System.ArgumentException();
        }

        var key = (int)type;
        if (!_ItemDataMap.ContainsKey(key))
        {
            throw new KeyNotFoundException();
        }
        _ItemDataMap[key].Count -= count;
        if(_ItemDataMap[key].Count < 0)
        {
            _ItemDataMap[key].Count = 0;
        }
    }


    private void Initialize()
    {
        var itemList = _Database.ItemDataList;
        foreach(var itemUserData in itemList)
        {
            if (_ItemDataMap.ContainsKey((int) itemUserData.Data.ItemType))
            {
                throw new System.Exception();
            }
            var itemData = new ItemData(itemUserData);
            var dataSet = new ItemDataSet(itemData, 1);
            _ItemDataMap.Add((int) itemData.ItemType, dataSet);
        }
    }
}
