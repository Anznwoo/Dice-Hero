using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
//using Data;

namespace DuloGames.UI
{
    public class Store : MonoBehaviour
    {

        [SerializeField] private Transform m_Container;
        //public DataManager DM;
        int RandomNum;
        Text text_name;
        Text text_price;
        string[] Scripts_entrance;
        string[] Scripts_buy;
        string[] Scripts_bought;
        string[] Scripts_nomoney;
        string[] Scripts_leave;
        public GameObject Store_TextBox;
        public Text Storetext;
        public Situation situation;
        List<int> CheckSale;
        int Ran_num;
        //ChangeScene changeScene;

        public AudioSource coin_source;


        // Start is called before the first frame update
        void Start()
        {
            Scripts_entrance = new string[3] { "훔칠 생각은 하지도 마", "거래를 할까...", "세상이 어찌 이리 됐는지..." };
            Scripts_buy = new string[3] { "목숨이 아까운가, 돈이 아까운가?", "내 아들 같아서 이 가격에 주는거야", "어차피 죽으면 다 아무 쓸모 없다고" };
            Scripts_bought = new string[3] { "잘 생각했어", "목숨부터 부지해야지. 안그래?", "몸 조심해" };
            Scripts_nomoney = new string[3] { "돈도 없는게... 꺼져!", "어린 놈의 새끼가...", "돈은 있는거야?" };
            Scripts_leave = new string[3] { "다음에 또 보자고", "꼭 살아남으라고", "자네처럼 착한 고객은 언제나 환영일세" };
            CheckSale = new List<int>();
            OpenStore();
        }

        // Update is called once per frame

        public int RandomCheck()
        {
            
            bool check = false;
            while (check == false)
            {
                Ran_num = UnityEngine.Random.Range(1, 50);
                if (!CheckSale.Contains(Ran_num)&&Ran_num!=36&& Ran_num != 37&& Ran_num != 38)
                    check = true;
            }
            CheckSale.Add(Ran_num);
            return Ran_num;
        }
        public void OpenStore()
        {
            UIItemSlot[] slots = this.m_Container.gameObject.GetComponentsInChildren<UIItemSlot>();
            Text[] slots_name = this.m_Container.gameObject.GetComponentsInChildren<Text>();

            OpenTextBox(Situation.entrance);

            for (int i = 0; i < slots.Length; i++)
            {
                
                RandomNum = RandomCheck();
                Transform Shop_Slot = m_Container.transform.GetChild(i);
                slots[i].Assign(UIItemDatabase.Instance.GetByID(RandomNum));
                text_name = Shop_Slot.GetChild(1).GetChild(0).GetComponent<Text>();
                text_price = Shop_Slot.GetChild(1).GetChild(1).GetComponentInChildren<Text>();

                text_name.text = UIItemDatabase.Instance.GetByID(RandomNum).Name;
                text_price.text = UIItemDatabase.Instance.GetByID(RandomNum).Price.ToString();
            }
        }


