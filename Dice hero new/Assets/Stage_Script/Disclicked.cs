using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace DuloGames.UI
{
    public class Disclicked : MonoBehaviour, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject Before;
        private bool mouseIsOver = false;

        void Awake()
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
            
        }
        void Start()
        {
            UIWindow after = this.GetComponent<UIWindow>();
            Debug.Log("이게 활성화 여부" + after.IsVisible);
        }
        public void OnDeselect(BaseEventData eventData)
        {
            UIWindow after = this.GetComponent<UIWindow>();
            UIWindow before = Before.GetComponent<UIWindow>();

            if (!mouseIsOver)
            {
                before.Show();
                after.Hide();
                Debug.Log("디설렉트");
                Debug.Log("비포어가 활성화 여부" + before.IsOpen);
                Debug.Log("이게 활성화 여부" + after.IsOpen);
            }



        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            mouseIsOver = true;
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            mouseIsOver = false;
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}

