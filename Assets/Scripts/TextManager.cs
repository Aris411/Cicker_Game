using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    public TextMeshProUGUI Text;
    public GameObject TextBox;

    private string [] Messages = new string[10];


    void Awake(){
        instance = this;
    }

    void Start(){
    }

    public void fillText(){
        Messages[0] = "Welcome to Clicker RPG! Click the enemy to defeat it! \n You can also buy Auto Clickers to help you defeat the enemy! \n You are a farmer and the slimey and froggy hordes of the evil witch are threatening you land. Set out and click them back to hell \n";
        Messages[1] = "After you defeated the witch she crumbles to dust and you pick up her mask. \n This is the end of your journey, or is it ... \n";
        Messages[2] = "";
    }
    public void showText(int index){
        TextBox.SetActive(true);
        Text.text = Messages[index];
    }

    public void hideText(){
        TextBox.SetActive(false);
        EnemyManager.instance.SpawnEnemy();
        ClickManager.instance.showPlayerButton();
        GameManager.instance.GeneralText.SetActive(true);
        GameManager.instance.SaveButton.SetActive(true);
    }
}

