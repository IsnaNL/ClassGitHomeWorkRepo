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
    //private PlayerData _playerData = new PlayerData();
    private bool hasWon;
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

    void Update()
    {

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
