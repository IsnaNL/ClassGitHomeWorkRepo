using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer != 8)
        {
            LoadLastScene();
        }
    }
    private void LoadLastScene()
    {

        SceneManager.LoadScene(0);
    }
}
