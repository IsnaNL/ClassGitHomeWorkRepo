using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potions : MonoBehaviour
{
    public float Fuel_To_Add; 
    //public float Speed_To_Add; 
    public float Speed_time; 
    public float Food_Radios; 

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<AudioSource>().Play();
        collision.GetComponent<Collider2D>().enabled= false;
        collision.GetComponent<SpriteRenderer>().enabled= false;
        Destroy(collision.gameObject,0.5f);
        if (collision.CompareTag("Fuel"))
        {
            GetComponent<WitchMovement>().Fuel += Fuel_To_Add;
        }
        if (collision.CompareTag("Food"))
        {
            Food();

        }
        if (collision.CompareTag("Speed"))
        {
            StartCoroutine(Speed_change());

        }

    }

    public void Food()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Food_Radios);

        foreach (Collider2D hit in colliders)
        {
            if (hit.CompareTag("cat"))
            {
              LeanTween.move(hit.gameObject, transform.position, 0.5f);
            }
        }

    }

    public IEnumerator Speed_change()
    {

        GetComponent<WitchMovement>().horMovementSpeed *= 5f;
        GetComponent<WitchMovement>().liftForce *= 5f;
        yield return new WaitForSeconds(Speed_time);
        GetComponent<WitchMovement>().horMovementSpeed /= 5f;
        GetComponent<WitchMovement>().liftForce /= 5f;
    }

}

