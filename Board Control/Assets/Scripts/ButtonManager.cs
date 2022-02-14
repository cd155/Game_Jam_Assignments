using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button option1;
    public Button option2;
    public Button option3;
    public Sprite imageWhite1;
    public Sprite imageBlack1;
    private bool isWhite1;
    public Sprite imageWhite2;
    public Sprite imageBlack2;
    private bool isWhite2;
    public Sprite imageWhite3;
    public Sprite imageBlack3;
    private bool isWhite3;

    void Start()
    {
        isWhite1 = true;
        isWhite2 = true;
        isWhite3 = true;
    }
    public void ChoiceButton1Clicked()
    {
        if(isWhite1)
        {
            Debug.Log("here");
            option1.image.sprite = imageBlack1;
            isWhite1 = false;
        }
        else
        {
            option1.image.sprite = imageWhite1;
            isWhite1 = true;
        }
    }

    public void ChoiceButton2Clicked()
    {
        if(isWhite2)
        {
            option2.GetComponent<Image>().sprite = imageBlack2;
            isWhite2 = false;
        }
        else
        {
            option2.GetComponent<Image>().sprite = imageWhite2;
            isWhite2 = true;
        }
    }

    public void ChoiceButton3Clicked()
    {
        if(isWhite3)
        {
            option1.GetComponent<Image>().sprite = imageBlack3;
            isWhite3 = false;
        }
        else
        {
            option1.GetComponent<Image>().sprite = imageWhite3;
            isWhite3 = true;
        }
    }

    public void ConfirmButtonClicked()
    {
        Debug.Log("Confirm clicked");
    }
}
