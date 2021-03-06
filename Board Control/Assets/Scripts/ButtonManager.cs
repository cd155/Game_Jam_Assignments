using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public GameObject graphManager;

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
        List<string> confirmList = new List<string>();
        if(!isWhite1)
        {
            confirmList.Add(option1.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if(!isWhite2)
        {
            confirmList.Add(option2.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        if(!isWhite3)
        {
            confirmList.Add(option3.GetComponentInChildren<TextMeshProUGUI>().text);
        }

        RestButtons();

        if(confirmList.Count > 0)
        {
            graphManager.GetComponent<GraphManager>().ShowSelectNode(confirmList);
        }
    }

    public void RestButtons()
    {
        track = 0;
        isWhite1 = true;
        isWhite2 = true;
        isWhite3 = true;

        option1.GetComponent<Image>().sprite = imageWhite1;
        option2.GetComponent<Image>().sprite = imageWhite2;
        option3.GetComponent<Image>().sprite = imageWhite3;
        option1.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        option1.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        option1.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CloseButtonClicked()
    {
        Application.Quit();
    }
}
