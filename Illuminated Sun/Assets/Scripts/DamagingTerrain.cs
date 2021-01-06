using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingTerrain : MonoBehaviour
{

    public int damageOnCollision = 10;
    public Collider damageCollider;     //this ensures that the object is setup correctly 

    private void Start()
    {
        if (!damageCollider.isTrigger)
        {
            Debug.LogError("Damage collider is not currently set as a trigger.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<Health>())
        {
            other.GetComponent<Health>().TakeDamage(damageOnCollision);
        }
        else
        {
            print("Detected object that either has no health or is not tagged as the player");
        }
    }

}
