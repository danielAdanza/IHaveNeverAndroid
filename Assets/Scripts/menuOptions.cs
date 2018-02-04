using UnityEngine;
using System.Collections;

public class menuOptions : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject instructions;
    public GameObject languages;
    public GameObject gameTypeMenu;
    public GameObject backButton;
    public GameObject ownPhrasesMask;
    public GameObject enterPhrase;
    public GameObject powerOffButton;
    public GameObject moreApps;
    public GameObject purchaseButton;

    void Start ()
    {
        if ( PlayerPrefs.GetString("noAds").Equals("NO") )
        {
            purchaseButton.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackClicked();
        }  
    }

    public void PlayClicked ()
    {
        mainMenu.SetActive(false);
        gameTypeMenu.SetActive(true);
        powerOffButton.SetActive(false);
    }

    public void InstClicked ()
    {
        mainMenu.SetActive(false);
        instructions.SetActive(true);
        powerOffButton.SetActive(false);
    }

    public void LanguageClicked ()
    {
        mainMenu.SetActive(false);
        languages.SetActive(true);
        powerOffButton.SetActive(false);
    }

    public void BackClicked ()
    {
        mainMenu.SetActive(true);
        powerOffButton.SetActive(true);
        gameTypeMenu.SetActive(false);
        instructions.SetActive(false);
        languages.SetActive(false);
        ownPhrasesMask.SetActive(false);
        backButton.SetActive(false);
        enterPhrase.SetActive(false);
        moreApps.SetActive(false);
    }

    public void OwnPhrasesClicked ()
    {
        mainMenu.SetActive(false);
        powerOffButton.SetActive(false);
        ownPhrasesMask.SetActive(true);
        backButton.SetActive(true);
    }

    public void WritePhrase()
    {
        mainMenu.SetActive(false);
        powerOffButton.SetActive(false);
        enterPhrase.SetActive(true);
    }

    public void GoToMoreApps ()
    {
        mainMenu.SetActive(false);
        powerOffButton.SetActive(false);
        moreApps.SetActive(true);
    }

    public void GoToUrl (string url)
    {
        Application.OpenURL(url);
    }

    //gametype = 0: Normal
    //gametype = 1: Spicy
    //gametype = 2: Mix

    public void GoToMainGameNormal()
    {
        PlayerPrefs.SetInt("gameType",0);
        Application.LoadLevel(1);
    }

    public void GoToMainGameSpicy()
    {
        PlayerPrefs.SetInt("gameType", 1);
        Application.LoadLevel(1);
    }

    public void GoToMainGameMix()
    {
        PlayerPrefs.SetInt("gameType", 2);
        Application.LoadLevel(1);
    }

    public void ChangeToEnglish()
    {
        //english = 0
        PlayerData.playerData.languaje = 0;
        PlayerData.playerData.Save();
    }

    public void ChangeToSpanish()
    {
        //spanish = 1
        PlayerData.playerData.languaje = 1;
        PlayerData.playerData.Save();
    }

    public void ExitApp()
    {
        Application.Quit();
    }

}
