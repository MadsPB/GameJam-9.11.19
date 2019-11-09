using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class DialogueManager : MonoBehaviour
    {
        public List<GameObject> DialogueScreens;
        public int CurrentIndex;

        void Start()
        {
            OnDialogueClicked();
        }

        public void OnDialogueClicked()
        {
            foreach (var dialogueScreen in DialogueScreens)
            {
                dialogueScreen.SetActive(false);
            }

            if (CurrentIndex < DialogueScreens.Count)
            {
                DialogueScreens[CurrentIndex].SetActive(true);
                CurrentIndex++;
            }
        }
    }
}