using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;
//using Data;

namespace DuloGames.UI
{
	[AddComponentMenu("UI/Icon Slots/Item Slot", 12)]
	public class UIItemSlot : UISlotBase, IUIItemSlot
    {
        //StageManager SM;
        [Serializable] public class OnRightClickEvent : UnityEvent<UIItemSlot> { }
        [Serializable] public class OnDoubleClickEvent : UnityEvent<UIItemSlot> { }
		[Serializable] public class OnAssignEvent : UnityEvent<UIItemSlot> { }
        [Serializable] public class OnAssignWithSourceEvent : UnityEvent<UIItemSlot, Object> { }
		[Serializable] public class OnUnassignEvent : UnityEvent<UIItemSlot> { }
        [Serializable] public class OnThrowAwayEvent : UnityEvent<UIItemSlot> { }

        [SerializeField] private UIItemSlot_Group m_SlotGroup = UIItemSlot_Group.None;
		[SerializeField] private int m_ID = 0;


        Color color;
        Text StackNum1;
        /// <summary>
        /// Gets or sets the slot group.
        /// </summary>
        /// <value>The slot group.</value>
        public UIItemSlot_Group slotGroup
		{
			get { return this.m_SlotGroup; }
			set { this.m_SlotGroup = value; }
		}
		
		/// <summary>
		/// Gets or sets the slot ID.
		/// </summary>
		/// <value>The I.</value>
		public int ID
		{
			get { return this.m_ID; }
			set { this.m_ID = value; }
		}
		
		/// <summary>
		/// The assigned item info.
		/// </summary>
		private UIItemInfo m_ItemInfo;

        /// <summary>
        /// The right click event delegate.
        /// </summary>
        public OnRightClickEvent onRightClick = new OnRightClickEvent();

        /// <summary>
        /// The double click event delegate.
        /// </summary>
        public OnDoubleClickEvent onDoubleClick = new OnDoubleClickEvent();

        /// <summary>
        /// The assign event delegate.
        /// </summary>
        public OnAssignEvent onAssign = new OnAssignEvent();

        /// <summary>
        /// The assign with source event delegate.
        /// </summary>
        public OnAssignWithSourceEvent onAssignWithSource = new OnAssignWithSourceEvent();

        /// <summary>
        /// The unassign event delegate.
        /// </summary>
        public OnUnassignEvent onUnassign = new OnUnassignEvent();

        public OnThrowAwayEvent onThrowAway = new OnThrowAwayEvent();



        /// <summary>
        /// Gets the item info of the item assigned to this slot.
        /// </summary>
        /// <returns>The spell info.</returns>

        public UIItemInfo GetItemInfo()
		{
			return this.m_ItemInfo;
		}
        
        protected override void OnEnable()
        {
            base.OnEnable();

            // Check for duplicate id
            List<UIItemSlot> slots = GetSlotsInGroup(this.m_SlotGroup);
            UIItemSlot duplicate = slots.Find(x => x.ID == this.m_ID && !x.Equals(this));

            if (duplicate != null)
            {
                int oldId = this.m_ID;
                this.AutoAssignID();
                Debug.LogWarning("Item Slot with duplicate ID: " + oldId + " in Group: " + this.m_SlotGroup + ", generating and assigning new ID: " + this.m_ID + ".");
            }
        }

        /// <summary>
        /// Determines whether this slot is assigned.
        /// </summary>
        /// <returns><c>true</c> if this instance is assigned; otherwise, <c>false</c>.</returns>
        public override bool IsAssigned()
		{
			return (this.m_ItemInfo != null);
		}

        /// <summary>
        /// Assign the slot by new item info while refering to the source.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <param name="source">The source slot (Could be null).</param>
        /// <returns><c>true</c> if this instance is assigned; otherwise, <c>false</c>.</returns>
        public bool Assign(UIItemInfo itemInfo, Object source)
        {
            if (itemInfo == null)
                return false;

            // Make sure we unassign first, so the event is called before new assignment
            this.Unassign();

            // Use the base class assign to set the icon
            this.Assign(itemInfo.Icon);

            // Set the spell info
            this.m_ItemInfo = itemInfo;

            // Invoke the on assign event
            if (this.onAssign != null)
                this.onAssign.Invoke(this);

            // Invoke the on assign event
            if (this.onAssignWithSource != null)
                this.onAssignWithSource.Invoke(this, source);

            // Success
            return true;
        }

