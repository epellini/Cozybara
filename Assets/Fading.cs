using Unity.VisualScripting;
using UnityEngine;

public class Fading : MonoBehaviour
{
    public void Fade()
    {
        GameObject obj = GameObject.Find("BlackScreen");
        Animator animator = obj.GetComponent<Animator>();

        //animator.SetTrigger("Fading");
        animator.Play("Fading");
    }

}
