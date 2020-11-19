using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().enabled=true;
        GameManager.score++;
        Destroy(gameObject, 0.5f);
    }
   
}