		/// <summary>
		/// Assign the slot by item info.
		/// </summary>
		/// <param name="itemInfo">The item info.</param>
		public bool Assign(UIItemInfo itemInfo)
		{
            return this.Assign(itemInfo, null);
		}
		
		/// <summary>
		/// Assign the slot by the passed source slot.
		/// </summary>
		/// <param name="source">Source.</param>
		public override bool Assign(Object source)
		{
			if (source is IUIItemSlot)
			{
                IUIItemSlot sourceSlot = source as IUIItemSlot;
				
				if (sourceSlot != null)
					return this.Assign(sourceSlot.GetItemInfo(), source);
			}
			
			// Default
			return false;
		}

        /// <summary>
        /// Unassign this slot.
        /// </summary>

        public override void Unassign()
		{

			// Remove the icon
			base.Unassign();


            // Clear the spell info
            this.m_ItemInfo = null;
			
			// Invoke the on unassign event
			if (this.onUnassign != null)
				this.onUnassign.Invoke(this);
		}
        public void DelInfo()
        {
            this.m_ItemInfo = null;
        }
        public void DelItem()
        {
            if (this.m_ItemInfo.IsStackable)
            {
                this.GetItemInfo().Stack = 1;
                this.transform.GetChild(3).gameObject.SetActive(false);
            }
            this.Unassign();
        }

        public void RemoveCombine()
        {
            if (this.IsAssigned())
            {
                this.Unassign();
                this.transform.GetChild(3).gameObject.SetActive(false);
            }
        }

        public override void OnThrowAway()
        {
            base.OnThrowAway();
        }
        public void ChangeAlpha()
        {
            color = this.iconGraphic.color;
            color.a = 0;
            
        }

