using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Consumers,
    Etc
}

 [System.Serializable]

public class Item
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    public int itemPrice;
    public int itemAttack;
    public int itemDefense;

    public bool Use()
    {
        return false;
    }
}

