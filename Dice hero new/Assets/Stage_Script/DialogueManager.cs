using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DuloGames.UI
{
    public class DialogueManager : MonoBehaviour
    {
        //public StageManager stageManager;
        //List<StateData> MyStateList;
        public Text Notification;

        public AudioSource radio;
        public Text DialogueText;
        public Animator animator;
        public Animator Filteranimator;
        public Animator Notifier;
        public Image Filter;
        public Button OKbutton;
        public Button ChoiceOKbutton;
        public Button Yes;
        public Button No;
        public bool isRand;

        public Image Ending_hunt;
        public Image Ending_run;
        public Image GameOver;

        private Queue<string> sentences;
        public DialogueTrigger[] dialogues;
        [SerializeField] private Transform m_Container;
        //public List<Isread> isreadList;
        //public Isread isread;

        void Start()
        {

            //MyStateList = ES3.Load<List<StateData>>("MyStateList");
            sentences = new Queue<string>();

            //ES3.Save<List<Isread>>("isread", isreadList);
            /*if (ES3.KeyExists("isread"))
            {
                //isreadList = ES3.Load<List<Isread>>("isread");
                LoadRead();
            }
            else
            {
                Debug.Log("새로할때마다 만듬");
                isread = new Isread(false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
                if (isreadList.Count == 0)
                    isreadList.Add(isread);
                //ES3.Save<List<Isread>>("isread",isreadList);
                SaveRead();
            }
            
            dialogues = this.m_Container.gameObject.GetComponentsInChildren<DialogueTrigger>();
            LoadRead();
            if (MyStateList[0].stageIndex==1)
                dialogues[0].TriggerDialouge();
            else if(MyStateList[0].stageIndex == 2)
                dialogues[2].TriggerDialouge();
            else if (MyStateList[0].stageIndex == 4)
                dialogues[4].TriggerDialouge();
            else if (MyStateList[0].stageIndex == 5)
                dialogues[5].TriggerDialouge();
            else if (MyStateList[0].stageIndex == 6)
                dialogues[6].TriggerDialouge();
            else if (MyStateList[0].stageIndex == 7)
                dialogues[8].TriggerDialouge();
            else if (MyStateList[0].stageIndex == 9)
                dialogues[10].TriggerDialouge();
            else if (MyStateList[0].stageIndex == 10)
                dialogues[12].TriggerDialouge();
            else if (MyStateList[0].stageIndex == 12)
                dialogues[14].TriggerDialouge();
                */
        }

        private void OnDestroy()
        {
            //SaveRead();
        }
        public void hunt_success()
        {
            Ending_hunt.gameObject.SetActive(true);
        }
        public void runaway()
        {
            Ending_run.gameObject.SetActive(true);
        }
        public void Gameover()
        {
            GameOver.gameObject.SetActive(true);
        }

        public void StartDialogue(Dialogue dialogue)
        {
            OKbutton.gameObject.SetActive(true);
            ChoiceOKbutton.gameObject.SetActive(false);
            Yes.gameObject.SetActive(false);
            No.gameObject.SetActive(false);
            radio.Play();
            Filteranimator.SetBool("FilterActive", true);

            animator.SetBool("IsOpen", true);

            sentences.Clear();
            foreach(string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
        public void StartChoiceDialogue(Dialogue dialogue)
        {
            Filteranimator.SetBool("FilterActive", true);
            OKbutton.gameObject.SetActive(false);
            ChoiceOKbutton.gameObject.SetActive(true);
            animator.SetBool("IsOpen", true);

            sentences.Clear();
            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayChoiceSentence();
        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
            
        }
        public void DisplayChoiceSentence()
        {
            if (sentences.Count == 1)
            {
                ChoiceOKbutton.gameObject.SetActive(false);
                string sentence_final = sentences.Dequeue();
                StartCoroutine(Choice(sentence_final));
                return;
            }
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeChoiceSentence(sentence));

        }

        IEnumerator TypeSentence(string sentence)
        {
            DialogueText.text = "";
            foreach(char letter in sentence.ToCharArray())
            {
                DialogueText.text += letter;
                OKbutton.interactable = false;
                yield return new WaitForSeconds(0.05f);
            }
            OKbutton.interactable = true;
        }
        IEnumerator TypeChoiceSentence(string sentence)
        {
            DialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                DialogueText.text += letter;
                ChoiceOKbutton.interactable = false;
                yield return new WaitForSeconds(0.05f);
            }
            ChoiceOKbutton.interactable = true;
        }
        IEnumerator Choice(string sentence)
        {
            DialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                DialogueText.text += letter;
                ChoiceOKbutton.interactable = false;
                yield return new WaitForSeconds(0.05f);
            }
            Yes.gameObject.SetActive(true);
            No.gameObject.SetActive(true);

        }

        IEnumerator Notify(string stage)
        {
            Notification.text = stage;
            Notifier.SetBool("Notify", true);
            yield return new WaitForSeconds(3f);
            Notifier.SetBool("Notify", false);
        }

        public void EndDialogue()
        {
            animator.SetBool("IsOpen", false);
            Filteranimator.SetBool("FilterActive", false);
            //ES3.Save<List<Isread>>("isread", isreadList);
            if (isRand == false)
            {
                //나중에 이 곳을 수정할것. 각 스테이지 별로 어떤 텍스트를 띄울지 if를 통해서 구현하면 됨
                //StartCoroutine(Notify("서울역\n"));
                /*if (stageManager.MyStateList[0].stageNumber == 0.ToString())
                    StartCoroutine(Notify("서울역"));
                else if (stageManager.MyStateList[0].stageNumber == 1.ToString())
                    StartCoroutine(Notify("서울역 내부\n"));
                else if (stageManager.MyStateList[0].stageNumber == 2.ToString())
                    StartCoroutine(Notify("공덕역\n"));
                else if (stageManager.MyStateList[0].stageNumber == 3.ToString())
                    StartCoroutine(Notify("염리동\n"));
                else if (stageManager.MyStateList[0].stageNumber == 4.ToString())
                    StartCoroutine(Notify("대흥역\n"));
                else if (stageManager.MyStateList[0].stageNumber == 5.ToString())
                    StartCoroutine(Notify("대흥역 입구\n"));
                else if (stageManager.MyStateList[0].stageNumber == 6.ToString())
                    StartCoroutine(Notify("대흥역 내부\n"));
                else if (stageManager.MyStateList[0].stageNumber == 7.ToString())
                    StartCoroutine(Notify("마포구청역 가는길\n"));
                else if (stageManager.MyStateList[0].stageNumber == 8.ToString())
                    StartCoroutine(Notify("마포구청역\n"));*/
            }

        }
        public void Ending()
        {
            animator.SetBool("IsOpen", false);
            //Filteranimator.SetBool("FilterActive", false);
        }
        /*public void LoadRead()
        {
            isreadList = ES3.Load<List<Isread>>("isread");
            dialogues[0].CheckRead = isreadList[0].isread1;
            dialogues[1].CheckRead = isreadList[0].isread2;
            dialogues[2].CheckRead = isreadList[0].isread3;
            dialogues[3].CheckRead = isreadList[0].isread4;
            dialogues[4].CheckRead = isreadList[0].isread5;
            dialogues[5].CheckRead = isreadList[0].isread6;
            dialogues[6].CheckRead = isreadList[0].isread7;
            dialogues[7].CheckRead = isreadList[0].isread8;
            dialogues[8].CheckRead = isreadList[0].isread9;
            dialogues[9].CheckRead = isreadList[0].isread10;
            dialogues[10].CheckRead = isreadList[0].isread11;
            dialogues[11].CheckRead = isreadList[0].isread12;
            dialogues[12].CheckRead = isreadList[0].isread13;
            dialogues[13].CheckRead = isreadList[0].isread14;
            dialogues[14].CheckRead = isreadList[0].isread15;
            dialogues[15].CheckRead = isreadList[0].isread16;
            dialogues[16].CheckRead = isreadList[0].isread17;
            dialogues[17].CheckRead = isreadList[0].isread18;

        }

        public void SaveRead()
        {
            isreadList[0].isread1 = dialogues[0].CheckRead;
            isreadList[0].isread2 = dialogues[1].CheckRead;
            isreadList[0].isread3 = dialogues[2].CheckRead;
            isreadList[0].isread4 = dialogues[3].CheckRead;
            isreadList[0].isread5 = dialogues[4].CheckRead;
            isreadList[0].isread6 = dialogues[5].CheckRead;
            isreadList[0].isread7 = dialogues[6].CheckRead;
            isreadList[0].isread8 = dialogues[7].CheckRead;
            isreadList[0].isread9 = dialogues[8].CheckRead;
            isreadList[0].isread10 = dialogues[9].CheckRead;
            isreadList[0].isread11 = dialogues[10].CheckRead;
            isreadList[0].isread12 = dialogues[11].CheckRead;
            isreadList[0].isread13 = dialogues[12].CheckRead;
            isreadList[0].isread14 = dialogues[13].CheckRead;
            isreadList[0].isread15 = dialogues[14].CheckRead;
            isreadList[0].isread16 = dialogues[15].CheckRead;
            isreadList[0].isread17 = dialogues[16].CheckRead;
            isreadList[0].isread18 = dialogues[17].CheckRead;
            ES3.Save<List<Isread>>("isread", isreadList);
        }
        */
    }
}
