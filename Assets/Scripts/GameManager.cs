using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //sorry for terrible dependencies but we do need to release something :D
    public static int score;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI time_text;
    public WitchMovement PlayerRef;
    public Slider FuelSliderRef;
    public int catsLeft;
    public Transform catHanlder;
    [SerializeField]
    private PlayerData _PlayerData = new PlayerData();
    private float timeFromStart;
    public static int timeFromStartInt;
    public float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        timeFromStart = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FuelSliderRef.value = PlayerRef.Fuel;
        score_text.text = score.ToString();
        timeFromStart += Time.deltaTime;
        timeFromStartInt = Mathf.RoundToInt(timeFromStart);
        time_text.text = timeFromStartInt.ToString();
        CountCats();
        TimeLimit();
    }

    private void TimeLimit()
    {
        if(timeFromStart >= maxTime)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void CountCats()
    {
        catsLeft = catHanlder.childCount;
        if(catsLeft <= 0)
        {
            WinGame();
        }
    }

    
    
    private void WinGame()
    {
        SceneManager.LoadScene(0);
         SaveIntoJson();
    }
    public void SaveIntoJson()
    {
        _PlayerData.playerName = UserAuthentication.UserName;
        Debug.Log(Application.persistentDataPath);
        string data = JsonUtility.ToJson(_PlayerData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/_PlayerData.json", data);
    }
}

