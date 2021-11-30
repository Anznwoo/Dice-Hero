using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuloGames.UI
{
    public class DialogueTrigger : MonoBehaviour
    {
        public Dialogue dialogue;
        //List<Isread> isreadList;
        public Dialogue[] Randialogues;
        public int DialogueID;
        //Isread isread;
        [SerializeField] private Transform m_Container;
        public DialogueTrigger[] dialogues;

        public bool CheckRead = false;

        private void Start()
        {

        }


        public void TriggerDialouge()
        {
            if(CheckRead==false)
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            CheckRead = true;
            FindObjectOfType<DialogueManager>().isRand = false;
        }
        public void TriggerChoiceDialouge()
        {
            if (CheckRead == false)
                FindObjectOfType<DialogueManager>().StartChoiceDialogue(dialogue);
            CheckRead = true;
            FindObjectOfType<DialogueManager>().isRand = false;
        }

        public void TriggerRandomDialogue()
        {
            int ran = Random.Range(0, Randialogues.Length);
            FindObjectOfType<DialogueManager>().StartDialogue(Randialogues[ran]);
            FindObjectOfType<DialogueManager>().isRand = true;
        }

    }
}
