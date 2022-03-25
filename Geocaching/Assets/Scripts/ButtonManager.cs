using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public GameObject mapView;
    public GameObject streetView;
    public GameObject scenePage;
    public Button challengeButton;

    private bool isStreet;
    private bool isChallengeShow;

    public void CloseButtonClicked()
    {
        Application.Quit();
    }

    public void ChangeViews()
    {
        if(isStreet){
            mapView.SetActive(true);
            streetView.SetActive(false);
            isStreet = false;
        }
        else{
            streetView.SetActive(true);
            mapView.SetActive(false);
            isStreet = true;
        }
    }

    public void showChallenges()
    {
        if (isChallengeShow){
            scenePage.SetActive(false);
            isChallengeShow = false;
            challengeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Scene Challenges";
        }
        else{
            scenePage.SetActive(true);
            isChallengeShow = true;
            challengeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Accept Challenge";
        }
        

    }
}
