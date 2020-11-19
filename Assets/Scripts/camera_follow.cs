using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    { 
    
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,  transform.position + offset,0.2f);
    }
    private void LateUpdate()
    {
    }
}
