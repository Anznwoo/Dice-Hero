using UnityEngine;

namespace DuloGames.UI
{
    public class Test_UIItemSlot_Assign : MonoBehaviour
    {
        [SerializeField] private Transform m_Container;
        [SerializeField] private UIItemSlot slot;
        //[SerializeField] private int assignItem;

        void Awake()
        {
            if (this.slot == null)
                this.slot = this.GetComponent<UIItemSlot>();
        }

        void Start()
        {
            if (this.slot == null)
            {
                this.Destruct();
                return;
            }
            //Debug.Log("assign start");
            //this.slot.Assign(Inventory.instance.items[0]);
            this.Destruct();
        }
        /*
        void UpdateInven()
        {
            UIItemSlot[] slots = this.m_Container.gameObject.GetComponentsInChildren<UIItemSlot>();
            Debug.Log("assign start");
            for (int i = 0; i < Inventory.instance.items.Length; i++)
            {
                Debug.Log("Assigning"+i);
                if (slots[i].IsAssigned())
                {
                    continue;
                }
                else
                {
                    slots[i].Assign(Inventory.instance.items[Inventory.instance.items.Length-1]);
                    //this.Destruct();
                }
            }
            
        }*/

        private void Destruct()
        {
            DestroyImmediate(this);
        }

    }
}
