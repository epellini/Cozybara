using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image currentHungry;
    public Image currentBored;
    public Image currentTired;
    public Image currentDirty;

    // Icons
    public Image hungryIcon;
    public Image boredIcon;
    public Image tiredIcon;
    public Image dirtyIcon;


    public Text HappyText;
     public Text TiredText;
    public Text CleanText;
    public Text BoredText;
    public Text HungryText;

    private float hunger = 100;
    private float fun = 100;
    private float energy  = 100;
    private float dirtyness = 100;


    //Action buttons
    public Button Feed;
    public Button Play;
    public Button Sleep;
    public Button Clean;

    public Text GameOverText;

    public Image CappyHappy;
    public Image CappySad;

    private void Start(){
        //Button listener for hunger
        Button btnFeed = Feed.GetComponent<Button>();
        //btnFeed.onClick.AddListener(Cappy_Feed);

        //Button Listerner for Playtime
         Button btnPlay = Play.GetComponent<Button>();
        //btnPlay.onClick.AddListener(Cappy_Play);

        Button btnSleep = Sleep.GetComponent<Button>();
        //btnSleep.onClick.AddListener(Cappy_Sleep);

        Button btnClean = Clean.GetComponent<Button>();
        //btnClean.onClick.AddListener(Cappy_Clean );

        
    
    // Make icons not visible upon start
    hungryIcon.CrossFadeAlpha(0,0.001f, true);
    boredIcon.CrossFadeAlpha(0,0.001f, true);
    tiredIcon.CrossFadeAlpha(0,0.001f, true);
    dirtyIcon.CrossFadeAlpha(0,0.001f, true);

    //Make Capy happy from start
    CappySad.gameObject.SetActive(false);


    UpdateHungerBar();
    UpdateBoredBar();
    UpdateEnergyBar();
    UpdateDirtyBar();

    Update();

    }

    private void Update(){

    // This deplinishes hunger overtime:
    hunger -= 5.5f * Time.deltaTime;
    if (hunger < 0) {
        hunger = 0;
    }

     fun -= 5.5f * Time.deltaTime;
    if (fun < 0) {
        fun = 0;
    }

     energy -= 5.5f * Time.deltaTime;
    if (energy < 0) {
        energy = 0;
    }

     dirtyness -= 5.5f * Time.deltaTime;
    if (dirtyness < 0) {
        dirtyness = 0;
    }


    // Checks for needs
    needsCheck();
    goodParentCheck();

    UpdateHungerBar();
    UpdateBoredBar();
    UpdateEnergyBar();
    UpdateDirtyBar();


    }

    // Check needs
    private void needsCheck(){
        if(hunger <= 50){
            hungryIcon.CrossFadeAlpha(1,0.05f, true);
        } else {
              hungryIcon.CrossFadeAlpha(0,0.05f, true);
        }

         if(fun <= 50){
            boredIcon.CrossFadeAlpha(1,0.05f, true);
        } else {
              boredIcon.CrossFadeAlpha(0,0.05f, true);
        }

         if(energy <= 50){
            tiredIcon.CrossFadeAlpha(1,0.05f, true);
        } else {
              tiredIcon.CrossFadeAlpha(0,0.05f, true);
        }

         if(dirtyness <= 50){
            dirtyIcon.CrossFadeAlpha(1,0.05f, true);
        } else {
              dirtyIcon.CrossFadeAlpha(0,0.05f, true);
        }
    }

    // Check if u took care of cappy

    private void goodParentCheck(){
        if(hunger <= 60 || fun <=30 || energy <=20 || dirtyness <= 40) {
            CappyHappy.gameObject.SetActive(false);
            CappySad.gameObject.SetActive(true);
        } else {
            CappySad.gameObject.SetActive(false);
            CappyHappy.gameObject.SetActive(true);
        }
    }


    private void UpdateHungerBar(){
        //float ratio = hunger / max;
       // currentHungry.rectTransform.localScale = new Vector3(ratio, 1, 1);
       // HungryText.text = (ratio * 100).ToString("0") + '%';

    }

        private void  UpdateBoredBar(){
        //float ratio = hunger / max;
        //currentBored.rectTransform.localScale = new Vector3(ratio, 1, 1);
        //BoredText.text = (ratio * 100).ToString("0") + '%';

    }

        private void UpdateEnergyBar(){
        //float ratio = hunger / max;
        //currentTired.rectTransform.localScale = new Vector3(ratio, 1, 1);
        //TiredText.text = (ratio * 100).ToString("0") + '%';

    }

        private void UpdateDirtyBar(){
        //float ratio = hunger / max;
        //currentDirty.rectTransform.localScale = new Vector3(ratio, 1, 1);
        //CleanText.text = (ratio * 100).ToString("0") + '%';

    } 


}