        //��Ŭ���� �ش� ���Կ� ����ε� ������ ������ ��ȯ
        /*public UIItemInfo GetItem()
        {
            return Inventory.instance.items[this.ID - 1];
        }*/
        /*public void Combine_RightClick()
        {
            bool check = true;
            UIModalBox box = UIModalBoxManager.Instance.Create(this.gameObject);
            if (this.GetItemInfo().ItemType != 0)
            {

                if (GameObject.Find("Window_combine").GetComponent<UIWindow>().IsVisible && Inventory.instance.items[this.ID - 1].Stack >= UIModalBox.Amount)
                {

                    for (int i = 0; i < Combine.combine.Materials.Length - 1 && check == true; i++)
                    {
                        if (Combine.combine.Materials[i] == null)
                        {
                            Combine.combine.Materials[i] = Inventory.instance.items[this.ID - 1];
                            Combine.combine.amounts[i] = UIModalBox.Amount;
                            Combine.combine.MaterialSlotID[i] = this.ID - 1;
                            check = false;
                            Combine.combine.AddMaterial();
                            Debug.Log("���� ���� : "+Combine.combine.amounts[i]);
                            UIModalBox.Amount = 1;
                        }
                    }
                    //Combine.combine.Materials.Add(Inventory.instance.items[this.ID - 1]);
                }
                else if (Inventory.instance.items[this.ID - 1].Stack < UIModalBox.Amount)
                {
                    Debug.Log("������ �����մϴ�");
                    UIModalBox.Amount = 1;
                }
            }
            else
            {
                if (GameObject.Find("Window_combine").GetComponent<UIWindow>().IsVisible)
                {
                    for (int i = 0; i < Combine.combine.Materials.Length - 1 && check == true; i++)
                    {
                        if (Combine.combine.Materials[i] == null)
                        {
                            Combine.combine.Materials[i] = Inventory.instance.items[this.ID - 1];
                            Combine.combine.amounts[i] = 1;
                            Combine.combine.MaterialSlotID[i] = this.ID - 1;
                            check = false;
                            Combine.combine.AddMaterial();
                        }
                    }
                }
            }
        }
        public void Combine_Confirm()
        {
            if (!this.isStatic&& GameObject.Find("Window_combine").GetComponent<UIWindow>().IsVisible)
            {
                if (!Combine.combine.CombineSlots[0].IsAssigned() || !Combine.combine.CombineSlots[1].IsAssigned())
                {
                    if (Combine.combine.CombineSlots[0].GetItemInfo() != Inventory.instance.items[this.ID - 1] && Combine.combine.CombineSlots[1].GetItemInfo() != Inventory.instance.items[this.ID - 1])
                    {
                        if (UIModalBoxManager.Instance == null)
                        {
                            Debug.LogWarning("Could not load the modal box manager while creating a modal box.");
                            return;
                        }

                        UIModalBox box = UIModalBoxManager.Instance.Create(this.gameObject);
                        if (this.GetItemInfo().ItemType != 0)
                        {
                            if (box != null)
                            {
                                box.SetText1(string.Format("<color=#FFAF45FF>" + this.m_ItemInfo.Name + "</color>" + "�� � �����Ͻðڽ��ϱ�?"));
                                box.SetText2((UIModalBox.Amount.ToString()));
                                box.SetUpDown();
                                box.SetConfirmButtonText("Ȯ��");
                                //box.onConfirm.AddListener(Unassign);
                                box.onConfirm.AddListener(Combine_RightClick);
                                box.onUp.AddListener(delegate { box.DeactivateUp(Inventory.instance.items[this.ID - 1].Stack); });
                                box.onUp.AddListener(box.ActivateDown);
                                box.onDown.AddListener(box.ActivateUp);
                                box.Show();
                            }
                        }
                        else
                        {
                            if (box != null)
                            {
                                box.SetText1("���� \"<color=#FFAF45FF>" + this.m_ItemInfo.Name + "</color>\"�� �����Ͻðڽ��ϱ�?");
                                box.SetText2("");
                                box.SetConfirmButtonText("Ȯ��");
                                box.onConfirm.AddListener(Combine_RightClick);
                                box.Show();
                            }
                        }
                    }
                }
            }
            else if(GameObject.Find("Window (Character)").gameObject.activeSelf == true || GameObject.Find("Window (Character) (1)").gameObject.activeSelf == true)
            {
                UIModalBox box = UIModalBoxManager.Instance.Create(this.gameObject);
                SM = GameObject.Find("StageManager").GetComponent<StageManager>();
                if (this.GetItemInfo().ItemType == 0)
                {
                    if (box != null)
                    {
                        box.SetText1("������ ĳ���͸� ������.");
                        box.SetText2("");
                        
                        //�Ŀ� set_first,set_second,set_third �ؼ� ĳ���� �󱼷� ��ư ����� �Ұ�, ����� interactive=false �� �Ұ�
                        for(int i = 0; i < 3; i++)
                        {
                            if (DataManager.MyCharacterList[i].characterSlot == 1)
                            {
                                if (DataManager.MyCharacterList[i].characterIsAlive)
                                {
                                    box.Button_Image0(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    Equipment_Manager.EM.one = i;
                                }
                                else
                                {
                                    box.Button_Image0(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    box.CharButton(DataManager.MyCharacterList[i].characterSlot).interactable = false;
                                }
                            }
                            else if (DataManager.MyCharacterList[i].characterSlot == 2)
                            {
                                if (DataManager.MyCharacterList[i].characterIsAlive)
                                {
                                    box.Button_Image1(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    Equipment_Manager.EM.two = i;
                                }
                                else
                                {
                                    box.Button_Image1(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    box.CharButton(DataManager.MyCharacterList[i].characterSlot).interactable = false;
                                }
                            }
                            else if (DataManager.MyCharacterList[i].characterSlot == 3)
                            {
                                if (DataManager.MyCharacterList[i].characterIsAlive)
                                {
                                    box.Button_Image2(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    Equipment_Manager.EM.three = i;
                                }
                                else
                                {
                                    box.Button_Image2(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    box.CharButton(DataManager.MyCharacterList[i].characterSlot).interactable = false;
                                }
                            }

                        }
                        box.set_Equip();
                        box.First.AddListener(delegate { Equipment_Manager.EM.First(); });
                        box.Second.AddListener(delegate { Equipment_Manager.EM.Second(); });
                        box.Third.AddListener(delegate { Equipment_Manager.EM.Third(); });
                        //box.onConfirm.AddListener(Unassign);
                        box.Show();
                        box.DeactivateConfirm();
                    }
                }
                else if (this.GetItemInfo().ItemType == 2)
                {
                    int one=0, two=0, three=0;
                    if (box != null)
                    {
                        box.SetText1("�������� ����� ĳ���͸� ������.");
                        box.SetText2("");

                        //�Ŀ� set_first,set_second,set_third �ؼ� ĳ���� �󱼷� ��ư ����� �Ұ�, ����� interactive=false �� �Ұ�
                        for (int i = 0; i < 3; i++)
                        {
                            if (DataManager.MyCharacterList[i].characterSlot == 1)
                            {
                                if (DataManager.MyCharacterList[i].characterIsAlive)
                                {
                                    box.Button_Image0(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    one = i;
                                }
                                else
                                {
                                    box.Button_Image0(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    box.CharButton(DataManager.MyCharacterList[i].characterSlot).interactable = false;
                                }

                            }
                            else if (DataManager.MyCharacterList[i].characterSlot == 2)
                            {
                                if (DataManager.MyCharacterList[i].characterIsAlive)
                                {
                                    box.Button_Image1(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    two = i;
                                }
                                else
                                {
                                    box.Button_Image1(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    box.CharButton(DataManager.MyCharacterList[i].characterSlot).interactable = false;
                                }
                            }
                            else if (DataManager.MyCharacterList[i].characterSlot == 3)
                            {
                                if (DataManager.MyCharacterList[i].characterIsAlive)
                                {
                                    box.Button_Image2(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    three = i;
                                }
                                else
                                {
                                    box.Button_Image2(Resources.Load<Sprite>("Sprites/Characters/Player/" + DataManager.MyCharacterList[i].characterName + "/" + DataManager.MyCharacterList[i].characterName + "_head"));
                                    box.CharButton(DataManager.MyCharacterList[i].characterSlot).interactable = false;
                                }

                            }


                        }
                        box.set_Equip();
                        box.First.AddListener(delegate { PotionManager.PM.Heal(one); });
                        box.Second.AddListener(delegate { PotionManager.PM.Heal(two); });
                        box.Third.AddListener(delegate { PotionManager.PM.Heal(three); });
                        //box.onConfirm.AddListener(Unassign);
                        box.Show();
                        box.DeactivateConfirm();
                    }
                }
            }
        }
        */
        /// <summary>
        /// Determines whether this slot can swap with the specified target slot.
        /// </summary>
        /// <returns><c>true</c> if this instance can swap with the specified target; otherwise, <c>false</c>.</returns>
        /// <param name="target">Target.</param>
        public override bool CanSwapWith(Object target)
		{
			if (target is IUIItemSlot)
			{
				// Check if the equip slot accpets this item
				if (target is UIEquipSlot)
				{
					return (target as UIEquipSlot).CheckEquipType(this.GetItemInfo());
				}
				
				// It's an item slot
				return false;
			}
			
			// Default
			return false;
		}
		
