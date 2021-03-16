using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private ItemData data;
    private int count;

    public ItemData Info
    {
        get { return (data); }
    }
    public int Count
    {
        get { return (count); }
    }

    public Item(ItemData d)
    {
        data = d;
        count = 1;
    }

    public void AddItem()
    {
        ++count;
    }
    public bool RemoveItem()
    {
        --count;
        return (count <= 0);
    }
}
