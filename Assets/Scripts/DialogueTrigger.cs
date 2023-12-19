using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // You'll need this for working with UI elements

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    //public Button dialogueButton;
    private bool dialogueTriggered = false;

      public TextMeshProUGUI textToDisable;

    void Start()
    {

    }

    public void TriggerDialogue()
    {
        DeleteText();
        if (!dialogueTriggered)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Fade();
            dialogueTriggered = true;
            // Disable the button or the component
            //dialogueButton.interactable = false;

        }
    }

    public void DeleteText()
    {
        if (textToDisable != null)
        {
            textToDisable.gameObject.SetActive(false);
        }
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.2f);
        //gameObject.SetActive(false);
    }
}
