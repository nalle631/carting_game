using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxHandler : MonoBehaviour
{
    public float removeDelay = 1f;
    public float enableDelay = 4f;
    public float clearTextDelay = 2f;

    public bool hasLetter = false;
    

    public GameObject box;
    public GameObject letterCanvas;
    public GameObject letterArray;
    public GameObject boxMaster;

    public TextMeshProUGUI boxSide;

    private Text letter;
    private Text array;

    public void Start()
    {
       box = transform.Find("LetterBox").gameObject;
       letterCanvas = GameObject.Find("LetterCanvas").gameObject;
       letterArray = GameObject.Find("LetterArray").gameObject;
       boxMaster = GameObject.Find("MasterBoxHandler").gameObject;
       
       
    }
    public void GiveLetter()
    {
        if(hasLetter == false)
        {

            hasLetter = true;
            
            Debug.Log("Letter gained");
            Invoke(nameof(disableBox), removeDelay);
            Invoke(nameof(enableBox), enableDelay);
            
        }
       
    }

    public void disableBox()
    {
        box.SetActive(false);
        showLetter();
    }

    public void enableBox()
    {
        box.SetActive(true);
        hasLetter = false;
    }

    public void showLetter()
    {
       letter = letterCanvas.GetComponent<Text>();
       letter.text = boxSide.text;
       addToArray();
       Invoke(nameof(clearText), clearTextDelay);
       
       
       
    }

    public void clearText()
    {
        letter.text = "";
    }

    public void addToArray()
    {
        array = letterArray.GetComponent<Text>();
        if (boxMaster.GetComponent<MasterBoxHandler>().isEmpty)
        {
            
            array.text = array.text + boxSide.text;
            boxMaster.GetComponent<MasterBoxHandler>().setFalse();
            //Debug.Log("if");
        }
        else
        {
            array.text = array.text + " | " + boxSide.text;
            Debug.Log("else");
        }
    }
    

    
}
