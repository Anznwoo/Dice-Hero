using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        item.itemPrice = _item.itemPrice;
        item.itemAttack = _item.itemAttack;
        item.itemDefense = _item.itemDefense;
        image.sprite =item.itemImage;
    }
    public Item GetItem()
    {
        return item;
    }
}