		// <summary>
		/// Performs a slot swap.
		/// </summary>
		/// <returns><c>true</c>, if slot swap was performed, <c>false</c> otherwise.</returns>
		/// <param name="sourceSlot">Source slot.</param>
		/*
        public override bool PerformSlotSwap(Object sourceObject)
		{
            // Get the source slot
            UIItemSlot sourceSlot = (sourceObject as UIItemSlot);

            // Get the source item info
            //UIItemInfo sourceItemInfo = sourceSlot.GetItemInfo();
            UIItemInfo sourceItemInfo = Inventory.instance.items[sourceSlot.ID-1];
            //peform inven swap
            // Assign the source slot by this slot
            //bool assign1 = sourceSlot.Assign(this.GetItemInfo(), this);
            bool assign1 = sourceSlot.Assign(Inventory.instance.items[this.ID-1], this);
            // Assign this slot by the source slot
            Inventory.instance.items[sourceSlot.ID - 1] = Inventory.instance.items[this.ID - 1];
            bool assign2 = this.Assign(sourceItemInfo, sourceObject);
            Inventory.instance.items[this.ID-1] = sourceItemInfo;
            if (sourceSlot.GetItemInfo().IsStackable)
            {
                sourceSlot.transform.GetChild(3).gameObject.SetActive(true);
                StackNum1 = sourceSlot.transform.GetChild(3).GetComponentInChildren<Text>();
                StackNum1.text = sourceSlot.GetItemInfo().Stack.ToString();
            }
            else
            {
                sourceSlot.transform.GetChild(3).gameObject.SetActive(false);
            }
            if (this.GetItemInfo().IsStackable)
            {
                this.transform.GetChild(3).gameObject.SetActive(true);
                StackNum1 = this.transform.GetChild(3).GetComponentInChildren<Text>();
                StackNum1.text = this.GetItemInfo().Stack.ToString();
            }
            else
            {
                this.transform.GetChild(3).gameObject.SetActive(false);
            }
            if (Inventory.CurrentTab == 0)
            {
                Test_UIItemSlot_AssignAll.TUAA.UpdateInven();
            }
            else if(Inventory.CurrentTab == 1)
            {
                Test_UIItemSlot_AssignAll.TUAA.UpdateInven_equip();
            }
            else if(Inventory.CurrentTab == 2)
            {
                Test_UIItemSlot_AssignAll.TUAA.UpdateInven_material();
            }
            else if(Inventory.CurrentTab == 3)
            {
                Test_UIItemSlot_AssignAll.TUAA.UpdateInven_expendable();
            }

            // Return the status
            return (assign1 && assign2);
		}

        public override void OnDrop(PointerEventData eventData)
        {
            base.OnDrop(eventData);
            // Get the source slot
            UISlotBase source = (eventData.pointerPress != null) ? eventData.pointerPress.GetComponent<UISlotBase>() : null;
            UIItemSlot source1 = (eventData.pointerPress != null) ? eventData.pointerPress.GetComponent<UIItemSlot>() : null;
            // Make sure we have the source slot

            // Normal empty slot assignment
            if (!this.IsAssigned()&&this.dragAndDropEnabled==true)
            {
                // Assign the target slot with the info from the source
                if (!source.isStatic)
                {
                    if (source1.GetItemInfo().IsStackable)
                    {
                        source1.transform.GetChild(3).gameObject.SetActive(false);
                        this.transform.GetChild(3).gameObject.SetActive(true);
                        StackNum1 = this.transform.GetChild(3).GetComponentInChildren<Text>();
                        StackNum1.text = source1.GetItemInfo().Stack.ToString();

                    }
                    Inventory.instance.items[this.ID - 1] = Inventory.instance.items[source1.ID - 1];
                    Inventory.instance.items[source1.ID - 1] = null;
                }
            }
        }
        /// <summary>
        /// Raises the tooltip event.
        /// </summary>
        /// <param name="show">If set to <c>true</c> show.</param>
        /// */
        public override void OnTooltip(bool show)
		{
			// Make sure we have spell info, otherwise game might crash
			if (this.m_ItemInfo == null)
				return;
			
			// If we are showing the tooltip
			if (show)
			{
                UITooltip.InstantiateIfNecessary(this.gameObject);

                // Prepare the tooltip
                UIItemSlot.PrepareTooltip(this.m_ItemInfo);
				
				// Anchor to this slot
				UITooltip.AnchorToRect(this.transform as RectTransform);
				
				// Show the tooltip
				UITooltip.Show();
			}
			else
			{
				// Hide the tooltip
				UITooltip.Hide();
			}
		}
        
