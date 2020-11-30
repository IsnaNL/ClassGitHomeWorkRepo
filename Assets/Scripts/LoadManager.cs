using System.Collections.Generic;
using UnityEngine;
public class LoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Menus")]
    public GameObject PauseMenu;
    public GameObject HUD;
    public GameObject CreditsMenu;

    private List<GameObject> Screens;

    public static bool IsPlaying { get => UnityEditor.EditorApplication.isPlaying || Application.isPlaying; }
    private void Awake()
    {
        Screens = new List<GameObject>
        {
            PauseMenu,
            HUD,
            CreditsMenu
        };
    }

    void Start()
    {
        PauseScene();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScene();
        }
    }
    public void ResumeScene()
    {
        Time.timeScale = 1f;
        SelectScreen(HUD);

    }
    public void PauseScene()
    {
        SelectScreen(PauseMenu);
        Time.timeScale = 0f;
    }
    public void CreditsScene()
    {
        SelectScreen(CreditsMenu);
    }
    private void SelectScreen(GameObject SelectedScreen)
    {
        foreach (GameObject item in Screens)
        {
            if (item != null)
            {
                item.SetActive(false);
            }
            else
            {
                Debug.LogError(item.name + " screen is nullified");
            }
        }
        SelectedScreen.SetActive(true);
        
    }
    public void QuitGame()
    {
        //splitting isPlaying to settle conflicts between editor and application
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
