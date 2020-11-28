using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_destroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
 
}