        /// <summary>
		/// Raises the pointer click event.
		/// </summary>
		/// <param name="eventData">Event data.</param>
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            // Make sure the slot is assigned
            if (!this.IsAssigned())
                return;

            // Check for left double click
            if (eventData.button == PointerEventData.InputButton.Left && eventData.clickCount == 2)
            {
                // Reset the click count
                eventData.clickCount = 0;

                // Invoke the double click event
                if (this.onDoubleClick != null)
                    this.onDoubleClick.Invoke(this);
            }

            // Check for right click
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                //if (GameObject.Find("Window (Character)").gameObject.GetComponent<UIWindow>().IsVisible)
                /*if(Inventory.isSUb==false)
                {
                    Equipment_Manager.EM.Source = this.m_ItemInfo;
                    Equipment_Manager.EM.SourceID = this.ID;
                    Debug.Log("UIItemSlot isSub=" + Inventory.isSUb + "    " + Equipment_Manager.EM.SourceID);
                }
                else if(Inventory.isSUb == true)
                //else if(GameObject.Find("Window (Character) (1)").gameObject.GetComponent<UIWindow>().IsVisible)
                {
                    int t = this.ID;
                    Equipment_Manager.EM.Source = this.m_ItemInfo;
                    Equipment_Manager.EM.SourceID = t - 200;
                    Debug.Log("suppose to be true UIItemSlot isSub=" + Inventory.isSUb+"    "+ Equipment_Manager.EM.SourceID);
                }
                // Invoke the double click event
                if (this.onRightClick != null)
                    this.onRightClick.Invoke(this);*/
            }
        }

        /// <summary>
		/// This method is raised when the slot is denied to be thrown away and returned to it's source.
		/// </summary>
        protected override void OnThrowAwayDenied()
        {
            if (!this.IsAssigned())
                return;

            if (UIModalBoxManager.Instance == null)
            {
                Debug.LogWarning("Could not load the modal box manager while creating a modal box.");
                return;
            }

            UIModalBox box = UIModalBoxManager.Instance.Create(this.gameObject);
            if (box != null)
            {
                box.SetText1("���� \"" + this.m_ItemInfo.Name + "\"�� �����ðڽ��ϱ�?");
                box.SetText2("�������� ���������� �����˴ϴ�.");
                box.SetConfirmButtonText("������");
                //box.onConfirm.AddListener(Unassign);
                box.onConfirm.AddListener(DelItem);
                box.Show();
            }
        }

        /// <summary>
        /// Automatically generate and assign slot ID.
        /// </summary>
        [ContextMenu("Auto Assign ID")]
        public void AutoAssignID()
        {
            // Get the active slots in the slot's group
            List<UIItemSlot> slots = GetSlotsInGroup(this.m_SlotGroup);

            if (slots.Count > 0)
            {
                slots.Reverse();
                this.m_ID = slots[0].ID + 1;
            }
            else
            {
                // If we have no slots
                this.m_ID = 1;
            }

            slots.Clear();
        }

        #region Static Methods
        /// <summary>
        /// Gets all the item slots.
        /// </summary>
        /// <returns>The slots.</returns>
        public static List<UIItemSlot> GetSlots()
		{
			List<UIItemSlot> slots = new List<UIItemSlot>();
			UIItemSlot[] sl = Resources.FindObjectsOfTypeAll<UIItemSlot>();
			
			foreach (UIItemSlot s in sl)
			{
				// Check if the slow is active in the hierarchy
				if (s.gameObject.activeInHierarchy)
					slots.Add(s);
			}
			
			return slots;
		}
		
		/// <summary>
		/// Gets all the item slots with the specified ID.
		/// </summary>
		/// <returns>The slots.</returns>
		/// <param name="ID">The slot ID.</param>
		public static List<UIItemSlot> GetSlotsWithID(int ID)
		{
			List<UIItemSlot> slots = new List<UIItemSlot>();
			UIItemSlot[] sl = Resources.FindObjectsOfTypeAll<UIItemSlot>();
			
			foreach (UIItemSlot s in sl)
			{
				// Check if the slow is active in the hierarchy
				if (s.gameObject.activeInHierarchy && s.ID == ID)
					slots.Add(s);
			}
			
			return slots;
		}
		
		/// <summary>
		/// Gets all the item slots in the specified group.
		/// </summary>
		/// <returns>The slots.</returns>
		/// <param name="group">The item slot group.</param>
		public static List<UIItemSlot> GetSlotsInGroup(UIItemSlot_Group group)
		{
			List<UIItemSlot> slots = new List<UIItemSlot>();
			UIItemSlot[] sl = Resources.FindObjectsOfTypeAll<UIItemSlot>();
			
			foreach (UIItemSlot s in sl)
			{
				// Check if the slow is active in the hierarchy
				if (s.gameObject.activeInHierarchy && s.slotGroup == group)
					slots.Add(s);
			}

            // Sort the slots by id
            slots.Sort(delegate (UIItemSlot a, UIItemSlot b)
            {
                return a.ID.CompareTo(b.ID);
            });

			return slots;
		}
		
		/// <summary>
		/// Gets the slot with the specified ID and Group.
		/// </summary>
		/// <returns>The slot.</returns>
		/// <param name="ID">The slot ID.</param>
		/// <param name="group">The slot Group.</param>
		public static UIItemSlot GetSlot(int ID, UIItemSlot_Group group)
		{
			UIItemSlot[] sl = Resources.FindObjectsOfTypeAll<UIItemSlot>();
			
			foreach (UIItemSlot s in sl)
			{
				// Check if the slow is active in the hierarchy
				if (s.gameObject.activeInHierarchy && s.ID == ID && s.slotGroup == group)
					return s;
			}
			
			return null;
		}

        /// <summary>
		/// Prepares the tooltip with the specified item info.
		/// </summary>
		/// <param name="itemInfo">Item info.</param>
		public static void PrepareTooltip(UIItemInfo itemInfo)
        {
            if (itemInfo == null)
                return;

            // Set the tooltip width
            if (UITooltipManager.Instance != null)
                UITooltip.SetWidth(UITooltipManager.Instance.itemTooltipWidth);

            // Set the title and description
            UITooltip.AddTitle("<color=#" + UIItemQualityColor.GetHexColor(itemInfo.Quality) + ">" + itemInfo.Name + "</color>");

            // Spacer
            UITooltip.AddSpacer();

            // Item types
            UITooltip.AddLineColumn(itemInfo.Type, "ItemAttribute");
            UITooltip.AddLineColumn(itemInfo.Subtype, "ItemAttribute");
            UITooltip.AddSpacer();
            if (itemInfo.ItemType == 0)
            {
                UITooltip.AddLineColumn(itemInfo.Damage.ToString() + " Damage", "ItemAttribute");
                //UITooltip.AddLineColumn(itemInfo.AttackSpeed.ToString("0.0") + " Attack speed", "ItemAttribute");

                //UITooltip.AddLine("(" + ((float)itemInfo.Damage / itemInfo.AttackSpeed).ToString("0.0") + " damage per second)", "ItemAttribute");
            }
            else if(itemInfo.ItemType == 1)
            {
                //UITooltip.AddLineColumn(itemInfo.Armor.ToString() + " Armor", "ItemAttribute");
                //UITooltip.AddLineColumn(itemInfo.Block.ToString() + " Block", "ItemAttribute");
            }
            else if (itemInfo.ItemType == 2)
            {
                UITooltip.AddLineColumn(itemInfo.Heal.ToString() + " Heal", "ItemAttribute");
            }
            else if (itemInfo.ItemType == 3)
            {
                UITooltip.AddLineColumn("ü�� "+itemInfo.HP.ToString(),"itemAttribute");
                UITooltip.AddLineColumn("������ "+itemInfo.Damage.ToString(), "ItemAttribute");
            }

            UITooltip.AddSpacer();

            //UITooltip.AddLine("+" + itemInfo.Stamina.ToString() + " Stamina", "ItemStat");
            //UITooltip.AddLine("+" + itemInfo.Strength.ToString() + " Strength", "ItemStat");

            //UITooltip.AddSpacer();

            //UITooltip.AddLine("Durability " + itemInfo.Durability + "/" + itemInfo.Durability, "ItemAttribute");

            //if (itemInfo.RequiredLevel > 0)
             //   UITooltip.AddLine("Requires Level " + itemInfo.RequiredLevel, "ItemAttribute");

            // Set the item description if not empty
            if (!string.IsNullOrEmpty(itemInfo.Description))
            {
                UITooltip.AddSpacer();
                UITooltip.AddLine(itemInfo.Description, "ItemDescription");
            }
        }
        #endregion
    }
}
