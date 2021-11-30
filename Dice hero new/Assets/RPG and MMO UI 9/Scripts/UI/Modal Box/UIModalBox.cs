using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace DuloGames.UI
{
    [RequireComponent(typeof(UIWindow)), RequireComponent(typeof(UIAlwaysOnTop))]
    public class UIModalBox : MonoBehaviour
    {
        [Header("Texts")]
        [SerializeField] private Text m_Text1;
        [SerializeField] private Text m_Text2;
        //[SerializeField] private Text m_Text3;
        [Header("Buttons")]
        [SerializeField] private Button m_ConfirmButton;
        [SerializeField] private Text m_ConfirmButtonText;
        [SerializeField] private Button m_CancelButton;
        [SerializeField] private Text m_CancelButtonText;
        [SerializeField] private Button m_Up;
        [SerializeField] private Button m_Down;
        [SerializeField] private Button m_char1;
        [SerializeField] private Button m_char2;
        [SerializeField] private Button m_char3;
        
        Button[] Chars;
        [Header("Inputs")]
        [SerializeField] private string m_ConfirmInput = "Submit";
        [SerializeField] private string m_CancelInput = "Cancel";

        private UIWindow m_Window;
        private bool m_IsActive = false;

        [Header("Events")]
        public UnityEvent onConfirm = new UnityEvent();
        public UnityEvent onCancel = new UnityEvent();
        public UnityEvent onUp = new UnityEvent();
        public UnityEvent onDown = new UnityEvent();
        public UnityEvent First = new UnityEvent();
        public UnityEvent Second = new UnityEvent();
        public UnityEvent Third = new UnityEvent();

        public static int Amount=1;
        /// <summary>
        /// Gets a value indicating whether this modal box is active.
        /// </summary>
        public bool isActive
        {
            get { return this.m_IsActive; }
        }

        protected void Awake()
        {
            // Make sure we have the window component
            if (this.m_Window == null)
            {
                this.m_Window = this.gameObject.GetComponent<UIWindow>();
            }

            // Prepare some window parameters
            this.m_Window.ID = UIWindowID.ModalBox;
            this.m_Window.escapeKeyAction = UIWindow.EscapeKeyAction.None;

            // Hook an event to the window
            this.m_Window.onTransitionComplete.AddListener(OnWindowTransitionEnd);

            // Prepare the always on top component
            UIAlwaysOnTop aot = this.gameObject.GetComponent<UIAlwaysOnTop>();
            aot.order = UIAlwaysOnTop.ModalBoxOrder;

            // Hook the button click event
            if (this.m_ConfirmButton != null)
            {
                this.m_ConfirmButton.onClick.AddListener(Confirm);
            }

            if (this.m_CancelButton != null)
            {
                this.m_CancelButton.onClick.AddListener(Close);
            }
            this.m_Up.gameObject.SetActive(false);
            this.m_Down.gameObject.SetActive(false);
            this.DeactivateChar();
            Chars = new Button[3] { m_char1, m_char2, m_char3 };
            
            //Amount = 1;
        }

        protected void Update()
        {
            if (!string.IsNullOrEmpty(this.m_CancelInput) && Input.GetButtonDown(this.m_CancelInput))
                this.Close();
            
            if (!string.IsNullOrEmpty(this.m_ConfirmInput) && Input.GetButtonDown(this.m_ConfirmInput))
                this.Confirm();
        }

        /// <summary>
        /// Sets the text on the first line.
        /// </summary>
        /// <param name="text"></param>
        public void SetText1(string text)
        {
            if (this.m_Text1 != null)
            {
                this.m_Text1.text = text;
                this.m_Text1.gameObject.SetActive(!string.IsNullOrEmpty(text));
            }
        }

        /// <summary>
        /// Sets the text on the second line.
        /// </summary>
        /// <param name="text"></param>
        public void SetText2(string text)
        {
            if (this.m_Text2 != null)
            {
                this.m_Text2.text = text;
                this.m_Text2.gameObject.SetActive(!string.IsNullOrEmpty(text));
            }
        }

        /*public void SetText3(string text)
        {
            if (this.m_Text3 != null)
            {
                this.m_Text3.text = text;
                this.m_Text3.gameObject.SetActive(!string.IsNullOrEmpty(text));
            }
        }*/

        public Button CharButton(int a)
        {
            if (a == 1)
                return m_char1;
            else if (a == 2)
                return m_char2;
            else if (a == 3)
                return m_char3;
            else
                return null;

        }
        public void SetUpDown()
        {
            this.m_Up.gameObject.SetActive(true);
            this.m_Down.gameObject.SetActive(true);
        }

        public void DeactivateUpDown()
        {
            this.m_Up.gameObject.SetActive(false);
            this.m_Down.gameObject.SetActive(false);
        }

        public void ActivateUp()
        {
            this.m_Up.interactable = true;
        }
        public void ActivateDown()
        {
            this.m_Down.interactable = true;
        }

        public void DeactivateUp(int a)
        {
            if(Amount==a)
                this.m_Up.interactable = false;
        }

        public void StopUp()
        {
            this.m_Up.interactable = false;
        }
        public void DeactivateDown()
        {
            this.m_Down.interactable = false;
        }
        public void DeactivateConfirm()
        {
            this.m_ConfirmButton.gameObject.SetActive(false);
        }
        /// <summary>
        /// Sets the confirm button text.
        /// </summary>
        /// <param name="text">The confirm button text.</param>
        public void SetConfirmButtonText(string text)
        {
            if (this.m_ConfirmButtonText != null)
            {
                this.m_ConfirmButtonText.text = text;
            }
        }

        /// <summary>
        /// Sets the cancel button text.
        /// </summary>
        /// <param name="text">The cancel button text.</param>
        public void SetCancelButtonText(string text)
        {
            if (this.m_CancelButtonText != null)
            {
                this.m_CancelButtonText.text = text;
            }
        }

        /// <summary>
        /// Shows the modal box.
        /// </summary>
        public void Show()
        {
            this.m_IsActive = true;

            if (UIModalBoxManager.Instance != null)
                UIModalBoxManager.Instance.RegisterActiveBox(this);

            // Show the modal
            if (this.m_Window != null)
            {
                this.m_Window.Show();
            }
        }

        /// <summary>
        /// Closes the modal box.
        /// </summary>
        public void Close()
        {
            this._Hide();
            Amount = 1;
            // Invoke the cancel event
            if (this.onCancel != null)
            {
                this.onCancel.Invoke();
            }
        }

        public void Confirm()
        {
            this._Hide();

            // Invoke the confirm event
            if (this.onConfirm != null)
            {
                this.onConfirm.Invoke();
            }
        }

        private void _Hide()
        {
            this.m_IsActive = false;

            if (UIModalBoxManager.Instance != null)
                UIModalBoxManager.Instance.UnregisterActiveBox(this);

            // Hide the modal
            if (this.m_Window != null)
            {
                this.m_Window.Hide();
            }
        }

        public void OnWindowTransitionEnd(UIWindow window, UIWindow.VisualState state)
        {
            // Destroy the modal box when hidden
            if (state == UIWindow.VisualState.Hidden)
            {
                Destroy(this.gameObject);
            }
        }

        public void UpButton()
        {
            Amount += 1;
            m_Text2.text = Amount.ToString();
            if (Amount > 1)
                m_Down.interactable=true;
            if (this.onUp != null)
            {
                this.onUp.Invoke();
            }
            //return Amount;
        }

        public void DownButton()
        {
            if (Amount > 1)
                Amount -= 1;
            m_Text2.text = Amount.ToString();
            if (this.onDown != null)
            {
                this.onDown.Invoke();
            }
            //return Amount;
        }

        public void set_Equip()
        {
            this.m_char1.gameObject.SetActive(true);
            this.m_char2.gameObject.SetActive(true);
            this.m_char3.gameObject.SetActive(true);
        }
        public void Button_Image0(Sprite sprite)
        {
            this.m_char1.image.sprite = sprite;
        }
        public void Button_Image1(Sprite sprite)
        {
            this.m_char2.image.sprite = sprite;
        }
        public void Button_Image2(Sprite sprite)
        {
            this.m_char3.image.sprite = sprite;
        }
        public void Char_dead(int num)
        {
            Chars[num].interactable = false;
        }
        public void Char1()
        {
            this.m_char1.gameObject.SetActive(false);
            this.m_char2.gameObject.SetActive(false);
            this.m_char3.gameObject.SetActive(false);
            this._Hide();
            if (this.First != null)
            {
                this.First.Invoke();
            }
        }
        public void Char2()
        {
            this.m_char1.gameObject.SetActive(false);
            this.m_char2.gameObject.SetActive(false);
            this.m_char3.gameObject.SetActive(false);
            this._Hide();
            if (this.Second != null)
            {
                this.Second.Invoke();
            }
        }
        public void Char3()
        {
            this.m_char1.gameObject.SetActive(false);
            this.m_char2.gameObject.SetActive(false);
            this.m_char3.gameObject.SetActive(false);
            this._Hide();
            if (this.Third != null)
            {
                this.Third.Invoke();
            }
        }

        public void DeactivateChar()
        {
            this.m_char1.gameObject.SetActive(false);
            this.m_char2.gameObject.SetActive(false);
            this.m_char3.gameObject.SetActive(false);
        }

        public void SetOne()
        {
            Amount = 1;
        }
    }
}