        public void StoreRightClick(int SlotNum)
        {
            
            UIItemSlot[] slots = this.m_Container.gameObject.GetComponentsInChildren<UIItemSlot>();
            
            UIModalBox.Amount = 1;
            if( Data.Gold>=slots[SlotNum].GetItemInfo().Price)
            {
                OpenTextBox(Situation.buy);
                UIModalBox box = UIModalBoxManager.Instance.Create(this.gameObject);
                if (UIModalBoxManager.Instance == null)
                {
                    Debug.LogWarning("Could not load the modal box manager while creating a modal box.");
                    return;
                }
                OpenTextBox(Situation.buy);

                if (box != null)
                {
                    box.SetText1("정말 \"" + slots[SlotNum].GetItemInfo().Name + "\"을 구매하시겠습니까?");
                    box.SetText2("");
                    box.SetConfirmButtonText("구매");
                    box.onConfirm.AddListener(delegate { GetItem(SlotNum); });
                    box.onConfirm.AddListener(delegate { OpenTextBox(Situation.bought); });
                    //box.onConfirm.AddListener(delegate { PurchaseStack(box, slots[SlotNum].GetItemInfo()); });
                    box.onConfirm.AddListener(delegate { box.SetOne(); });
                    box.Show();
                }


                /*if (slots[SlotNum].GetItemInfo().ItemType != 0)
                {
                    if (box != null)
                    {
                        box.SetText1("\"" + slots[SlotNum].GetItemInfo().Name + "\"를 몇 개 사시겠습니까??");
                        box.SetText2((UIModalBox.Amount.ToString()));
                        box.SetUpDown();
                        box.SetConfirmButtonText("구매");
                        //box.onConfirm.AddListener(Unassign);
                        box.onConfirm.AddListener(delegate { GetItems(SlotNum, UIModalBox.Amount); });
                        //box.onConfirm.AddListener(ResetAmount);
                        box.onConfirm.AddListener(delegate { OpenTextBox(Situation.bought); });
                        //box.onConfirm.AddListener(delegate { PurchaseStack(box, slots[SlotNum].GetItemInfo()); });
                        box.onUp.AddListener(delegate { GetPrice(box, slots[SlotNum].GetItemInfo()); });
                        box.onDown.AddListener(box.ActivateUp);
                        box.onConfirm.AddListener(delegate { box.SetOne(); });
                        box.Show();
                    }
                }

            }

            else if(slots[SlotNum].GetItemInfo().IsStackable==false)
                //&& DataManager.MyStateList[0].money >= slots[SlotNum].GetItemInfo().Price)
            {
                OpenTextBox(Situation.buy);
                UIModalBox box = UIModalBoxManager.Instance.Create(this.gameObject);
                if (box != null)
                {
                    box.SetText1("정말 \"" + slots[SlotNum].GetItemInfo().Name + "\"을 구매하시겠습니까?");
                    box.SetText2("");
                    box.SetConfirmButtonText("구매");
                    box.onConfirm.AddListener(delegate { GetItem(SlotNum); });
                    box.onConfirm.AddListener(delegate { OpenTextBox(Situation.bought); });
                    //box.onConfirm.AddListener(delegate { PurchaseStack(box, slots[SlotNum].GetItemInfo()); });
                    box.onConfirm.AddListener(delegate { box.SetOne(); });
                    box.Show();
                }
                */
            }
        
            if(Data.Gold < slots[SlotNum].GetItemInfo().Price)
            {
                OpenTextBox(Situation.nomoney);
            }
            
        }
        public void GetItem(int SlotNum)
        {
            UIItemSlot[] slots = this.m_Container.gameObject.GetComponentsInChildren<UIItemSlot>();
            //
            //Inventory.instance.Add(slots[SlotNum].GetItemInfo().ID);
            Data.Inventory.Add(slots[SlotNum].GetItemInfo().ID);
            Data.Gold -= slots[SlotNum].GetItemInfo().Price;
            Debug.Log(Data.Inventory.Count);

            coin_source.Play();
        }
        public void GetItems(int SlotNum, int amount)
        {
            UIItemSlot[] slots = this.m_Container.gameObject.GetComponentsInChildren<UIItemSlot>();
            //
            for (int i = 0; i < amount; i++)
            {
                //Inventory.instance.Add(slots[SlotNum].GetItemInfo().ID);
            }
            coin_source.Play();

        }
        public void ResetAmount()
        {
            UIModalBox.Amount = 1;
        }
        public void OpenTextBox(Situation situation)
        {
            int ran = UnityEngine.Random.Range(1, 3);
            Store_TextBox.SetActive(true);
            if (situation == Situation.entrance)
            {
                Storetext.text = Scripts_entrance[ran];
            }
            else if (situation == Situation.buy)
            {
                Storetext.text = Scripts_buy[ran];
            }
            else if (situation == Situation.bought)
            {
                Storetext.text = Scripts_bought[ran];
            }
            else if (situation == Situation.nomoney)
            {
                Storetext.text = Scripts_nomoney[ran];
            }
            else if (situation == Situation.leave)
            {
                Storetext.text = Scripts_leave[ran];
            }
            StopAllCoroutines();
            StartCoroutine(WaitForIt());

        }

        public void GoodBye(string scenename)
        {
            StopAllCoroutines();
            StartCoroutine(FairWell(scenename));
        }
        public void GetPrice(UIModalBox box, UIItemInfo item)
        {
            
            /* 현재 보유 금액 대비 최대 구매 가능갯수 까지만 스택이 증가하도록 함
             if ((UIModalBox.Amount+1) * item.Price > DataManager.MyStateList[0].money)
            {
                box.StopUp();
            }
            */
        }

        /* 뭉치 구매
        public void PurchaseStack(UIModalBox box, UIItemInfo item)
        {
            int jigab = DataManager.MyStateList[0].money;
            jigab -= item.Price * UIModalBox.Amount;
            DataManager.MyStateList[0].money = jigab;
            DataManager.SaveMyStateData();
            //ES3.Save<List<StateData>>("MyStateList", DataManager.MyStateList);
            Gold.gold.RefreshMoney();
        }
        */

        IEnumerator WaitForIt()
        {
            yield return new WaitForSeconds(3.0f);
            Store_TextBox.SetActive(false);
        }
        IEnumerator FairWell(string scenename)
        {
            int ran = UnityEngine.Random.Range(1, 3);
            Store_TextBox.SetActive(true);
            Storetext.text = Scripts_leave[ran];
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("StageSelect");
        }
    }
    public enum Situation
    {
        entrance,
        buy,
        bought,
        nomoney,
        leave
    }
}
