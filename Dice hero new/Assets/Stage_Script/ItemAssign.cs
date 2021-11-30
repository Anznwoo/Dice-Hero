using UnityEngine;

namespace DuloGames.UI
{
    public class ItemAssign : MonoBehaviour
    {
        [SerializeField] private Transform m_Container;
        UIItemInfo[] items = UIItemDatabase.Instance.items;

        void Start()
        {

            if (this.m_Container == null || UIItemDatabase.Instance == null)
            {
                this.Destruct();
                return;
            }
            Debug.Log("start");
        }

        void Update()
        {
            if (Input.GetKeyDown("space")) 
                UpdateUI();
        }
        void UpdateUI()
        {
            Debug.Log("씨발");
            UIItemSlot[] slots = this.m_Container.gameObject.GetComponentsInChildren<UIItemSlot>();
            UIItemInfo[] items = UIItemDatabase.Instance.items;
            for (int i = 0; i<5; i++)
            {
                Debug.Log(slots[i]);
                slots[i].Assign(items[Random.Range(0, items.Length)]);
            }
            this.Destruct();

        }

        private void Destruct()
        {
            DestroyImmediate(this);
        }
    }
}
