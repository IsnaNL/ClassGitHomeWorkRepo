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
    public float timeFromStart;
    public static int timeFromStartInt;
    public float maxTime;
    public static bool hasWon;
    public static int HighScore;

    // Start is called before the first frame update
    void Start()
    {
        GetHighScore();
        timeFromStart = 0;
        timeFromStartInt = 0;
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
        hasWon = true;
        GetHighScore();
        SaveIntoJson();
        SceneManager.LoadScene(2);
    }
    public void SaveIntoJson()
    {
        _PlayerData.playerName = UserAuthentication.UserName;
        Debug.Log(Application.persistentDataPath);
        string data = JsonUtility.ToJson(_PlayerData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/_PlayerData.json", data);
        if (score > HighScore)
        {
            HighScore = score;
            _PlayerData.highScore = HighScore;
        }
    }

    public void GetHighScore()
    {
        PlayerData _pd;
        string data = System.IO.File.ReadAllText(Application.persistentDataPath + "/_PlayerData.json");
        _pd = JsonUtility.FromJson<PlayerData>(data);
        HighScore = _pd.highScore;
    }

}

