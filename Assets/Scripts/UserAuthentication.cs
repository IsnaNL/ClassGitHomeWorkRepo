using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class UserAuthentication : MonoBehaviour
{
    public static string UserName;
    public TextMeshProUGUI GUI;
    public Button SaveButt;
    private bool IsValid;
    private void Awake()
    {
        IsValid = false;
    }

    private void Update()
    {
        UserName = GUI.text;
        IsValid = UserName.Length > 3 && UserName.Length < 12;
        SaveButt.interactable = IsValid;
    }

    public void  SaveNameIntoJSON()
    {
        UserName = GUI.text;
        
        LoadNextScene();
        //Debug.Log( PlayerData.playerName);
    }

    private static void LoadNextScene()
    {
        int _nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(_nextScene);
    }
}
