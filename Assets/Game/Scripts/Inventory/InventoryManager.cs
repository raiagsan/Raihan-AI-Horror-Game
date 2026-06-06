using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    private List<ItemData> _item = new List<ItemData>();
    public List<ItemData> Items => _item;
    
    public void AddItems(ItemData item)
    {
        Items.Add(item);
    }

    public bool CheckItem(string id)
    {
        bool isExsists = Items.Exists(ItemData => string.Equals(ItemData.ID, id));
        return isExsists;
    }

    public void RemoveItem(ItemData item)
    {
        Items.Remove(item);
    }
}
