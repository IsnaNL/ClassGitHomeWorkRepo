using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PauseMenu;
    public GameObject HUD;
    public GameObject CreditsMenu;

    public static bool IsPlaying { get => UnityEditor.EditorApplication.isPlaying || Application.isPlaying; }
    private void Awake()
    {
        if (PauseMenu == null || HUD == null || CreditsMenu == null)
        {
            Debug.LogError("some or all menus aren't connect to the SceneManager script in 'UI' Canvas");
        }
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
        if (PauseMenu != null)
        {
            PauseMenu.gameObject.SetActive(false);
        }
        if (CreditsMenu != null)
        {
            CreditsMenu.gameObject.SetActive(false);
        }
        if (HUD != null)
        {
            HUD.gameObject.SetActive(true);
        }

    }
    public void PauseScene()
    {
        if (HUD != null)
        {
            HUD.gameObject.SetActive(false);
        }
        if (CreditsMenu != null)
        {
            CreditsMenu.gameObject.SetActive(false);
        }
        if (PauseMenu != null)
        {
            PauseMenu.gameObject.SetActive(true);
        }
        if (IsPlaying)
        {
            Time.timeScale = 0f;
        }
    }
    public void CreditsScene()
    {
        if (PauseMenu != null)
        {
            PauseMenu.gameObject.SetActive(false);
        }
        if (HUD != null)
        {
            HUD.gameObject.SetActive(false);
        }
        if (CreditsMenu != null)
        {
            CreditsMenu.gameObject.SetActive(true);
        }
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
