using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class WinLossCanvas : MonoBehaviour
{ 
    public ParticleSystem Confetti;
    public TextMeshProUGUI FinishText;
    void Start()
    {
        if (GameManager.hasWon)
        {
            //win
            FinishText.text = "You Collected all the cats in\n" + GameManager.timeFromStartInt + " Seconds !!!!!!!!!!!!";
            return;
        }
        //lose
        FinishText.text = "You're terrible and should feel bad";
    }
    public void Confett()
    {
        Confetti.Play();
    }
    public void PlayeAgain()
    {
        SceneManager.LoadScene(0);
    }
}
