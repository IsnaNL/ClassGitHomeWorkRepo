using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Animator>().enabled=true;
        GameManager.score++;
        GetComponent<AudioSource>().pitch=Random.Range(0.5f,2f);
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 0.5f);
       
    }
   
}
