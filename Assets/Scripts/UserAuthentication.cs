using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class UserAuthentication : MonoBehaviour
{
    private string UserName;
    public TextMeshProUGUI text;
    public Button SaveButt;
    private bool IsValid;
    private void Awake()
    {
        IsValid = false;
    }

    private void Update()
    {
        UserName = text.text;
        IsValid = UserName.Length > 3;
        SaveButt.interactable = IsValid;
    }

    public void LoadLevelAndSaveNameIntoJSON()
    {
        UserName = text.text;
        Debug.Log("loading next scene");
        int _nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        SceneManager.LoadScene(_nextScene);
    }
}
