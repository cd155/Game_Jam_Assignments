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

    private int max = 2;
    private int track;

    void Start()
    {
        track = 0;
        isWhite1 = true;
        isWhite2 = true;
        isWhite3 = true;
    }
    public void ChoiceButton1Clicked()
    {
        if (track >= max && isWhite1) {return;}
        if(isWhite1)
        {
            track ++;
            option1.image.sprite = imageBlack1;
            isWhite1 = false;
        }
        else
        {
            track--;
            option1.image.sprite = imageWhite1;
            isWhite1 = true;
        }
    }

    public void ChoiceButton2Clicked()
    {
        if (track >= max && isWhite2) {return;}
        if(isWhite2)
        {
            track ++;
            option2.GetComponent<Image>().sprite = imageBlack2;
            isWhite2 = false;
        }
        else
        {
            track --;
            option2.GetComponent<Image>().sprite = imageWhite2;
            isWhite2 = true;
        }
    }

    public void ChoiceButton3Clicked()
    {
        Debug.Log(track + "::" + max);
        if (track >= max && isWhite3) {return;}
        if(isWhite3)
        {
            track ++;
            option3.GetComponent<Image>().sprite = imageBlack3;
            isWhite3 = false;
        }
        else
        {
            track --;
            option3.GetComponent<Image>().sprite = imageWhite3;
            isWhite3 = true;
        }
    }

    public void ConfirmButtonClicked()
    {
        Debug.Log("Confirm clicked");
    }
}
