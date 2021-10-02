using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextLine : MonoBehaviour
{
    // Start is called before the first frame update

    public Text backgroundText;
    public Text correctText;
    public Text wrongText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBaseText(string text)
    {
        backgroundText.text = text;
        correctText.text = "";
        wrongText.text = "";
    }

    public void SetInputText(string text)
    {
        correctText.text = text;
    }

    public void ResetText()
    {
        SetBaseText("");
    }


}
