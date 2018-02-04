using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FrasesScript : MonoBehaviour {

    public GameObject text;
    
    public void SetText (string text)
    {
        this.text.GetComponent<Text>().text = text;
    }
}
