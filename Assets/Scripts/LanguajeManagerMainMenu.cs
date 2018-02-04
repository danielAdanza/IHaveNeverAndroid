using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguajeManagerMainMenu : MonoBehaviour {

    //buttons in the main menu
    public Text play;
    public Text instructions;
    public Text languaje;
    public Text write;
    public Text ownPhrases;
    public Text removeAdds;
    public Text moreApps;
    //instructions section
    public Text instructionsText;
    public Text back5;
    //write section
    public Text writeInstructions;
    public Text back;
    public Text write2;
    //ganetype menu;
    public Text mix;
    public Text back2;
    public Text spicy;
    //ownPhrases section
    public Text back3;
    public Text back4;
    public Text back6;



    void Start ()
    {
        PlayerData.playerData.Load();

	    if (PlayerData.playerData.languaje == 1)
        {
            ChangeToSpanish();
        }

    }

    public void ChangeToEnglish()
    {
        //main menu buttons
        play.text = "PLAY";
        instructions.text = "INSTRUCTIONS";
        languaje.text = "LANGUAJES";
        write.text = "WRITE";
        ownPhrases.text = "OWN PHRASES";
        removeAdds.text = "REMOVE ADDS";
        moreApps.text = "MORE APPS";
        //instructions section
        back5.text = "BACK";
        instructionsText.text = "Typical drinking game where \n players will comment something \n that they have never done. \n \n The phase has to start with \n \"I have never ...\" \n \n And all of those who have done \n that have to take a shot";
        //write section
        write2.text = "WRITE";
        back.text = "BACK";
        writeInstructions.text = "Write your own phrases. \n it will automatically start with \n \"I have never ... \"";
        //gametype menu
        back2.text = "BACK";
        spicy.text = "SPICY";
        mix.text = "MIX";
        //ownPhrases section
        back3.text = "BACK";
        back4.text = "BACK";
        back6.text = "BACK";
    }

    public void ChangeToSpanish()
    {
        //main menu buttons
        play.text = "JUGAR";
        instructions.text = "INSTRUCCIONES";
        languaje.text = "IDIOMAS";
        write.text = "ESCRIBE";
        ownPhrases.text = "FRASES PROPIAS";
        removeAdds.text = "QUITAR ANUNCIOS";
        moreApps.text = "MÁS APPS";
        //instructions section
        back5.text = "VOLVER";
        instructionsText.text = "Mítico juego de beber en donde \n los jugadores comentan algo \n que nunca han hecho. \n \n Las frases tienen que empezar con  \n \"yo nunca ...\" \n \n Y todos los que lo hallan hecho \n tienen que beber";
        //write section
        write2.text = "ESCRIBIR";
        back.text = "VOLVER";
        writeInstructions.text = "Escribe tus propias frases. \n empezará automáticamente \n con \"Yo nunca ... \"";
        //gametype menu
        back2.text = "VOLVER";
        spicy.text = "FUERTE";
        mix.text = "MEZCLA";
        //ownphrases section
        back3.text = "VOLVER";
        back4.text = "VOLVER";
        back6.text = "VOLVER";
    }

}
