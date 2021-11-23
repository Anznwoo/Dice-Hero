using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Inventory : MonoBehaviour
    {
        #region Singleton
        public static Inventory instance;
        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);

                return;
            }
            instance = this;
        }
        #endregion
    
    public delegate void OnSlotCountChange(int val); //슬롯 UI에도 추가
    public OnSlotCountChange onSlotCountChange;


    List<Item> items = new List<Item>();
     
    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    void Start()
    {
        SlotCnt = 4; //인벤토리 칸수
    }

    public bool AddItem(Item _item)
    {      if(items.Count < SlotCnt)
        {
            items.Add(_item);
            //if(onChangeItem != null)
            //onChangeItem.Invoke();
            return true;
        }
        return false;
    }

    //상대가 죽으면 AddItem 호출

    /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("FieldItem"))
        {
            FieldItems fielditems = collision.GetComponent<FieldItems>();
            if (Additem(fieldItems.GetItem()))
            fieldItems.DestroyItem();
        }
    } */
}
  
