using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuloGames.UI
{


    public class Inventory_start : MonoBehaviour
    {
        public static Inventory_start IS;
        public UIItemInfo[] itemss;
        private void Awake()
        {
            IS = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            itemss = new UIItemInfo[72];
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
