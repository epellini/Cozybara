using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
   // private Animator fade;
    void Start()
    {
        //fade = GetComponent<Animator>();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //fade.Play("fading");
        Fade();
        //gameObject.SetActive(true);
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.2f);
        //Destroy(gameObject);
        gameObject.SetActive(true);
    }
}
