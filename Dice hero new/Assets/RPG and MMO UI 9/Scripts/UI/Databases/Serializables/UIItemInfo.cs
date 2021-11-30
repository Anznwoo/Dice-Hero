using UnityEngine;
using System;

namespace DuloGames.UI
{
	[Serializable]
	public class UIItemInfo
	{
		public int ID;
		public string Name;
		public Sprite Icon;
		public string Description;
        public UIItemQuality Quality;
        public UIEquipmentType EquipType;
        //ItemType 0=장비, 1=기타, 2=소모
		public int ItemType;
		public string Type;
		public string Subtype;
        public int ItemTier;
		public int Damage;
        public int HP;
        public int Heal;
		//public float AttackSpeed;
		//public int Block;
		public int Armor;
		//public int Stamina;
		//public int Strength;
        //public int Durability;
        //public int RequiredLevel;
        public bool IsStackable;
        public bool Expendable;
        public int Stack;
        public int StoreStack;
        public int Price;
        
	}
}
